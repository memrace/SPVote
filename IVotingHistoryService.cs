using System.Collections.Generic;

namespace SpeechVoting
{
    public interface IVotingHistoryService
    {
        public IEnumerable<ClosedVoting> GetClosedVotings();
        public void Close(ClosedVoting voting);
    }
}