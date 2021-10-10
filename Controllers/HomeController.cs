using AppSettingsManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppSettingsManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _configuration;

        private TwilloSettings _settings;


        private readonly IOptions<TwilloSettings> _options;


        private readonly IOptions<SocialLoginsSettings> _optionSocialLogins;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IOptions<TwilloSettings> options, TwilloSettings settings, IOptions<SocialLoginsSettings> optionSocialLogins)
        {
            _logger = logger;
            _configuration = configuration;
            _settings = settings;
            _options = options;
            _optionSocialLogins = optionSocialLogins;
        }

        public IActionResult Index()
        {
            ViewBag.SendGridkey = _configuration.GetValue<string>("SendGridKey");

            ViewBag.TwilloSampleKey = _settings.TwilloKey;
            ViewBag.TwilloSampleValue = _settings.TwilloValue;
            ViewBag.TwilloPhoneNumber = _settings.TwilloPhoneNumber;

            ViewBag.TwilloSampleKeySection = _options.Value.TwilloKey ;
            ViewBag.TwilloSampleValueSection = _options.Value.TwilloValue;
            ViewBag.TwilloSamplePhoneNumberSection = _options.Value.TwilloPhoneNumber;


            ViewBag.FaceBookKey = _optionSocialLogins.Value.FaceBookLoginSettings.Value;

            ViewBag.GoogleKey = _optionSocialLogins.Value.GoogleLoginSettings.Value;

            //ViewBag.InnerLastsection = _configuration.GetValue<string>("FirstLevelSettings:SecondLevelSettings:LastLevelSettings");

            //ViewBag.InnerLastsectionSample = _configuration.GetSection("FirstLevelSettings").GetSection("SecondLevelSettings").GetValue<string>("LastLevelSettings");


            //ViewBag.InnerLastsectionSampleGetSection = _configuration.GetSection("FirstLevelSettings").GetSection("SecondLevelSettings").GetSection("LastLevelSettings").Value;



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
    }
}
