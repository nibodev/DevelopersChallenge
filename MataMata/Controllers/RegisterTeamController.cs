using ApplicationExpose.IApp;
using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MataMata.Controllers
{
    public class RegisterTeamController : Controller
    {
        private readonly ITeamApp _team;
        private readonly IRulesApp _rules;
        private readonly IChampionshipApp _champioship;
        public RegisterTeamController(ITeamApp team, IRulesApp rules,IChampionshipApp championship)
        {
            _team = team;
            _rules = rules;
            _champioship = championship;
        }
        // GET: RegisterPlayers
        public ActionResult Index()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public JsonResult GetAllTeamsNotSelectedToChampionship()
        {
            try
            {
                Response.StatusCode = 200;
          
                var result = _team.GetAllList();
                var champioship = _champioship.GetAllList();
                for (int i = 0; i < champioship.Count; i++)
                {
                    var team1 = result.Where(x => x.IdTeam == champioship[i].IdTeam1).FirstOrDefault();
                    var team2 = result.Where(x => x.IdTeam == champioship[i].IdTeam2).FirstOrDefault();
                    result.Remove(team1);
                    result.Remove(team2);
                }
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

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public JsonResult GetAllPlayers()
        {
            try
            {
                Response.StatusCode = 200;
                var result = _team.GetList();
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

        [HttpPost]
        public JsonResult Save(Team pTeams)
        {
            try
            {
                var listRules = _rules.GetList().ToList();
                var listaTeams = _team.GetAllList();
                if (pTeams.IdTeam != 0)
                {
                    pTeams.Name = pTeams.Name.ToUpper();
                    _team.Update(pTeams);
                }
                else
                {
                    var rule = listRules[0];
                    if (rule.ValidationNumberOfParticipants(listaTeams.Count()))
                    {
                        pTeams.Name = pTeams.Name.ToUpper();
                        _team.Add(pTeams);
                    }
                    else
                    {
                        return Json(new { msg = "Número de equipes permitidas ja foi alcançado.", MsgType = TypeMessage.Info });
                    }

                }


                Response.StatusCode = 200;
                return Json(new { dados = _team.GetAll(), msg = "Time cadastrado com sucesso!.", MsgType = TypeMessage.Success });
            }
            catch (Exception)
            {

                Response.StatusCode = 500;
                return Json(new { dados = _team.GetAll(), msg = "Falha no processo cadastro!.", MsgType = TypeMessage.Error });
            }
            return null;
        }

        [HttpPost]
        public JsonResult Excluir(Team pTeams)
        {
            try
            {
                _team.Delete(pTeams);

                Response.StatusCode = 200;
                return Json(new { dados = _team.GetAll(), msg = "Time excluido com sucesso!.", MsgType = TypeMessage.Success });
            }
            catch (Exception)
            {

                Response.StatusCode = 500;
                return Json(new { dados = _team.GetAll(), msg = "Falha no processo de exclusão!.", MsgType = TypeMessage.Error });
            }
            return null;
        }

        // POST: RegisterPlayers/Create



    }
}
