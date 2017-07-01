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
    public class ClassificationService:Service<Classification>, IClassificationService
    {
        private readonly IClassificationRepository _classification;
        public ClassificationService(IClassificationRepository classification):base(classification)
        {
            _classification = classification;
        }
    }
}
