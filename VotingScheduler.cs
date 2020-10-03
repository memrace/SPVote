using System;

namespace SpeechVoting
{
    public class VotingScheduler
    {
        private IVotingHistoryService _votingHistoryService;
        private VotingTheme _votingTheme;
        public VotingScheduler(IVotingHistoryService votingHistoryService)
        {
            _votingHistoryService = votingHistoryService;
        }

        public VotingTheme CreateForce(string title)
        {
            return _votingTheme = new VotingTheme(title, _votingHistoryService);
        }

        public void CloseForce()
        {
            _votingTheme.Close();
            _votingTheme = null;
        }

        public void ReOpenVoting()
        {
            _votingTheme.Close();
            _votingTheme.Create();
        }

        public void ProlongForce(int amountDays)
        {
            _votingTheme.ActiveVoting.Prolong(amountDays);
        }

        public void ProlongForce(DateTime endDate)
        {
            _votingTheme.ActiveVoting.Prolong(endDate);
        }
    }
}