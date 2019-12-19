using System;
using System.Collections.Generic;
using System.Text;

namespace restSharp_Try
{    
    public class Story
    {
        public int id;
        public string title;
        public Story(int id, string title)
        {
            this.id = id;
            this.title = title;
        }
    }
    public class Stories
    {
        public Story[] stories { get; set; }
    }
}
