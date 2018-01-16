using System;
using System.Collections.Generic;
using System.Web;

namespace WechatPayTest01.lib
{
    public class WxPayException : Exception 
    {
        public WxPayException(string msg) : base(msg) 
        {

        }
     }
}