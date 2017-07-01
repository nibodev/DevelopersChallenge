using ApplicationExpose.IApp;
using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MataMata.Controllers
{
    public class RegisterPhaseController : Controller
    {
        private readonly IPhaseApp _phase;
        private readonly IRulesApp _rules;
        public RegisterPhaseController(IPhaseApp phase, IRulesApp rules)
        {
            _phase = phase;
            _rules = rules;
        }

        public ActionResult Index()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public JsonResult GetAllStages()
        {
            try
            {
                Response.StatusCode = 200;
                var result = _phase.GetList();
                var data = new
                {
                    page = 1,
                    total = result.Count(),
                    records = result.Count(),
                    rows = result

                };

                return Json(data , JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                Response.StatusCode = 200;
                return Json(new { msg = "Falha ao retornar a listagem de fases do campeonato", MsgType = TypeMessage.Error }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpPost]
        public JsonResult Save(Phase pPhase)
        {
            try
            {

                var listRules = _rules.GetList().ToList();
                var listStages = _phase.GetAllList();
                if (pPhase.IdPhase != 0)
                {
                    pPhase.Name = pPhase.Name.ToUpper();
                    _phase.Update(pPhase);
                }
                else
                {
                    var rule = listRules[0];
                    if (rule.ValidationNumberOfStages(listStages.Count()))
                    {
                        pPhase.Name = pPhase.Name.ToUpper();
                        _phase.Add(pPhase);
                    }
                    else
                    {
                        return Json(new { msg = "Número de fases permitidas já foi alcançado.", MsgType = TypeMessage.Info });
                    }
                }


                Response.StatusCode = 200;
                return Json(new { dados = _phase.GetAll(), msg = "Fase cadastrada com sucesso!.", MsgType = TypeMessage.Success });
            }
            catch (Exception)
            {

                Response.StatusCode = 500;
                return Json(new { dados = _phase.GetAll(), msg = "Falha no processo cadastro!.", MsgType = TypeMessage.Error });
            }
            return null;
        }

        [HttpPost]
        public JsonResult Excluir(Phase pPhase)
        {
            try
            {
                _phase.Delete(pPhase);

                Response.StatusCode = 200;
                return Json(new { dados = _phase.GetAll(), msg = "Fase excluida com sucesso!.", MsgType = TypeMessage.Success });
            }
            catch (Exception)
            {

                Response.StatusCode = 500;
                return Json(new { dados = _phase.GetAll(), msg = "Falha no processo de exclusão!.", MsgType = TypeMessage.Error });
            }
            return null;
        }


    }
}
