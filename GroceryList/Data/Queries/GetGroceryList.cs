using System;
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
//			    Host = Environment.GetEnvironmentVariable("GL_HOST"),
//			    Database = Environment.GetEnvironmentVariable("GL_DATABASE"),
//			    Username = Environment.GetEnvironmentVariable("GL_USER"),
//			    Password = Environment.GetEnvironmentVariable("GL_PASSWORD")
				Host = SERVER,
			    Database = DATABASE,
			    Username = USER,
			    Password = PASSWORD
		    };

		    return csBuilder.ConnectionString;
	    }

	    public List<GroceryItem> GetGroceryListQuery()
	    {

			// Create and open database connection
			string connectionString = GetConnectionString();
			NpgsqlConnection conn = new NpgsqlConnection(connectionString);
			conn.Open();

			// Define Query
			var sql = "SELECT * FROM GroceryItems " +
			          "WHERE 1 = 1 " +
			          "ORDER BY last_modified ASC NULLS LAST;";
			NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

			// Execute Query
			NpgsqlDataReader dataReader = cmd.ExecuteReader();

			List<GroceryItem> groceryList = new List<GroceryItem>();

			groceryList = _dataMapper.GetGroceryItemsMapper(dataReader);

			conn.Close();

		    return groceryList;
	    }

	    public List<GroceryItem> GetGroceryListQuery(BaseRequest Request)
	    {

		    Request = Request ?? new BaseRequest
		    {
			    sortField = "name",
			    sortDirection = "asc"
		    };

   			// Create and open database connection
			string connectionString = GetConnectionString();
			NpgsqlConnection conn = new NpgsqlConnection(connectionString);
			conn.Open();

			// Define Query
			// could not parameterize for ORDER BY forcing me to use string interpolation
		    var sql = "SELECT * FROM GroceryItems " +
		              "WHERE 1 = 1 " +
		              $"ORDER BY {Request.sortField} {Request.sortDirection} NULLS LAST;";

			NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

			// Execute Query
			NpgsqlDataReader dataReader = cmd.ExecuteReader();

//			List<GroceryItem> groceryList = new List<GroceryItem>();
			List<GroceryItem> groceryList = _dataMapper.GetGroceryItemsMapper(dataReader);

			conn.Close();

		    return groceryList;
	    }
    }
}
