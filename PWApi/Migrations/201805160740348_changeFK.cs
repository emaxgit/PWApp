namespace PWApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeFK : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BankAccounts", name: "Id", newName: "BankCustomerId");
            RenameIndex(table: "dbo.BankAccounts", name: "IX_Id", newName: "IX_BankCustomerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.BankAccounts", name: "IX_BankCustomerId", newName: "IX_Id");
            RenameColumn(table: "dbo.BankAccounts", name: "BankCustomerId", newName: "Id");
        }
    }
}
