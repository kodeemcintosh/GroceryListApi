using System;
using System.Collections.Generic;
using Npgsql;

namespace GroceryList.Data.Map
{
    public class DataMapper : IDataMapper
    {
	    public List<GroceryItem> GetGroceryItemsMapper(NpgsqlDataReader dataReader)
	    {
			List<GroceryItem> groceryList = new List<GroceryItem>();

		    try
		    {
			    while (dataReader.Read())
			    {
					GroceryItem groceryItem = new GroceryItem
					{
						name = dataReader["NAME"].ToString().ToLower(),
						quantity = (int)dataReader["QUANTITY"]
					};

					groceryList.Add(groceryItem);
			    }
		    }
		    catch (NpgsqlException e)
		    {
			    Console.WriteLine(e);
			    throw;
		    }

			return groceryList;
	    }

    }
}
