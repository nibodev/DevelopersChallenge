using DOMAIN.Entities;
using DOMAIN.IRepository;
using INFRA.Context;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRA.Repository
{
    public class ChampionshipRepository : RepositoryBase<Championship>, IChampionshipRepository
    {
        public Championship GetByID(int ID)
        {
            return GetAll().Where(x => x.IdCampionShip == ID).FirstOrDefault();
        }
    }
}
