using System.Collections.Generic;
using GroceryList.Data.Map;
using Npgsql;

namespace GroceryList.Data.Queries
{
    public class GetGroceryList
    {
	    private readonly IDataMapper _dataMapper;
	    public GetGroceryList(IDataMapper dataMapper)
	    {
		    _dataMapper = dataMapper;
	    }

		//	TODO: replace connection string local variables with environment variables
	    private const string SERVER = "localhost";
	    private const string DATABASE = "GroceryListDB";
	    private const string USER = "kwik";
	    private const string PASSWORD = "pNyn8_5E";
	    private static string GetConnectionString()
	    {
		    var csBuilder = new NpgsqlConnectionStringBuilder()
		    {
			    Host = SERVER,
			    Database = DATABASE,
			    Username = USER,
			    Password = PASSWORD
		    };

		    return csBuilder.ConnectionString;
	    }

	    public List<GroceryItem> GetGroceryListQuery()
		{
			string connectionString = GetConnectionString();
			NpgsqlConnection conn = new NpgsqlConnection(connectionString);
			conn.Open();

			// Define Query
			var sql = "SELECT * FROM GroceryItems;";
			NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

			// Execute Query
			NpgsqlDataReader dataReader = cmd.ExecuteReader();
			List<GroceryItem> groceryList = new List<GroceryItem>();

//			try
//			{
			groceryList = _dataMapper.GetGroceryItemsMapper(dataReader);
//			}
//			catch (NpgsqlException e)
//			{
//				Console.WriteLine(e);
//				throw;
//			}
//			finally
//			{
//				Console.WriteLine("Closing connections");
			conn.Close();
//			}

		    return groceryList;
	    }
    }
}
