using System.Collections.Generic;

namespace GroceryList
{
    public interface IGrocery
    {
        List<GroceryItem> GetGroceryList();

        void InsertGroceryItem(string item, int quantity);

	    void DeleteGroceryItem(string item, int quantity);
    }
}
