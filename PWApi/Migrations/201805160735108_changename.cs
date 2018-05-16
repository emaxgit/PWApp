namespace PWApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changename : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "CorrespondentBankAccount_BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Transactions", "SourseBankAccount_BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Transactions", "BankAccount_BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Transactions", "BankAccount_BankAccountId1", "dbo.BankAccounts");
            RenameColumn(table: "dbo.Transactions", name: "BankAccount_BankAccountId", newName: "BankAccount_BankCustomerId");
            RenameColumn(table: "dbo.Transactions", name: "BankAccount_BankAccountId1", newName: "BankAccount_BankCustomerId1");
            RenameColumn(table: "dbo.Transactions", name: "CorrespondentBankAccount_BankAccountId", newName: "CorrespondentBankAccount_BankCustomerId");
            RenameColumn(table: "dbo.Transactions", name: "SourseBankAccount_BankAccountId", newName: "SourseBankAccount_BankCustomerId");
            RenameIndex(table: "dbo.Transactions", name: "IX_CorrespondentBankAccount_BankAccountId", newName: "IX_CorrespondentBankAccount_BankCustomerId");
            RenameIndex(table: "dbo.Transactions", name: "IX_SourseBankAccount_BankAccountId", newName: "IX_SourseBankAccount_BankCustomerId");
            RenameIndex(table: "dbo.Transactions", name: "IX_BankAccount_BankAccountId", newName: "IX_BankAccount_BankCustomerId");
            RenameIndex(table: "dbo.Transactions", name: "IX_BankAccount_BankAccountId1", newName: "IX_BankAccount_BankCustomerId1");
            DropPrimaryKey("dbo.BankAccounts");
            AddColumn("dbo.BankAccounts", "BankCustomerId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.BankAccounts", "BankCustomerId");
            AddForeignKey("dbo.Transactions", "CorrespondentBankAccount_BankCustomerId", "dbo.BankAccounts", "BankCustomerId");
            AddForeignKey("dbo.Transactions", "SourseBankAccount_BankCustomerId", "dbo.BankAccounts", "BankCustomerId");
            AddForeignKey("dbo.Transactions", "BankAccount_BankCustomerId", "dbo.BankAccounts", "BankCustomerId");
            AddForeignKey("dbo.Transactions", "BankAccount_BankCustomerId1", "dbo.BankAccounts", "BankCustomerId");
            DropColumn("dbo.BankAccounts", "BankAccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BankAccounts", "BankAccountId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Transactions", "BankAccount_BankCustomerId1", "dbo.BankAccounts");
            DropForeignKey("dbo.Transactions", "BankAccount_BankCustomerId", "dbo.BankAccounts");
            DropForeignKey("dbo.Transactions", "SourseBankAccount_BankCustomerId", "dbo.BankAccounts");
            DropForeignKey("dbo.Transactions", "CorrespondentBankAccount_BankCustomerId", "dbo.BankAccounts");
            DropPrimaryKey("dbo.BankAccounts");
            DropColumn("dbo.BankAccounts", "BankCustomerId");
            AddPrimaryKey("dbo.BankAccounts", "BankAccountId");
            RenameIndex(table: "dbo.Transactions", name: "IX_BankAccount_BankCustomerId1", newName: "IX_BankAccount_BankAccountId1");
            RenameIndex(table: "dbo.Transactions", name: "IX_BankAccount_BankCustomerId", newName: "IX_BankAccount_BankAccountId");
            RenameIndex(table: "dbo.Transactions", name: "IX_SourseBankAccount_BankCustomerId", newName: "IX_SourseBankAccount_BankAccountId");
            RenameIndex(table: "dbo.Transactions", name: "IX_CorrespondentBankAccount_BankCustomerId", newName: "IX_CorrespondentBankAccount_BankAccountId");
            RenameColumn(table: "dbo.Transactions", name: "SourseBankAccount_BankCustomerId", newName: "SourseBankAccount_BankAccountId");
            RenameColumn(table: "dbo.Transactions", name: "CorrespondentBankAccount_BankCustomerId", newName: "CorrespondentBankAccount_BankAccountId");
            RenameColumn(table: "dbo.Transactions", name: "BankAccount_BankCustomerId1", newName: "BankAccount_BankAccountId1");
            RenameColumn(table: "dbo.Transactions", name: "BankAccount_BankCustomerId", newName: "BankAccount_BankAccountId");
            AddForeignKey("dbo.Transactions", "BankAccount_BankAccountId1", "dbo.BankAccounts", "BankAccountId");
            AddForeignKey("dbo.Transactions", "BankAccount_BankAccountId", "dbo.BankAccounts", "BankAccountId");
            AddForeignKey("dbo.Transactions", "SourseBankAccount_BankAccountId", "dbo.BankAccounts", "BankAccountId");
            AddForeignKey("dbo.Transactions", "CorrespondentBankAccount_BankAccountId", "dbo.BankAccounts", "BankAccountId");
        }
    }
}
