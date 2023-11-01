using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebOS.Data;
using WebOS.Models;
using Microsoft.AspNetCore.Localization;
using WebOS.AuxiliaryClasses;

namespace WebOS.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _usermanager;
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _environment;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> usermanager, IWebHostEnvironment environment)
        {
            _context = context;
            _usermanager = usermanager;
            _logger = logger;
            _environment = environment;
        }

        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            if (string.IsNullOrEmpty(culture))
            {
                return LocalRedirect(returnUrl);
            }
            //CultureInfo cInfo = new CultureInfo(culture);
            //CultureInfo cInfoInvarian = new CultureInfo("en-GB");
            //cInfoInvarian.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            //cInfoInvarian.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            //cInfoInvarian.DateTimeFormat.Calendar = new GregorianCalendar();
            //cInfo.DateTimeFormat.Calendar = new GregorianCalendar();
            //Response.Cookies.Append(
            //    CookieRequestCultureProvider.DefaultCookieName,
            //    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cInfoInvarian, cInfo)),
            //    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            //);

            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTime.Now.AddDays(30) });

            return LocalRedirect(returnUrl);
        }
        public JsonResult GetCitiesList(int countryid)
        {
            var cities = new SelectList(_context.City.Where(c => c.CountryId == countryid), "Id", "ArCityName");
            return Json(cities);
        }



        //notifications
        public IActionResult GetMyViewCompNotification(string uid)
        {
            var unreadnotification = _context.Notification.Where(n => n.IsRead == false && n.ApplicationUserId == uid);
            foreach (var item in unreadnotification)
            {
                item.IsRead = true;
                _context.Update(item);

            }
            _context.SaveChanges();
            return ViewComponent("Notification", new { id = uid });//it will call Follower.cs InvokeAsync, and pass id to it.
        }
        public IActionResult GetNotificationsCount()
        {
            var result = _context.Notification.Where(c => c.ApplicationUserId == _usermanager.GetUserId(User) && c.IsRead == false).Count();
            return Json(new { res = result.ToString() });
        }


        //messages
        public IActionResult GetMessagesCount()
        {
            var currentuserid = _usermanager.GetUserId(User);
            var messages = _context.Messages.Include(m => m.FromApplicationUser).Include(m => m.ToApplicationUser).Where(m => m.ToApplicationUserId == _usermanager.GetUserId(User) || m.FromApplicationUserId == _usermanager.GetUserId(User)).OrderByDescending(m => m.LastActivitydate);
            var messagenotreadcount = messages.Where(m => m.IsRead == false && _context.MessageReplies.Where(c => c.MessageId == m.Id).Count() == 0 && m.ToApplicationUserId == _usermanager.GetUserId(User) && m.FromApplicationUserId != _usermanager.GetUserId(User)).Count();
            var repliesnotread = messages.Where(n => n.Id != 0 && _context.MessageReplies.Where(m => m.MessageId == n.Id).Any() && _context.MessageReplies.Where(m => m.MessageId == n.Id && m.IsRead == false && m.ApplicationUserId != _usermanager.GetUserId(User)).Any()).Count();
            var result = messagenotreadcount + repliesnotread;
            return Json(new { res = result.ToString() });
        }

        public IActionResult GetMyViewCompMessage(string uid)
        {
            return ViewComponent("Message", new { id = uid });//it will call Follower.cs InvokeAsync, and pass id to it.
        }
        public IActionResult Try()
        {
            return View();
        }
        public IActionResult Reports()
        {
            var Reports = _context.BlogPost.Where(b => b.IsPdf);
            return View(Reports);
        }
        public IActionResult UploadedFiles()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile myfile)
        {
            string file = "";
            file = await UserFile.UploadeNewFileAsync(file,
myfile, _environment.WebRootPath, Properties.Resources.UploadedFile);

            return RedirectToAction(nameof(UploadedFiles));
        }
        public IActionResult Index()
        {
            HomeViewModel HomeVM = new HomeViewModel()
            {
                Courses = _context.Course.Where(s => s.IsAdminApproved && !s.Ishidden && !s.IsDeleted),
                CoursePackages = _context.CoursePackage.Where(s => s.IsAdminApproved && !s.Ishidden && !s.IsDeleted),
                Testimonials = _context.Testimonial.Where(s => s.IsActive),
                BlogPosts = _context.BlogPost.Where(s => !s.IsDeleted).OrderByDescending(b=>b.PostDateTime).Take(4),
                MostReadPosts = _context.BlogPost.Where(s => !s.IsDeleted).OrderByDescending(b=>b.Reads).Take(4),
                SystemSettings = _context.SystemSettings.FirstOrDefault(),
            };


            return View(HomeVM);
        }


        public IActionResult About()
        {
            ViewBag.Services = _context.Service.Where(s => s.IsActive);
            var systemSetting = _context.SystemSettings.FirstOrDefault();
            return View(systemSetting);
        }

        public IActionResult Causes()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Donate()
        {
            return View();
        }

        public IActionResult Service()
        {
            return View();
        }

        public IActionResult Team()
        {
            return View();
        }

        public IActionResult Testimonal()
        {
            return View();
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


        public JsonResult GetSubList(int mainid)
        {
            var taxonomies = new SelectList(_context.BlogTaxonomy.Where(c => c.Sub == mainid), "Id", "Name");
            return Json(taxonomies);
        }
    }
}
