using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryList.Models
{
    public class PostResponse
    {
	    public PostResponse(string response)
	    {
		    value = response;
	    }

		private string value { get; }
    }
}
