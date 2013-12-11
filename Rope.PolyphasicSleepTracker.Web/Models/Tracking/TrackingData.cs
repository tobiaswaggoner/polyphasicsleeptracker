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
    [Table("TrackingData")]
    public class TrackingData
    {
        [Key]
        public Guid TrackingDataPK { get; set; }

        [Required]
        public Guid ExperimentPK { get; set; }

        [Required]
        public DateTime PointInTime { get; set; }

        [Range(minimum: 0, maximum: 10, ErrorMessage = "alertness attribute must be between 0 and 10")]
        public int? Alertness { get; set; }

        public String Comment { get; set; }

        [ForeignKey("ExperimentPK")]
        public virtual Experiment Experiment { get; set; }
    }
}