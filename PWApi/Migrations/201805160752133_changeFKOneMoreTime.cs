namespace PWApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeFKOneMoreTime : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BankAccounts", name: "ClientId", newName: "ClientId");
            RenameIndex(table: "dbo.BankAccounts", name: "IX_ClientId", newName: "IX_ClientId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.BankAccounts", name: "IX_ClientId", newName: "IX_ClientId");
            RenameColumn(table: "dbo.BankAccounts", name: "ClientId", newName: "ClientId");
        }
    }
}
