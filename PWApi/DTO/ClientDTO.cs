using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PWApi.Models
{
	public class ClientDTO
	{
		public int Id { get; set; }
		/*public int OwnerId { get; set; }*/
		public string ClientName { get; set; }
		public decimal ClientBalance { get; set; }
	}
}