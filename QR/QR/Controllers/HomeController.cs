using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QR.Data;
using QR.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using QRCoder;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Web.Helpers;
using Microsoft.AspNetCore.Http;
using ZXing;

namespace QR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _context;
        private readonly Random _random = new Random();
        private User user;

        private const int NOT_LOGGED = 0;
        private const int LOGGED = 1;
        private const int MIN_RANDOM = 100000;
        private const int MAX_RANDOM = 999999;

        public HomeController(
            ILogger<HomeController> logger,
            UserContext context)
        {
            _logger = logger;
            _context = context;
            user = new User();
            user.currMode = NOT_LOGGED;
        }

        private demouser GetLoggedUser(string username, string pw)
        {
            var currentcode = 0;
            var user = _context.Demousers.FirstOrDefault(x => x.username == username && x.pw == pw);

            if(user != null)
            {
                currentcode = _random.Next(MIN_RANDOM, MAX_RANDOM);
                user.currentcode = currentcode.ToString();
                _context.Demousers.Update(user);
                _context.SaveChanges();
                return user;
            }

            return new demouser();
        }
        private demouser GetCheckedInUser(UserJson juser)
        {
            var user = _context.Demousers.FirstOrDefault(u => u.username == juser.username &&
                                                              u.pw == juser.pw &&
                                                              u.currentcode == juser.currentcode);
            if(user != null)
            {
                user.lastcheckedin = DateTime.Now;
                _context.Demousers.Update(user);
                _context.SaveChanges();
                return user;
            }

            return new demouser();
        }
        private string CreateLoginJson(demouser user)
        {
            try
            {
                UserJson uj = new UserJson();
                uj.username = user.username;
                uj.pw = user.pw;
                uj.currentcode = user.currentcode;
                string json = JsonConvert.SerializeObject(uj);
                return json;
            }
            catch
            {
                return string.Empty;
            }
        }

        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        private Byte[] CreateQr(string text)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return BitmapToBytes(qrCodeImage);
        }

        private User GetCurrUser(demouser u)
        {
            User user = new User();
            user.currMode = LOGGED;
            user.id = u.id;
            user.username = u.username;
            user.lastcheckedin = u.lastcheckedin;

            var json = CreateLoginJson(u);
            user.qr = CreateQr(json);

            return user;
        }
        private User GetCurrCheckedUser(demouser u)
        {
            User user = new User();
            user.currMode = LOGGED;
            user.id = u.id;
            user.username = u.username;
            user.lastcheckedin = u.lastcheckedin;
            return user;
        }
        public IActionResult Index()
        {
            return View(user);
        }

        public IActionResult Login(string username, string pw)
        {
            if(string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(pw))
            {
                return RedirectToAction("Index");
            }

            var loggedUser = GetLoggedUser(username, pw);
            user = GetCurrUser(loggedUser);
            return View(user);
        }

        private string RetrieveInfo(Bitmap qr)
        {
            // create a barcode reader instance
            BarcodeReader reader = new BarcodeReader();
            // detect and decode the barcode inside the bitmap
            var result = reader.Decode(qr);

            var type = string.Empty;
            var content = string.Empty;

            if (result != null)
            {
                type = result.BarcodeFormat.ToString();
                content = result.Text;
                return content;
            }

            return string.Empty;
        }
        private User CheckinUser(UserJson juser)
        {
            User user = new User();
            var duser = GetCheckedInUser(juser);
            user = GetCurrCheckedUser(duser);
            return user;
        }
        public async Task<IActionResult> CheckinAsync(IFormFile file)
        {
            try
            {
                var info = string.Empty;

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var img = (Bitmap)Image.FromStream(memoryStream);
                    info = RetrieveInfo(img);
                }

                var checkinUser = new UserJson();

                if (!string.IsNullOrEmpty(info))
                {
                    checkinUser = JsonConvert.DeserializeObject<UserJson>(info);
                }

                user = CheckinUser(checkinUser);

                if (string.IsNullOrEmpty(user.username))
                {
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
