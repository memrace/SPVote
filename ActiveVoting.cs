using System;
using System.Collections.Generic;

namespace SpeechVoting
{
    public class ActiveVoting: VotingBase
    {
        public sealed override DateTime? StartDate { get; protected set; }
        public sealed override DateTime? EndDate { get; protected set; } 
        public sealed override Dictionary<Speech, List<UserProfile>> VoteMap { get; }
        public ActiveVoting()
        {
            StartDate = null;
            EndDate = null;
        }
        internal void AddSpeech(Speech speech)
        {
            VoteMap.Add(speech, new List<UserProfile>());
        }

        internal void RemoveSpeech(Speech speech)
        {
            VoteMap.Remove(speech);
        }

        internal void Vote(Speech speech, UserProfile profile)
        {
            VoteMap[speech].Add(profile);
        }

        internal void SetStartDate(DateTime startDate)
        {
            StartDate = startDate;
        }

        internal void Prolong(DateTime endDate)
        {
            EndDate = endDate;
        }

    }
}