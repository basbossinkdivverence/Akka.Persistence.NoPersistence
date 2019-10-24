using Akka.Actor;
using Akka.Persistence.Journal;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace Akka.Persistence.NoPersistence
{
    public class EmptyJournal : AsyncWriteJournal
    {
        public override Task ReplayMessagesAsync(
            IActorContext context, 
            string persistenceId, 
            long fromSequenceNr, 
            long toSequenceNr, 
            long max,
            Action<IPersistentRepresentation> recoveryCallback)
        {
            return Task.CompletedTask;
        }

        public override Task<long> ReadHighestSequenceNrAsync(string persistenceId, long fromSequenceNr)
        {
            return Task.FromResult(0L);
        }

        protected override Task<IImmutableList<Exception>> WriteMessagesAsync(IEnumerable<AtomicWrite> messages)
        {
            return Task.FromResult(ImmutableList<Exception>.Empty as IImmutableList<Exception>);
        }

        protected override Task DeleteMessagesToAsync(string persistenceId, long toSequenceNr)
        {
            return Task.CompletedTask;
        }
    }
}
