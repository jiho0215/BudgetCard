using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using GmailAPI.APIHelper;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using BuckitClassLibrary;

namespace GmailAPI.Converters
{
    public class GmailConverter
    {        public List<DailySummary> ConvertToDailySummaries(List<string> htmlList)
        {
            var summaries = new List<DailySummary>();
            htmlList.ForEach(x =>
            {
                var summary = ConvertToHtmlObj(x);
                summaries.Add(summary);
            });
            return summaries;
        }
        private DailySummary ConvertToHtmlObj(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
            var accountSummaryForTD = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(text(),'Account summary for')]");
            var accountSummaryForStirng = accountSummaryForTD.InnerText.Replace("Account summary for ", "");

            var mainTableNode = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(text(), 'Account ending in')]/../../../../..");

            var accountEnding = string.Empty;
            var currentBalance = string.Empty;
            var totalWithdrawal = string.Empty;
            var withdrawals = new List<string>();
            var totalDeposit = string.Empty;
            var deposits = new List<string>();

            foreach (var childNode in mainTableNode.ChildNodes)
            {
                var name = childNode.Name;
                var content = childNode.InnerText.Replace("\r\n", "").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ");

                if (string.IsNullOrWhiteSpace(content))
                    continue;

                content.Replace("&bull;", "");
                content = content.Trim();

                if (content.Contains("Account ending in") || content.Contains("End of Day Balance") || content.Contains("Total Withdrawals") || content.Contains("Total Deposits"))
                {
                    if (content.Contains("Account ending in"))
                        accountEnding = Regex.Match(content, @"\d+").Value;
                    if (content.Contains("End of Day Balance"))
                        currentBalance = content.Replace("End of Day Balance", "").Trim().Substring(1);
                    if (content.Contains("Total Withdrawals"))
                        totalWithdrawal = content.Replace("Total Withdrawals", "").Trim().Substring(1);
                    if (content.Contains("Total Deposits"))
                        totalDeposit = content.Replace("Total Deposits", "").Trim().Substring(1);
                }
                else
                {
                    if (!string.IsNullOrEmpty(totalWithdrawal) && string.IsNullOrEmpty(totalDeposit))
                        withdrawals.Add(content.Replace("&bull;", "").Trim());
                    if (!string.IsNullOrEmpty(totalDeposit))
                        deposits.Add(content.Replace("&bull;", "").Trim());
                }
            }

            DateTime.TryParse(accountSummaryForStirng, out var date);
            float.TryParse(currentBalance, out var endOfDayBalance);
            float.TryParse(totalDeposit, out var totalDeposits);
            float.TryParse(totalWithdrawal, out var totalWithdrawls);

            var dailySummary = new DailySummary()
            {
                Date = date,
                EndingDigits = accountEnding,
                EndOfDayBalance = endOfDayBalance,
                TotalDeposits = totalDeposits,
                TotalWithdrawls = totalWithdrawls
            };

            withdrawals.ForEach(withdrawal =>
            {
                var dollarIndex = withdrawal.IndexOf('$');
                var description = withdrawal.Substring(0, dollarIndex).Trim();
                float.TryParse(withdrawal.Substring(dollarIndex + 1), out var amount);
                var transaction = new Transaction()
                {
                    Description = description,
                    Amount = amount
                };
                dailySummary.WithdrawalList.Add(transaction);
            });

            deposits.ForEach(deposit =>
            {
                var dollarIndex = deposit.IndexOf('$');
                var description = deposit.Substring(0, dollarIndex).Trim();
                float.TryParse(deposit.Substring(dollarIndex + 1), out var amount);
                var transaction = new Transaction()
                {
                    Description = description,
                    Amount = amount
                };
                dailySummary.DepositList.Add(transaction);
            });
            return dailySummary;
        }
    }
}
