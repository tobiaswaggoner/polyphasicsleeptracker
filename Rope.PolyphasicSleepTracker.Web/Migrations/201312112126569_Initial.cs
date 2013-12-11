namespace Rope.PolyphasicSleepTracker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        CurrentExperimentPK = c.Guid(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Experiment", t => t.CurrentExperimentPK)
                .Index(t => t.CurrentExperimentPK);
            
            CreateTable(
                "dbo.Experiment",
                c => new
                    {
                        ExperimentPK = c.Guid(nullable: false),
                        UserId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ExperimentPK)
                .ForeignKey("dbo.UserProfile", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SleepingPeriod",
                c => new
                    {
                        SleepingPeriodPK = c.Guid(nullable: false),
                        ExperimentPK = c.Guid(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(),
                        TotalDurationInSeconds = c.Int(),
                        EffectiveSleepDurationInSeconds = c.Int(),
                        QualityOfSleep = c.Int(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.SleepingPeriodPK)
                .ForeignKey("dbo.Experiment", t => t.ExperimentPK, cascadeDelete: true)
                .Index(t => t.ExperimentPK);
            
            CreateTable(
                "dbo.TrackingData",
                c => new
                    {
                        TrackingDataPK = c.Guid(nullable: false),
                        ExperimentPK = c.Guid(nullable: false),
                        PointInTime = c.DateTime(nullable: false),
                        Alertness = c.Int(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.TrackingDataPK)
                .ForeignKey("dbo.Experiment", t => t.ExperimentPK, cascadeDelete: true)
                .Index(t => t.ExperimentPK);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TrackingData", new[] { "ExperimentPK" });
            DropIndex("dbo.SleepingPeriod", new[] { "ExperimentPK" });
            DropIndex("dbo.Experiment", new[] { "UserId" });
            DropIndex("dbo.UserProfile", new[] { "CurrentExperimentPK" });
            DropForeignKey("dbo.TrackingData", "ExperimentPK", "dbo.Experiment");
            DropForeignKey("dbo.SleepingPeriod", "ExperimentPK", "dbo.Experiment");
            DropForeignKey("dbo.Experiment", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.UserProfile", "CurrentExperimentPK", "dbo.Experiment");
            DropTable("dbo.TrackingData");
            DropTable("dbo.SleepingPeriod");
            DropTable("dbo.Experiment");
            DropTable("dbo.UserProfile");
        }
    }
}
