namespace PWApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somechanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "ResultingOwnerBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BankAccounts", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transactions", "Ammount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "Ammount", c => c.Single(nullable: false));
            AlterColumn("dbo.BankAccounts", "Balance", c => c.Single(nullable: false));
            DropColumn("dbo.Transactions", "ResultingOwnerBalance");
        }
    }
}
