using ApplicationExpose.IApp;
using DOMAIN.Entities;
using DOMAIN.IServiceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationExpose.App
{
    public class PhaseApp : Application<Phase>, IPhaseApp
    {
        private readonly IPhaseService _phase;
        public PhaseApp(IPhaseService phase) : base(phase)
        {
            _phase = phase;
        }
    }
}
