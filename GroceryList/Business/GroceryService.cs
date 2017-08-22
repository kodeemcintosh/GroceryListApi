using System.Collections.Generic;
using GroceryList.Data;

namespace GroceryList.Business
{

    public class GroceryService : IGrocery
    {
        private readonly IGrocery _groceryRepository;

        public GroceryService(IGrocery groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }

		public List<GroceryItem> GetGroceryList()
		{
			List<GroceryItem> businessGroceryList = _groceryRepository.GetGroceryList();

            return businessGroceryList;
        }

        public void InsertGroceryItem(string item, int quantity)
        {
	        _groceryRepository.InsertGroceryItem(item, quantity);
        }

		public void DeleteGroceryItem(string item, int quantity)
		{
			_groceryRepository.DeleteGroceryItem(item, quantity);
		}
    }
}
