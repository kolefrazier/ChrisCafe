using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChrisCafe.Models.ViewModels
{
    //View model passed to /Home/Index for a given notice. 
    //  Intentionally does not have all properties used in the serializable version (NoticeRaw.cs) 
    //      to discourage use of some variables on the frontend.
    public class Notice
    {
        public Notice(string styleClass, string[] messages, string iconLeft, string iconRight)
        {
            StyleClass = styleClass;
            Messages = messages;
            IconLeft = iconLeft;
            IconRight = iconRight;
        }
        public string StyleClass { get; private set; }
        public string[] Messages { get; private set; }
        public string IconLeft { get; private set; }
        public string IconRight { get; private set; }
    }
}
