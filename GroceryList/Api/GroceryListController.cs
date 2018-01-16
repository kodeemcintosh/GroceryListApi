using System;
using System.Collections.Generic;
using System.Web.Http.Routing;
using Microsoft.AspNetCore.Mvc;
using GroceryList.Business;
using GroceryList.Data.Queries;
using GroceryList.Models;
using Microsoft.AspNetCore.Cors;

namespace GroceryList.Api
{

	[EnableCors("CORS_POLICY")]
    public class GroceryListController : Controller
    {
	    private readonly IGrocery _groceryService;

	    public GroceryListController(IGrocery groceryService)
	    {
		    _groceryService = groceryService;
	    }

        // GET API/values
        [HttpGet]
		[Route("/api/v1/GroceryList")]
        public List<GroceryItem> GetGroceryList([FromBody] BaseRequest ApiRequest)
        {
//	        ApiRequest = ApiRequest ?? new BaseRequest{ sortField = "last_modified", sortDirection = "ASC"};
//	        ApiRequest = ApiRequest ?? new BaseRequest();


	        // Should return list of items from a select query
	        List<GroceryItem> apiGroceryList = _groceryService.GetGroceryList(ApiRequest);

			return apiGroceryList;
        }

		// Inserts item with quantity or Updates item and quantity
        [HttpPost]
		[Route("/api/v1/GroceryList/Create")]
        public PostResponse CreateGroceryItem([FromBody] GroceryItem ApiRequest)
        {
			// Null or Empty checks
	        ApiRequest = ApiRequest ?? throw new NullReferenceException("Item object is null");

			_groceryService.CreateGroceryItem(ApiRequest);

	        return new PostResponse("SUCCESS");
        }

	    [HttpPost]
	    [Route("/api/v1/GroceryList/Update")]
	    public PostResponse UpdateGroceryList([FromBody] GroceryItem ApiRequest)
	    {

	        ApiRequest = ApiRequest ?? throw new NullReferenceException("string is null");

		    ApiRequest.quantity = ApiRequest.quantity < 1 ? 1 : ApiRequest.quantity;

			_groceryService.UpdateGroceryList(ApiRequest);

			return new PostResponse("SUCCESS");
	    }

		 // DELETE API/GroceryList/Delete
        [HttpPost]
		[Route("/api/v1/GroceryList/Delete")]
        public PostResponse DeleteGroceryItem([FromBody] GroceryItem ApiRequest)
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

			return new PostResponse("SUCCESS");
        }
    }
}
