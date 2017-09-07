using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GroceryList.Business;

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
        public List<GroceryItem> GetGroceryList([FromBody] BaseRequest ApiRequest = null)
        {
	        ApiRequest = ApiRequest ?? new BaseRequest();

	        // Should return list of items from a select query
	        List<GroceryItem> apiGroceryList = _groceryService.GetGroceryList(ApiRequest);

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

	        if (ApiRequest.quantity != 0)
	        {
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
        [HttpPut]
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
