using System;

namespace SpeechVoting
{
	public class VotingEventArgs : EventArgs
	{
		public VotingEventArgs(ActiveVoting activeVoting)
		{
			ActiveVoting = activeVoting ?? throw new ArgumentNullException();
		}

		public ActiveVoting ActiveVoting { get; }
	}
}
