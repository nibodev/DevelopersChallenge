using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Entities
{
    [Table("TeamRelationship")]
    public class TeamRelationship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TeamRelationshipId")]
        public int TeamRelationshipId { get; set; }

        [Column("TeamFirstId")]
        public int TeamFirstId { get; set; }

        [Column("TeamSecondId")]
        public int TeamSecondId { get; set; }

    }
}
