using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PWApi.DTO
{
	public class TransactionsDTO
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public decimal Ammount { get; set; }
		public decimal ResultingOwnerBalance { get; set; }
	}
}