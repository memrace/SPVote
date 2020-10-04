using System;
using System.Collections.Generic;

namespace SpeechVoting
{
    public class VotingTheme
    {
		private readonly IVotingHistoryService _votingHistoryService;

        public VotingTheme(string title, IVotingHistoryService votingHistoryService)
        {
            Title = title;
            _votingHistoryService = votingHistoryService;
            Create();
        }

        public string Title { get; }
        public Speech Winner => ActiveVoting.GetWinner();
        public IEnumerable<Speech> Speeches => ActiveVoting.VoteMap.Keys;
		public ActiveVoting ActiveVoting { get; private set; }
		public IEnumerable<ClosedVoting> ClosedVotings => _votingHistoryService.GetClosedVotings();

        internal void Create()
        {
            if (ActiveVoting != null)
            {
                throw new Exception("Активное голосование уже существует.");
            }
            ActiveVoting = new ActiveVoting();
        }

        internal void Close()
        {
            _votingHistoryService.Close(new ClosedVoting(ActiveVoting.StartDate, ActiveVoting.EndDate, ActiveVoting.VoteMap));
            ActiveVoting = null;
        }

        public void AddSpeech(Speech speech)
        {
            ActiveVoting.AddSpeech(speech);
        }

        public void RemoveSpeech(Speech speech)
        {
            ActiveVoting.RemoveSpeech(speech);
        }

        public void Vote(Speech speech, UserProfile profile)
        {
            ActiveVoting.Vote(speech, profile);
        }

    }
}