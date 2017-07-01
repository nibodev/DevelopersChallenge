using DOMAIN.Entities;
using DOMAIN.IRepository;
using DOMAIN.IServiceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.ServiceBase
{
    public class PhaseService : Service<Phase>, IPhaseService
    {
        private readonly IPhaseRepository _phase;
        public PhaseService(IPhaseRepository phase):base(phase)
        {
            _phase = phase;
        }
    }
}
