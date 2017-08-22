using System;
using System.Collections.Generic;
using GroceryList.Data.Queries;

namespace GroceryList.Data
{
    public class GroceryRepository : IGrocery
    {
	    private readonly GetGroceryList _getGroceryList;
	    private readonly InsertGroceryItem _insertGroceryItem;
	    private readonly DeleteGroceryItem _deleteGroceryItem;

	    public GroceryRepository(GetGroceryList getGroceryList, InsertGroceryItem insertGroceryItem, DeleteGroceryItem deleteGroceryItem)
	    {
		    _getGroceryList = getGroceryList ?? throw new ArgumentNullException(nameof(getGroceryList));
		    _insertGroceryItem = insertGroceryItem ?? throw new ArgumentNullException(nameof(insertGroceryItem));
		    _deleteGroceryItem = deleteGroceryItem ?? throw new ArgumentNullException(nameof(deleteGroceryItem));
	    }

        public List<GroceryItem> GetGroceryList()
        {
	        List<GroceryItem> dataGroceryList = _getGroceryList.GetGroceryListQuery();

	        return dataGroceryList;
        }

	    public void InsertGroceryItem(string item, int quantity)
	    {
		    _insertGroceryItem.InsertGroceryItemQuery(item, quantity);
	    }

	    public void DeleteGroceryItem(string item, int quantity)
	    {
		    _deleteGroceryItem.DeleteGroceryItemQuery(item, quantity);
	    }
    }
}
