using ApplicationExpose.IApp;
using DOMAIN.IServiceBase;
using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationExpose.App
{
    public class ChampionshipApp : Application<Championship>, IChampionshipApp
    {
        private readonly IChampionshipService _championship;
        public ChampionshipApp(IChampionshipService championship):base(championship)
        {
            _championship = championship;
        }
    }
}
