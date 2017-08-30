using System;
using System.Collections.Generic;
using GroceryList.Data.Queries;

namespace GroceryList.Data
{
    public class GroceryRepository : IGroceryRepository
    {
	    private readonly GetGroceryList _getGroceryList;
	    private readonly InsertGroceryItem _insertGroceryItem;
	    private readonly UpdateGroceryItem _updateGroceryItem;
	    private readonly DeleteGroceryItem _deleteGroceryItem;

	    public GroceryRepository(GetGroceryList getGroceryList, InsertGroceryItem insertGroceryItem,UpdateGroceryItem updateGroceryItem, DeleteGroceryItem deleteGroceryItem)
	    {
		    _getGroceryList = getGroceryList ?? throw new ArgumentNullException(nameof(getGroceryList));
		    _insertGroceryItem = insertGroceryItem ?? throw new ArgumentNullException(nameof(insertGroceryItem));
		    _updateGroceryItem = updateGroceryItem ?? throw new ArgumentNullException(nameof(updateGroceryItem));
		    _deleteGroceryItem = deleteGroceryItem ?? throw new ArgumentNullException(nameof(deleteGroceryItem));
	    }

        public List<GroceryItem> GetGroceryList()
        {
	        List<GroceryItem> dataGroceryList = _getGroceryList.GetGroceryListQuery();

	        return dataGroceryList;
        }

	    public void InsertGroceryItem(string name)
	    {

		    _insertGroceryItem.InsertGroceryItemQuery(name);
	    }

		public void UpdateGroceryItem(GroceryItem Item)
	    {
		    _updateGroceryItem.UpdateGroceryItemQuery(Item);
	    }

	    public void DeleteGroceryItem(string name)
	    {
		    _deleteGroceryItem.DeleteGroceryItemQuery(name);
	    }

	    public void DeleteGroceryItem(GroceryItem Item)
	    {
		    _deleteGroceryItem.DeleteGroceryItemQuery(Item);
	    }
    }
}
