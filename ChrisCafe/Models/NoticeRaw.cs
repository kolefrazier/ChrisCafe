using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChrisCafe.Models
{
    //Serializable clasas, for JSON->Obj conversion
    public class NoticeRaw
    {
        public int Month { get; set; }
        public int Day { get; set; }
        public string StyleClass { get; set; }
        public string[] Messages { get; set; }
        public string IconLeft { get; set; }
        public string IconRight { get; set; }
    }
}
