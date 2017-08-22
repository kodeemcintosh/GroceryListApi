using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace GroceryList.Data.Map
{
    public interface IDataMapper
    {
	    List<GroceryItem> GetGroceryItemsMapper(NpgsqlDataReader dataReader);

    }
}
