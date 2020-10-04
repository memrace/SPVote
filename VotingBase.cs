using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeechVoting
{
    public abstract class VotingBase: Entity
    {
        public abstract DateTime? StartDate {  get; protected set; }
        public abstract DateTime? EndDate { get; protected set; }
        public abstract Dictionary<Speech, List<UserProfile>> VoteMap { get; }

        protected VotingBase(): base()
		{
		}
        protected VotingBase(Guid id): base(id)
		{

		}
        public Speech GetWinner()
        {
            var maxVote = VoteMap.Max(pair => pair.Value.Count);
            if (VoteMap.Count(pair => pair.Value.Count == maxVote) > 1)
            {
                return null;
            }
            return VoteMap.First(pair => pair.Value.Count == maxVote).Key;
        }
    }
}