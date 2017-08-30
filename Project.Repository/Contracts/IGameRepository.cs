using Project.Repository.Dto;
using Project.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Contracts
{
    public interface IGameRepository
    {
        //Create new duel
        void NewDuel(TeamRelationship t);


        //Consult Team Available
        List<Team> ConsultTeam();

        //Consult list of duels
        List<TeamAndTeamRelation> ConsultDuels();


        //Save duels
        void SavetDuel(Deleted t);

        //Remove Team table TeamRelationShip
        void Remove(TeamRelationship t);


        //Returning only TeamRelationShipID
        TeamRelationship FindById(int id);

    }
}
