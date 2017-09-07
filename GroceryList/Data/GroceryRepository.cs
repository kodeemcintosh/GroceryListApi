using System;
using System.Collections.Generic;
using GroceryList.Data.Queries;

namespace GroceryList.Data
{
    public class GroceryRepository : IGrocery
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

        public List<GroceryItem> GetGroceryList(BaseRequest DataRequest)
        {
	        List<GroceryItem> dataGroceryList = _getGroceryList.GetGroceryListQuery(DataRequest);

	        return dataGroceryList;
        }

	    public void InsertGroceryItem(string name)
	    {
		    _insertGroceryItem.InsertGroceryItemQuery(name);
	    }

		public void AddGroceryItem(GroceryItem DataRequest)
	    {
		    _updateGroceryItem.AddGroceryItemQuery(DataRequest);
	    }
	    public void RemoveGroceryItem(GroceryItem DataRequest)
	    {
		    _deleteGroceryItem.RemoveGroceryItemQuery(DataRequest);
	    }
	    public void DeleteGroceryItem(string name)
	    {
		    _deleteGroceryItem.DeleteGroceryItemQuery(name);
	    }

    }
}
