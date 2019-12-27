using System;
using System.Collections.Generic;
using System.Text;

namespace restSharp_Try
{    
    public class Story  //this one is for story creation since story creation and story info are sepparate APIs
    {
        public Story[] Stories { get; set; }
        public string title { get; set; }
    }    
}
