namespace PWApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeFK : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BankAccounts", name: "Id", newName: "ClientId");
            RenameIndex(table: "dbo.BankAccounts", name: "IX_Id", newName: "IX_ClientId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.BankAccounts", name: "IX_ClientId", newName: "IX_Id");
            RenameColumn(table: "dbo.BankAccounts", name: "ClientId", newName: "Id");
        }
    }
}
