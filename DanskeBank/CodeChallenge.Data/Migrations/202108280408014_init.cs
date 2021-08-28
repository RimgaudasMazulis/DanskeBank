namespace CodeChallenge.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppliedAmountDecision",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Decision = c.Boolean(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsGreaterThanAmount = c.Boolean(nullable: false),
                        AmountIsRange = c.Boolean(nullable: false),
                        AmountRangeFrom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountRangeTo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TotalFutureDebtInterestRate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsGreaterThanAmount = c.Boolean(nullable: false),
                        AmountIsRange = c.Boolean(nullable: false),
                        AmountRangeFrom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountRangeTo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TotalFutureDebtInterestRate");
            DropTable("dbo.AppliedAmountDecision");
        }
    }
}
