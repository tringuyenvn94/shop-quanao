using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shop_quanao.COMM
{
    public class DataNavigatorEventArgs : EventArgs
    {
        public DataNavigatorEventArgs() { }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}