using DOMAIN.IServiceBase;
using DOMAIN.Entities;
using DOMAIN.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.ServiceBase
{
    public class TeamService:Service<Team>,IPlayersService
    {
        private readonly ITeamRepository _players;
        public TeamService(ITeamRepository players):base(players)
        {
            _players = players;
        }
    }
}
