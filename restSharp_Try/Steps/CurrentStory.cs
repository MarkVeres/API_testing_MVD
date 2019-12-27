using System;
using System.Collections.Generic;
using System.Text;

namespace restSharp_Try.Steps
{
    public class CurrentStory   //this one is for general Story Information, the other "Story" object is for creating stories ONLY
    {
        public string title { get; set; }

        public int votingDuration { get; set; }
    }
}
