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
				
				this.Date = DateTime.UtcNow;
			}

			public int Id { get; set; }
			public string Description { get; set; }
			public DateTime Date { get; set; }
			public float Ammount { get; set; }

		//foreign keys

		public int CorrecpondentBankAccountAId { get; set; }
		//[ForeignKey("CorrecpondentBankAccountId")]
		public BankAccount CorrespondentBankAccount { get; set; }


		
		public int SorceBankAccountId { get; set; }
		//[ForeignKey("SorceBankAccountId")]
		public BankAccount SourseBankAccount { get; set; }


		
			


	}
	
}