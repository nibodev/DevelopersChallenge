using DOMAIN.Entities;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRA.Context
{
    public class DBContext<T> : DbContext, IDisposable where T : class
    {

        public DBContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\ProvaMataMata.mdf;Integrated Security=True")
        {

        }
        public DbSet<T> _Entities { get; set; }


    }
}
