using System;

namespace SpeechVoting
{
    //delete
    public abstract class Entity
    {
        public virtual Guid Id => Guid.NewGuid();
    }
}