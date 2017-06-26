using ApplicationExpose.IApp;
using DOMAIN.IServiceBase;
using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationExpose.App
{
    public class RulesApp : Application<Rules>, IRulesApp
    {
        private readonly IRulesService _rules;
        public RulesApp(IRulesService rules) : base(rules)
        {
            _rules = rules;
        }
    }
}
