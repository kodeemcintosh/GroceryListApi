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

				_groceryService.UpdateGroceryItem(ApiRequest);

        }

		 // DELETE API/values/5
        [HttpDelete]
        public void DeleteGroceryItem([FromBody] GroceryItem ApiRequest)
        {
			// Null or Empty checks
	        ApiRequest = ApiRequest ?? throw new NullReferenceException("Item Object is null");

	        if (ApiRequest.quantity != 0)
	        {
				// Removes a specific quantity of an item
				_groceryService.DeleteGroceryItem(ApiRequest);
	        }
	        else
	        {
				// Removes entire item and its quantity from the list
				_groceryService.DeleteGroceryItem(ApiRequest.name);
	        }

        }
    }
}
