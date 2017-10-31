using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GroceryList.Business;
using GroceryList.Data.Queries;

namespace GroceryList.Api
{

    [Route("api/[controller]")]
    public class GroceryListController : Controller
    {
	    private readonly IGrocery _groceryService;

	    public GroceryListController(IGrocery groceryService)
	    {
		    _groceryService = groceryService;
	    }

        // GET API/values
        [HttpGet]
        public List<GroceryItem> GetGroceryList([FromBody] BaseRequest ApiRequest)
        {
//	        ApiRequest = ApiRequest ?? new BaseRequest{ sortField = "last_modified", sortDirection = "ASC"};
//	        ApiRequest = ApiRequest ?? new BaseRequest();


//	        List<GroceryItem> apiGroceryList = _groceryService.GetGroceryList();
	        // Should return list of items from a select query
	        List<GroceryItem> apiGroceryList = _groceryService.GetGroceryList(ApiRequest);
//	        List<GroceryItem> apiGroceryList = ApiRequest == null ? _groceryService.GetGroceryList(): _groceryService.GetGroceryList(ApiRequest);

			return apiGroceryList;
        }

		// Inserts item with quantity or Updates item and quantity
        [HttpPut]
        public void InsertGroceryItem([FromBody] GroceryItem ApiRequest)
        {
			// Null or Empty checks
	        ApiRequest = ApiRequest ?? throw new NullReferenceException("Item object is null");

			// Creates an item or updates an existing item's quantity
			_groceryService.InsertGroceryItem(ApiRequest.name);

	        if (ApiRequest.quantity > 0)
	        {
				// Reduces quantity by one to make up for the 1 added in the initial existence check
		        ApiRequest.quantity--;

				// Adds specified quantity
				_groceryService.AddGroceryItem(ApiRequest);
	        }
	        else
	        {
				// Adds a single item
		        _groceryService.AddGroceryItem(new GroceryItem { name = ApiRequest.name, quantity = 1 });
	        }
        }

		 // DELETE API/values/5
        [HttpDelete]
        public void DeleteGroceryItem([FromBody] GroceryItem ApiRequest)
        {
			// Null or Empty checks
	        ApiRequest = ApiRequest ?? throw new NullReferenceException("string is null");

	        if (ApiRequest.quantity != 0)
	        {
				// Removes quantity specified in http Put request
		        _groceryService.RemoveGroceryItem(ApiRequest);
	        }
	        else
	        {
				// Removes entire item and its quantity from the list
				_groceryService.DeleteGroceryItem(ApiRequest.name);
	        }
        }
    }
}
