using System;
using System.Collections.Generic;
using System.Text;

namespace restSharp_Try.Steps
{
    public class CurrentStory
    {
        public string title { get; set; }
        public string votingStart { get; set; }

        public string GetVotingStart()
        {
            return votingStart;
        }
    }
}
