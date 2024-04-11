using NetStandard20Library;
using System.Data.SqlClient;
using System.Net.Http;

namespace FrameworkLibrary
{
    public class FrameworkLibrary
    {
        public SharedLibrary GetLibrary()
        {
            var client = new HttpClient();
            var connection = new SqlConnection();

            // this line will break unless I reference the (NetStandard2.0) version of System.Data.SqlClient.SqlClient in a nuget package
            var testLibrary = new SharedLibrary(client, connection);

            return testLibrary;
        }
    }
}
