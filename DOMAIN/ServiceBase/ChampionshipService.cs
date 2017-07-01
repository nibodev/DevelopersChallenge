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
    public class ChampionshipService : Service<Championship>, IChampionshipService
    {
        private readonly IChampionshipRepository _championship; 
        public ChampionshipService(IChampionshipRepository championship):base(championship)
        {
            _championship = championship;
        }
    }
}
