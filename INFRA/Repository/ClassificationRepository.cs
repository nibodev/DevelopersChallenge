using DOMAIN.Entities;
using DOMAIN.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRA.Repository
{
    public class ClassificationRepository : RepositoryBase<Classification>, IClassificationRepository
    {
        public Classification GetByID(int ID)
        {
            return GetAll().Where(x => x.IdClassification == ID).FirstOrDefault();
        }
    }
}
