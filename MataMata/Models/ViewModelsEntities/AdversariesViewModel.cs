using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MataMata.Models.ViewModelsEntities
{
    public class AdversariesViewModel
    {
        public int IdChampionship { get; set; }
        public int IdTeam1 { get; set; }
        public string Name1 { get; set; }
        public int IdTeam2 { get; set; }
        public string Name2 { get; set; }

        public AdversariesViewModel GetAdversariesToGridChampionship(List<Team> pTeam, Championship pChampionship)
        {
            return new AdversariesViewModel()
            {
                IdChampionship = pChampionship.IdCampionShip,
                IdTeam1 = pChampionship.IdTeam1,
                IdTeam2 = pChampionship.IdTeam2,
                Name1 = pTeam[0].Name,
                Name2 = pTeam[1].Name
            };
        }

    }
}