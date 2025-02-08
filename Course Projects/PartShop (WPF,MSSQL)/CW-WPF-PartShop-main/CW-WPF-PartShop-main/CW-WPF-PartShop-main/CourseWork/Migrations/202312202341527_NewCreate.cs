namespace CourseWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewCreate : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "OrderState", c => c.String());
            AlterColumn("dbo.Deliveries", "Name", c => c.String());
            AlterColumn("dbo.Deliveries", "Description", c => c.String());
            AlterColumn("dbo.Providers", "Name", c => c.String());
            AlterColumn("dbo.Marks", "MarkName", c => c.String());
            AlterColumn("dbo.Parts", "FullDescription", c => c.String());
            AlterColumn("dbo.Parts", "Description", c => c.String());
            AlterColumn("dbo.Parts", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Description", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
