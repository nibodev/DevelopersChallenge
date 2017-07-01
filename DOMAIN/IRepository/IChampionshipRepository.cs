using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.IRepository
{
    public interface IChampionshipRepository : IRepositoryBase<Championship>
    {
        Championship GetByID(int ID);
    }
}
