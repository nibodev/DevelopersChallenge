using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Dto
{
    public class TeamAndTeamRelation
    {
        public string NameA { get; set; }
        public string NameB { get; set; }
        public int FirstId { get; set; }
        public int SecondId { get; set; }
        public int TeamRelationshipId { get; set; }
    }
}
