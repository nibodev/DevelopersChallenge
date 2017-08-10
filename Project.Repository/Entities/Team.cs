using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Entities
{
    [Table("Team")]
    public class Team
    {
        [Key]
        [Column("TeamId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Key")]
        public string Key { get; set; }

        public virtual ICollection<Deleted> Deleted { get; set;}
    }
}
