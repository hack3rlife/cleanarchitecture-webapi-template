using Xunit;

namespace Infrastructure.IntegrationTests
{
    [CollectionDefinition("DatabaseCollectionFixture")]
    public class DatabaseCollectionFixture : ICollectionFixture<DatabaseFixture>
    {
    }
}
