using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GroceryList.Business;
using Microsoft.AspNetCore.Razor.Chunks;

namespace GroceryList.Controllers
{

    [Route("api/[controller]")]
    public class GroceryListController : Controller, IGrocery
    {
	    private readonly IGrocery _groceryService;

	    public GroceryListController(IGrocery groceryService)
	    {
		    _groceryService = groceryService;
	    }

        // GET API/values
        [HttpGet]
        public List<GroceryItem> GetGroceryList()
        {
	        // Should return list of items from a select query
	        List<GroceryItem> controllerGroceryList = _groceryService.GetGroceryList();
//			var controllerGroceryList = new List<GroceryItem>
//			{
//				new GroceryItem
//				{
//					item = "chocolate",
//					quantity = 2
//				}
//			};

	        return controllerGroceryList;
        }

        // PUT API/values/5
//        [HttpPut("/{item:string}/{quantity:int}")]
        [HttpPut]
        public void InsertGroceryItem([FromBody]string item,[FromBody]int quantity)
        {
//			item ?? item :
			// Inserts a new item along with the quantity
			_groceryService.InsertGroceryItem(item, quantity);
        }

        // DELETE API/values/5
        [HttpDelete]
        public void DeleteGroceryItem([FromBody]string item,[FromBody] int quantity)
        {
			// Removes an item or multiple items
			_groceryService.DeleteGroceryItem(item, quantity);
        }
    }
}
