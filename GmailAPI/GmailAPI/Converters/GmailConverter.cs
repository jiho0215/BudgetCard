using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using GmailAPI.APIHelper;
using GmailAPI.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace GmailAPI.Converters
{
    public class GmailConverter
    {
        public List<DailySummary> ConvertToDailySummaryList(List<string> htmlList)
        {
            var dailySummaryList = new List<DailySummary>();

            htmlList?.ForEach(html =>
            {
                var tst = ConvertToHtmlObj(html);
                var dailySummary = ConvertToDailySummary(html);
                if (dailySummary != null)
                {
                    dailySummaryList.Add(dailySummary);
                }
            });
            return dailySummaryList;
        }

        private DailySummary ConvertToDailySummary(string html)
        {

            //TODO: enhance the logic to be more efficient.

            var parser = new HtmlParser();
            var documentBody = parser.ParseDocument(html).Body;

            //summary date
            var searchText = "Account summary for";
            var textContent = GetTextContext(documentBody, searchText);
            var date = textContent.Replace(searchText, "").Trim();
            DateTime.TryParse(date, out var dateParsed);

            //account ending number
            searchText = "Account ending in";
            var endingNumber = GetSiblingTextContext(documentBody, searchText);
            endingNumber = Regex.Match(endingNumber, @"\d{4}").Value;

            //end of day balance
            searchText = "End of Day Balance";
            var endOfDayBalance = GetSiblingTextContext(documentBody, searchText);
            endOfDayBalance = Regex.Match(endOfDayBalance, @"\d*\.\d\d").Value;

            //total withdrawal
            searchText = "Total Withdrawals";
            var totalWithdrawl = GetSiblingTextContext(documentBody, searchText);
            totalWithdrawl = Regex.Match(endOfDayBalance, @"\d*\.\d\d").Value;

            //total deposit
            searchText = "Total Deposits";
            var totalDeposit = GetSiblingTextContext(documentBody, searchText);
            totalDeposit = Regex.Match(endOfDayBalance, @"\d*\.\d\d").Value;

            //withdrawal list
            searchText = "Total Withdrawals";
            var withdrawalTransactions = GetTransactionListFromChildElement(documentBody, searchText);

            //deposit list
            searchText = "Total Deposits";
            var depositTransactions = GetTransactionListFromChildElement(documentBody, searchText);

            return new DailySummary()
            {
                Date = dateParsed,
                EndingDigits = endingNumber,
                EndOfDayBalance = float.Parse(endOfDayBalance),
                TotalDeposits = float.Parse(totalDeposit),
                DepositList = depositTransactions,
                TotalWithdrawls = float.Parse(totalWithdrawl),
                WithdrawalList = withdrawalTransactions
            };
        }

        private string GetSiblingTextContext(IElement element, string searchString)
        {
            var targetElement = element.QuerySelectorAll("td").Where(x => x.TextContent.Contains(searchString)).OrderBy(x => x.TextContent.Length).FirstOrDefault();
            var textContent = targetElement.NextElementSibling.TextContent;
            return textContent;
        }

        private string GetTextContext(IElement element, string searchString)
        {
            var targetElement = element.QuerySelectorAll("td").Where(x => x.TextContent.Contains(searchString)).OrderBy(x => x.TextContent.Length).FirstOrDefault();
            var textContent = targetElement?.TextContent;
            return textContent;
        }

        private List<Transaction> GetTransactionListFromChildElement(IElement element, string searchString)
        {
            var transactions = new List<Transaction>();

            //var htmldoc = new HtmlDocument();
            //try
            //{
            //    var html = htmldoc.LoadHtml(element.)
            //}
            //var targetElement = element.QuerySelectorAll("td").Where(x => x.TextContent.Contains(searchString)).OrderBy(x => x.TextContent.Length).FirstOrDefault();
            //var searchText = "Account ending in";
            //var targetElement = element.QuerySelectorAll("td").Where(x => x.TextContent.Contains(searchText)).OrderBy(x => x.TextContent.Length).FirstOrDefault();


            //var foundTopTable = false;
            //while (!foundTopTable)
            //{
            //    if (parent.NodeName == "TABLE")
            //    {
            //        var content = parent.TextContent;
            //        if (content.Contains("Account ending in") && content.Contains("Total Deposits"))
            //        {
            //            foundTopTable = true;
            //        }
            //    }
            //    parent = parent.ParentElement;
            //}
            Console.ReadLine();
            return transactions;
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

//table
//