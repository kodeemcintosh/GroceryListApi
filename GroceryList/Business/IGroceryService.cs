using System.Collections.Generic;

namespace GroceryList
{
    public interface IGroceryService
    {
        List<GroceryItem> GetGroceryList();

        void InsertGroceryItem(string name);

        void UpdateGroceryItem(GroceryItem Item);

	    void DeleteGroceryItem(string name);

	    void DeleteGroceryItem(GroceryItem Item);
    }
}
