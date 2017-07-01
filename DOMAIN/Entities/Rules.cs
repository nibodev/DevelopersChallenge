using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities
{
    [Table("Rules")]
    public class Rules
    {
        [Key]
        public int IdRules { get; set; }
        public int MaxScore { get; set; }
        public int MinScore { get; set; }
        public int NumberOfPaticipants { get; set; }
        public int NumberOfStages { get; set; }

        public bool validationNumberOfListRules(List<Rules> lRules)
        {
            if (lRules.Count == 1)
            {
                return true;
            }
            return false;
        }

        public bool ValidationNumberOfParticipants(int CountRegister)
        {
            if (CountRegister <= NumberOfPaticipants)
            {
                return true;
            }
            return false;
        }

        public bool ValidationNumberOfStages(int CountRegister)
        {
            if (CountRegister <= NumberOfStages)
            {
                return true;
            }
            return false;
        }
    }
}
