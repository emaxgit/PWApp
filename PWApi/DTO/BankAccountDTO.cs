using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PWApi.Models
{
	public class BankAccountDTO
	{
		public int Id { get; set; }
		public int OwnerId { get; set; }
		/*public string OwnerName { get; set; }*/
		public string Number { get; set; }
		public decimal Balance { get; set; }
		public DateTime OpenDate { get; set; }

	}
}