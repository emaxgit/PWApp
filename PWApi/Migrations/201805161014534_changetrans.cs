namespace PWApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetrans : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Transactions", new[] { "BankAccount_BankAccountId" });
            DropIndex("dbo.Transactions", new[] { "BankAccount_BankAccountId1" });
            DropColumn("dbo.Transactions", "SourseBankAccount_BankAccountId");
            DropColumn("dbo.Transactions", "CorrespondentBankAccount_BankAccountId");
            RenameColumn(table: "dbo.Transactions", name: "BankAccount_BankAccountId", newName: "SourseBankAccount_BankAccountId");
            RenameColumn(table: "dbo.Transactions", name: "BankAccount_BankAccountId1", newName: "CorrespondentBankAccount_BankAccountId");
            AddColumn("dbo.Transactions", "TransactionDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transactions", "Date");
            DropColumn("dbo.Transactions", "CorrecpondentBankAccountAId");
            DropColumn("dbo.Transactions", "SorceBankAccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "SorceBankAccountId", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "CorrecpondentBankAccountAId", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transactions", "TransactionDate");
            RenameColumn(table: "dbo.Transactions", name: "CorrespondentBankAccount_BankAccountId", newName: "BankAccount_BankAccountId1");
            RenameColumn(table: "dbo.Transactions", name: "SourseBankAccount_BankAccountId", newName: "BankAccount_BankAccountId");
            AddColumn("dbo.Transactions", "CorrespondentBankAccount_BankAccountId", c => c.Int());
            AddColumn("dbo.Transactions", "SourseBankAccount_BankAccountId", c => c.Int());
            CreateIndex("dbo.Transactions", "BankAccount_BankAccountId1");
            CreateIndex("dbo.Transactions", "BankAccount_BankAccountId");
        }
    }
}
