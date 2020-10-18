namespace MVC_Vidily.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieViewModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "NumInStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "NumInStock", c => c.Int(nullable: false));
        }
    }
}
