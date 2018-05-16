namespace PWApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeFKOneMoreTime : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BankAccounts", name: "BankCustomerId", newName: "ClientId");
            RenameIndex(table: "dbo.BankAccounts", name: "IX_BankCustomerId", newName: "IX_ClientId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.BankAccounts", name: "IX_ClientId", newName: "IX_BankCustomerId");
            RenameColumn(table: "dbo.BankAccounts", name: "ClientId", newName: "BankCustomerId");
        }
    }
}
