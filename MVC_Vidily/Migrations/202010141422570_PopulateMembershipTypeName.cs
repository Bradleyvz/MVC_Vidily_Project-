namespace MVC_Vidily.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            //Populating the MembershipTypeName Field 
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Pay as You Go' WHERE Id=1");
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Monthly' WHERE Id=2");
            Sql("UPDATE MembershipTypes SET MembershipTypeName  = 'Quaterly' WHERE Id=3");
            Sql("UPDATE MembershipTypes SET MembershipTypeName  = 'Annual' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
