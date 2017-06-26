using ApplicationExpose.IApp;
using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MataMata.Controllers
{
    public class RegisterRulesController : Controller
    {
        private readonly IRulesApp _rules;
        public RegisterRulesController(IRulesApp rules)
        {
            _rules = rules;
        }


        public ActionResult Index()
        {
            return View();
        }

        // GET: RegisterRules
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public JsonResult GetAllRules()
        {
            try
            {
                Response.StatusCode = 200;
                var result = _rules.GetList();
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

                throw;
            }

        }

        [HttpPost]
        public JsonResult Save(Rules pRules)
        {
            try
            {
                var lista = _rules.GetList();

                if (pRules.IdRules != 0)
                {

                    _rules.Update(pRules);
                }
                else
                {
                    if (!pRules.validationNumberOfListRules(lista.ToList()))
                    {
                        _rules.Add(pRules);
                    }
                    else
                    {
                        return Json(new { msg = "Número de regras permitidas já foi alcançado!.", MsgType = TypeMessage.Info });
                    }
                   
                }


                Response.StatusCode = 200;
                return Json(new { dados = _rules.GetAll(), msg = "Regra cadastrada com sucesso!.", MsgType = TypeMessage.Success });
            }
            catch (Exception)
            {

                Response.StatusCode = 500;
                return Json(new { dados = _rules.GetAll(), msg = "Falha no processo de cadastro!.", MsgType = TypeMessage.Success });
            }
            return null;
        }

        [HttpPost]
        public JsonResult Excluir(Rules pRules)
        {
            try
            {
                _rules.Delete(pRules);

                Response.StatusCode = 200;
                return Json(new { dados = _rules.GetAll(), msg = "Regra excluida com sucesso!.", MsgType = TypeMessage.Success });
            }
            catch (Exception)
            {

                Response.StatusCode = 500;
                return Json(new { dados = _rules.GetAll(), msg = "Falha no processo de exclusão!.", MsgType = TypeMessage.Error });
            }
            return null;
        }

    }
}
