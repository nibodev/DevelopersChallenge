using MataMata.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MataMata.TratamentotoMensagens
{
    public class Mensagens
    {
        public string messages { get; set; }
        public TypeMessage MsgType { get; set; }

        public static Mensagens _Mensagens;

        public static void SetMessage(string Mensagem, TypeMessage TipoMSG)
        {
            _Mensagens = new Mensagens()
            {
                messages = Mensagem,
                MsgType = TipoMSG,
            };
        }


    }
}