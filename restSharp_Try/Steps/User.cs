using System;
using System.Collections.Generic;
using System.Text;

namespace restSharp_Try.Steps
{
    public class User
    {
        public User[] players { get; set; }    //this gives the list of players
        public string name { get; set; }       //this is for getting the name of the user
        public bool voted { get; set; }        //this is for seeing if the user has voted
        public string title { get; set; }      //this is the Room title
        public string votingStart { get; set; }    //this is the Vote Start status
        public bool closed { get; set; }    //this is for Finish voting
    }
}
