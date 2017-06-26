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
    public class RulesService:Service<Rules>, IRulesService
    {
        private readonly IRulesRepository _rules;
        public RulesService(IRulesRepository rules):base(rules)
        {
            _rules = rules;
        }
    }
}
