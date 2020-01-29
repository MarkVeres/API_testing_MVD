using System;
using System.Collections.Generic;
using System.Text;

namespace restSharp_Try.Steps
{
    public class CurrentStory //this class is for Current Story Information only
    {
        public string title { get; set; }
        public int votingDuration { get; set; } //NEVER use this parameter; because of API test speed, this will always be 0
                                                //only in debbuging mode does it receive real time values
        public string votingStart { get; set; }

        public string GetVotingStart()
        {
            return votingStart;
        }
    }
}
