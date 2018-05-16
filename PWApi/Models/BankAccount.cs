using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PWApi.Models
{
	public class BankAccount
	{

		/*public BankAccount()
		{
			this.OpenDate = DateTime.UtcNow;
			this.Balance = 500;
		}*/


		[Key]
		public int BankAccountId { get; set; }

		//public int OwnerId { get; set; }
		[StringLength(8)]
		[Index(IsUnique = true)]
		[MaxLength(8), MinLength(8)]
		public string Number { get; set; }
		public decimal Balance { get; set; }
		public DateTime OpenDate { get; set; }

		// relation one-to-one
		
		public virtual Client AccountOwner { get; set; }


		//for navigation Purposes
		//public virtual ICollection<Transaction> Transactions { get; set; }

		//[InverseProperty("SorceBankAccountId")]
		public virtual List<Transaction> TransactionsFromAccount { get; set; }
		public virtual List<Transaction> TransactionsToAccount { get; set; }

	}
}