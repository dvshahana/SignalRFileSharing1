using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M8_C11_w01.Models
{
    public class MessageInfo
    {
        public int Id { get; set; }
        public string MessageBody { get; set; }
        public string PostDateTime { get; set; }
        
        public string UserName { get; set; }

        
    }
}