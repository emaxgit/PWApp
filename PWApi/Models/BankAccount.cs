﻿using System;
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
		public int Id { get; set; }
		[StringLength(8)]
		[Index(IsUnique = true)]
		[MaxLength(8), MinLength(8)]
		public string Number { get; set; }
		public float Balance { get; set; }
		public DateTime OpenDate { get; set; }

		//foreign key
		
		public int BankCustomerId { get; set; }
		public BankCustomer AccountOwner { get; set; }

		//for navigation Purposes
		//public virtual ICollection<Transaction> Transactions { get; set; }

		//[InverseProperty("SorceBankAccountId")]
		public virtual List<Transaction> TransactionsFromAccount { get; set; }
		public virtual List<Transaction> TransactionsToAccount { get; set; }

	}
}