using System.Collections.Generic;

namespace GroceryList
{
    public interface IGrocery
    {
        List<GroceryItem> GetGroceryList();

        List<GroceryItem> GetGroceryList(BaseRequest Request);

        void CreateGroceryItem(GroceryItem Request);

        void UpdateGroceryList(GroceryItem Request);

        void RemoveGroceryItem(GroceryItem Request);

	    void DeleteGroceryItem(string request);

    }
}
