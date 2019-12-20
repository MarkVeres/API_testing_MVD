using System;
using System.Collections.Generic;
using System.Text;

namespace restSharp_Try.Steps
{
    public class User
    {
        public string name { get; set; }
        public bool voted { get; set; }
        public User(string name, bool voted)
        {
            this.name = name;
            this.voted = voted;
        }
        public class Players
        {
            public User[] players { get; set; }
        }
    }
}
