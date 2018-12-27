namespace DriveToGether.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Vorname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Nachname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Nachname");
            DropColumn("dbo.AspNetUsers", "Vorname");
        }
    }
}
