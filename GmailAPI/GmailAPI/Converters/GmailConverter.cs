﻿using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using GmailAPI.APIHelper;
using GmailAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GmailAPI.Converters
{
    public class GmailConverter
    {
        public List<DailySummary> ConvertToDailySummaryList(List<string> htmlList)
        {
            var dailySummaryList = new List<DailySummary>();

            htmlList?.ForEach(html =>
            {
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
                EndingDigits = int.Parse(endingNumber),
                EndOfDayBalance = float.Parse(endOfDayBalance),
                TotalDeposit = float.Parse(totalDeposit),
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

            var targetElement = element.QuerySelectorAll("td").Where(x => x.TextContent.Contains(searchString)).OrderBy(x => x.TextContent.Length).FirstOrDefault();
            var childNodes = targetElement?.Children;


            return transactions;
        }
    }
}

