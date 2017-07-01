using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities
{
    [Table("Classification")]
    public class Classification
    {
        [Key]
        public int IdClassification { get; set; }
        public int IdPlayer { get; set; }
        public int ScoreClassification { get; set; }
    }
}
