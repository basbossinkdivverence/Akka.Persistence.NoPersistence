using System.Threading.Tasks;
using Akka.Persistence.Snapshot;

namespace Akka.Persistence.NoPersistence
{
    public class EmptySnapshotStore : SnapshotStore
    {
        protected override Task<SelectedSnapshot> LoadAsync(string persistenceId, SnapshotSelectionCriteria criteria)
        {
            return Task.FromResult<SelectedSnapshot>(null);
        }

        protected override Task SaveAsync(SnapshotMetadata metadata, object snapshot)
        {
            return Task.CompletedTask;
        }

        protected override Task DeleteAsync(SnapshotMetadata metadata)
        {
            return Task.CompletedTask;
        }

        protected override Task DeleteAsync(string persistenceId, SnapshotSelectionCriteria criteria)
        {
            return Task.CompletedTask;
        }
    }
}