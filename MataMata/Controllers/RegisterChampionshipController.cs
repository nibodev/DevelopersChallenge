using ApplicationExpose.IApp;
using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MataMata.Controllers
{
    public class RegisterChampionshipController : Controller
    {
        private readonly IChampionshipApp _champioship;
       
        public RegisterChampionshipController(IChampionshipApp championship)
        {
            _champioship = championship;
            
        }
        // GET: RegisterChampionship
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public JsonResult GetAllAdversaries()
        {
            try
            {
                Response.StatusCode = 200;
                var result = _champioship.GetList();
                var data = new
                {
                    page = 1,
                    total = result.Count(),
                    records = result.Count(),
                    rows = result

                };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                Response.StatusCode = 500;
            }
            return null;
        }
        public JsonResult SaveAdversaries(Championship pChampionship)
        {
            try
            {
               
                if (pChampionship.IdCampionShip != 0)
                {
                    
                    _champioship.Update(pChampionship);
                }
                else
                {
                    _champioship.Add(pChampionship);
                   

                }

                Response.StatusCode = 200;
                return Json(new { dados = _champioship.GetAll(), msg = "Adversários incluidos com sucesso!.", MsgType = TypeMessage.Success });
            }
            catch (Exception)
            {

                Response.StatusCode = 500;
                return Json(new { dados = _champioship.GetAll(), msg = "Falha no processo cadastro!.", MsgType = TypeMessage.Error });
            }
            return null;
        }

        [HttpPost]
        public JsonResult DeleteAdversaries(Championship pChampionship)
        {
            try
            {
                _champioship.Delete(pChampionship);

                Response.StatusCode = 200;
                return Json(new { dados = _champioship.GetAll(), msg = "Adversários removidos com sucesso!.", MsgType = TypeMessage.Success });
            }
            catch (Exception)
            {

                Response.StatusCode = 500;
                return Json(new { dados = _champioship.GetAll(), msg = "Falha no processo de remoção!.", MsgType = TypeMessage.Error });
            }
            return null;
        }
    }
}
