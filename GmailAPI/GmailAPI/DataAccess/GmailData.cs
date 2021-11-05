using GmailAPI.APIHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuckitClassLibrary;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;

namespace GmailAPI.DataAccess
{
    public class GmailData : IGmailData
    {
        private GmailService gmailService;
        public GmailData()
        {
            gmailService = GmailAPIHelper.GetService();
        }

        public List<Gmail> GetUnreadDailySummaryListFromGmail(string HostEmailAddress)
        {

            var gmailList = new List<Gmail>();

            UsersResource.MessagesResource.ListRequest ListRequest = gmailService.Users.Messages.List(HostEmailAddress);
            ListRequest.LabelIds = new List<string>()
            {
                "INBOX"
                , "UNREAD"
            };
            ListRequest.IncludeSpamTrash = false;
            var query = "after:" + DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd") + " from:chase \"daily summary\"";
            ListRequest.Q = query;

            //GET EMAILS
            ListMessagesResponse ListResponse = ListRequest.Execute();

            if (ListResponse != null && ListResponse.Messages != null)
            {
                //LOOP THROUGH EACH EMAIL AND GET WHAT FIELDS I WANT
                foreach (Message Msg in ListResponse.Messages)
                {
                    //MESSAGE MARKS AS READ AFTER READING MESSAGE
                    GmailAPIHelper.MsgMarkAsRead(HostEmailAddress, Msg.Id);

                    UsersResource.MessagesResource.GetRequest Message = gmailService.Users.Messages.Get(HostEmailAddress, Msg.Id);

                    //MAKE ANOTHER REQUEST FOR THAT EMAIL ID...
                    Message MsgContent = Message.Execute();

                    if (MsgContent != null)
                    {
                        string MailBody = string.Empty;
                        string ReadableText = string.Empty;

                        //READ MAIL BODY-------------------------------------------------------------------------------------
                        MailBody = string.Empty;
                        if (MsgContent.Payload.Parts == null && MsgContent.Payload.Body != null)
                        {
                            MailBody = MsgContent.Payload.Body.Data;
                        }
                        else
                        {
                            MailBody = GmailAPIHelper.MsgNestedParts(MsgContent.Payload.Parts);
                        }

                        //BASE64 TO READABLE TEXT--------------------------------------------------------------------------------
                        ReadableText = string.Empty;
                        ReadableText = GmailAPIHelper.Base64Decode(MailBody);

                        if (!string.IsNullOrEmpty(ReadableText))
                        {
                            Gmail gMail = new Gmail();
                            gMail.Body = ReadableText;
                            gmailList.Add(gMail);
                        }
                    }
                }
            }
            return gmailList;
        }
    }

}
