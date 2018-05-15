﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PWApi.Models
{
	public class BankCustomer
	{
		
			public int Id { get; set; }
			public string Email { get; set; }
			public string Password { get; set; }
			public string FirstName { get; set; }
			public string LastName { get; set; }

		    /*[InverseProperty("BankCustomerId")]
		    public BankAccount BankAccounts { get; set; }*/


		    public virtual List<BankAccount> BankAccounts { get; set; } 

	}
}