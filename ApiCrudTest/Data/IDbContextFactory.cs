namespace ApiCrudTest.Data
{
    public interface IDbContextFactory
    {
        ApiTestDbContext CreateDbContext();
    }
}
