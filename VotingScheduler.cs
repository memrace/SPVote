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

        public VotingTheme Create(string title)
        {
            return _votingTheme = new VotingTheme(title, _votingHistoryService);
        }

        public void Close()
        {
            _votingTheme.Close();
            _votingTheme = null;
        }

        public void ReOpenVoting()
        {
            _votingTheme.Close();
            _votingTheme.Create();
        }

        public void Prolong(int amountDays)
        {
            _votingTheme.ActiveVoting.SetEndDate(_votingTheme.ActiveVoting.EndDate.Value.AddDays(amountDays));
        }

        public void Prolong(DateTime endDate)
        {
            _votingTheme.ActiveVoting.SetEndDate(endDate);
        }

        private void CloseAuto() 
        {
           
        }
        private void CreateAuto() 
        {
        
        }
        private void ProlongAuto()
        { 
        
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