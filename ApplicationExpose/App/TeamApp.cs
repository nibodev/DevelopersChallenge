using ApplicationExpose.IApp;
using DOMAIN.IServiceBase;
using DOMAIN.ServiceBase;
using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationExpose.App
{
    public class TeamApp:Application<Team>,ITeamApp
    {
        private readonly IPlayersService _players;
        public TeamApp(IPlayersService players):base(players)
        {
            _players = players;
        }
    }
}
