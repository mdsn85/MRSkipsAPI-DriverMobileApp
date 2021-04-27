using MRSkipsAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Web.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using JWT;
using JWT.Serializers;
using JWT.Algorithms;
using MRSkipsAPI.ViewModels;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Web.Hosting;
using System.Data.Entity;
using log4net;
using MRSkipsAPI.Helpers;
using System.Web.Script.Serialization;
using System.Globalization;

namespace MRSkipsAPI.Controllers
{
    public class APIController : System.Web.Http.ApiController
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private const string DRIVER = "DRIVER";
        private ILog log = LogManager.GetLogger("mylog");
        EmailHelper emailHelper = new EmailHelper();

        [AcceptVerbs("GET")]
        public object Login(string username, string password)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var Driver = db.Drivers.Where(d => d.AppUserName == username && d.AppPassWard == password).FirstOrDefault();
            if (Driver == null)
            {
                return new { Success = false, ErrorCode = "403" };
            }
            else
            {
                var payload = new Dictionary<string, object>
                {
                    { "DriverId", Driver.DriverId }
                };
                string secret = WebConfigurationManager.AppSettings.Get("jwtKey");

                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

                var token = encoder.Encode(payload, secret);

                var DriverRoute = db.Routes.Where(r => r.DriverId == Driver.DriverId && r.isActive == true).Select(r => new
                {
                    Helpers = r.Helper.Select(h => new {
                        Id = h.HelperId,
                        Name = h.Name
                    }),
                    Vehicle = new
                    {
                        Id = r.VehicleId,
                        Name = r.Vehicle == null ? "" : r.Vehicle.PlateNo
                    }
                }).AsEnumerable().Select(r => new
                {
                    Helpers = r.Helpers,
                    Vehicle = r.Vehicle,
                    Id = Driver.DriverId,
                    Name = Driver.Name,
                }).FirstOrDefault();
                return new { Success = true, ErrorCode = "", User = DriverRoute, Token = token };
            }
        }

        [AcceptVerbs("GET")]
        public object StartShift(string token)
        {
            log.Info("StartShift: New request.");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception ex)
            {
                log.Error("StartShift: Unauthorized access.");
                return new { Success = false, ErrorCode = "403" };
            }
            Driver Driver = db.Drivers.Find(claims.DriverId.Value);
            Route Route = db.Routes.Where(r => r.DriverId == Driver.DriverId && r.isActive == true).OrderByDescending(t => t.RouteId).FirstOrDefault();
            if (Route == null)
            {

                log.Error("StartShift: Couldn't find actual duty.");
                return new { Success = false, ErrorCode = "400", Message = "Couldn't find actual duty." };
            }
            else
            {

                db.SaveChanges();
                return new { Success = true, ErrorCode = "" };
            }
        }

        [AcceptVerbs("GET")]

        public object StopShift(string token, float endKM)
        {
            log.Info("StopShift: New request.");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception ex)
            {
                log.Error("StartShift: Unauthorized access.");
                return new { Success = false, ErrorCode = "403" };
            }
            Driver Driver = db.Drivers.Find(claims.DriverId.Value);
            Route Route = db.Routes.Where(r => r.DriverId == Driver.DriverId && r.isActive == true).OrderByDescending(t => t.RouteId).FirstOrDefault();
            if (false)
            {
                return new { Success = false, ErrorCode = "400", Message = "No trip for this driver." };
            }
            else
            {
                List<Shift> DriverShifts = db.Shifts.Where(s => s.DriverId == Driver.DriverId).OrderByDescending(t => t.ShiftId).ToList();
                if (DriverShifts.Count == 0)
                {
                    log.Error("StopShift: Driver " + Driver.EmployeeId + " Doesn't have any started shift..");
                    return new { Success = false, ErrorCode = "400", Message = "Driver Doesn't have any started shift." };
                }
                else
                {
                    foreach (Shift shift in DriverShifts)
                    {
                        shift.EndShift = DateTime.Now;
                        shift.EndKM = endKM;
                        db.Entry(shift).State = System.Data.Entity.EntityState.Modified;
                    }
                }
                db.SaveChanges();
                //foreach (Helper Helper in Route.Helper)
                //{

                //    Shift ShiftHelper = db.Shifts.Where(s => s.EmployeeId == Helper.EmployeeId).OrderByDescending(t => t.ShiftId).FirstOrDefault();
                //    if (ShiftHelper == null)
                //    {
                //        log.Error("StopShift: Helper " + Helper.EmployeeId + " Doesn't have any started shift.");
                //        //return new { Success = false, ErrorCode = "400", Message = "Helper Doesn't have any started shift." };
                //        //go to driver shift 

                //        //ShiftId	EmployeeId	ActualDutyId	StartShift	EndShift	TripSheetId	StartKM	EndKM
                //        //   44  22  NULL    2019 - 11 - 09 14:51:36.727 2019 - 11 - 09 14:51:36.727 61  120 NULL
                //        //ShiftHelper = new Shift();
                //        //ShiftHelper.EmployeeId = Helper.EmployeeId;
                //        //ShiftHelper. = Helper.EmployeeId;


                //    }
                //    else
                //    {
                //        ShiftHelper.EndShift = DateTime.Now;
                //        ShiftHelper.EndKM = endKM;
                //        db.Entry(ShiftHelper).State = System.Data.Entity.EntityState.Modified;
                //    }

                //}

                return new { Success = true, ErrorCode = "" };
            }

        }

        [AcceptVerbs("GET")]
        public object GetDailyTripsbyDriver(string token, string date)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception)
            {
                log.Error("GetDailyTripbyDriver: Unauthorized access.");
                return new { Success = false, ErrorCode = "403" };
            }
            Driver Driver = db.Drivers.Find(claims.DriverId.Value);
            //var shift = db.Shifts.Where(sh => sh.EmployeeId == Driver.EmployeeId).ToList().LastOrDefault();
            DateTime dateDateTime = DateTime.ParseExact(date, "yyyy-MM-dd", null);
            List<TripSheetDaetails> tripDetails = db.TripSheetDaetails.Where(td => td.DriverId == Driver.DriverId && td.TripsDate == dateDateTime 
            && (td.NumberOfSkips > td.NumberOfSkipscollected || td.NumberOfSkipscollected == null)).ToList();
            var trips = tripDetails.OrderBy(trip => trip.Contracts.TallyCode).Select(t => new
            {
                Id = t.TripSheetDaetailsId,
                Name = t.Contracts.Customer.CompanyName,
                Location = t.Contracts.SkipLocation,
                Size = t.Contracts.Products.Name,
                Telephone = t.Contracts.MobileNo == null ? "" : t.Contracts.MobileNo,
                isCDC = t.Contracts.PaymentTerm.Name == "CDC" || t.Contracts.PaymentTerm.Name == "COD",
                Service = (t.ServiceTypes == null ? "" : t.ServiceTypes.Name),
                DoNum = t.DoNum,
                PunchInText = "Punch in" + ((t.Timein != null && t.Timein != "") ? (": " + t.Timein.Substring(10)) : ""),
                TallyCode = t.Contracts.TallyCode,
                NumOfSkips = t.NumberOfSkips,
                Ownership = t.Contracts.OwnerShipOfSkips.Name
            }).ToList();
            return new { Success = true, Trips = trips };


        }
        [AcceptVerbs("GET")]
        public object GetTripSigner(string token, int tripid)
        {
            log.Info("try GetTripSigner ");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception)
            {
                log.Error("GetDailyTripbyDriver: Unauthorized access.");
                return new { Success = false, ErrorCode = "403" };
            }
            try
            {
                var trip = db.TripSheetDaetails.Find(tripid);

                var signerList = db.TripsSigners.Where(ts => ts.ContractId == trip.ContractId)
                    .Select(ts => new { Name=ts.Name, Mobile = ts.Mobile, Tel=ts.Tel, ContractId=ts.ContractId }).ToList();


                return new { Success = true, signerList = signerList };
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException != null)
                {
                    log.Error($"\r\n \r\n**********Error while posting get signer:,\r\n \r\n message: { ex.Message },\r\n \r\nInner Message: {ex.InnerException.Message} , {ex.InnerException.ToString()} , {ex.InnerException.InnerException.Message} , \r\n \r\nstacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");

                }
                else
                {
                    log.Error($"\r\n \r\n**********Error while posting get signer:,\r\n \r\n message: { ex.Message },\r\n \r\nInner Message:  , \r\n \r\nstacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");

                }
                return new { Success = false , Message = "error"};
            }
        }

        [AcceptVerbs("GET")]
        public object GetContractSigner(string token, int contractId)
        {
            log.Info("try GetTripSigner ");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception)
            {
                log.Error("GetDailyTripbyDriver: Unauthorized access.");
                return new { Success = false, ErrorCode = "403" };
            }
            try
            {
                var signerList = db.TripsSigners.Where(ts => ts.ContractId == contractId)
                    .Select(ts => new { Name = ts.Name, Mobile = ts.Mobile, Tel = ts.Tel, ContractId = ts.ContractId }).ToList();

                return new { Success = true, signerList = signerList };
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException != null)
                {
                    log.Error($"\r\n \r\n**********Error while posting get signer:,\r\n \r\n message: { ex.Message },\r\n \r\nInner Message: {ex.InnerException.Message} , {ex.InnerException.ToString()} , {ex.InnerException.InnerException.Message} , \r\n \r\nstacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");

                }
                else
                {
                    log.Error($"\r\n \r\n**********Error while posting get signer:,\r\n \r\n message: { ex.Message },\r\n \r\nInner Message:  , \r\n \r\nstacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");

                }
                return new { Success = false, Message = "error" };
            }
        }
        

        //  return this.httpClient.get(this.apiURL + 'getContractId?token=' + this.token+'&tripid=' + tripid);
        [AcceptVerbs("GET")]
        public object getContractId(string token, int tripid)
        {
            
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            log.Info("try getContractId " + tripid);
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                int id = db.TripSheetDaetails.Find(tripid).ContractId;
                log.Info("success getContractId " + id);
                return new { Success = true, contractId = id };
            }
            catch (Exception ex)
            {
                string x = "";
                if (ex.InnerException.InnerException != null)
                {
                     x = $"\r\n \r\n**********Error while posting Fuel Receipt:,\r\n \r\n message: { ex.Message },\r\n \r\nInner Message: {ex.InnerException.Message} , {ex.InnerException.ToString()} , {ex.InnerException.InnerException.Message} , \r\n \r\nstacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }";
                    log.Error(x);
                }
                else
                {
                    x= $"\r\n \r\n**********Error while posting Fuel Receipte:,\r\n \r\n message: { ex.Message },\r\n \r\nInner Message:  , \r\n \r\nstacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }";
                    log.Error(x);
                }
                return new { Success = false, ErrorCode = "403" , Message = x};
            }
           

            
        }

        [AcceptVerbs("POST", "OPTIONS")]
        public object SaveNewSigner([FromBody]TripsSigner signer)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
            if (HttpContext.Current.Request.RequestType == "OPTIONS")
                return Ok();

            log.Info("try SaveNewSigner ");
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
            }
            catch (Exception)
            {

                return new { Success = false, ErrorCode = "403" };
            }


            string jsonString = JsonConvert.SerializeObject(signer);
            log.Info("try save new signer " + jsonString);
            try
            {
               
                db.TripsSigners.Add(signer);
                db.SaveChanges();
            }catch(Exception ex)
            {
                if (ex.InnerException.InnerException != null)
                {
                    log.Error($"\r\n \r\n**********Error while posting Fuel Receipt:,\r\n \r\n message: { ex.Message },\r\n \r\nInner Message: {ex.InnerException.Message} , {ex.InnerException.ToString()} , {ex.InnerException.InnerException.Message} , \r\n \r\nstacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");

                }
                else
                {
                    log.Error($"\r\n \r\n**********Error while posting Fuel Receipte:,\r\n \r\n message: { ex.Message },\r\n \r\nInner Message:  , \r\n \r\nstacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");

                }
                return new { Success = false };
            }

            return new
            {
                Success = true
            };
        }
            

        [AcceptVerbs("GET")]
        public object GetCompletedTripsbyDriver(string token)
        {
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception)
            {

                return new { Success = false, ErrorCode = "403" };
            }
            Driver Driver = db.Drivers.Find(claims.DriverId.Value);
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            List<TripSheetDaetails> tripDetails = db.TripSheetDaetails.Include(t=>t.TripSheetDeatails_skips).Where(td => td.DriverId == Driver.DriverId && td.TripSheetDeatails_skips.Count > 0).ToList();
            log.Info("GetCompletedTripsbyDriver");
            var trips = tripDetails.Select(t => new
            {
                Id = t.TripSheetDaetailsId,
                Name = t.Contracts.Customer.CompanyName,
                Location = t.Contracts.SkipLocation,
                Size = t.Contracts.Products.Name,
                Telephone = t.Contracts.MobileNo,
                Service = t.ServiceTypes == null ? "" : t.ServiceTypes.Name,
                Date = t.TripsDate,
                Ownership = t.Contracts.OwnerShipOfSkips.Name,
                weight = t.TripSheetDeatails_skips.Sum(s => s.Weight),
                numOfSkipsCollected = t.NumberOfSkipscollected,
                NumOfSkipsByContract = t.Contracts.NoOfSkips,
                Route = t.Contracts.Route == null ? "" : t.Contracts.Route.Name,
                DoNum = t.TripSheetDeatails_skips.FirstOrDefault().DoNum,
                TallyCode = t.Contracts.TallyCode ,
                TotalComplete = t.TripSheetDeatails_skips.Where(s=>s.Status == TripStatus_skip.Complete).Count(),
                TotalVisitFree = t.TripSheetDeatails_skips.Where(s => s.Status == TripStatus_skip.visit_free).Count(),
                TotalUnsign = t.TripSheetDeatails_skips.Where(s => s.Status == TripStatus_skip.unsign).Count(),
                TotalDrop = t.TripSheetDeatails_skips.Where(s => s.Status == TripStatus_skip.drop).Count()


            }).ToList();
            log.Info(trips[10].Id + "," + trips[0].weight + "," + trips[0].numOfSkipsCollected + "," + trips[0].Name + "," + trips[0].Date);
            log.Info(trips[10].Id + ","+trips[10].weight + "," + trips[10].numOfSkipsCollected + "," + trips[10].Name + "," + trips[10].Date);
            var list = JsonConvert.SerializeObject(new { Success = true, Trips = trips },
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });

            return new { Success = true, Trips = trips };

        }

        [AcceptVerbs("GET")]
        public object getSkipsByTrip(int TripId, string token)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception)
            {
                return new { Success = false, ErrorCode = "403" };
            }
            Driver Driver = db.Drivers.Find(claims.DriverId.Value);
            var Skips = db.TripSheetDaetails.Where(trip => trip.TripSheetDaetailsId == TripId).Select(t => new {
                Id = t.TripSheetDaetailsId,
                Name = t.Contracts.Customer.CompanyName,
                Location = t.Contracts.SkipLocation,
                Size = t.Contracts.Products.Name,
                Telephone = t.Contracts.MobileNo,
                DoNum = t.DoNum,
                Service = (t.ServiceTypes == null ? "" : t.ServiceTypes.Name),
                isCompactor = t.Contracts.TruckTypes.Name == "COMPACTOR TRUCK",
                NumOfSkips = t.NumberOfSkips - (t.NumberOfSkipscollected ?? 0),
                Ownership = t.Contracts.OwnerShipOfSkipId,
                NumOfSkipsByContract = t.Contracts.SkipOnSite,
                numOfSkipsCollected = t.NumberOfSkipscollected ?? 0
            }).First();

            return new { Success = true, ErrorCode = "", Skips = Skips };

        }

        [AcceptVerbs("GET")]
        public object getPendingSignatureSkipsByTrip(int TripId, string token)
        {
            log.Info(" getPendingSignatureSkipsByTrip with number");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception)
            {
                return new { Success = false, ErrorCode = "403" };
            }
            Driver Driver = db.Drivers.Find(claims.DriverId.Value);
            var Skips = db.TripSheetDeatails_skips.Where(sk => sk.TripSheetDaetails.DriverId == Driver.DriverId &&
            ( sk.Status == TripStatus_skip.unsign || string.IsNullOrEmpty(sk.SignateImg) )
            && sk.TripSheetDaetailsId == TripId).Select(sk => new
                                                       {
                Id = sk.TripSheetDeatails_skipId,
                Serial = sk.SkipSerialNumber,
                DO = sk.DoNum,
                Weight = sk.Weight,
                Remarks = sk.Remarks,
                Customer = sk.TripSheetDaetails.Contracts.Customer.CompanyName,
                TripDate = sk.TripSheetDaetails.TripsDate,
                Status = sk.Status.ToString(),
                SignateImg = sk.SignateImg.ToString()
            });

            return new { Success = true, ErrorCode = "", Skips = Skips };

        }

        [AcceptVerbs("GET")]
        public object getPendingSignatureSkipsByTripArray(string TripId, string token)
        {
            int[] tripIdArray = Array.ConvertAll(TripId.Split(','), int.Parse);
            log.Info(" getPendingSignatureSkipsByTrip with array");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception)
            {
                return new { Success = false, ErrorCode = "403" };
            }
            Driver Driver = db.Drivers.Find(claims.DriverId.Value);

            // var Trips = db.TripSheetDaetails.Where(tr => tr.DriverId == Driver.DriverId && tr.TripSheetDeatails_skips.Where(sk => sk.Status == TripStatus_skip.unsign
            //||  string.IsNullOrEmpty(sk.SignateImg)  ).ToList().Count > 0).ToList();//
            var Skips = db.TripSheetDeatails_skips.Where(sk => tripIdArray.Contains(sk.TripSheetDaetailsId) &&
            (sk.Status == TripStatus_skip.unsign || string.IsNullOrEmpty(sk.SignateImg)))
            .Select(sk => new
            {
                Id = sk.TripSheetDeatails_skipId,
                Serial = sk.SkipSerialNumber,
                DO = sk.DoNum,
                Weight = sk.Weight,
                Remarks = sk.Remarks,
                Customer = sk.TripSheetDaetails.Contracts.Customer.CompanyName,
                TripDate = sk.TripSheetDaetails.TripsDate,
                Status = sk.Status.ToString(),
                SignateImg = sk.SignateImg.ToString(),
                ContractId = sk.TripSheetDaetails.ContractId
            }).OrderBy (a=>a.TripDate);

            return new { Success = true, ErrorCode = "", Skips = Skips };

        }


        [AcceptVerbs("POST", "OPTIONS")]
        public object SaveChecklist(VehicleCheckListVM checklistVM)
        {
            try
            {
                HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

                if (HttpContext.Current.Request.RequestType == "OPTIONS")
                    return Ok();
                string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
                dynamic claims;
                try
                {
                    IJsonSerializer serializer = new JsonNetSerializer();
                    IDateTimeProvider provider = new UtcDateTimeProvider();
                    IJwtValidator validator = new JwtValidator(serializer, provider);
                    IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                    IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                    var json = decoder.Decode(checklistVM.token, secret, verify: true);
                    claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                }
                catch (Exception)
                {
                    return new { Success = false, ErrorCode = "403" };
                }
                Driver Driver = db.Drivers.Find(claims.DriverId.Value);
                


                Route Route = db.Routes.Where(r => r.DriverId == Driver.DriverId && r.isActive ==true).OrderByDescending(t => t.RouteId).FirstOrDefault();
                VehicleCheckList checklist = new VehicleCheckList()
                {
                    Reason = checklistVM.Reason,
                    LIGHTSINDICATORS = checklistVM.LIGHTSINDICATORS,
                    ENGINEOILLEVEL = checklistVM.ENGINEOILLEVEL,
                    HYDRAULICOILLEVEL = checklistVM.HYDRAULICOILLEVEL,
                    REDIATORCOOLENTLEVEL = checklistVM.REDIATORCOOLENTLEVEL,
                    WIPERMIRROR = checklistVM.WIPERMIRROR,
                    HYDRAULICFUNCTION = checklistVM.HYDRAULICFUNCTION,
                    ALLTYRES = checklistVM.ALLTYRES,
                    VEHICLECLEANLINESS = checklistVM.VEHICLECLEANLINESS,
                    PPEFIRSTAID = checklistVM.PPEFIRSTAID,
                    UNIFORM = checklistVM.UNIFORM,
                    WARNINGTRIANGLE = checklistVM.WARNINGTRIANGLE,
                    TARPAULINE = checklistVM.TARPAULINE,
                    BODYDAMAGE = checklistVM.BODYDAMAGE,
                    SEATBELTAC = checklistVM.SEATBELTAC,
                    TOOLS = checklistVM.TOOLS,
                    VEHICLEPAPERS = checklistVM.VEHICLEPAPERS,
                    FIREEXTINGUSHER = checklistVM.FIREEXTINGUSHER
                };
                checklist.DriverId = Driver.DriverId;
                checklist.VehicleId = Route.VehicleId;
                checklist.CheckDate = DateTime.Now;
                db.VehicleCheckLists.Add(checklist);

                int VehicleId = Route.VehicleId;
                if (checklist.VehicleReady())
                {
                    Shift shift = new Shift()
                    {
                        DriverId = Driver.DriverId,
                        StartShift = DateTime.Now,
                        StartKM = checklistVM.StartKM,
                        VehicleId = VehicleId
                    };
                    log.Info("\r\n shift:" + JsonConvert.SerializeObject(shift) +"\r\n  \r\n");
                    List<ShiftHelperLink> Linklist = new List<ShiftHelperLink>();
                    foreach (Helper Helper in Route.Helper)
                    {

                        // log.Info("\r\n Helper:" + JsonConvert.SerializeObject(Helper) + "\r\n  \r\n");

                        Linklist.Add(new ShiftHelperLink
                        {
                            Shift = shift,
                            Helper = Helper
                        });
                       // log.Info("\r\n Linklist:" + JsonConvert.SerializeObject(Linklist) + "\r\n  \r\n");

                        //ShiftHelper ShiftHelper = new ShiftHelper()
                        //{
                        //    EmployeeId = Helper.HelperId,
                        //    StartShift = DateTime.Now,
                        //    StartKM = checklistVM.StartKM
                        //};

                    }

                    if (Linklist.Count()>0)
                    {
                        shift.ShiftHelperLinks = Linklist;
                       // log.Info("\r\n shift:" + JsonConvert.SerializeObject(shift) + "\r\n  \r\n");
                    }
                    db.Shifts.Add(shift);
                }
                db.SaveChanges();

                return new { Success = true, ErrorCode = "" };
            }
            catch (Exception ex)
            {
                log.Error($"SaveChecklist: Exception message: { ex.Message }, stacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");
                return new { Success = false, ErrorCode = "400", Message = "Server Error" };
            }
        }

        private object JavaScriptSerializer()
        {
            throw new NotImplementedException();
        }

        [AcceptVerbs("POST", "OPTIONS")]
        public async Task<Object> PostFuel()
        {
            log.Info(" enter PostFuel");
            try
            {
                FuelVM fuelVM = new FuelVM();
                if (!Request.Content.IsMimeMultipartContent())
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                var fileProvider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(fileProvider);
                fuelVM.Amount = double.Parse(HttpContext.Current.Request.Form["Amount"].ToString());
                fuelVM.Quantity = double.Parse(HttpContext.Current.Request.Form["Quantity"].ToString());
                fuelVM.Rate = double.Parse(HttpContext.Current.Request.Form["Rate"].ToString());
                fuelVM.unit = HttpContext.Current.Request.Form["unit"].ToString();
                fuelVM.ReciptNo = HttpContext.Current.Request.Form["RecieptNo"].ToString();
                

                fuelVM.ReciptDate = HttpContext.Current.Request.Form["ReciptDate"].ToString();
                fuelVM.ReciptDate = fuelVM.ReciptDate.Substring(0, 19);
                log.Info(" \r\n Fill fuel : fuelVM.ReciptDate =" + fuelVM.ReciptDate);
                //fuelVM.ReciptDate = 2021-03-13
                //2021-03-13 16:43:22+08:00
                //2021-03-11 11:42:00
                DateTime recieptdate = new DateTime();
                try
                {
                    recieptdate = DateTime.ParseExact(fuelVM.ReciptDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                }catch(Exception s)
                {
                    log.Error("\r\n error:"+s.Message + "- "+ s.StackTrace);
                    return new { Success = false, ErrorCode = "500", Message = "time error" };

                }
                log.Info(" \r\n Fill fuel : recieptdate orginal =" + recieptdate);
                fuelVM.token = HttpContext.Current.Request.Form["token"].ToString();
                fuelVM.FuelProviderId = int.Parse(HttpContext.Current.Request.Form["Provider"].ToString());
                log.Info("posting feul receipt with FuelProviderId = " + fuelVM.FuelProviderId);
                string filePath = "";
                string filename = "";
                foreach (var file in fileProvider.Contents)
                {
                    if (file.Headers.ContentDisposition.FileName != null)
                    {
                        filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".jpg";
                        var buffer = await file.ReadAsByteArrayAsync();
                        File.WriteAllBytes(filePath = HostingEnvironment.MapPath("~/FuelReceipts/") + filename, buffer);
                    }
                }
                HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

                if (HttpContext.Current.Request.RequestType == "OPTIONS")
                    return Ok();
                string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
                dynamic claims;
                try
                {
                    IJsonSerializer serializer = new JsonNetSerializer();
                    IDateTimeProvider provider = new UtcDateTimeProvider();
                    IJwtValidator validator = new JwtValidator(serializer, provider);
                    IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                    IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                    var json = decoder.Decode(fuelVM.token, secret, verify: true);
                    claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                }
                catch (Exception)
                {
                    return new { Success = false, ErrorCode = "403" };
                }
                if (filename == "")
                {
                    return new { Success = false, ErrorCode = "400", Message = "File coudn't be empty" };
                }
                Driver Driver = db.Drivers.Find(claims.DriverId.Value);
                Route Route = db.Routes.Where(r => r.DriverId == Driver.DriverId && r.isActive == true).OrderByDescending(t => t.RouteId).FirstOrDefault();

                //get shift 
                // 03/11 02:20
                DateTime searchStartDate = recieptdate.AddHours(-12);  //03/10 14:20
                DateTime searchEndDate = recieptdate.AddHours(12); //03/11 16:20
                var shift = db.Shifts.Where(s => s.DriverId == Driver.DriverId && (s.StartShift >= searchStartDate && s.StartShift <= searchEndDate)).FirstOrDefault();
                log.Info(" \r\n Fill fuel : recieptdate=" + recieptdate);
                if (shift != null)
                {
                    log.Info(" \r\n Fill fuel : shitid=" + shift.ShiftId);
                }
                else
                {
                    log.Info(" \r\n Fill fuel : shitid=no shift found");
                }
                FuelRecipt fuelRecipt = new FuelRecipt()
                {
                    Amount = (float)fuelVM.Amount,
                    Qty = (float)fuelVM.Quantity,
                    Rate = (float)fuelVM.Rate,
                    VehicleId = Route.VehicleId,
                    DriverId = Driver.DriverId,
                    FuelProviderId = (int)fuelVM.FuelProviderId,
                    CreateDate = DateTime.Now,
                    ImgRecipt = filename,
                    unit = fuelVM.unit,
                    ReciptDate = recieptdate,
                    ShiftId = (shift != null) ? shift.ShiftId : -1,
                    RecieptNo = fuelVM.ReciptNo
                };

                fuelRecipt = db.FuelRecipt.Add(fuelRecipt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException != null)
                {
                    log.Error($"\r\n \r\n**********Error while posting Fuel Receipt:,\r\n \r\n message: { ex.Message },\r\n \r\nInner Message: {ex.InnerException.Message} , {ex.InnerException.ToString()} , {ex.InnerException.InnerException.Message} , \r\n \r\nstacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");

                }
                else
                {
                    log.Error($"\r\n \r\n**********Error while posting Fuel Receipte:,\r\n \r\n message: { ex.Message },\r\n \r\nInner Message:  , \r\n \r\nstacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");

                }
            }
            return new { Success = true };
        }

        [HttpGet]
        public Object PunchIn(int TripId, string token)
        {
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");



            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception)
            {
                return new { Success = false, ErrorCode = "403" };
            }

            Driver Driver = db.Drivers.Find(claims.DriverId.Value);
            TripSheetDaetails Trip = db.TripSheetDaetails.Where(tr => tr.TripSheetDaetailsId == TripId).FirstOrDefault();
            Trip.Timein = DateTime.Now.ToString();
            bool unsignedSkips = db.TripSheetDeatails_skips.Where(sk => sk.Status == TripStatus_skip.Complete && (sk.SignateImg == null || sk.SignateImg == "")).Count() > 0;
            db.Entry(Trip).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return new { Success = true, UnsignedSkips = unsignedSkips };
        }

        [AcceptVerbs("GET")]
        public Object GetUnsignedTrips(string token)
        {
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception)
            {
                return new { Success = false, ErrorCode = "403" };
            }

            Driver Driver = db.Drivers.Find(claims.DriverId.Value);
            Route route = db.Routes.Include(r=>r.Contracts).Where(r => r.isActive == true && r.DriverId == Driver.DriverId).FirstOrDefault();
            //var Trips = db.TripSheetDaetails.Where(tr => tr.DriverId == Driver.DriverId && tr.TripSheetDeatails_skips.Where(sk => sk.Status == TripStatus_skip.unsign


            //var Trips = db.TripSheetDaetails.Include(t=>t.Contracts).Include(t=>t.TripSheetDeatails_skips).Where(tr =>( tr.Contracts.RouteId == route.RouteId) 
            //&& tr.TripSheetDeatails_skips.Where(sk => sk.Status == TripStatus_skip.unsign
            //||  string.IsNullOrEmpty(sk.SignateImg)  ).ToList().Count > 0).ToList();

            var Trips = db.TripSheetDeatails_skips.Include(ts=>ts.TripSheetDaetails).Where(
                sk => (sk.Status == TripStatus_skip.unsign || string.IsNullOrEmpty(sk.SignateImg))
                && ( sk.TripSheetDaetails.Contracts.RouteId == route.RouteId)
                ).ToList();



            log.Info("Number of unsigned trips is  " + Trips.Count);

            var trips = Trips.Select(t => new
            {
                Id = t.TripSheetDaetailsId,
                Name = t.TripSheetDaetails.Contracts.Customer.CompanyName,
                Location = t.TripSheetDaetails.Contracts.SkipLocation,
                Size = t.TripSheetDaetails.Contracts.Products.Name,
                Telephone = t.TripSheetDaetails.Contracts.MobileNo,
                Service = t.TripSheetDaetails.ServiceTypes == null ? "" : t.TripSheetDaetails.ServiceTypes.Name,
                Date = t.TripSheetDaetails.TripsDate
            }).ToList();

            var list = JsonConvert.SerializeObject(new { Success = true, Trips = trips },
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });

            return new { Success = true, Trips = trips };
        }

        [AcceptVerbs("POST", "OPTIONS")]
        public Object SendEmails([FromBody] SendEmailVM sendEmailVM)
        {

            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
            if (HttpContext.Current.Request.RequestType == "OPTIONS")
                return Ok();
            int[] selectedStatuses = sendEmailVM.selectedStatuses;
            int tripId = sendEmailVM.tripId;
            try
            {
                foreach (int statusId in selectedStatuses) {
                    int result = 0;
                    TripStatus_skip status = (TripStatus_skip)statusId;
                    TripSheetDaetails trip = db.TripSheetDaetails.Find(tripId);
                    List<TripStatus_skip?> statusesList = trip.TripSheetDeatails_skips.Select(sk => sk.Status).ToList();
                    switch (status)
                    {
                        case TripStatus_skip.Complete:
                            result = emailHelper.SendEmailCompleteOnTime(trip);
                            if (result == 0)
                            {
                                log.Error("Email wasn't sent");
                            }
                            else
                            {
                                log.Info("Complete Email Sent to " + tripId);
                            }
                            break;

                        case TripStatus_skip.visit_free:
                            result = emailHelper.SendEmailVisitOnTime(trip);
                            if (result == 0)
                            {
                                log.Error("Email wasn't sent");
                            }
                            else
                            {
                                log.Info("Visit Email Sent to " + tripId);
                            }
                            break;

                        case TripStatus_skip.drop:
                            result = emailHelper.SendEmailDropOnTime(db.TripSheetDaetails.Find(tripId));
                            if (result == 0)
                            {
                                log.Error("Email wasn't sent");
                            }
                            else
                            {
                                log.Info("Drop Email Sent to " + tripId);
                            }
                            break;

                        case TripStatus_skip.unsign:
                            result = emailHelper.SendEmailUnsignedOnTime(trip);
                            if (result == 0)
                            {
                                log.Error("Email wasn't sent");
                            }
                            else
                            {
                                log.Info("Unsigned Email Sent to " + tripId);
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception while trying to send an email, Message: " + ex.Message + ", stacktrace: " + ex.StackTrace);
                return new { Success = false };
            }

            return new { Success = true };
        }

        [AcceptVerbs("POST")]
        public async Task<Object> PostSkip()
        {
            try
            {
                log.Info("Trying to post skip for trip with Id: " + HttpContext.Current.Request.Form["TripId"].ToString());
                HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
                string token = HttpContext.Current.Request.Form["token"].ToString();
                var fileProvider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(fileProvider);
                string filePath = "";
                string filename = "";



                // Edits on 20/02/2021
                string signatureImage = "";
                string reasonImage = "";
                foreach (var file in fileProvider.Contents)
                {
                    if (file.Headers.ContentDisposition.FileName != null)
                    {
                        filename = Guid.NewGuid().ToString() + ".jpg";
                        log.Info("--- \r\n File uploaded : " + filename+" \r\n");
                        log.Info("--- \r\n File Headers : " + file.Headers.ContentDisposition.FileName + " \r\n");
                        if (file.Headers.ContentDisposition.FileName.Contains("signature"))
                        {
                            signatureImage = filename;
                        }
                        else
                        {
                            reasonImage = filename;
                        }
                        var buffer = await file.ReadAsByteArrayAsync();
                        File.WriteAllBytes(filePath = HostingEnvironment.MapPath("~/SkipsImages/") + filename, buffer);
                    }
                }
                // End of edits



                string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
                dynamic claims;
                try
                {
                    IJsonSerializer serializer = new JsonNetSerializer();
                    IDateTimeProvider provider = new UtcDateTimeProvider();
                    IJwtValidator validator = new JwtValidator(serializer, provider);
                    IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                    IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                    var json = decoder.Decode(token, secret, verify: true);
                    claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                }
                catch (Exception)
                {
                    return new { Success = false, ErrorCode = "403" };
                }
                Driver Driver = db.Drivers.Find(claims.DriverId.Value);
                //Route route = db.Routes.Where(r => r.isActive && r.DriverId == Driver.DriverId).LastOrDefault();

                TripSheetDeatails_skip Skip = new TripSheetDeatails_skip();
                Skip.DoNum = HttpContext.Current.Request.Form["DO"].ToString();
                if(!string.IsNullOrEmpty(Skip.DoNum))
                {
                    Skip.DoNum = Skip.DoNum.Trim();
                }
                Skip.SkipSerialNumber = HttpContext.Current.Request.Form["Serial"].ToString();
                Skip.SkipSerialNumber2 = HttpContext.Current.Request.Form["Serial2"].ToString();
                Skip.WasteTypex = HttpContext.Current.Request.Form["WasteType"].ToString();
                Skip.Status = (TripStatus_skip)int.Parse(HttpContext.Current.Request.Form["Status"].ToString());
                Skip.Reason = HttpContext.Current.Request.Form["Reason"].ToString();
                Skip.UserId = Driver.Name;
               
                Boolean isCopy = Boolean.Parse(HttpContext.Current.Request.Form["IsCopy"]);


                // Edits on 20/02/2021
                if (Skip.Status != TripStatus_skip.unsign)
                {
                    if (signatureImage != "")
                    {
                        Skip.SignateImg = signatureImage;
                        Skip.SignMobile = HttpContext.Current.Request.Form["SignMobile"].ToString();
                        Skip.SignTel = HttpContext.Current.Request.Form["SignTel"].ToString();
                        Skip.SignName = HttpContext.Current.Request.Form["SignName"].ToString();
                    }
                }
                //if (Skip.Status != TripStatus_skip.Complete)
                {
                    Skip.ReasonImg = reasonImage;
                }
                //End of edits

                //if (Skip.Status == TripStatus_skip.Complete)
                //{
                //    if (filePath != "")
                //    {
                //        Skip.SignateImg = filename;
                //        Skip.SignMobile = HttpContext.Current.Request.Form["SignMobile"].ToString();
                //        Skip.SignTel = HttpContext.Current.Request.Form["SignTel"].ToString();
                //        Skip.SignName = HttpContext.Current.Request.Form["SignName"].ToString();
                //    }
                //}
                //else
                //{
                //    Skip.ReasonImg = filename;
                //}




                float weight = 0;


                try
                {
                    string ssss = HttpContext.Current.Request.Form["Weight"].ToString();
                    log.Info("\r\n \r\n weight: " + ssss+"\r\n");
                    if (!string.IsNullOrEmpty(ssss))
                    {

                        weight = float.Parse(ssss);
                        if(float.IsNaN(weight))
                        {
                            weight = 0;
                        }

                    }
                }
                catch(Exception fkldjfk)
                {
                    weight = 0;
                }
                
                Skip.Weight = weight;
                Skip.Remarks = HttpContext.Current.Request.Form["Remarks"].ToString();
                Skip.TripSheetDaetailsId = int.Parse(HttpContext.Current.Request.Form["TripId"].ToString());
                Skip.ProductId = db.TripSheetDaetails.Find(Skip.TripSheetDaetailsId).ProductId;

                Skip.Timeout = DateTime.Now.ToString();
                Skip = db.TripSheetDeatails_skips.Add(Skip);

                Skip.Timein = Skip.TripSheetDaetails.Timein;

                log.Info("trying save skip with information : \r\n"  + Skip.DoNum + "," +Skip.SkipSerialNumber + "," +Skip.SkipSerialNumber2 + "," + Skip.WasteTypex + "," + Skip.Status + "," + Skip.Reason + "," + Skip.UserId + "," + Skip.Weight + "," 
                    + Skip.Remarks + "," + Skip.TripSheetDaetailsId + "," + Skip.ProductId + "," + Skip.Timeout + "," + Skip.Timein+","+ Skip.ReasonImg + "," + Skip.SignateImg);
                //skip saved
                db.TripSheetDeatails_skips.Add(Skip);
                db.SaveChanges();

                log.Info("Saved skip is: " + Skip);
                //if (isCopy)
                //{
                //    Skip.TripSheetDaetails.NumberOfSkips++;
                //}

                // update parent



                //if (Skip.TripSheetDaetails.NumberOfSkipscollected == null)
                //{
                //    Skip.TripSheetDaetails.NumberOfSkipscollected = 1;
                //}
                //else
                //{
                //    Skip.TripSheetDaetails.NumberOfSkipscollected++;
                //}

                TripSheetDaetails tripParent = db.TripSheetDaetails.Find(Skip.TripSheetDaetailsId);
                tripParent.NumberOfSkipscollected = tripParent.TripSheetDeatails_skips.Count();
                tripParent.Timeout = DateTime.Now.ToString();


                db.Entry(Skip.TripSheetDaetails).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                //if (Skip.TripSheetDaetails.NumberOfSkipscollected == Skip.TripSheetDaetails.NumberOfSkips)
                //{
                //    Skip.TripSheetDaetails.Status = TripStatus.complete;
                //    if (Skip.TripSheetDaetails.CallBasedId != null)
                //    {
                //        try
                //        {
                //            CallBased cB = db.CallBaseds.Find(Skip.TripSheetDaetails.CallBasedId);
                //            cB.Status = CallStatus.completed;
                //            db.Entry(cB).State = System.Data.Entity.EntityState.Modified;
                //        }
                //        catch (Exception ex)
                //        {
                //            return new { Success = true };
                //        }
                //    }
                //}


                //update call
                if (Skip.TripSheetDaetails.CallBasedId != null)
                {
                    CallBased cb = db.CallBaseds.Find(Skip.TripSheetDaetails.CallBasedId);
                    int total = cb.NumOfSkips;
                    // get all trips of call
                    List<TripSheetDaetails> tsd = cb.TripSheetDaetails.ToList();
                    int allocated = 0;
                    foreach (var ttt in tsd)
                    {
                        allocated += ttt.NumberOfSkipscollected ?? 0;
                    }
                    if (total <= allocated)
                    {
                        cb.Status = CallStatus.completed;
                    }

                }




                //db.Entry(Skip).State = EntityState.Modified;
                db.SaveChanges();
                try
                {
                    PunchOutUpdateAll(Skip);
                }
                catch (Exception ex)
                {
                    

                    if(ex.InnerException != null)
                    {
                        log.Error($"\r\n \r\n**********Error while post processing skip with trip id: { Skip.TripSheetDaetailsId },\r\n \r\n message: { ex.Message },\r\n \r\nInner Message: {ex.InnerException.Message} , \r\n \r\nstacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");
                    }else
                    {
                        log.Error($"\r\n \r\n**********Error while post processing skip with trip id: { Skip.TripSheetDaetailsId },\r\n \r\n message: { ex.Message }, \r\n \r\nstacktrace: { ex.StackTrace }, \r\n \r\nfull exception:  { ex.ToString() }");
                    }
                    return new { Success = false };
                }
                log.Info($"Successfully saved skip for trip: { Skip.TripSheetDaetailsId }");
                return new { Success = true };
            }

            catch (Exception ex)
            {
                //log.Error($"Error while posting skip message: { ex.Message }, stacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");

                if (ex.InnerException != null)
                {
                    if (ex.InnerException.InnerException != null)
                    {
                        log.Error($"\r\n \r\n**********Error while posting skip message:,\r\n \r\n message: { ex.Message },\r\n \r\nInner Message: {ex.InnerException.Message} , {ex.InnerException.ToString()} , {ex.InnerException.InnerException.Message} , \r\n \r\nstacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");

                    }
                    else
                    {
                        log.Error($"\r\n \r\n**********Error while posting skip message:,\r\n \r\n message: { ex.Message },\r\n \r\nInner Message: {ex.InnerException.Message} , \r\n \r\nstacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");

                    }
                }
                else
                {
                    log.Error($"\r\n \r\n**********Error while posting skip message:,\r\n \r\n message: { ex.Message }, \r\n \r\nstacktrace: { ex.StackTrace }, \r\n \r\nfull exception:  { ex.ToString() }");
                }
                return new { Success = false };
            }
        }

        [AcceptVerbs("GET")]
        public object GetSerialNumbers(string token, int tripId)
        {

            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

            TripSheetDaetails trip = db.TripSheetDaetails.Where(tr => tr.TripSheetDaetailsId == tripId).FirstOrDefault();
            if (trip == null)
            {
                return new { Success = true, ErrorCode = "403" };
            }
            var usedSerials = trip.TripSheetDeatails_skips.Select(skip => skip.SkipSerialNumber);
            var serials = trip.Contracts.ContractSkips.Where(ser => !usedSerials.Contains(ser.SkipSerialNumber)).Select(ser => new
            {
                ser.SkipSerialNumber
            }).ToList();
            List<string> serialsArray = new List<string>();
            foreach (var serial in serials)
            {
                serialsArray.Add(serial.SkipSerialNumber);
            }
            return new { Success = true, SerialNumbers = serialsArray };
        }


        [AcceptVerbs("GET")]
        public object GetCustomerOfToken(string token)
        {

            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception)
            {
                return new { Success = false, ErrorCode = "403" };
            }
            log.Info(" \r\n \r\n Enter GetCustomerOfToken"+ claims.DriverId.Value + " token:"+ token);



            Driver Driver = db.Drivers.Find(claims.DriverId.Value);
            var DriverRoute = db.Routes.Where(r => r.DriverId == Driver.DriverId&& r.isActive == true).FirstOrDefault();

            var Contract = db.Contracts.Include(c=>c.Route).Include(c=>c.Products).Include(c => c.Schedule1).Include(c => c.DoSheets)
                .Include(c=>c.ContractServiceStatus).Include(c=>c.OwnerShipOfSkips).Where(tr => tr.RouteId == DriverRoute.RouteId)
                .Include(c=>c.WasteTypes).Include(c=>c.SkipTypes).Include(c => c.SkipTypes1).Include(c=>c.Customer); ;

            string[] statuses = { "Cancelled", "RENEWED", "REVISED", "Terminated" };
            Contract = Contract.Where(c => !statuses.Contains(c.ContractStatuses.Name)  );

            if (Contract == null)
            {
                return new { Success = true, ErrorCode = "403" };
            }
            var Contracts = Contract.Select(c => new
            {
                RouteNumber = c.Route.Name,
                Custommer = c.Customer.CompanyName,
                TallyCode = c.TallyCode,
                ContractCode = c.Code,
                SkipLocations = c.SkipLocation,
                SkipSize = c.Products.Name,
                NoOfSkips = c.NoOfSkips,
                SkipOnsSite = c.SkipOnSite,
                DONumber = c.DoSheets.Where(d=>d.StartDate < DateTime.Now && d.EndDate> DateTime.Now).FirstOrDefault() == null ? "" : c.DoSheets.Where(d => d.EndDate > DateTime.Now).FirstOrDefault().DoNum.ToString(),
                Schedule = c.Schedule1.Text ,
               // Driver = c.Route.Driver.Name,
                ServiceStatus = c.ContractServiceStatus.Name,
                Restricted = c.RestrictSch ? "yes" : "No",
                OwnershipOfSkips = c.OwnerShipOfSkips.Name,
                SkipType1 = c.SkipTypes.Name,
                SkipType2 = c.SkipTypes1.Name,
                WasteType = c.WasteTypes.Name

            }).ToList();

            return new { Success = true, Customers = Contracts.ToList() };
        }


        [AcceptVerbs("GET")]
        public object GetSerialNumbersArray(string token, string tripId)
        {
            int[] tripIdArray = Array.ConvertAll(tripId.Split(','), int.Parse);
            log.Info(" getPendingSignatureSkipsByTrip with array");

            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

            TripSheetDaetails trip = db.TripSheetDaetails.Where(tr => tripIdArray.Contains( tr.TripSheetDaetailsId)).FirstOrDefault();
            if (trip == null)
            {
                return new { Success = true, ErrorCode = "403" };
            }
            var usedSerials = trip.TripSheetDeatails_skips.Select(skip => skip.SkipSerialNumber);
            var serials = trip.Contracts.ContractSkips.Where(ser => !usedSerials.Contains(ser.SkipSerialNumber)).Select(ser => new
            {
                ser.SkipSerialNumber
            }).ToList();
            List<string> serialsArray = new List<string>();
            foreach (var serial in serials)
            {
                serialsArray.Add(serial.SkipSerialNumber);
            }
            return new { Success = true, SerialNumbers = serialsArray };
        }

        [AcceptVerbs("POST")]
        public async Task<Object> SignSkip()
        {

            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
            string token = HttpContext.Current.Request.Form["token"].ToString();
            var fileProvider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(fileProvider);
            string filePath = "";
            string filename = "";
            foreach (var file in fileProvider.Contents)
            {
                if (file.Headers.ContentDisposition.FileName != null)
                {
                    filename = HttpContext.Current.Request.Form["Id"].ToString() + "-Signature.jpg";
                    var buffer = await file.ReadAsByteArrayAsync();
                    File.WriteAllBytes(filePath = HostingEnvironment.MapPath("~/SkipsImages/") + filename, buffer);
                }
            }
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();

                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception)
            {
                return new { Success = false, ErrorCode = "403" };
            }
            string skipId = HttpContext.Current.Request.Form["Id"].ToString();
            string SignMobile = HttpContext.Current.Request.Form["SignMobile"].ToString();
            string SignTel = HttpContext.Current.Request.Form["SignTel"].ToString();
            string SignName = HttpContext.Current.Request.Form["SignName"].ToString();
            TripSheetDeatails_skip Skip = db.TripSheetDeatails_skips.Where(sk => sk.TripSheetDeatails_skipId.ToString() == skipId ).FirstOrDefault();
            if (Skip == null)
            {
                return new { Success = false };
            }

            if (filePath != "")
            {
                if (Skip.Status == TripStatus_skip.unsign)
                {
                    Skip.Status = TripStatus_skip.Complete;
                }
                Skip.SignMobile = SignMobile;
                Skip.SignTel = SignTel;
                Skip.SignName = SignName;
                Skip.SignateImg = filename;
            }
            db.Entry(Skip).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return new { Success = true };
        }


        [AcceptVerbs("GET")]
        public object RefreshTripSheet(string token)
        {
            try
            {
                HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

                string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
                dynamic claims;
                try
                {
                    IJsonSerializer serializer = new JsonNetSerializer();
                    IDateTimeProvider provider = new UtcDateTimeProvider();
                    IJwtValidator validator = new JwtValidator(serializer, provider);
                    IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                    IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                    var json = decoder.Decode(token, secret, verify: true);
                    claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                }

                catch (Exception)
                {
                    return new { Success = false, ErrorCode = "403" };
                }
                log.Info("claims.DriverId.Value " + claims.DriverId.Value);
                Driver Driver = db.Drivers.Find(claims.DriverId.Value);
                log.Info("Driver.DriverId " + Driver.DriverId);
                var DriverRoute = db.Routes.Where(r => r.DriverId == Driver.DriverId && r.isActive == true).Select(r => new
                {
                    Helpers = r.Helper.Select(h => new
                    {
                        Id = h.HelperId,
                        Name = h.Name
                    }),
                    Vehicle = new
                    {
                        Id = r.VehicleId,
                        Name = r.Vehicle == null ? "" : r.Vehicle.PlateNo
                    }
                }).AsEnumerable().Select(r => new
                {
                    Helpers = r.Helpers,
                    Vehicle = r.Vehicle,
                    Id = Driver.DriverId,
                    Name = Driver.Name,
                }).FirstOrDefault();
                // var lastShift = db.Shifts.OrderBy(shift => shift.EndShift).LastOrDefault(shift => shift.TripSheet.Vehicle.VehicleId == DriverRoute.Vehicle.Id);
                dynamic DriverRouteNew;

                DriverRouteNew = new
                {
                    Helpers = DriverRoute.Helpers,
                    Vehicle = DriverRoute.Vehicle,
                    Id = DriverRoute.Id,
                    Name = DriverRoute.Name,
                    StartKM = 0
                };

                return new { Success = true, ErrorCode = "", User = DriverRouteNew };
            }catch(Exception ex)
            {
                log.Error($"\r\n \r\n RefreshTripSheet:    \r\n :Exception message: { ex.Message }, stacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");
                return new { Success = true, ErrorCode = "ex.Message"};
            }
        }

        [HttpGet]
        public object CheckShiftStatus(string token)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception)
            {
                return new { Success = false, ErrorCode = "403" };
            }
            Driver Driver = db.Drivers.Find(claims.DriverId.Value);
            Route Route = db.Routes.Where(r => r.DriverId == Driver.DriverId && r.isActive ==true).OrderByDescending(t => t.RouteId).FirstOrDefault();
            if (false)
            {
                return new { Success = false, ErrorCode = "400", Message = "No trip for this driver." };
            }
            else
            {
                Shift DriverShift = db.Shifts.Where(s => s.DriverId == Driver.DriverId && s.EndShift == null).OrderByDescending(t => t.ShiftId).FirstOrDefault();
                if (DriverShift == null)
                {
                    return new { Success = true, Status = true };
                }
                else
                {
                    return new { Success = true, Status = false };
                }
            }

        }

        [HttpGet]
        public object Dumb(string token, int DumbLocationId, float? weight, string timein ,string timeout)
        {
            
            try
            {
                string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
                dynamic claims;
                try
                {
                    IJsonSerializer serializer = new JsonNetSerializer();
                    IDateTimeProvider provider = new UtcDateTimeProvider();
                    IJwtValidator validator = new JwtValidator(serializer, provider);
                    IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                    IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                    var json = decoder.Decode(token, secret, verify: true);
                    claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                }
                catch (Exception)
                {
                    return new { Success = false, ErrorCode = "403" };
                }
                HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

                Driver Driver = db.Drivers.Find(claims.DriverId.Value);
                var shift = db.Shifts.Where(sh => sh.DriverId == Driver.DriverId && sh.EndShift == null).ToList().OrderBy(sh=>sh.ShiftId).LastOrDefault();
                var dumpLocation = db.DumpLocations.FirstOrDefault(location => location.DumpLocationId == DumbLocationId);
                log.Info($"\r\n \r\n SaveDump for shift :{shift.ShiftId} , driver: {Driver.Name}, { Driver.DriverId} weight: {weight} , timein :{timein}  \r\n :");
                //create dump 
                Dumb dump = new Dumb();
                dump.ShiftId = shift.ShiftId;
                dump.DumpLocationId = dumpLocation.DumpLocationId;
                dump.TimeIn = timein;
                dump.TimeOut = timeout;
                dump.LandFillWeight = weight;
                dump.DumpDate = DateTime.Now;
                db.Dumbs.Add(dump);

                db.SaveChanges();

                //List<TripSheetDaetails> tripDetails = db.TripSheetDaetails.Where(td => td.DriverId == Driver.DriverId && td.TripsDate.Year == shift.StartShift.Year &&
                //                                    td.TripsDate.Month == shift.StartShift.Month && td.TripsDate.Day == shift.StartShift.Day 
                                                   
                //                                    && (td.NumberOfSkips > td.NumberOfSkipscollected || td.NumberOfSkipscollected == null)).ToList();

                if (dumpLocation == null)
                {
                    return new { Success = false, ErrorCode = "400" };
                }

                DateTime now = DateTime.Now;
                DateTime last2days = now.AddDays(-2);
                //avoid bring all data 
                var skipsToDumb = db.TripSheetDeatails_skips.Where(sk => (sk.DumbId == null && sk.DumpLocationId == null)
                && sk.TripSheetDaetails.DriverId == Driver.DriverId  && sk.TripSheetDaetails.TripsDate> last2days).ToList();
                
                
                /*&& (td.NumberOfSkips > td.NumberOfSkipscollected || td.NumberOfSkipscollected == null)).Contains(sk.TripSheetDaetails));*/
                foreach (TripSheetDeatails_skip trip in skipsToDumb)
                {
                    trip.DumpLocationId = dumpLocation.DumpLocationId;
                    trip.DumbId = dump.DumbId;
                    db.Entry(trip).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    //string st = JsonConvert.SerializeObject(dump);
                    //log.Info($"\r\n \r\n SaveDump for shift: {shift.ShiftId} , Dump :{st}  \r\n :");
                    db.SaveChanges();
                    return new { Success = true };
                }
                catch (Exception ex)
                {
                    //string st = JsonConvert.SerializeObject(dump);
                    log.Error($"\r\n \r\n SaveDump for shift: {shift.ShiftId} , Dump :  \r\n :Exception message: { ex.Message }, stacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");
                }
                return new { Success = false };
            }
            catch (Exception ex)
            {
                
                log.Error($"\r\n \r\n SaveDump for shift: {DumbLocationId}  \r\n :Exception message: { ex.Message }, stacktrace: { ex.StackTrace }, full exception:  { ex.ToString() }");
            }
            return new { Success = false };
        }

        [HttpGet]
        public object GetDumbLocations(string token)
        {

            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

            var DumbLocations = db.DumpLocations.Select(dl => new
            {
                Id = dl.DumpLocationId,
                dl.Name
            }).ToList();

            return new { Success = true, DumbLocation = DumbLocations };
        }

        [HttpGet]
        public object GetServiceTypes(string token)
        {

            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

            var ServiceTypes = db.ServiceTypes.Select(dl => new
            {
                Id = dl.ServiceTypeId,
                dl.Name
            }).ToList();

            return new { Success = true, ServiceTypes = ServiceTypes };
        }

        [HttpGet]
        public object GetFuelProvider(string token)
        {

            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

            var FuelProviders = db.FuelProviders.Select(dl => new
            {
                Id = dl.FuelProviderId,
                Name = dl.Name
            }).ToList();
            log.Info("fuel:"+FuelProviders.Count() + ","+ FuelProviders[0].Name);
            return new { Success = true, FuelProviders = FuelProviders };
        }

        [HttpGet]
        public object GetWasteTypes(string token)
        {

            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

            var WasteTypes = db.WasteTypes.Select(dl => new
            {
                Id = dl.WasteTypeId,
                dl.Name
            }).ToList();

            return new { Success = true, WasteTypes = WasteTypes };
        }

        [HttpGet]
        public object GetTotalAmountByTrip(string token, int TripId)
        {
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception)
            {
                return new { Success = false, ErrorCode = "403" };
            }
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

            Driver Driver = db.Drivers.Find(claims.DriverId.Value);
            TripSheetDaetails Trip = db.TripSheetDaetails.Where(t => t.TripSheetDaetailsId == TripId).FirstOrDefault();
            if (Trip == null)
            {
                return new { Success = false, ErrorCode = "400", Message = "Couldn't find trip." };
            }
            int totalAmount = 100;
            return new { Success = true, amount = totalAmount };
        }

        [HttpGet]
        public object PayCash(string token, int TripId, float Amount)
        {
            string secret = WebConfigurationManager.AppSettings.Get("jwtKey");
            dynamic claims;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                claims = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
            catch (Exception)
            {
                return new { Success = false, ErrorCode = "403" };
            }
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

            Driver Driver = db.Drivers.Find(claims.DriverId.Value);
            TripSheetDaetails Trip = db.TripSheetDaetails.Where(t => t.TripSheetDaetailsId == TripId).FirstOrDefault();
            if (Trip == null)
            {
                return new { Success = false, ErrorCode = "400", Message = "Couldn't find trip." };
            }
            CdcReceipt receipt = new CdcReceipt()
            {
                AmountCollected = Amount,
                ContractId = Trip.ContractId,
                DriverId = Driver.DriverId,
                ReceiptDate = DateTime.Now,
                ServiceCharges = 0
            };
            db.CdcReceipts.Add(receipt);
            db.SaveChanges();
            return new { Success = true };
        }


        public int totalLPo(int ContractId){
            return db.LPOs.Where(l => l.ContractId == ContractId && l.IsActive == true).Count();
        }

        public void PunchOutUpdateAll(TripSheetDeatails_skip t)
        {
            int ServiceTypeDeliveryId = db.ServiceTypes.Where(st => st.Name == "Delivery").FirstOrDefault().ServiceTypeId;
            int ServiceTypeGarbageCollectionId = db.ServiceTypes.Where(st => st.Name == "Garbage Collection").FirstOrDefault().ServiceTypeId;
            int ServiceTypePulloutId = db.ServiceTypes.Where(st => st.Name == "Pullout").FirstOrDefault().ServiceTypeId;
            int ServiceTypeLastServiceTripId = db.ServiceTypes.Where(st => st.Name == "Last Service Trip").FirstOrDefault().ServiceTypeId;

            TripSheetDeatails_skip TripDetails = new TripSheetDeatails_skip();
            TripSheetDaetails TripDetails_parent = new TripSheetDaetails();
            int i = 0;
            int ContractId = 0;

         
            if (t.Status.ToString() != "Reset" && t.Status != null)
            {
                i++;

                TripDetails_parent = db.TripSheetDaetails.Find(t.TripSheetDaetailsId);
                ContractId = TripDetails_parent.ContractId;
                log.Debug("Post processing for trip with contract id: " + ContractId.ToString());

                //14-12-2020
                //if (t.Status.ToString() != "Reset")
                //{
                //    TripDetails.Status = (TripStatus_skip)Enum.Parse(typeof(TripStatus_skip), t.Status.ToString(), true);
                //    db.SaveChanges();
                //}


                //update tripshitdetail total skip served
               // TripSheetDaetails tripSheetDaetails = t.TripSheetDaetails; /// هون عدلت

             

                //need get all tripsheetdetails of call 
                //sum all NumberOfSkipscollected skips 
                ///compare with call
                ///
                //if (TripDetails_parent.CallBasedId != null)
                //{
                //    CallBased cb = db.CallBaseds.Find(TripDetails_parent.CallBasedId);
                //    int total = cb.NumOfSkips;
                //    // get all trips of call
                //    List<TripSheetDaetails> tsd = cb.TripSheetDaetails.ToList();
                //    int allocated = 0;
                //    foreach (var ttt in tsd)
                //    {
                //        allocated += ttt.NumberOfSkipscollected ?? 0;
                //    }
                //    if (total <= allocated)
                //    {
                //        cb.Status = CallStatus.completed;
                //    }
                    
                //    //12/12/2020
                //    db.SaveChanges();

                //}



                // }


                //if there is lpo and it is qty-lpo or qty-priod-lpo need to reduce the qty and trip is collection

                //effect the skip
                Contract contract = db.Contracts.Find(ContractId);

                //get all lpo of contract
                int totalLPo1 = totalLPo(contract.ContractId);
                if (totalLPo1 > 0)
                {
                    if (TripDetails_parent.ServiceTypeId == 1 || TripDetails_parent.ServiceTypeId == 3)//if garbage collection or pullout
                    {
                        var a = contract.TallyCode;
                        if (t.Status == TripStatus_skip.Complete || t.Status == TripStatus_skip.visit_charge)
                        {
                            if (contract.LPOQtyBalance != null)
                            {
                                contract.LPOQtyBalance += 1;

                            }
                            else
                            {
                                contract.LPOQtyBalance = 1;
                            }

                            var lpo = contract.LPOs.Where(l => l.IsActive == true).FirstOrDefault();
                            if (lpo != null)
                            {
                                if (lpo.ServicedActualQty != null)
                                {
                                    lpo.ServicedActualQty += 1;

                                }
                                else
                                {
                                    lpo.ServicedActualQty = 1;
                                }


                            }
                            // contract. += t.NumberOfSkipscollected;
                        }

                        //Decision
                        //after perform the trip  if reach lpo qty Suspend service 
                        if (contract.LPOQtyBalance == contract.LPOQty)
                        {

                            contract.UserServiceLastStatus = TripDetails_parent.Driver.Name + " _ lpo complete";
                            contract.StatusServiceReason = " lpo complete totalLPo="+ totalLPo1.ToString();
                            contract.ServiceLastStatusDate = DateTime.Now;
                            contract.ContractServiceStatusId = 2;//suspended

                            log.Debug("Change servicestatus to suspended contract id: " + ContractId.ToString());
                        }
                    }
                    db.SaveChanges();
                }







                //if carbage collection and chain truck (two serial)
                if (TripDetails.SkipSerialNumber2 != null)
                {
                    //link contract with skip serial number 
                    ContractSkip ContractSkip = new ContractSkip();
                    ContractSkip.ContractId = TripDetails_parent.ContractId;
                    ContractSkip.SkipSerialNumber = TripDetails.SkipSerialNumber2;
                    ContractSkip.SkipSize = TripDetails_parent.Products.Name;
                    ContractSkip.ProductId = TripDetails_parent.ProductId;

                    db.ContractSkips.Add(ContractSkip);


                    //remove first one 
                    ContractSkip ContractSkipRemove = db.ContractSkips.Where(cs => cs.SkipSerialNumber == TripDetails.SkipSerialNumber).FirstOrDefault();
                    if (ContractSkipRemove != null)
                    {
                        db.ContractSkips.Remove(ContractSkipRemove);
                    }
                    db.SaveChanges();
                }



                //Decision 
                // i should know first trip frelated to contract 
                //   int sid = t.CallBased.ServiceTypeId ?? 1;
                //if (TripDetails.ServiceTypeId == ServiceTypeGarbageCollectionId)
                //{
                //    //عندما ننفذ اول رحلة  نبدأ الخدمة 
                //    //if (CheckDeliverAllSkipOfContract(t.Contracts))
                //    int n = t.CallBased.TripSheetDaetails.Where(td => td.Status.ToString() == "complete").Count();

                //    if (n <= t.Contracts.NoOfSkips) {
                //        t.Contracts.ContractServiceStatusId = 1;// active the service for contrasct
                //    }

                //}

                //Decision
                //if contract is on hold and trip is confirmed 
                if (TripDetails_parent.Contracts.ContractStatusId == 4 && t.Status != TripStatus_skip.drop)
                {
                    TripDetails_parent.Contracts.ContractStatusId = 3;
                    TripDetails_parent.Contracts.UserLastStatus = TripDetails_parent.Driver.Name + " _  it was on hold and make service";
                    TripDetails_parent.Contracts.LastStatusDate = DateTime.Now;


                    log.Debug("Change status to active contract id: " + ContractId.ToString());
                }


                //when is SRF and ownership is client
                if (TripDetails_parent.CallBasedId != null && TripDetails_parent.CallBased.isSRF == true)
                {
                    if (TripDetails_parent.Contracts.OwnerShipOfSkipId == 1)
                    {
                        contract.UserServiceLastStatus = TripDetails_parent.Driver.Name +"_ SRF Complete";
                        contract.ServiceLastStatusDate = DateTime.Now;
                        TripDetails_parent.Contracts.ContractServiceStatusId = 1;// ON SITE

                        log.Debug("Change servicestatus to active _ SRF Complete contract id: " + ContractId.ToString());

                    }
                }

                //Decision
                //when delTripDetailsiver skips
                //اذا كان في تسليم حاويات
                if (TripDetails_parent.ServiceTypeId == ServiceTypeDeliveryId && t.Status != TripStatus_skip.drop)
                {

                    //if (CheckDeliverAllSkipOfContract(t.Contracts))
                    TripDetails_parent.Contracts.UserServiceLastStatus = TripDetails_parent.Driver.Name + " _  delever skips";
                    TripDetails_parent.Contracts.ServiceLastStatusDate = DateTime.Now;
                    TripDetails_parent.Contracts.ContractServiceStatusId = 1;// active the service for contrasct

                    //link contract with skip serial number 
                    //ContractSkip ContractSkip = new ContractSkip();
                    //ContractSkip.ContractId = TripDetails_parent.ContractId;
                    //ContractSkip.SkipSerialNumber = TripDetails.SkipSerialNumber2;
                    //ContractSkip.SkipSize = TripDetails_parent.Products.Name;
                    //ContractSkip.ProductId = TripDetails_parent.ProductId;

                    //db.ContractSkips.Add(ContractSkip);

                    //update number of skips on site,,q1`'l
                    contract = db.Contracts.Find(TripDetails_parent.ContractId);

                    //i add it when srf placed
                    //contract.SkipOnSite++;

                    db.SaveChanges();

                }


                //Decision
                //when Last Service Trip
                //cancel the service and contract
                if (TripDetails_parent.ServiceTypeId == 9 && t.Status != TripStatus_skip.drop)//Last Service Trip
                {
                    if (TripDetails_parent.Contracts.OwnerShipOfSkipId == 1) //client
                    {
                        TripDetails_parent.Contracts.ContractServiceStatusId = 4;// CANCELLED
                        TripDetails_parent.Contracts.ContractStatusId = 5;// CANCELLED

                        // TripDetails_parent.Contracts.UserLastStatus = User.Identity.GetUserId();
                        TripDetails_parent.Contracts.UserLastStatus = TripDetails_parent.Driver.Name + " _ last service trip";
                        TripDetails_parent.Contracts.LastStatusDate = DateTime.Now;

                        TripDetails_parent.Contracts.UserServiceLastStatus = TripDetails_parent.Driver.Name + " _ last service trip";
                        TripDetails_parent.Contracts.ServiceLastStatusDate = DateTime.Now;
                        log.Debug("Change servicestatus to CANCELLED _  Last Service Trip contract id: " + ContractId.ToString());

                    }
                    else
                    {
                        TripDetails_parent.Contracts.UserServiceLastStatus = TripDetails_parent.Driver.Name + " _ last service trip";
                        TripDetails_parent.Contracts.ServiceLastStatusDate = DateTime.Now;
                        TripDetails_parent.Contracts.ContractServiceStatusId = 3;//Terminated- Not Pulled Out

                        log.Debug("Change servicestatus to Terminated- Not Pulled Out Last Service Trip contract id: " + ContractId.ToString());
                    }
                }

                //Decision
                //when pullout skips
                //اذا كان في سحب حاويات
                if (TripDetails_parent.ServiceTypeId == ServiceTypePulloutId && t.Status != TripStatus_skip.drop)
                {

                    var contract1 = db.Contracts.Find(TripDetails_parent.ContractId);
                    // int a = contract1.SkipOnSite-1;

                    bool a = CheckPullOutAllSkipOfContract(TripDetails_parent.Contracts);



                    if (a == true)
                    {

                        TripDetails_parent.Contracts.ContractServiceStatusId = 4;//Service CANCELLED
                        TripDetails_parent.Contracts.UserServiceLastStatus = TripDetails_parent.Driver.Name + " _ pull out allskip";
                        TripDetails_parent.Contracts.ServiceLastStatusDate = DateTime.Now;

                        log.Debug("Change servicestatus to CANCELLED-  Pulled Out Last Service Trip contract id: " + ContractId.ToString());
                        if (TripDetails_parent.Contracts.ContractStatusId != 7)
                        {
                            TripDetails_parent.Contracts.ContractStatusId = 5;//Contract CANCELLED
                                                                              // TripDetails_parent.Contracts.UserLastStatus = User.Identity.GetUserId();

                            TripDetails_parent.Contracts.UserLastStatus = TripDetails_parent.Driver.Name + " _ pull out all skip";
                            TripDetails_parent.Contracts.LastStatusDate = DateTime.Now;


                            log.Debug("Change status to CANCELLED-  Pulled Out Last Service Trip contract id: " + ContractId.ToString());
                        }
                        db.SaveChanges();
                    }

                    //remove the link between the skips and the contract 
                    if (t.SkipSerialNumber != "" || t.SkipSerialNumber != null)
                    {
                        //get the serial number of skip 
                        // removed 
                        try
                        {
                            ContractSkip cskip = db.ContractSkips.Where(c => c.SkipSerialNumber == t.SkipSerialNumber).FirstOrDefault();
                            db.ContractSkips.Remove(cskip);

                        }
                        catch (Exception e) { }
                    }

                    //reduce number of skip on site
                    //var c = db.Contracts.Find(ContractId);
                    // c.SkipOnSite -= 1;


                    //update number of skips on site
                    contract = db.Contracts.Find(TripDetails_parent.ContractId);
                    contract.SkipOnSite--;
                    db.SaveChanges();



                }

                //Decision
                //when deliver skips Last Service Trip
                //اذا كانت اخر رحلة
                if (TripDetails_parent.ServiceTypeId == ServiceTypeLastServiceTripId)
                {
                    if (CheckLastServiceAllSkipOfContract(TripDetails_parent.Contracts))
                    {
                        if (TripDetails_parent.Contracts.OwnerShipOfSkipId == 1) //client
                        {
                            TripDetails_parent.Contracts.ContractServiceStatusId = 4;// CANCELLED
                            TripDetails_parent.Contracts.UserServiceLastStatus = TripDetails_parent.Driver.Name + " _ last service trip";
                            TripDetails_parent.Contracts.ServiceLastStatusDate = DateTime.Now;
                        }
                        else // mr.skip  skip
                        {
                            TripDetails_parent.Contracts.UserServiceLastStatus = TripDetails_parent.Driver.Name + " _ last service trip";
                            TripDetails_parent.Contracts.ServiceLastStatusDate = DateTime.Now;
                            TripDetails_parent.Contracts.ContractServiceStatusId = 3;//CANCELLED- Not Pulled Out
                        }
                    }
                }

                //Decision
                //when terminate service
                //اذا كانت انهاء خدمة
                if (TripDetails_parent.ServiceTypeId == 39)
                {
                    //if (CheckLastServiceAllSkipOfContract(TripDetails_parent.Contracts))
                    //{

                    TripDetails_parent.Contracts.ContractServiceStatusId = 4;// CANCELLED
                    TripDetails_parent.Contracts.ContractStatusId = 5;// CANCELLED

                    //TripDetails_parent.Contracts.UserLastStatus = User.Identity.GetUserId();
                    TripDetails_parent.Contracts.UserLastStatus = TripDetails_parent.Driver.Name + " _ terminate service"; ;
                    TripDetails_parent.Contracts.LastStatusDate = DateTime.Now;

                    TripDetails_parent.Contracts.UserServiceLastStatus = TripDetails_parent.Driver.Name + " _ terminate service"; ;
                    TripDetails_parent.Contracts.ServiceLastStatusDate = DateTime.Now;

                    //}
                }

                //change status of srf if complete all trips

            }
        }
        //public void PunchOutUpdateAllOld(TripSheetDeatails_skip t)
        //{
        //    int ContractId;
        //    TripSheetDeatails_skip TripDetails = new TripSheetDeatails_skip();
        //    if (t.Status.ToString() != "Reset" && t.Status != null)
        //    {
        //        // TripDetails = db.TripSheetDaetails.Find(t.TripSheetDaetailsId);
        //        TripSheetDeatails_skip TripDetails_parent = db.TripSheetDaetails.Find(t.TripSheetDaetailsId);
        //        ContractId = TripDetails_parent.ContractId;
        //        if (t.Status.ToString() != "Reset")
        //        {
        //            TripDetails.Status = (TripStatus_skip)Enum.Parse(typeof(TripStatus_skip), t.Status.ToString(), true);
        //        }
        //        if (t.DoNum != null)
        //        {
        //            TripDetails.DoNum = t.DoNum.Trim();
        //        }

        //        if (t.SkipSerialNumber != null)
        //        {
        //            TripDetails.SkipSerialNumber = t.SkipSerialNumber.Trim();
        //        }

        //        if (t.SkipSerialNumber2 != null)
        //        {
        //            TripDetails.SkipSerialNumber2 = t.SkipSerialNumber2.Trim();
        //        }
        //        // TripDetails.NumberOfSkipscollected = t.NumberOfSkipscollected;//always one
        //        TripDetails.Timein = t.Timein;
        //        TripDetails.Timeout = t.Timeout;

        //        TripDetails.WasteTypex = t.ReasonImg;

        //        TripDetails.DumpLocationId = t.DumpLocationId;
        //        TripDetails.Weight = t.Weight;
        //        TripDetails.Remarks = t.Remarks;
        //        TripDetails.ProductId = t.ProductId;
        //        TripDetails.TripSheetDaetailsId = t.TripSheetDaetailsId;

        //        TripDetails.UserId = t.UserId;
        //        //add confirmed skip
        //        db.TripSheetDeatails_skips.Add(TripDetails);

        //        //update tripshitdetail total skip served
        //        TripSheetDaetails tripSheetDaetails = db.TripSheetDaetails.Find(TripDetails.TripSheetDaetailsId);
        //        if (TripDetails.Status != TripStatus_skip.drop)
        //        {
        //            if (tripSheetDaetails.NumberOfSkipscollected != null)
        //            {
        //                tripSheetDaetails.NumberOfSkipscollected = tripSheetDaetails.NumberOfSkipscollected + 1;
        //            }
        //            else
        //            {
        //                tripSheetDaetails.NumberOfSkipscollected = 1;
        //            }
        //        }
        //        //change status
        //        //if (tripSheetDaetails.NumberOfSkipscollected >= tripSheetDaetails.NumberOfSkips)
        //        //{

        //        //need get all tripsheetdetails of call 
        //        //sum all NumberOfSkipscollected skips 
        //        ///compare with call
        //        ///
        //        ///tripSheetDaetails.Status = TripStatus.complete;
        //        if (tripSheetDaetails.CallBasedId != null)
        //        {
        //            CallBased cb = db.CallBaseds.Find(tripSheetDaetails.CallBasedId);
        //            int total = cb.NumOfSkips;
        //            // get all trips of call
        //            List<TripSheetDaetails> tsd = cb.TripSheetDaetails.ToList();
        //            int allocated = 0;
        //            foreach (var ttt in tsd)
        //            {
        //                allocated += ttt.NumberOfSkipscollected ?? 0;
        //            }
        //            if (total <= allocated)
        //            {
        //                cb.Status = CallStatus.completed;
        //            }

        //        }



        //        // }


        //        //if there is lpo and it is qty-lpo or qty-priod-lpo need to reduce the qty and trip is collection

        //        //effect the skip
        //        Contract contract = db.Contracts.Find(ContractId);
        //        if (tripSheetDaetails.ServiceTypeId == 1 || tripSheetDaetails.ServiceTypeId == 3)//if garbage collection or pullout
        //        {
        //            if (contract.LPOs != null)
        //            {
        //                var a = contract.TallyCode;
        //                if (t.Status == TripStatus_skip.Complete || t.Status == TripStatus_skip.visit_charge)
        //                {
        //                    if (contract.LPOQtyBalance != null)
        //                    {
        //                        contract.LPOQtyBalance += 1;

        //                    }
        //                    else
        //                    {
        //                        contract.LPOQtyBalance = 1;
        //                    }

        //                    var lpo = contract.LPOs.Where(l => l.IsActive == true).FirstOrDefault();
        //                    if (lpo != null)
        //                    {
        //                        if (lpo.ServicedActualQty != null)
        //                        {
        //                            lpo.ServicedActualQty += 1;

        //                        }
        //                        else
        //                        {
        //                            lpo.ServicedActualQty = 1;
        //                        }


        //                    }
        //                    // contract. += t.NumberOfSkipscollected;
        //                }

        //                //Decision
        //                //after perform the trip  if reach lpo qty Suspend service 
        //                if (contract.LPOQtyBalance == contract.LPOQty)
        //                {
        //                    contract.ContractServiceStatusId = 2;//suspended
        //                }
        //            }
        //        }


        //        db.SaveChanges();



        //        //if carbage collection and chain truck (two serial)
        //        if (TripDetails.SkipSerialNumber2 != null)
        //        {
        //            //link contract with skip serial number 
        //            ContractSkip ContractSkip = new ContractSkip();
        //            ContractSkip.ContractId = TripDetails_parent.ContractId;
        //            ContractSkip.SkipSerialNumber = TripDetails.SkipSerialNumber2;
        //            ContractSkip.SkipSize = TripDetails_parent.Products.Name;
        //            ContractSkip.ProductId = TripDetails_parent.ProductId;

        //            db.ContractSkips.Add(ContractSkip);


        //            //remove first one 
        //            ContractSkip ContractSkipRemove = db.ContractSkips.Where(cs => cs.SkipSerialNumber == TripDetails.SkipSerialNumber).FirstOrDefault();
        //            if (ContractSkipRemove != null)
        //            {
        //                db.ContractSkips.Remove(ContractSkipRemove);
        //            }
        //            db.SaveChanges();
        //        }



        //        //Decision 
        //        // i should know first trip frelated to contract 
        //        //   int sid = t.CallBased.ServiceTypeId ?? 1;
        //        //if (TripDetails.ServiceTypeId == ServiceTypeGarbageCollectionId)
        //        //{
        //        //    //عندما ننفذ اول رحلة  نبدأ الخدمة 
        //        //    //if (CheckDeliverAllSkipOfContract(t.Contracts))
        //        //    int n = t.CallBased.TripSheetDaetails.Where(td => td.Status.ToString() == "complete").Count();

        //        //    if (n <= t.Contracts.NoOfSkips) {
        //        //        t.Contracts.ContractServiceStatusId = 1;// active the service for contrasct
        //        //    }

        //        //}

        //        //Decision
        //        //if contract is on hold and trip is confirmed 
        //        if (TripDetails_parent.Contracts.ContractStatusId == 4 && t.Status != TripStatus_skip.drop)
        //        {
        //            TripDetails_parent.Contracts.ContractStatusId = 3;
        //        }


        //        //when is SRF and ownership is client
        //        if (TripDetails_parent.CallBasedId != null && TripDetails_parent.CallBased.isSRF == true)
        //        {
        //            if (TripDetails_parent.Contracts.OwnerShipOfSkipId == 1)
        //            {
        //                TripDetails_parent.Contracts.ContractServiceStatusId = 1;// ON SITE
        //            }
        //        }

        //        //Decision
        //        //when delTripDetailsiver skips
        //        //اذا كان في تسليم حاويات
        //        if (TripDetails_parent.ServiceTypeId == ServiceTypeDeliveryId && t.Status != TripStatus_skip.drop)
        //        {

        //            //if (CheckDeliverAllSkipOfContract(t.Contracts))

        //            TripDetails_parent.Contracts.ContractServiceStatusId = 1;// active the service for contrasct

        //            //link contract with skip serial number 
        //            //ContractSkip ContractSkip = new ContractSkip();
        //            //ContractSkip.ContractId = TripDetails_parent.ContractId;
        //            //ContractSkip.SkipSerialNumber = TripDetails.SkipSerialNumber2;
        //            //ContractSkip.SkipSize = TripDetails_parent.Products.Name;
        //            //ContractSkip.ProductId = TripDetails_parent.ProductId;

        //            //db.ContractSkips.Add(ContractSkip);

        //            //update number of skips on site,,q1`'l
        //            contract = db.Contracts.Find(TripDetails_parent.ContractId);

        //            //i add it when srf placed
        //            //contract.SkipOnSite++;

        //            db.SaveChanges();

        //        }


        //        //Decision
        //        //when Last Service Trip
        //        //cancel the service and contract
        //        if (TripDetails_parent.ServiceTypeId == 9 && t.Status != TripStatus_skip.drop)//Last Service Trip
        //        {
        //            if (TripDetails_parent.Contracts.OwnerShipOfSkipId == 1) //client
        //            {
        //                TripDetails_parent.Contracts.ContractServiceStatusId = 4;// CANCELLED
        //                TripDetails_parent.Contracts.ContractStatusId = 5;// CANCELLED

        //                // TripDetails_parent.Contracts.UserLastStatus = User.Identity.GetUserId();
        //                TripDetails_parent.Contracts.UserLastStatus = t.UserId;
        //                TripDetails_parent.Contracts.LastStatusDate = DateTime.Now;

        //                TripDetails_parent.Contracts.UserServiceLastStatus = t.UserId;
        //                TripDetails_parent.Contracts.ServiceLastStatusDate = DateTime.Now;

        //            }
        //            else
        //            {
        //                TripDetails_parent.Contracts.ContractServiceStatusId = 3;//Terminated- Not Pulled Out
        //            }
        //        }

        //        //Decision
        //        //when pullout skips
        //        //اذا كان في سحب حاويات
        //        if (TripDetails_parent.ServiceTypeId == ServiceTypePulloutId && t.Status != TripStatus_skip.drop)
        //        {

        //            var contract1 = db.Contracts.Find(TripDetails_parent.ContractId);
        //            // int a = contract1.SkipOnSite-1;

        //            bool a = CheckPullOutAllSkipOfContract(TripDetails_parent.Contracts);



        //            if (a == true)
        //            {

        //                TripDetails_parent.Contracts.ContractServiceStatusId = 4;//Service CANCELLED
        //                TripDetails_parent.Contracts.UserServiceLastStatus = t.UserId;
        //                TripDetails_parent.Contracts.ServiceLastStatusDate = DateTime.Now;

        //                if (TripDetails_parent.Contracts.ContractStatusId != 7)
        //                {
        //                    TripDetails_parent.Contracts.ContractStatusId = 5;//Contract CANCELLED
        //                                                                        // TripDetails_parent.Contracts.UserLastStatus = User.Identity.GetUserId();

        //                    TripDetails_parent.Contracts.UserLastStatus = t.UserId;
        //                    TripDetails_parent.Contracts.LastStatusDate = DateTime.Now;
        //                }
        //                db.SaveChanges();
        //            }

        //            //remove the link between the skips and the contract 
        //            if (t.SkipSerialNumber != "" || t.SkipSerialNumber != null)
        //            {
        //                //get the serial number of skip 
        //                // removed 
        //                try
        //                {
        //                    ContractSkip cskip = db.ContractSkips.Where(c => c.SkipSerialNumber == t.SkipSerialNumber).FirstOrDefault();
        //                    db.ContractSkips.Remove(cskip);

        //                }
        //                catch (Exception e) { }
        //            }

        //            //reduce number of skip on site
        //            //var c = db.Contracts.Find(ContractId);
        //            // c.SkipOnSite -= 1;


        //            //update number of skips on site
        //            contract = db.Contracts.Find(TripDetails_parent.ContractId);
        //            contract.SkipOnSite--;
        //            db.SaveChanges();



        //        }

        //        //Decision
        //        //when deliver skips Last Service Trip
        //        //اذا كانت اخر رحلة
        //        if (TripDetails_parent.ServiceTypeId == ServiceTypeLastServiceTripId)
        //        {
        //            if (CheckLastServiceAllSkipOfContract(TripDetails_parent.Contracts))
        //            {
        //                if (TripDetails_parent.Contracts.OwnerShipOfSkipId == 1) //client
        //                {
        //                    TripDetails_parent.Contracts.ContractServiceStatusId = 4;// CANCELLED
        //                }
        //                else // mr.skip  skip
        //                {
        //                    TripDetails_parent.Contracts.ContractServiceStatusId = 3;//CANCELLED- Not Pulled Out
        //                }
        //            }
        //        }

        //        //Decision
        //        //when terminate service
        //        //اذا كانت انهاء خدمة
        //        if (TripDetails_parent.ServiceTypeId == 39)
        //        {
        //            //if (CheckLastServiceAllSkipOfContract(TripDetails_parent.Contracts))
        //            //{

        //            TripDetails_parent.Contracts.ContractServiceStatusId = 4;// CANCELLED
        //            TripDetails_parent.Contracts.ContractStatusId = 5;// CANCELLED

        //            //TripDetails_parent.Contracts.UserLastStatus = User.Identity.GetUserId();
        //            TripDetails_parent.Contracts.UserLastStatus = t.UserId;
        //            TripDetails_parent.Contracts.LastStatusDate = DateTime.Now;

        //            TripDetails_parent.Contracts.UserServiceLastStatus = t.UserId;
        //            TripDetails_parent.Contracts.ServiceLastStatusDate = DateTime.Now;

        //            //}
        //        }

        //        //change status of srf if complete all trips

        //    }
        //    //--------------------------------------------------------------------------------------------
        //    //update tripshitdetail total skip served
        //    TripSheetDaetails tripSheetDaetails = db.TripSheetDaetails.Find(TripDetails.TripSheetDaetailsId);
        //    if (TripDetails.Status != TripStatus_skip.drop)
        //    {
        //        if (tripSheetDaetails.NumberOfSkipscollected != null)
        //        {
        //            tripSheetDaetails.NumberOfSkipscollected = tripSheetDaetails.NumberOfSkipscollected + 1;
        //        }
        //        else
        //        {
        //            tripSheetDaetails.NumberOfSkipscollected = 1;
        //        }
        //    }
        //    //change status
        //    //if (tripSheetDaetails.NumberOfSkipscollected >= tripSheetDaetails.NumberOfSkips)
        //    //{

        //    //need get all tripsheetdetails of call
        //    //sum all NumberOfSkipscollected skips
        //    ///compare with call
        //    ///
        //    ///tripSheetDaetails.Status = TripStatus.complete;
        //    if (tripSheetDaetails.CallBasedId != null)
        //    {
        //        CallBased cb = db.CallBaseds.Find(tripSheetDaetails.CallBasedId);
        //        int total = cb.NumOfSkips;
        //        // get all trips of call
        //        List<TripSheetDaetails> tsd = cb.TripSheetDaetails.ToList();
        //        int allocated = 0;
        //        foreach (var ttt in tsd)
        //        {
        //            allocated += ttt.NumberOfSkipscollected ?? 0;
        //        }
        //        if (total <= allocated)
        //        {
        //            cb.Status = CallStatus.completed;
        //        }

        //    }




        //    // }


        //    //if there is lpo and it is qty-lpo or qty-priod-lpo need to reduce the qty and trip is collection

        //    //effect the skip
        //    int ContractId = tripSheetDaetails.ContractId;
        //    TripSheetDeatails_skip t  = TripDetails;
        //    Contract contract = db.Contracts.Find(ContractId);
        //    if (tripSheetDaetails.ServiceTypeId == 1)//if garbage collection
        //    {
        //        if (contract.LPOQty != 0 && contract.LPOQty != null)
        //        {
        //            if (t.Status == TripStatus_skip.Complete || t.Status == TripStatus_skip.drop)
        //            {
        //                if (contract.LPOQtyBalance != null)
        //                {
        //                    contract.LPOQtyBalance += 1;
        //                }
        //                else
        //                {
        //                    contract.LPOQtyBalance = 1;
        //                }

        //                // contract. += t.NumberOfSkipscollected;
        //            }

        //            //Decision
        //            //after perform the trip  if reach lpo qty Suspend service
        //            if (contract.LPOQtyBalance == contract.LPOQty)
        //            {
        //                contract.ContractServiceStatusId = 2;//suspended
        //            }
        //        }
        //    }


        //    db.SaveChanges();



        //    //if carbage collection and chain truck (two serial)
        //    TripSheetDaetails  TripDetails_parent = tripSheetDaetails;
        //    if (TripDetails.SkipSerialNumber2 != null)
        //    {
        //        //link contract with skip serial number
        //        ContractSkip ContractSkip = new ContractSkip();
        //        ContractSkip.ContractId = TripDetails_parent.ContractId;
        //        ContractSkip.SkipSerialNumber = TripDetails.SkipSerialNumber2;
        //        ContractSkip.SkipSize = TripDetails_parent.Products.Name;
        //        ContractSkip.ProductId = TripDetails_parent.ProductId;

        //        db.ContractSkips.Add(ContractSkip);


        //        //remove first one
        //        ContractSkip ContractSkipRemove = db.ContractSkips.Where(cs => cs.SkipSerialNumber == TripDetails.SkipSerialNumber).FirstOrDefault();
        //        if (ContractSkipRemove != null)
        //        {
        //            db.ContractSkips.Remove(ContractSkipRemove);
        //        }
        //        db.SaveChanges();
        //    }



        //    //Decision
        //    // i should know first trip frelated to contract
        //    //   int sid = t.CallBased.ServiceTypeId ?? 1;
        //    //if (TripDetails.ServiceTypeId == ServiceTypeGarbageCollectionId)
        //    //{
        //    //    //عندما ننفذ اول رحلة  نبدأ الخدمة
        //    //    //if (CheckDeliverAllSkipOfContract(t.Contracts))
        //    //    int n = t.CallBased.TripSheetDaetails.Where(td => td.Status.ToString() == "complete").Count();

        //    //    if (n <= t.Contracts.NoOfSkips) {
        //    //        t.Contracts.ContractServiceStatusId = 1;// active the service for contrasct
        //    //    }

        //    //}

        //    //Decision
        //    //if contract is on hold and trip is confirmed
        //    if (TripDetails_parent.Contracts.ContractStatusId == 4 && t.Status != TripStatus_skip.drop)
        //    {
        //        TripDetails_parent.Contracts.ContractStatusId = 3;
        //    }


        //    //when is SRF and ownership is client
        //    if (TripDetails_parent.CallBasedId != null && TripDetails_parent.CallBased.isSRF == true)
        //    {
        //        if (TripDetails_parent.Contracts.OwnerShipOfSkipId == 1)
        //        {
        //            TripDetails_parent.Contracts.ContractServiceStatusId = 1;// ON SITE
        //        }
        //    }

        //    int ServiceTypeDeliveryId = db.ServiceTypes.Where(st => st.Name == "Delivery").FirstOrDefault().ServiceTypeId;
        //    int ServiceTypePulloutId = db.ServiceTypes.Where(st => st.Name == "Pullout").FirstOrDefault().ServiceTypeId;
        //    int ServiceTypeLastServiceTripId = db.ServiceTypes.Where(st => st.Name == "Last Service Trip").FirstOrDefault().ServiceTypeId;

        //    //Decision
        //    //when delTripDetailsiver skips
        //    //اذا كان في تسليم حاويات
        //    if (TripDetails_parent.ServiceTypeId == ServiceTypeDeliveryId && t.Status != TripStatus_skip.drop)
        //    {

        //        //if (CheckDeliverAllSkipOfContract(t.Contracts))

        //        TripDetails_parent.Contracts.ContractServiceStatusId = 1;// active the service for contrasct

        //        //link contract with skip serial number
        //        //ContractSkip ContractSkip = new ContractSkip();
        //        //ContractSkip.ContractId = TripDetails_parent.ContractId;
        //        //ContractSkip.SkipSerialNumber = TripDetails.SkipSerialNumber2;
        //        //ContractSkip.SkipSize = TripDetails_parent.Products.Name;
        //        //ContractSkip.ProductId = TripDetails_parent.ProductId;

        //        //db.ContractSkips.Add(ContractSkip);

        //        //update number of skips on site,,q1`'l
        //        contract = db.Contracts.Find(TripDetails_parent.ContractId);
        //        contract.SkipOnSite++;
        //        db.SaveChanges();

        //    }


        //    //Decision
        //    //when Last Service Trip
        //    //cancel the service and contract
        //    if (TripDetails_parent.ServiceTypeId == 9 && t.Status != TripStatus_skip.drop)//Last Service Trip
        //    {
        //        if (TripDetails_parent.Contracts.OwnerShipOfSkipId == 1) //client
        //        {
        //            TripDetails_parent.Contracts.ContractServiceStatusId = 4;// CANCELLED
        //            TripDetails_parent.Contracts.ContractStatusId = 5;// CANCELLED
        //        }
        //        else
        //        {
        //            TripDetails_parent.Contracts.ContractServiceStatusId = 3;//Terminated- Not Pulled Out
        //        }
        //    }

        //    //Decision
        //    //when pullout skips
        //    //اذا كان في سحب حاويات
        //    if (TripDetails_parent.ServiceTypeId == ServiceTypePulloutId && t.Status != TripStatus_skip.drop)
        //    {
        //        //uncomment
        //        //if (CheckPullOutAllSkipOfContract(TripDetails_parent.Contracts))
        //        //{
        //        //    TripDetails_parent.Contracts.ContractServiceStatusId = 4;//Service CANCELLED
        //        //    if (TripDetails_parent.Contracts.ContractStatusId != 7)
        //        //    {
        //        //        TripDetails_parent.Contracts.ContractStatusId = 5;//Contract CANCELLED
        //        //    }
        //        //    db.SaveChanges();
        //        //}

        //        //remove the link between the skips and the contract
        //        if (t.SkipSerialNumber != "" || t.SkipSerialNumber != null)
        //        {
        //            //get the serial number of skip
        //            // removed
        //            try
        //            {
        //                ContractSkip cskip = db.ContractSkips.Where(c => c.SkipSerialNumber == t.SkipSerialNumber).FirstOrDefault();
        //                db.ContractSkips.Remove(cskip);

        //                //update number of skips on site
        //                contract = db.Contracts.Find(TripDetails_parent.ContractId);
        //                contract.SkipOnSite--;
        //                db.SaveChanges();
        //            }
        //            catch (Exception e) { }
        //        }

        //    }

        //    //Decision
        //    //when deliver skips Last Service Trip
        //    //اذا كانت اخر رحلة
        //    if (TripDetails_parent.ServiceTypeId == ServiceTypeLastServiceTripId)
        //    {
        //        if (CheckLastServiceAllSkipOfContract(TripDetails_parent.Contracts))
        //        {
        //            if (TripDetails_parent.Contracts.OwnerShipOfSkipId == 1) //client
        //            {
        //                TripDetails_parent.Contracts.ContractServiceStatusId = 4;// CANCELLED
        //            }
        //            else // mr.skip  skip
        //            {
        //                TripDetails_parent.Contracts.ContractServiceStatusId = 3;//CANCELLED- Not Pulled Out
        //            }
        //        }
        //    }

        //    //Decision
        //    //when terminate service
        //    //اذا كانت انهاء خدمة
        //    if (TripDetails_parent.ServiceTypeId == 39)
        //    {
        //        //if (CheckLastServiceAllSkipOfContract(TripDetails_parent.Contracts))
        //        //{

        //        TripDetails_parent.Contracts.ContractServiceStatusId = 4;// CANCELLED
        //        TripDetails_parent.Contracts.ContractStatusId = 5;// CANCELLED

        //        //}
        //    }

        //    //change status of srf if complete all trips

        //}
        public List<TripSheetDaetails> TripsByContractByServicetype(int ContractId, int ServicetypeId)
        {
            var tripSheetDaetails = db.TripSheetDaetails.Where(td => td.ContractId == ContractId && td.CallBased.ServiceTypeId == ServicetypeId).Include(t => t.Contracts).Include(t => t.Driver).Include(t => t.Products).Include(t => t.CallBased).Include(t => t.Vehicle);
            return tripSheetDaetails.ToList();
        }

        public bool CheckPullOutAllSkipOfContract(Contract contract)
        {
            int ServiceTypeId = db.ServiceTypes.Where(st => st.Name == "Pullout").FirstOrDefault().ServiceTypeId;
            int ServiceTypeIdDelivery = db.ServiceTypes.Where(st => st.Name == "Delivery").FirstOrDefault().ServiceTypeId;
            int conytractId = contract.ContractId;
            DateTime startDateOfContract = contract.ContractDate;



            //get all pullout trip

            List<TripSheetDaetails> tripSheetDaetails = //tripSheetDaetailsController.TripsByContractByServicetype(conytractId, ServiceTypeId);
                           db.TripSheetDaetails.Where(td => td.ContractId == conytractId && td.CallBased.ServiceTypeId == ServiceTypeId).ToList(); ;


            int sum = 0;
            foreach (TripSheetDaetails tsd in tripSheetDaetails)
            {
                sum += tsd.NumberOfSkipscollected ?? 0;
            }

            //get all delivery trip

            List<TripSheetDaetails> tripSheetDaetailsDelivery = db.TripSheetDaetails.Where(td => td.ContractId == conytractId && td.CallBased.ServiceTypeId == ServiceTypeIdDelivery).ToList(); ;

            int sumDel = 0;
            foreach (TripSheetDaetails tsd in tripSheetDaetailsDelivery)
            {
                sumDel += tsd.NumberOfSkipscollected ?? 0;
            }

            if (sum >= sumDel)
            {
                return true;
            }
            return false;
        }


        public bool CheckPullOutAllSkipOfContractOld(Contract contract)
        {
            int ServiceTypeId = db.ServiceTypes.Where(st => st.Name == "Pullout").FirstOrDefault().ServiceTypeId;
            int conytractId = contract.ContractId;
            DateTime startDateOfContract = contract.ContractDate;



            //get all delivery trip
            List<TripSheetDaetails> tripSheetDaetails = TripsByContractByServicetype(conytractId, ServiceTypeId);

            int sum = 0;
            foreach (TripSheetDaetails tsd in tripSheetDaetails)
            {
                sum += tsd.NumberOfSkipscollected ?? 0;
            }

            if (sum >= contract.NoOfSkips)
            {
                return true;
            }
            return false;
        }
        public bool CheckLastServiceAllSkipOfContract(Contract contract)
        {
            int ServiceTypeId = db.ServiceTypes.Where(st => st.Name == "Last Service Trip").FirstOrDefault().ServiceTypeId;
            int conytractId = contract.ContractId;
            DateTime startDateOfContract = contract.ContractDate;



            //get all delivery trip
            List<TripSheetDaetails> tripSheetDaetails = TripsByContractByServicetype(conytractId, ServiceTypeId);

            int sum = 0;
            foreach (TripSheetDaetails tsd in tripSheetDaetails)
            {
                sum += tsd.NumberOfSkipscollected ?? 0;
            }

            if (sum == contract.NoOfSkips)
            {
                return true;
            }
            return false;
        }
    }

}
