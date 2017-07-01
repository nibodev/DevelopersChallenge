using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities
{
    [Table("Team")]
    public class Team
    {
        [Key]
        public int IdTeam { get; set; }
        public string Name { get; set; }
       
        
    }
}
