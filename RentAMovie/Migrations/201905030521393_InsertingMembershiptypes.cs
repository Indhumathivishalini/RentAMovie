namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertingMembershiptypes : DbMigration
    {
        public override void Up()
        {
            Sql("insert MembershipTypes(MembershipTypeName,Amount,DurationInMonth,Discount) values('PayAsYouDo',0,0,0)");
            Sql("insert MembershipTypes(MembershipTypeName,Amount,DurationInMonth,Discount) values('Monthly',100,1,5)");
            Sql("insert MembershipTypes(MembershipTypeName,Amount,DurationInMonth,Discount) values('Quaterly',300,3,10)");
            Sql("insert MembershipTypes(MembershipTypeName,Amount,DurationInMonth,Discount) values('Half-yearly',600,6,15)");
            Sql("insert MembershipTypes(MembershipTypeName,Amount,DurationInMonth,Discount) values('Yearly',1200,12,20)");



        }
        
        public override void Down()
        {
        }
    }
}
