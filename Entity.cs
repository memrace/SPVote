using System;

namespace SpeechVoting
{
    //delete
    public abstract class Entity
    {
        public virtual Guid Id { get; protected set; }

        protected Entity()
		{
            Id = Guid.NewGuid();
		}
         protected Entity(Guid id)
		{
            Id = id;
		}
    }
}