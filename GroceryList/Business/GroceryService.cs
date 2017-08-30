using System.Collections.Generic;
using GroceryList.Data;

namespace GroceryList.Business
{

    public class GroceryService : IGroceryService
    {
        private readonly IGroceryRepository _groceryRepository;

        public GroceryService(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }

		public List<GroceryItem> GetGroceryList()
		{
			List<GroceryItem> businessGroceryList = _groceryRepository.GetGroceryList();

            return businessGroceryList;
        }

		public void InsertGroceryItem(string name)
        {
	        _groceryRepository.InsertGroceryItem(name);
        }

        public void UpdateGroceryItem(GroceryItem name)
        {
	        _groceryRepository.UpdateGroceryItem(name);
        }

		public void DeleteGroceryItem(string item)
		{
			_groceryRepository.DeleteGroceryItem(item);
		}

		public void DeleteGroceryItem(GroceryItem Item)
		{
			_groceryRepository.DeleteGroceryItem(Item);
		}
    }
}
