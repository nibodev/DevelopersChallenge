using INFRA.Repository;
using DOMAIN.IRepository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationExpose.Modules
{
    public class RepositoryModules
    {
        public static void RegisterRepositoryServices(IKernel kernel)
        {
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IChampionshipRepository>().To<ChampionshipRepository>();
            kernel.Bind<IClassificationRepository>().To<ClassificationRepository>();
            kernel.Bind<ITeamRepository>().To<TeamRepository>();
            kernel.Bind<IRulesRepository>().To<RulesRepository>();
            kernel.Bind<IPhaseRepository>().To<PhaseRepository>();
        }
    }
}
