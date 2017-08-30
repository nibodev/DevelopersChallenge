using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Entities
{
    [Table("Deleted")]
    public class Deleted
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DeletedId")]
        public int DeletedId { get; set; }

        //Id do time perdedor
        [Column("TeamId")]
        public int TeamId { get; set; }

        //ID dos times que se enfrentaram
        [Column("TeamRelationshipId")]
        public int TeamRelationshipId { get; set; }
    }
}
