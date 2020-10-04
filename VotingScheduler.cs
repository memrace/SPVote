using System;

namespace SpeechVoting
{
    public class VotingScheduler
    {
        public event EventHandler<VotingEventArgs> VotingClosed;
        public event EventHandler<VotingEventArgs> VotingExpiringSoon;
        public event EventHandler<VotingEventArgs> VotingCreated;
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
            _votingTheme.ActiveVoting.Prolong(_votingTheme.ActiveVoting.EndDate.Value.AddDays(amountDays));
        }

        public void ProlongForce(DateTime endDate)
        {
            _votingTheme.ActiveVoting.Prolong(endDate);
        }

        public void OnVotingClose(VotingEventArgs e)
		{
            VotingClosed?.Invoke(this, e);
		}

        public void OnVotingCreate(VotingEventArgs e)
		{
            VotingCreated?.Invoke(this, e);
		}

        public void OnVotingExpiringSoon(VotingEventArgs e)
		{
            VotingExpiringSoon?.Invoke(this, e);
		}
    }
}