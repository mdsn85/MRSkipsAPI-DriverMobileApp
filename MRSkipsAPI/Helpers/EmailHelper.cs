using log4net;
using MRSkipsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Hosting;

namespace MRSkipsAPI.Helpers
{
    public class EmailHelper
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        private ILog log = LogManager.GetLogger("emails log");
        public int sendEmail(String Subject, String emailBody, List<string> TO, List<string> CC, List<Attachment> attachments)
        {
            using (MailMessage mail = new MailMessage())
            {
                try
                {
                    mail.From = new MailAddress(EmailSetting.MailFrom);

                    // mail.To.Add(new MailAddress("mdsn85@gmail.com"));
                    // mail.To.Add(new MailAddress("basel.mansour95@gmail.com"));
                   // mail.CC.Add(new MailAddress("nazir@mrskips.net"));
                    mail.CC.Add(new MailAddress("customercare@mrskips.net"));


                    foreach (Attachment attachment in attachments)
                    {
                        mail.Attachments.Add(attachment);
                    }

                    if (TO != null)
                    {
                        foreach (string to in TO)
                        {
                           // MailAddress copy = new MailAddress(to);
                           // mail.To.Add(copy);
                        }
                    }

                    //if (CC != null)
                    //{

                    //    foreach (string cc in CC)
                    //    {
                    //        MailAddress copy = new MailAddress(cc);
                    //        mail.CC.Add(copy);
                    //    }
                    //}
                    Subject = Subject.Replace('\r', ' ').Replace('\n', ' ');
                    mail.Subject = Subject;
                    mail.Body = emailBody;


                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    EmailServer es = db.EmailServers.FirstOrDefault();
                    smtp.Host = es.Host;
                    smtp.EnableSsl = es.EnableSsl; ;
                    NetworkCredential networkCredential = new NetworkCredential(EmailSetting.MailFrom, EmailSetting.Password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = es.Port;
                    smtp.Send(mail);
                    log.Info("Email sent successfully");

                }
                catch (Exception e)
                {
                    log.Error("Email wasn't sent, Message: " + e.Message + ", Stacktrace: " + e.StackTrace);
                    log.ErrorFormat("Subject: {0}, Body: {1}", Subject, emailBody);
                    return 0;
                }
                return 1;
            }



        }

        public int SendEmailVisitOnTime(TripSheetDaetails c)
        {

            List<string> emails = new List<string>();
            List<string> CC = new List<string>();
            List<Attachment> attachments = new List<Attachment>();



            TripSheetDeatails_skip lastVisitSkip = c.TripSheetDeatails_skips.Where(sk => sk.Status == TripStatus_skip.visit_free /*|| sk.Status == TripStatus_skip.visit_charge*/).LastOrDefault();

            foreach (var skip in c.TripSheetDeatails_skips.Where(sk => sk.Status == TripStatus_skip.visit_free))
            {

                if (!string.IsNullOrEmpty( skip.ReasonImg))
                {
                    Attachment attachment = new Attachment(
                             HostingEnvironment.MapPath("~/SkipsImages/") + skip.ReasonImg,
                             MediaTypeNames.Application.Octet);
                    attachments.Add(attachment);
                }
            }

            string SubjectForCase = "";

            string emailBodys = "";

            Contract cont = c.Contracts;

            if (cont.ExtraEmail == null || cont.ExtraEmail.Trim() == "")
            {
                emails.Add(cont.EmailID.Trim());
            }
            else
            {
                String[] multiTo = cont.ExtraEmail.Split(',');
                foreach (string cc in multiTo)
                {
                    emails.Add(cc.Trim());
                }
            }
            // CC.Add("operations@mrskips.net");

            CC.Add("operations@mrskips.net");

            try
            {
                int SalesManId = cont.SalesManId;
                int empid = db.SalesMan.Find(SalesManId).EmployeeId ?? 0;
                //int ReportToId = db.SalesTeam.Find(SalesManId).EmployeeId ?? 0;
                //Employee ReportTo = db.employees.Find(SalesManId);

                //string ReportToUsername = db.EmployeeUsers.Where(e => e.EmployeeId == empid).FirstOrDefault().User;
                //string ReportToEmail = db.Users.Where(u => u.UserName == ReportToUsername).FirstOrDefault().Email;
                //CC.Add(ReportToEmail);

                string remark = "";
                string dos = "";
                int visited = 0;
                string old = "";
                string serial = "";
                string selectedReason = "";
                foreach (var cs in c.TripSheetDeatails_skips)
                {
                    if (/*cs.Status == TripStatus_skip.visit_charge ||*/ cs.Status == TripStatus_skip.visit_free)
                    {
                        if (old != cs.DoNum)
                        {
                            dos = dos + " , " + cs.DoNum;
                            old = cs.DoNum;
                        }
                        visited++;
                        serial = serial + " , " + cs.SkipSerialNumber2;
                        if (!remark.Contains(cs.Remarks))
                        {
                            remark = remark + " " + cs.Remarks;
                        }
                        if (!selectedReason.Contains(cs.Reason))
                        {
                            selectedReason = selectedReason + ", and " + cs.Reason;
                        }
                    }
                }

                SubjectForCase = "Waste Bin not Collected -  MR SKIPS WASTE SERVICES // " + c.Contracts.Customer.CompanyName + " / " + c.Contracts.SkipLocation + " on " + c.TripsDate.ToString("dd-MM-yyyy");

                emailBodys = "Dear Valued Customer,<br> <br>We thank you for choosing MR SKIPS for your Waste Management Services. This is to bring to <br>your kind notice that <br/>" +
                    " our collection team had visited your site on " + c.TripsDate.ToString("dd-MM-yyyy") + " at  " + (DateTime.Now.ToLongTimeString()) + " as per the schedule, however<br/>,the vehicle returned "+
                    "without collection due to “" + selectedReason  + ", " + remark + "” as per our discussion.<br/><br/>"+

                    "<u>Please note as per the terms:</u> It is the customer’s responsibility to ensure that MR Skips has proper access to the skip(s) to perform the service(s). In the event where MR Skips vehicles"+
                    "are denied proper access or turned down for whatever reasons, when the trips are scheduled by request/or in schedule, such Trips will be charged at 50% of the agreed trip rate in order to cover the Visit Cost."+

                    "<br><br>" + c.Contracts.ProjectName + " - " + c.Contracts.SkipLocation + ":  <br>Skip Size:    " + c.Products.Name + "<br><span style='color: rgb(255, 153, 0); '>No. Of skip Visited: " + visited.ToString() + "</span><br>DO # : " + dos + "<br><br><u>Please note as per the terms:</u> It is the customer’s responsibility to ensure that MR Skips <br>has proper access to the skip(s) to perform the service(s). In the event where MR <br>Skips vehicles are denied proper access or turned down for whatever reasons, when the<br> trips are scheduled by request/or in schedule, such Trips will be charged at 50%<br> of the agreed trip rate in order to cover the Visit Cost.<br> <br>If you need further clarification, please feel free to contact us on 0529067928/0529067929<br> or email us on operations@mrskips.net<br><br><span style='background - color:rgb(255, 153, 0); '>" +
                            "<span style='background-color: rgb(255, 153, 0)'>“Kindly Consider this email as a proof of waste collection”</span><br><br><i>This is an automated e-email, please do not reply back to this e-mail.</i>";





                //SubjectForCase = "Waste is not Collected on " + c.TripsDate.ToString("dd-MM-yyyy") + " due to “" + remark + "” & this visit is chargeable to " + c.Contracts.ProjectName + " - " + c.Contracts.SkipLocation + " – DO # " + dos;

                //emailBodys = "Dear Valued Customer,<br><span style='color: rgb(255, 153, 0); '>" + c.Contracts.Customer.CompanyName + "<br style='color: rgb(255, 153, 0); '></span><br>We thank you for choosing MR SKIPS for your Waste Management Services. This is to bring to <br>your kind notice that as per waste collection request / scheduled,<span style='color: rgb(255, 153, 0); '> our waste <br>collection team had visited your site on " + c.TripsDate.ToString("dd-MM-yyyy") + " at  " + (DateTime.Now.ToLongTimeString()) + ". but returned without collection due to “" + remark + "” </span><br><br>" + c.Contracts.ProjectName + " - " + c.Contracts.SkipLocation + ":  <br>Skip Size:    " + c.Products.Name + "<br><span style='color: rgb(255, 153, 0); '>No. Of skip collected: 0</span><br>DO # : " + dos + "<br><br><u>Please note as per the terms:</u> It is the customer’s responsibility to ensure that MR Skips <br>has proper access to the skip(s) to perform the service(s). In the event where MR <br>Skips vehicles are denied proper access or turned down for whatever reasons, when the<br> trips are scheduled by request/or in schedule, such Trips will be charged at 50%<br> of the agreed trip rate in order to cover the Visit Cost.<br> <br>If you need further clarification, please feel free to contact us on 0529067928/0529067929<br> or email us on operations@mrskips.net<br><br><span style='background - color:rgb(255, 153, 0); '>" +
                //            "<span style='background-color: rgb(255, 153, 0)'>“Kindly Consider this email as a proof of waste collection”</span><br><br><i>This is an automated e-email, please do not reply back to this e-mail.</i>";


                //SubjectForCase = "Waste is not Collected on " + c.TripsDate.ToString("dd-MM-yyyy") + " due to “" + remark + "” & this visit is chargeable to " + c.Contracts.ProjectName + " - " + c.Contracts.SkipLocation + " – DO # " + dos;

                //emailBodys = "Dear Valued Customer,<br><span style='color: rgb(255, 153, 0); '>" + c.Contracts.Customer.CompanyName + "<br style='color: rgb(255, 153, 0); '></span><br>We thank you for choosing MR SKIPS for your Waste Management Services. This is to bring to <br>your kind notice that as per waste collection request / scheduled,<span style='color: rgb(255, 153, 0); '> our waste <br>collection team had visited your site on " + c.TripsDate.ToString("dd-MM-yyyy") + " at  " + (DateTime.Now.ToLongTimeString()) + ". but returned without collection due to “" + remark + "” </span><br><br>" + c.Contracts.ProjectName + " - " + c.Contracts.SkipLocation + ":  <br>Skip Size:    " + c.Products.Name + "<br><span style='color: rgb(255, 153, 0); '>No. Of skip collected: 0</span><br>DO # : " + dos + "<br><br><u>Please note as per the terms:</u> It is the customer’s responsibility to ensure that MR Skips <br>has proper access to the skip(s) to perform the service(s). In the event where MR <br>Skips vehicles are denied proper access or turned down for whatever reasons, when the<br> trips are scheduled by request/or in schedule, such Trips will be charged at 50%<br> of the agreed trip rate in order to cover the Visit Cost.<br> <br>If you need further clarification, please feel free to contact us on 0529067928/0529067929<br> or email us on operations@mrskips.net<br><br><span style='background - color:rgb(255, 153, 0); '>" +
                //            "<span style='background-color: rgb(255, 153, 0)'>“Kindly Consider this email as a proof of waste collection”</span><br><br><i>This is an automated e-email, please do not reply back to this e-mail.</i>";



                return sendEmail(SubjectForCase, emailBodys, emails, CC, attachments);
            }
            catch (Exception e) {

                log.Error("Email wasn't sent, Message: " + e.Message + ", Stacktrace: " + e.StackTrace);
            }



            return 0;
        }

        public int SendEmailDropOnTime(TripSheetDaetails c)
        {

            List<string> emails = new List<string>();
            List<string> CC = new List<string>();
            List<Attachment> attachments = new List<Attachment>();
            TripSheetDeatails_skip lastDropSkip = c.TripSheetDeatails_skips.Where(sk => sk.Status == TripStatus_skip.drop).LastOrDefault();


            foreach (var skip in c.TripSheetDeatails_skips.Where(sk => sk.Status == TripStatus_skip.drop))
            {

                if (!string.IsNullOrEmpty(skip.ReasonImg))
                {
                    Attachment attachment = new Attachment(
                             HostingEnvironment.MapPath("~/SkipsImages/") + skip.ReasonImg,
                             MediaTypeNames.Application.Octet);
                    attachments.Add(attachment);
                }
            }

            string SubjectForCase = "";

            string emailBodys = "";

            Contract cont = c.Contracts;

            if (cont.ExtraEmail == null || cont.ExtraEmail.Trim() == "")
            {
                emails.Add(cont.EmailID.Trim());

                //emails.Add("mdsn85@gmail.com");
            }
            else
            {
                String[] multiTo = cont.ExtraEmail.Split(',');
                foreach (string cc in multiTo)
                {
                    emails.Add(cc);
                }
            }

            CC.Add("operations@mrskips.net");
           // CC.Add("customercare@mrskips.net");

            try
            {
                //int ReportToId = db.SalesTeam.Find(SalesManId).EmployeeId ?? 0;
                //Employee ReportTo = db.employees.Find(SalesManId);

                //string ReportToUsername = db.EmployeeUsers.Where(e => e.EmployeeId == empid).FirstOrDefault().User;
                // string ReportToEmail = db.Users.Where(u => u.UserName == ReportToUsername).FirstOrDefault().Email;
                //CC.Add(ReportToEmail);
                string st = c.TripSheetDeatails_skips.Where(tss => tss.Status == TripStatus_skip.drop).FirstOrDefault().Remarks;
                st = " " + c.TripSheetDeatails_skips.Where(tss => tss.Status == TripStatus_skip.drop).FirstOrDefault().Reason;
                string remarks = c.TripSheetDeatails_skips.Where(tss => tss.Status == TripStatus_skip.drop).FirstOrDefault().Remarks;
                string reason = c.TripSheetDeatails_skips.Where(tss => tss.Status == TripStatus_skip.drop).FirstOrDefault().Reason;
                string dos = c.TripSheetDeatails_skips.Where(tss => tss.Status == TripStatus_skip.drop).FirstOrDefault().DoNum.ToString();
                SubjectForCase = "Waste is not Collected on " + c.TripsDate.ToString("dd-MM-yyyy") + " due to “" + c.TripSheetDeatails_skips.Where(tss => tss.Status == TripStatus_skip.drop).FirstOrDefault().Remarks + "” – DO # " + c.TripSheetDeatails_skips.Where(tss => tss.Status == TripStatus_skip.drop).FirstOrDefault().DoNum;

                emailBodys = "Dear Valued Customer,<br><span style='color: rgb(255, 153, 0); '>" + c.Contracts.Customer.CompanyName + "<br style='color: rgb(255, 153, 0); '></span><br>We thank you for choosing MR SKIPS for your Waste Management Services. This is to bring to <br>your kind notice that as per waste collection request / scheduled,<span style='color: rgb(255, 153, 0); '> our waste <br>collection team had visited your site on " + c.TripsDate.ToString("dd-MM-yyyy") + " at  " + (DateTime.Now.ToLongTimeString()) + ". but returned without collection due to “" + remarks + "” </span><br><br>" + c.Contracts.ProjectName + " - " + c.Contracts.SkipLocation + ":  <br>Skip Size:    " + c.Products.Name + "<br><span style='color: rgb(255, 153, 0); '>No. Of skip collected: 0</span><br>DO # : " + dos + "<br><br><u>Please note as per the terms:</u> It is the customer’s responsibility to ensure that MR Skips <br>has proper access to the skip(s) to perform the service(s). In the event where MR <br>Skips vehicles are denied proper access or turned down for whatever reasons, when the<br> trips are scheduled by request/or in schedule, such Trips will be charged at 50%<br> of the agreed trip rate in order to cover the Visit Cost.<br> <br>If you need further clarification, please feel free to contact us on 0529067928/0529067929<br> or email us on operations@mrskips.net<br><br><span style='background - color:rgb(255, 153, 0); '>" +
                            "<span style='background-color: rgb(255, 153, 0)'>“Kindly Consider this email as a proof of waste collection”</span><br><br><i>This is an automated e-email, please do not reply back to this e-mail.</i>";

                //SubjectForCase = " Drop Report – " + c.Contracts.Customer.CompanyName;

                //emailBodys = "We thank you for choosing MR SKIPS for your Waste Management Services. This is to bring to your kind notice that as per waste collection scheduled vehicle had visited your site on " +
                //     c.TripsDate.ToString("dd-MM-yyyy") + "but returned without collection due to " + st;

                //emailBodys += "<br/><br/> " + c.Contracts.ProjectName + " - " + c.Contracts.SkipLocation + "<br/>" +
                //              "Skip Size: " + c.Contracts.Products.Name + " <br/>" +
                //              "No.Of skip collected:" + c.NumberOfSkipscollected + "<br/> " +
                //              "DO # :" + c.DoNum + "<br/><br/>" +

                //"If you need further clarification, please feel free to contact us on 0529067928 / 0529067929 or email us on operations@mrskips.net";


                return sendEmail(SubjectForCase, emailBodys, emails, CC, attachments);
            }
            catch (Exception e) {
                log.Error("Email wasn't sent, Message: " + e.Message + ", Stacktrace: " + e.StackTrace);
            }



            return 0;
        }

        public int SendEmailUnsignedOnTime(TripSheetDaetails c)
        {
            List<string> emails = new List<string>();
            List<string> CC = new List<string>();
            List<Attachment> attachments = new List<Attachment>();
            TripSheetDeatails_skip lastUnsignedSkip = c.TripSheetDeatails_skips.Where(sk => sk.Status == TripStatus_skip.unsign).LastOrDefault();
            //if (lastUnsignedSkip.ReasonImg != "")
            //{
            //    Attachment attachment = new Attachment(
            //             HostingEnvironment.MapPath("~/SkipsImages/") + lastUnsignedSkip.ReasonImg,
            //             MediaTypeNames.Application.Octet);
            //    attachments.Add(attachment);
            //}



            foreach (var skip in c.TripSheetDeatails_skips.Where(sk => sk.Status == TripStatus_skip.unsign))
            {

                if (!string.IsNullOrEmpty(skip.ReasonImg))
                {
                    Attachment attachment = new Attachment(
                             HostingEnvironment.MapPath("~/SkipsImages/") + skip.ReasonImg,
                             MediaTypeNames.Application.Octet);
                    attachments.Add(attachment);
                }
            }

            string SubjectForCase = "";

            string emailBodys = "";

            Contract cont = c.Contracts;

            if (cont.ExtraEmail == null || cont.ExtraEmail.Trim() == "")
            {
                emails.Add(cont.EmailID.Trim());
            }
            else
            {
                String[] multiTo = cont.ExtraEmail.Split(',');
                foreach (string cc in multiTo)
                {
                    emails.Add(cc.Trim());
                }
            }

            CC.Add("operations@mrskips.net");
            //CC.Add("customercare@mrskips.net");

            try
            {
                int SalesManId = cont.SalesManId;
                int empid = db.SalesMan.Find(SalesManId).EmployeeId ?? 0;
                //int ReportToId = db.SalesTeam.Find(SalesManId).EmployeeId ?? 0;
                //Employee ReportTo = db.employees.Find(SalesManId);

                //string ReportToUsername = db.EmployeeUsers.Where(e => e.EmployeeId == empid).FirstOrDefault().User;
                // string ReportToEmail = db.Users.Where(u => u.UserName == ReportToUsername).FirstOrDefault().Email;
                //CC.Add(ReportToEmail);


                string dos = "";
                string old = "";
                string serial = "";
                int totalTrips = 0;
                foreach (var cs in c.TripSheetDeatails_skips)
                {
                    if (cs.Status == TripStatus_skip.unsign)
                    {
                        totalTrips++;
                        if (old != cs.DoNum)
                        {
                            dos = dos + " , " + cs.DoNum;
                            old = cs.DoNum;

                            serial = serial + " , " + cs.SkipSerialNumber2;
                        }
                    }
                }

                SubjectForCase = "Delivery Order -Unsigned- for Waste Collected from “" + c.Contracts.Customer.CompanyName + c.Contracts.SkipLocation
                        + "“ on “" + c.TripsDate.ToString("dd-MM-yyyy");// + "” – DO # (“" + dos + "“)";

                emailBodys = "Dear Valued Customer,<br>"+
                    //"<span style='color: rgb(255, 153, 0); '>" + c.Contracts.Customer.CompanyName + "</span><br>"+
                    "<br>We thank you for choosing MR SKIPS for your Waste Management Services. This email is to confirm that we have collected <br>"+
                    "your waste bin on " + c.TripsDate.ToString("dd-MM-yyyy") + " at " + (DateTime.Now.ToLongTimeString()) + " +" +

                    " based on your request / schedule; however, there was no one <br/> available at the site to sign the delivery note.<br>" +
                    
                    "<br>We request you to acknowledge this trip done through email (operations@mrskips.net) within 3 business days</br>" +
                    "after you receive this email, and your subject line should mention your 'company Name' and location for waste collection</br> in specific.</br>" +
                    "If in case, you fail to revert in 3 business days with the proper acknowledgement, we will consider it as confirmed and <br>acknowledged from yourside   <br/> <br/>" +

                    c.Contracts.Customer.CompanyName + " - " + c.Contracts.SkipLocation + ": <br>Skip Size:  " + c.Contracts.Products.Name + "<br><span style='color: rgb(255, 153, 0); '>" +
                    "No. Of skip collected: " + totalTrips + "</span><br>DO # : " + c.TripSheetDeatails_skips.FirstOrDefault().DoNum + 
                    "<br><br>If you need further clarification, please feel free to contact us on 0529067928/0529067929 <br>or email us on operations@mrskips.net<br><br>" +
                    "“Kindly Consider this email as a proof of waste collection”<br><br><i>This is an automated e-email, please do not reply back to this e-mail.</i>";
             


//                emailBodys = "Dear Valued Customer,<br>" +
//    //"<span style='color: rgb(255, 153, 0); '>" + c.Contracts.Customer.CompanyName + "</span><br>"+
//    "<br>We thank you for choosing MR SKIPS for your Waste Management Services. This is to confirm that we have collected <br>" +
//    "your waste bin request / schedule, <span style='color: rgb(255, 153, 0); '>our dedicated waste collection <br style='color: rgb(255, 153, 0); '>" +
//    "team has been collected  your waste on&nbsp;" + c.TripsDate.ToString("dd-MM-yyyy") + " at " + (DateTime.Now.ToLongTimeString()) + " VisitTime </span>. Unfortunately," +
//"there was no one available at site to sign the Delivery Note.<br>We request you to kindly confirm the trips done through email (operations@mrskips.net) if" +
//"<br>we do not get the reply with 3 working days, its will be considered as confirmed.<br>"
//+ c.Contracts.Customer.CompanyName + " - " + c.Contracts.SkipLocation + ": <br>Skip Size:  " + c.Contracts.Products.Name + "<br><span style='color: rgb(255, 153, 0); '>" +
//"No. Of skip collected: " + c.NumberOfSkipscollected + "</span><br>DO # : " + c.TripSheetDeatails_skips.FirstOrDefault().DoNum + "+" +
//"<br><br>If you need further clarification, please feel free to contact us on 0529067928/0529067929 <br>or email us on operations@mrskips.net<br><br>" +
//"“Kindly Consider this email as a proof of waste collection”<br><br><i>This is an automated e-email, please do not reply back to this e-mail.</i>";

                return sendEmail(SubjectForCase, emailBodys, emails, CC, attachments);
            }
            catch (Exception e)
            {
                log.Error("Email wasn't sent, Message: " + e.Message + ", Stacktrace: " + e.StackTrace);
            }



            return 0;
        }

        public int SendEmailCompleteOnTime(TripSheetDaetails c)
        {
            List<string> emails = new List<string>();
            List<string> CC = new List<string>();
            List<Attachment> attachments = new List<Attachment>();
            string SubjectForCase = "";

            string emailBodys = "";

            Contract cont = c.Contracts;

            if (cont.ExtraEmail == null || cont.ExtraEmail.Trim() == "")
            {
                emails.Add(cont.EmailID.Trim());
            }
            else
            {
                String[] multiTo = cont.ExtraEmail.Split(',');
                foreach (string cc in multiTo)
                {
                    emails.Add(cc.Trim());
                }
            }

            //CC.Add("customercare@mrskips.net");

            try
            {
                int SalesManId = cont.SalesManId;
                int empid = db.SalesMan.Find(SalesManId).EmployeeId ?? 0;
                //int ReportToId = db.SalesTeam.Find(SalesManId).EmployeeId ?? 0;
                //Employee ReportTo = db.employees.Find(SalesManId);
                //  string ReportToUsername = db.EmployeeUsers.Where(e => e.EmployeeId == empid).FirstOrDefault().User;
                //string ReportToEmail = db.Users.Where(u => u.UserName == ReportToUsername).FirstOrDefault().Email;
                // CC.Add(ReportToEmail);

                string dos = "";
                string old = "";
                string serial = "";
                int totalTrips = 0;
                foreach (var cs in c.TripSheetDeatails_skips)
                {
                    if (cs.Status == TripStatus_skip.Complete || cs.Status == TripStatus_skip.visit_charge)
                    {
                        totalTrips++;
                        if (old != cs.DoNum)
                        {
                            dos = dos + " , " + cs.DoNum;
                            old = cs.DoNum;

                            serial = serial + " , " + cs.SkipSerialNumber2;
                        }
                    }
                }
                SubjectForCase = "Waste Bin Collected - MR SKIPS WASTE SERVICES // " + c.Contracts.Customer.CompanyName +" / "+ c.Contracts.SkipLocation + " on " + c.TripsDate.ToString("dd-MM-yyyy")  ;

                emailBodys = "Dear Valued Customer,<br><span style='color: rgb(255, 153, 0); '>" + c.Contracts.Customer.CompanyName + "</span><br><br>We thank you for choosing MR SKIPS for your Waste Management Services. This is to confirm<br> that as per your request/Schedule of waste collection,  <span style='color: rgb(255, 153, 0); '> your waste has been<br> collected on " + c.TripsDate.ToString("dd-MM-yyyy") + "</b>&nbsp;at  " + (DateTime.Now.ToLongTimeString()) + " </span>&nbsp; from , <br><br>" + c.Contracts.ProjectName + " - " + c.Contracts.SkipLocation + "<br>Skip Size:    " + c.Products.Name + "<br/><span style='color: rgb(255, 153, 0); '>No. Of skip collected: " +
                            totalTrips + "</span><br/> DO # : " + dos + "<br><br>If you need further clarification, please feel free to contact us on 0529067928/0529067929<br> or email us on operations@mrskips.net<br><br>" +
                            "<span style='background-color: rgb(255, 153, 0)'>“Kindly Consider this email as a proof of waste collection”</span><br>" +
                            "<br/><br/><I>This is an automated e-email, please do not reply back to this e-mail.</I>";


                //String s = "8/30/2020 12:21:50 PM";
                //s = s.Substring(10);
                string Aa = "<p class='MsoNormal' style='margin-bottom: 0px; color: rgb(34, 34, 34); font-size: small;'>&nbsp;<b><span style='font-family: &quot;Bradley Hand ITC&quot;; color: gray;'>Best Regards,</span></b></p><p class='MsoNormal' style='margin-bottom: 0px; color: rgb(34, 34, 34); font-size: small; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'><span style='font-size: 9.5pt; font-family: Arial, sans-serif; color: rgb(34, 34, 34);'><img width='141' height='78' id='m_-178687823975547928_x0000_i1025' src='https://www.mrskips.net/wp-content/themes/skips/assets/images/logo.png' alt='unnamed' data-image-whitelisted='' class='CToWUd' style='width: 1.4687in; height: 0.8125in;'></span></p><p class='MsoNormal' style='margin-bottom: 0px; color: rgb(34, 34, 34); font-size: small; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'><b><span style='font-family: &quot;Palatino Linotype&quot;, serif; color: rgb(255, 102, 0);'><br></span></b></p><p class='MsoNormal' style='margin-bottom: 0px; color: rgb(34, 34, 34); font-size: small; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'><b><span style='font-family: &quot;Palatino Linotype&quot;, serif; color: rgb(255, 102, 0);'><br></span></b></p><p class='MsoNormal' style='margin-bottom: 0px; color: rgb(34, 34, 34); font-size: small; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'><b><span style='font-family: &quot;Palatino Linotype&quot;, serif; color: rgb(255, 102, 0);'><br></span></b></p><p class='MsoNormal' style='margin-bottom: 0px; color: rgb(34, 34, 34); font-size: small; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'><b><span style='font-family: &quot;Palatino Linotype&quot;, serif; color: rgb(255, 102, 0);'><br></span></b></p><p class='MsoNormal' style='margin-bottom: 0px; color: rgb(34, 34, 34); font-size: small; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'><b><span style='font-family: &quot;Palatino Linotype&quot;, serif; color: rgb(255, 102, 0);'><br></span></b></p><p class='MsoNormal' style='margin-bottom: 0px; color: rgb(34, 34, 34); font-size: small; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'><b><span style='font-family: &quot;Palatino Linotype&quot;, serif; color: rgb(255, 102, 0);'>MR SKIPS TEAM</span></b></p><p class='MsoNormal' style='margin-bottom: 0px; color: rgb(34, 34, 34); font-size: small; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'><b><i><u><span style='font-size: 10pt; color: rgb(196, 89, 17);'>”ONE TEAM ONE GOAL’’</span></u></i></b></p><p class='MsoNormal' style='margin-bottom: 0px; color: rgb(34, 34, 34); font-size: small; line-height: 10.1pt; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'><span style='font-size: 9pt; font-family: &quot;Times New Roman&quot;, serif; color: rgb(34, 34, 34); background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'>102, Deyaar Building, Al Barsha 1,</span></p><p class='MsoNormal' style='margin-bottom: 0px; color: rgb(34, 34, 34); font-size: small; line-height: 10.1pt; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'><span style='font-size: 9pt; font-family: &quot;Times New Roman&quot;, serif; color: rgb(34, 34, 34); background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'>Shk Zayed Road, Dubai 282598, U.A.E.</span></p><p class='MsoNormal' style='margin-bottom: 0px; color: rgb(34, 34, 34); font-size: small; line-height: 10.1pt; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'><span style='font-size: 9pt; font-family: &quot;Times New Roman&quot;, serif; color: rgb(34, 34, 34);'>Email:&nbsp;</span><u><span style='font-size: 9pt; font-family: &quot;Times New Roman&quot;, serif; color: rgb(17, 85, 204);'><a href='mailto:operations@mrskips.net' target='_blank' style='color: rgb(17, 85, 204);'><span style='color: blue;'>operations@mrskips.net</span></a></span></u></p><p class='MsoNormal' style='margin-bottom: 0px; color: rgb(34, 34, 34); font-size: small; line-height: 10.1pt; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'><span style='font-size: 9pt; font-family: &quot;Times New Roman&quot;, serif; color: rgb(34, 34, 34);'>Tel: +971 4 379 4989 | Fax: +971 4 379 4969</span></p><p class='MsoNormal' style='margin-bottom: 0px; color: rgb(34, 34, 34); font-size: small; line-height: 10.1pt; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'><span style='font-size: 9pt; font-family: &quot;Times New Roman&quot;, serif; color: rgb(34, 34, 34);'>Web:&nbsp;</span><span style='font-size: 9.5pt; font-family: &quot;Times New Roman&quot;, serif; color: rgb(34, 34, 34);'><a href='http://www.mrskips.net/' target='_blank' data-saferedirecturl='https://www.google.com/url?q=http://www.mrskips.net/&amp;source=gmail&amp;ust=1587475936554000&amp;usg=AFQjCNGwFUddSXIs4m-3S8bEDhqceEdRyQ' style='color: rgb(17, 85, 204);'><span style='font-size: 9pt; color: blue;'>www.mrskips.net</span></a></span></p><p class='MsoNormal' style='margin-bottom: 0px; color: rgb(34, 34, 34); font-size: small; background-image: initial; background-position: initial; background-size: initial; background-repeat: initial; background-attachment: initial; background-origin: initial; background-clip: initial;'><span style='font-size: 12pt; font-family: &quot;Times New Roman&quot;, serif; color: rgb(31, 73, 125);'>“</span><b><u><span style='font-size: 12pt; font-family: &quot;Times New Roman&quot;, serif; color: rgb(131, 60, 11);'>24X7 CUSTOMER CARE NUMBER FOR SERVICE BOOKING: 043794989/0529067928/<wbr>0529067929”</span></u></b></p>";

                emailBodys = emailBodys + "-- <br/>" + Aa;

                if (totalTrips != 0)
                {
                    return sendEmail(SubjectForCase, emailBodys, emails, CC, attachments);
                }
            }
            catch (Exception e)
            {
                log.Error("Email wasn't sent, Message: " + e.Message + ", Stacktrace: " + e.StackTrace);
            }



            return 0;
        }
    }
}