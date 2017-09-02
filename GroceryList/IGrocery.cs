using System.Collections.Generic;

namespace GroceryList
{
    public interface IGrocery
    {
        List<GroceryItem> GetGroceryList();

        List<GroceryItem> GetGroceryList(BaseRequest Request);

        void InsertGroceryItem(string request);

        void UpdateGroceryItem(GroceryItem Request);

	    void DeleteGroceryItem(string request);

	    void DeleteGroceryItem(GroceryItem Request);
    }
}
