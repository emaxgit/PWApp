namespace PWApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        BankAccountId = c.Int(nullable: false, identity: true),
                        Number = c.String(maxLength: 8),
                        Balance = c.Single(nullable: false),
                        OpenDate = c.DateTime(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BankAccountId)
                .ForeignKey("dbo.Clients", t => t.Id, cascadeDelete: true)
                .Index(t => t.Number, unique: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        Ammount = c.Single(nullable: false),
                        CorrecpondentBankAccountAId = c.Int(nullable: false),
                        SorceBankAccountId = c.Int(nullable: false),
                        CorrespondentBankAccount_BankAccountId = c.Int(),
                        SourseBankAccount_BankAccountId = c.Int(),
                        BankAccount_BankAccountId = c.Int(),
                        BankAccount_BankAccountId1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.CorrespondentBankAccount_BankAccountId)
                .ForeignKey("dbo.BankAccounts", t => t.SourseBankAccount_BankAccountId)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccount_BankAccountId)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccount_BankAccountId1)
                .Index(t => t.CorrespondentBankAccount_BankAccountId)
                .Index(t => t.SourseBankAccount_BankAccountId)
                .Index(t => t.BankAccount_BankAccountId)
                .Index(t => t.BankAccount_BankAccountId1);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Transactions", "BankAccount_BankAccountId1", "dbo.BankAccounts");
            DropForeignKey("dbo.Transactions", "BankAccount_BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Transactions", "SourseBankAccount_BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Transactions", "CorrespondentBankAccount_BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.BankAccounts", "Id", "dbo.Clients");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Transactions", new[] { "BankAccount_BankAccountId1" });
            DropIndex("dbo.Transactions", new[] { "BankAccount_BankAccountId" });
            DropIndex("dbo.Transactions", new[] { "SourseBankAccount_BankAccountId" });
            DropIndex("dbo.Transactions", new[] { "CorrespondentBankAccount_BankAccountId" });
            DropIndex("dbo.BankAccounts", new[] { "Id" });
            DropIndex("dbo.BankAccounts", new[] { "Number" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Transactions");
            DropTable("dbo.Clients");
            DropTable("dbo.BankAccounts");
        }
    }
}
