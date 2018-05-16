using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PWApi.Models
{
	
		public class Transaction
		{
			public Transaction()
			{
				
				this.TransactionDate = DateTime.UtcNow;
			}

			public int Id { get; set; }
			public string Description { get; set; }
			public DateTime TransactionDate { get; set; }
			public decimal Ammount { get; set; }
			public decimal ResultingOwnerBalance { get; set; }


		//foreign keys

		
		//[ForeignKey("CorrecpondentBankAccountId")]
		public virtual BankAccount CorrespondentBankAccount { get; set; }
		//[ForeignKey("SorceBankAccountId")
		public virtual BankAccount SourseBankAccount { get; set; }

	}
	
}