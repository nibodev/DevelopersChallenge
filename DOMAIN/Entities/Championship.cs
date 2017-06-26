using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities
{
    [Table("Championship")]
    public class Championship
    {
        [Key]
        public int IdCampionShip { get; set; }
        public int IdTeam1 { get; set; }
        public string Name1 { get; set; }
        public int IdTeam2 { get; set; }
        public string Name2 { get; set; }



    }
}
