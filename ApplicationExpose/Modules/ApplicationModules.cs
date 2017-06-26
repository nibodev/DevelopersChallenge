using ApplicationExpose.App;
using ApplicationExpose.IApp;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationExpose.Modules
{
    public class ApplicationModules
    {
        public static void RegisterApplicationServices(IKernel kernel)
        {
            kernel.Bind(typeof(IApplication<>)).To(typeof(Application<>));
            kernel.Bind<IChampionshipApp>().To<ChampionshipApp>();
            kernel.Bind<IClassificationApp>().To<ClassificationApp>();
            kernel.Bind<ITeamApp>().To<TeamApp>();
            kernel.Bind<IRulesApp>().To<RulesApp>();
            kernel.Bind<IPhaseApp>().To<PhaseApp>();
        }
    }
}
