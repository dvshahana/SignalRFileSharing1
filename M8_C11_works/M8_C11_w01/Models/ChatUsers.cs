using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M8_C11_w01.Models
{
    public class ChatUsers
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string LoginTime { get; set; }
        public string ConnectionId { get; set; }
        public virtual ICollection<MessageInfo> MessageInfos { get; set; }
    }
}