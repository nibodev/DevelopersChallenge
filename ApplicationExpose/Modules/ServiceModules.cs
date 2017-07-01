using DOMAIN.IServiceBase;
using DOMAIN.ServiceBase;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationExpose.Modules
{
    public class ServiceModules
    {
        public static void RegisterServiceServices(IKernel kernel)
        {
            kernel.Bind(typeof(IService<>)).To(typeof(Service<>));
            kernel.Bind<IChampionshipService>().To<ChampionshipService>();
            kernel.Bind<IClassificationService>().To<ClassificationService>();
            kernel.Bind<IPlayersService>().To<TeamService>();
            kernel.Bind<IRulesService>().To<RulesService>();
            kernel.Bind<IPhaseService>().To<PhaseService>();
        }
    }
}
