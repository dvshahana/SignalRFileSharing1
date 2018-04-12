using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using M8_C11_w01.Models;

namespace M8_C11_w01
{
    public class MyHub : Hub
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Send(string  msg)
        {
            string gName = db.RequestInfos.Where(u => u.UserName.Equals(Context.User.Identity.Name)).SingleOrDefault().GroupName;
            var messInfo = new MessageInfo
            {
                UserName = Context.User.Identity.Name,
                 MessageBody=msg,
                 PostDateTime=DateTime.Now.ToString()
            };
            db.MessageInfos.Add(messInfo);
            if(db.SaveChanges()>0)
            {
                Groups.Add(Context.ConnectionId, gName);
                Clients.OthersInGroup(gName).Received(messInfo.UserName,msg);
                Clients.Caller.Received("You", msg);
            }
            
        }
    }
}