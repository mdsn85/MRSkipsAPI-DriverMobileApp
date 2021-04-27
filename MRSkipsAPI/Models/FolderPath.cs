using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Configuration;

namespace MRSkipsAPI.Models
{
    public static class FolderPath
    {
        public const String FolderPathCustomerDoc = "~/Uploads/CustomerDoc/";
        public const String FolderPathEmailDoc = "~/Uploads/emails/";
        public const String SignaturePath = "~/Uploads/CustomerDoc/";

        public const int NearExpiryDays = 30;
        public const int OutGoingContract = 6;

        public const String RemarkSecurityDeposit = "*Security Deposit amount is refundable at the time of Contract Termination /Contract Cancellation / Project Completion, once the customer’s account is clear.";

        public const String RemarkDMDisposal = "***The tipping fees will be applicable subject to the implementation of executive council resolution no: 58 from Dubai Municipality.";
        public const String Compacter = "";
        public static readonly  String[]  allowedExtensions = {
                ".Jpg", ".png", ".jpg", ".jpeg",".pdf",".doc",".docx",".xls",".xlsx",".doc",".docs"
                };


        public const String BodyEmailQ =
            " Dear Sir/ Madam, <br /><br />" +

            "Hope everything is good at your end,<br /><br />" +
            "Thank you for your enquiry, we are pleased to offer <br />" +
            "you our best price  for your requirement. Kindly find  <br />" +
            "herewith attached quotation file for your perusal. <br />  <br />" +
            "We value your trust in our company and given a  <br />" +
            "chance to serve you we will do our best to meet  <br /> " +
            "your service expectations.  <br /> <br />" +
            "We look forward to receive your positive approval at the earliest  <br />" +
            "For further query Please feel free to call us anytime.  <br />";

        public const String BodyEmailC = " <b>Dear Valued Customer,</b><br /><br />"+
 "We thank you for your confirmation on the quotation for<U><B> waste management services</B></U>.We have attached the contract(soft copy)<br />" +
            "for your acknowledgement(kindly sign and stamp) & send it back to us in order to complete the documentation process.<br />" +
 "We kindly request you to cooperate with us in completing the documentation process, in order to speed up the operation execution”.<br />" +
 "<B><U>Note:</U></B> The Original hard copy will be sent to you, once we receive the soft copy acknowledgement. " + 
 "Request you to prepare the deposit chq / contractual value (if Any).<br />" +
 "<br /><B><I><U>Please contact us on the below details to serve you better:</U></I></B><br />" +
 "For any SKIP Delivery / Trip Scheduling / Service-related issues Call @ 0529067928 / 0529067929 OR Email @ operations @mrskips.net<br />" +   
 "Kindly do not call the drivers directly for any service-related queries / issues.All communication should be made through above mentioned<br />" +
 "contact details / email address for smooth & hassle-free services.<br /><br />" +
 "Waiting for your swift response” ";





public const string ConnStr = @"Data Source = LAPTOP-8N0H3H43\SQLEXPRESS;Initial Catalog = mrskip; Integrated Security = True";


       
        public static string GetEmailAdress(this IIdentity identity)
        {       
            var userId = identity.GetUserId();
            ApplicationDbContext db = new ApplicationDbContext();
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            return user.Email;
        }

        public static int getEmployee(this IIdentity identity)
        {
            var userName = identity.GetUserName();
            ApplicationDbContext db = new ApplicationDbContext();
            var Empuser = db.EmployeeUsers.FirstOrDefault(u => u.User == userName);
            
            return Empuser.EmployeeId;
        }

        public static int getSaleMan(this IIdentity identity)
        {
            var userId = identity.GetUserId();
            var userName = identity.GetUserName();
            ApplicationDbContext db = new ApplicationDbContext();
            var Empuser = db.EmployeeUsers.FirstOrDefault(u => u.User == userName);
            
            try
            {
                var saleman = db.SalesMan.FirstOrDefault(u => u.EmployeeId == Empuser.EmployeeId);
                return saleman.SalesManId;
            }
            catch (Exception e){ return -1;  }
            
        }

        public static string getEmployeeUserId(int empid)
        {
  
            ApplicationDbContext db = new ApplicationDbContext();
            string Empuser = db.EmployeeUsers.FirstOrDefault(u => u.EmployeeId == empid).User;

            try
            {
            
                return Empuser;
            }
            catch (Exception e) { return ""; }

        }

        public static int numDayInMonth(DateTime today, String  dow)
        {
            //First We find out last date of mont
           // DateTime today = DateTime.Today;
            DateTime endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            //get only last day of month
            int day = endOfMonth.Day;

            DateTime now = DateTime.Now;
            int count;
            count = 0;
            for (int i = 0; i < day; ++i)
            {
                DateTime d = new DateTime(now.Year, now.Month, i + 1);
                //Compare date with sunday
                if (d.DayOfWeek.ToString() == dow)
                {
                    count = count + 1;
                }
            }
            return (count);
        }

        public static int numDayInMonth(DateTime today, List<CollectionDayMonthly> dow)
        {
            int count;
            count = 0;
            foreach (var da in dow)
            {
                //First We find out last date of mont
                // DateTime today = DateTime.Today;
                DateTime endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
                //get only last day of month
                int day = endOfMonth.Day;

                DateTime now = DateTime.Now;
                
                
                for (int i = 0; i < day; ++i)
                {
                    DateTime d = new DateTime(now.Year, now.Month, i + 1);
                    //Compare date with sunday
                    if (i == da.DayOfMonth)
                    {
                        count = count + 1;
                    }
                }
            }
            return (count);
        }

    }
}