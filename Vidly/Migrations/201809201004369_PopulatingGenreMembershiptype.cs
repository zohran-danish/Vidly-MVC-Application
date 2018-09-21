namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingGenreMembershiptype : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (1,'Pay as You Go', 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (2,'Mpnthly', 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes (Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (3,'Quarterly', 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes (Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (4,'Yearly', 300, 12, 20)");

            Sql("INSERT INTO Genres (Name) VALUES ( 'Action')");
            Sql("INSERT INTO Genres (Name) VALUES ( 'Thriller')");
            Sql("INSERT INTO Genres (Name) VALUES ( 'Family')");
            Sql("INSERT INTO Genres (Name) VALUES ( 'Romance')");
            Sql("INSERT INTO Genres (Name) VALUES ( 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
