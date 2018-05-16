namespace PWApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reqadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "SourseBankAccount_BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Transactions", "CorrespondentBankAccount_BankAccountId", "dbo.BankAccounts");
            DropIndex("dbo.Transactions", new[] { "SourseBankAccount_BankAccountId" });
            DropIndex("dbo.Transactions", new[] { "CorrespondentBankAccount_BankAccountId" });
            AlterColumn("dbo.Transactions", "SourseBankAccount_BankAccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "CorrespondentBankAccount_BankAccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "SourseBankAccount_BankAccountId");
            CreateIndex("dbo.Transactions", "CorrespondentBankAccount_BankAccountId");
            AddForeignKey("dbo.Transactions", "SourseBankAccount_BankAccountId", "dbo.BankAccounts", "BankAccountId", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "CorrespondentBankAccount_BankAccountId", "dbo.BankAccounts", "BankAccountId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "CorrespondentBankAccount_BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Transactions", "SourseBankAccount_BankAccountId", "dbo.BankAccounts");
            DropIndex("dbo.Transactions", new[] { "CorrespondentBankAccount_BankAccountId" });
            DropIndex("dbo.Transactions", new[] { "SourseBankAccount_BankAccountId" });
            AlterColumn("dbo.Transactions", "CorrespondentBankAccount_BankAccountId", c => c.Int());
            AlterColumn("dbo.Transactions", "SourseBankAccount_BankAccountId", c => c.Int());
            CreateIndex("dbo.Transactions", "CorrespondentBankAccount_BankAccountId");
            CreateIndex("dbo.Transactions", "SourseBankAccount_BankAccountId");
            AddForeignKey("dbo.Transactions", "CorrespondentBankAccount_BankAccountId", "dbo.BankAccounts", "BankAccountId");
            AddForeignKey("dbo.Transactions", "SourseBankAccount_BankAccountId", "dbo.BankAccounts", "BankAccountId");
        }
    }
}
