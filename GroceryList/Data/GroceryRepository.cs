using System;
using System.Collections.Generic;
using GroceryList.Data.Queries;

namespace GroceryList.Data
{
    public class GroceryRepository : IGrocery
    {
	    private readonly GetGroceryList _getGroceryList;
	    private readonly CreateGroceryItem _createGroceryItem;
	    private readonly UpdateGroceryList _updateGroceryList;
	    private readonly RemoveGroceryItem _removeGroceryItem;
	    private readonly DeleteGroceryItem _deleteGroceryItem;

	    public GroceryRepository(GetGroceryList getGroceryList, CreateGroceryItem createGroceryItem,UpdateGroceryList updateGroceryList,RemoveGroceryItem removeGroceryItem, DeleteGroceryItem deleteGroceryItem)
	    {
		    _getGroceryList = getGroceryList ?? throw new ArgumentNullException(nameof(getGroceryList));
		    _createGroceryItem = createGroceryItem ?? throw new ArgumentNullException(nameof(createGroceryItem));
		    _updateGroceryList = updateGroceryList ?? throw new ArgumentNullException(nameof(updateGroceryList));
		    _removeGroceryItem = removeGroceryItem ?? throw new ArgumentNullException(nameof(removeGroceryItem));
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

	    public void CreateGroceryItem(GroceryItem DataRequest)
	    {
		    if (!_createGroceryItem.CheckExistence(DataRequest.name))
		    {
				_createGroceryItem.CreateGroceryItemQuery(DataRequest);
		    }
	    }

		public void UpdateGroceryList(GroceryItem DataRequest)
	    {
		    if (_createGroceryItem.CheckExistence(DataRequest.name))
		    {
				_updateGroceryList.UpdateGroceryListQuery(DataRequest);
				return;
		    }
			_createGroceryItem.CreateGroceryItemQuery(DataRequest);
	    }
	    public void RemoveGroceryItem(GroceryItem DataRequest)
	    {
		    _removeGroceryItem.RemoveGroceryItemQuery(DataRequest);
	    }
	    public void DeleteGroceryItem(string name)
	    {
		    _deleteGroceryItem.DeleteGroceryItemQuery(name);
	    }
    }
}
