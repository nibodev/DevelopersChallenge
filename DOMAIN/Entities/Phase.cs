using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities
{
    [Table("Phase")]
    public class Phase
    {
        [Key]
        public int IdPhase { get; set; }
        public string Name { get; set; }
    }
}
