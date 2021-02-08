namespace InveonECommerce.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        Role = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
    }
}
