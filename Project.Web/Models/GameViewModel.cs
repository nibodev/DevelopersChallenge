using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Web.Models
{
    public class GameViewModelCreate
    {
        public int TeamFirstId { get; set; }
        public int TeamSecondId { get; set; }
    }

    public class GameViewModelSaveResult
    {
        public int TeamId { get; set; }
        public int TeamRelationShipId { get; set; }
    }

    public class ConsultAllTeamViewModel
    {
        public int TeamId { get; set; }
        public string  Name { get; set; }
        public string NameA { get; set; }
        public int  FirstTeamId { get; set; }
        public string NameB { get; set; }
        public int SecondTeamId { get; set; }
        public string Key { get; set; }
    }
}