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
    public class ClassificationApp:Application<Classification>, IClassificationApp
    {
        private readonly IClassificationService _classification;
        public ClassificationApp(IClassificationService classification):base(classification)
        {
            _classification = classification;
        }
    }
}
