using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GroceryList.Business;
using Microsoft.AspNetCore.Razor.Chunks;

namespace GroceryList.Controllers
{

    [Route("api/[controller]")]
//    public class GroceryListController : Controller, IGroceryController
    public class GroceryListController : Controller
    {
	    private readonly IGroceryService _groceryService;

	    public GroceryListController(IGroceryService groceryService)
	    {
		    _groceryService = groceryService;
	    }

        // GET API/values
        [HttpGet]
        public List<GroceryItem> GetGroceryList()
        {
	        // Should return list of items from a select query
	        List<GroceryItem> controllerGroceryList = _groceryService.GetGroceryList();

			return controllerGroceryList;
        }

		// Inserts item with quantity or Updates item and quantity
        [HttpPut]
        public void PutGroceryItem([FromBody]GroceryItem Item)
        {
			// Null or Empty checks
	        Item = Item ?? throw new NullReferenceException("Item object is null");

				// Creates an item or updates an existing item's quantity
				_groceryService.InsertGroceryItem(Item.Name);

				_groceryService.UpdateGroceryItem(Item);

        }

		 // DELETE API/values/5
        [HttpDelete]
        public void DeleteGroceryItem([FromBody]GroceryItem Item)
        {
			// Null or Empty checks
	        Item = Item ?? throw new NullReferenceException("Item Object is null");

	        if (Item.Quantity != 0)
	        {
				// Removes a specific quantity of an item
				_groceryService.DeleteGroceryItem(Item);
	        }
	        else
	        {
				// Removes entire item and its quantity from the list
				_groceryService.DeleteGroceryItem(Item.Name);
	        }

        }
    }
}
