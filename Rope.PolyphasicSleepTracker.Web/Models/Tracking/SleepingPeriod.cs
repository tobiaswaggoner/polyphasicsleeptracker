// *********************************************************************
// (c) 2013 Rope Development
// *********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Rope.PolyphasicSleepTracker.Web.Models.Tracking
{
    [Table("SleepingPeriod")]
    public class SleepingPeriod
    {
        [Key]
        public Guid SleepingPeriodPK { get; set; }

        [Required]
        public Guid ExperimentPK { get; set; }

        [Required]
        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public int? TotalDurationInSeconds { get; set; }

        public int? EffectiveSleepDurationInSeconds { get; set; }

        public QualityOfSleep? QualityOfSleep { get; set; }

        public String Comment { get; set; }

        [ForeignKey("ExperimentPK")]
        public virtual Experiment Experiment { get; set; }
    }
}