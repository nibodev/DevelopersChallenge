using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationSummoners.Models
{
    public class Kingdom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Giants { get; set; }//Gigants
        public int Swordsmen { get; set; }//Espadachins
        public int Archers { get; set; }//Arqueiro
        public int Launchers { get; set; }//Lançador
        public int Beaters { get; set; }//Batedores
    }
}