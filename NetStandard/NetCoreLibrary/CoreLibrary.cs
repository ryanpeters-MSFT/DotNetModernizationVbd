using NetStandard20Library;
using System.Data.SqlClient;

namespace NetCoreLibrary
{
    public class CoreLibrary
    {
        public SharedLibrary GetLibrary()
        {
            var client = new HttpClient();
            var connection = new SqlConnection();

            var testLibrary = new SharedLibrary(client, connection);

            return testLibrary;
        }
    }
}