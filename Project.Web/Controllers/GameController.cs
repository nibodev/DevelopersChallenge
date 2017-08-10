using Project.Repository.Contracts;
using Project.Repository.Dto;
using Project.Repository.Entities;
using Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository repository;

        public GameController(IGameRepository repository)
        {
            this.repository = repository;
        }

        public JsonResult GetTeams()
        {
            try
            {
                var list = new List<ConsultAllTeamViewModel>();
                foreach (Team t in repository.ConsultTeam())
                {
                    list.Add(new ConsultAllTeamViewModel()
                    {
                       Name = t.Name,
                       Key = t.Key,
                       TeamId = t.TeamId
                    });
                }

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, erro = e.Message });
            }
        }

        public JsonResult Create(GameViewModelCreate model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TeamRelationship team = new TeamRelationship()
                    {
                        TeamFirstId = model.TeamFirstId,
                        TeamSecondId = model.TeamSecondId
                    };

                    repository.NewDuel(team);
                }

                return Json(new { success = true });
            }
            catch (Exception e)
            {
                return Json(new { success = false, erro = e.Message });
            }
        }

        public JsonResult GetDuels()
        {
            try
            {
                var list = new List<ConsultAllTeamViewModel>();
                foreach (TeamAndTeamRelation t in repository.ConsultDuels())
                {
                    list.Add(new ConsultAllTeamViewModel()
                    {
                        
                        NameA = t.NameA,
                        FirstTeamId = t.FirstId,
                        NameB = t.NameB,
                        SecondTeamId = t.SecondId,
                        TeamId = t.TeamRelationshipId
                        
                    });
                }

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, erro = e.Message });
            }
        }


        public JsonResult AddDeleted(Deleted model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var t = new Deleted()
                    {
                        TeamId = model.TeamId,
                        TeamRelationshipId = model.TeamRelationshipId
                    };

                    repository.SavetDuel(t);

                    Remove(t.TeamRelationshipId);
                }

                return Json(new { success = true });
            }
            catch (Exception e)
            {
                return Json(new { success = false, erro = e.Message });
            }
        }

        public JsonResult Remove(int TeamRelationshipId)
        {
            try
            {
                var team  = repository.FindById(TeamRelationshipId);
                repository.Remove(team);

                return Json(new { success = true });
            }
            catch (Exception e)
            {
                return Json(new { success = false, erro = e.Message });
            }
        }





    }
}