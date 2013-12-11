// *********************************************************************
// (c) 2013 Rope Development
// *********************************************************************

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Rope.PolyphasicSleepTracker.Web.Models.Tracking;

namespace Rope.PolyphasicSleepTracker.Web.Models
{
    public class SleepTrackerContext : DbContext
    {
        public SleepTrackerContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<SleepingPeriod> SleepingPeriods { get; set; }
        public DbSet<TrackingData> TrackingDatas { get; set; }
    }
}