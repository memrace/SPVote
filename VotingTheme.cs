using System;
using System.Collections.Generic;

namespace SpeechVoting
{
    public class VotingTheme
    {
        private ActiveVoting _activeVoting;
        private readonly IVotingHistoryService _votingHistoryService;

        public VotingTheme(string title, IVotingHistoryService votingHistoryService)
        {
            Title = title;
            _votingHistoryService = votingHistoryService;
            Create();
        }

        public string Title { get; }
        public Speech Winner => _activeVoting.GetWinner();
        public IEnumerable<Speech> Speeches => _activeVoting.VoteMap.Keys;
        public ActiveVoting ActiveVoting => _activeVoting;
        public IEnumerable<ClosedVoting> ClosedVotings => _votingHistoryService.GetClosedVotings();

        internal void Create()
        {
            if (_activeVoting != null)
            {
                throw new Exception("Активное голосование уже существует.");
            }
            _activeVoting = new ActiveVoting();
        }

        internal void Close()
        {
            _votingHistoryService.Close(new ClosedVoting(_activeVoting.StartDate, _activeVoting.EndDate, _activeVoting.VoteMap));
            _activeVoting = null;
        }

        public void AddSpeech(Speech speech)
        {
            _activeVoting.AddSpeech(speech);
        }

        public void RemoveSpeech(Speech speech)
        {
            _activeVoting.RemoveSpeech(speech);
        }

        public void Vote(Speech speech, UserProfile profile)
        {
            _activeVoting.Vote(speech, profile);
        }

    }
}