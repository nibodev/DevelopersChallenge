using ApplicationSummoners.Context;
using ApplicationSummoners.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ApplicationSummoners.Controllers
{
    public class HomeController : Controller
    {
        private readonly EFContext _db = new EFContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Kingdoms()
        {
            var kingdoms = _db.Kingdom.ToList();
            return View(kingdoms);
        }

        [HttpPost]
        public JsonResult Register(Kingdom kingdom)
        {
            if (kingdom == null)
                return Json( new { HttpStatusCode.BadRequest, Data = "Kingdom not informed" });

            _db.Kingdom.Add(kingdom);
            _db.SaveChanges();

            return Json(new { Status = HttpStatusCode.OK, Data = kingdom });
        }

        [HttpGet]
        public ActionResult Battle()
        {
            var kingdoms = _db.Kingdom.ToList();
            var rnd = new Random();
            var query =
                from i in kingdoms
                let r = rnd.Next()
                orderby r
                select i;

            //var shuffled = 
            return View(query.ToList());
        }

        [HttpGet]
        public JsonResult ProcessVictory(int idKingdomOne, int idKingdomTwo)
        {
            if(idKingdomOne == 0 || idKingdomTwo == 0)
                return Json(new { HttpStatusCode.BadRequest, Data = "Invalid id" });

            var kingdomOne = _db.Kingdom.Where(p => p.Id == idKingdomOne).FirstOrDefault();
            var kingdomTwo = _db.Kingdom.Where(p => p.Id == idKingdomTwo).FirstOrDefault();

            var winner = CheckWinner(kingdomOne, kingdomTwo);

            return Json(new { Status = HttpStatusCode.OK, Data = winner }, JsonRequestBehavior.AllowGet );
        }

        private Kingdom CheckWinner(Kingdom kingdom1, Kingdom kingdom2)
        {
            //Giants    1 equals 7 points //Gigants
            //Swordsmen 1 equals 6 points //Espadachins
            //Archers   1 equals 4 points //Arqueiro
            //Launchers 1 equals 5 points //Lançador
            //Beaters   1 equals 1 points //Batedores

            var tot1 = (kingdom1.Giants * 7) + (kingdom1.Swordsmen * 6) + (kingdom1.Archers * 4) + (kingdom1.Launchers * 5) + (kingdom1.Beaters * 1);
            var tot2 = (kingdom2.Giants * 7) + (kingdom2.Swordsmen * 6) + (kingdom2.Archers * 4) + (kingdom2.Launchers * 5) + (kingdom2.Beaters * 1);
            var winner = new Kingdom();

            if (tot1 == tot2){
                //Unpacking
                //greater number of Beaters chosen
                if (kingdom1.Beaters > kingdom2.Beaters)
                {
                    winner = kingdom1;
                }
                else
                {
                    winner = kingdom2;
                }
            }
            else if (tot1 > tot2)
            {
                winner = kingdom1;
            }
            else {
                winner = kingdom2;
            }

            return winner;
        }


        [HttpGet]
        public JsonResult DeleteKingdom(int idKingdom)
        {
            if (idKingdom <= 0)
                return Json(new { HttpStatusCode.BadRequest, Data = "Kingdom not informed" });

            var kingdom = _db.Kingdom.Where(p => p.Id == idKingdom).FirstOrDefault();

            _db.Kingdom.Remove(kingdom);
            _db.SaveChanges();

            return Json(new { Status = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet );
        }

    }
}