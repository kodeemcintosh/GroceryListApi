using System.Collections.Generic;

namespace GroceryList
{
    public interface IGroceryRepository
    {
        List<GroceryItem> GetGroceryList();

        void InsertGroceryItem(string item);

        void UpdateGroceryItem(GroceryItem Item);

	    void DeleteGroceryItem(string name);

	    void DeleteGroceryItem(GroceryItem Item);
    }
}
