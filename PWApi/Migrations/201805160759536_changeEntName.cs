namespace PWApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeEntName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BankCustomers", newName: "Clients");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Clients", newName: "BankCustomers");
        }
    }
}
