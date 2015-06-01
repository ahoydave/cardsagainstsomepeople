using cardstake1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cardstake1.Controllers
{
    public class HomeController : Controller
    {
        private List<Card> _theCards = null;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestGame()
        {
            return View();
        }

        public ActionResult About()
        {
            if (_theCards == null)
            {
                _theCards = JsonConvert.DeserializeObject<List<Card>>(System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/cards.json")));
            }

            ViewBag.Title = "Dave\'s about.";
            ViewBag.Message = "Your application description page.";
            ViewBag.Cards = _theCards;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}