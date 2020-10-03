using System;
using System.Collections.Generic;

namespace SpeechVoting
{
    public class ClosedVoting: VotingBase
    {
        public ClosedVoting(DateTime? startDate, DateTime? endDate, Dictionary<Speech, List<UserProfile>> voteMap)
        {
            StartDate = startDate;
            EndDate = endDate;
            VoteMap = voteMap;
        }

        public sealed override DateTime? StartDate { get; protected set; }

        public sealed override DateTime? EndDate { get; protected set; }
        public sealed override Dictionary<Speech, List<UserProfile>> VoteMap { get; }
    }
}