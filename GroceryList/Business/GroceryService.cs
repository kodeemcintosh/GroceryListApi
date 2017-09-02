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

		public List<GroceryItem> GetGroceryList(BaseRequest BusinessRequest)
		{
			List<GroceryItem> businessGroceryList = _groceryRepository.GetGroceryList(BusinessRequest);

            return businessGroceryList;
        }

		public void InsertGroceryItem(string name)
        {
	        _groceryRepository.InsertGroceryItem(name);
        }

        public void UpdateGroceryItem(GroceryItem BusinessRequest)
        {
	        _groceryRepository.UpdateGroceryItem(BusinessRequest);
        }

		public void DeleteGroceryItem(string item)
		{
			_groceryRepository.DeleteGroceryItem(item);
		}

		public void DeleteGroceryItem(GroceryItem BusinessRequest)
		{
			_groceryRepository.DeleteGroceryItem(BusinessRequest);
		}
    }
}
