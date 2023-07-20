using System.Data;

namespace Base.Core
{
    public interface IDapperContext : IDisposable, IAsyncDisposable
    {
         IDbConnection CreateConnection();
    }
}