using Xunit;

namespace WebApi.EndToEndTests
{
    [CollectionDefinition("DatabaseCollectionFixture")]
    public class DatabaseCollectionFixture : ICollectionFixture<DataBaseFixture>
    {
    }
}
