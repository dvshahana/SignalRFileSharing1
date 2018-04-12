using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M8_C11_w01.Models 
{
    public class RequestInfo
    {
    public  int Id {get;set;}
    public string	GroupName {get;set;}
    public string	ReqDateTime {get;set;}
	public string UserName {get;set;}
	public   bool Approved{get;set;}
    }
}