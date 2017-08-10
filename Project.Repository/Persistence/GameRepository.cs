using Project.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository.Entities;
using Project.Repository.Context;
using System.Data.Entity;
using Project.Repository.Dto;

namespace Project.Repository.Persistence
{
    public class GameRepository : IGameRepository
    {
        public void NewDuel(TeamRelationship t)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(t).State = EntityState.Added;
                d.SaveChanges();
            }
        }

        public List<TeamAndTeamRelation> ConsultDuels()
        {

            using (DataContext d = new DataContext())
            {
                var query = (from tr in d.TeamRelationship
                             join t in d.Team on tr.TeamFirstId equals t.TeamId
                             join t2 in d.Team on tr.TeamSecondId equals t2.TeamId
                             select new TeamAndTeamRelation
                             {
                                 NameA = t.Name,
                                 NameB = t2.Name,
                                 FirstId = t.TeamId,
                                 SecondId = t2.TeamId,
                                 TeamRelationshipId = tr.TeamRelationshipId
                             }).ToList();

                return query.ToList();

            }
        }

        public List<Team> ConsultTeam()
        {
            using (DataContext d = new DataContext())
            {
                var Del = d.Deleted.ToList();

                var IsCreate = d.TeamRelationship.ToList();
                if (IsCreate.Count() > 0)
                {
                    var query = (from t in d.Team
                                 where !d.TeamRelationship.Where(ma => ma.TeamFirstId == t.TeamId || ma.TeamSecondId == t.TeamId).Any()
                                 select t).ToList();

                    foreach (var item in query.ToList())
                    {
                        if (Del.Any(x => x.TeamId == item.TeamId))
                        {
                            query.Remove(item);
                        }
                    }
                    return query;
                }

                var ListTeam = d.Team.ToList();
                foreach (var item in ListTeam.ToList())
                {
                    if (Del.Any(x => x.TeamId == item.TeamId))
                    {
                        ListTeam.Remove(item);
                    }
                }

                return ListTeam;
            }
        }

        public void SavetDuel(Deleted t)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(t).State = EntityState.Added;
                d.SaveChanges();
            }
        }


        public void Remove(TeamRelationship t)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(t).State = EntityState.Deleted;
                d.SaveChanges();
            }
        }

        public TeamRelationship FindById(int id)
        {
            using (DataContext d = new DataContext())
            {
                return d.TeamRelationship.Find(id);
            }
        }
    }
}
