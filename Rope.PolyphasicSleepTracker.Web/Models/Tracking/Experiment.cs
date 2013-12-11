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
    /// <summary>
    ///     An experiment summarizes sleeping periods and metrics
    ///     over a certain period for one user.
    /// </summary>
    [Table("Experiment")]
    public class Experiment
    {
        [Key]
        public Guid ExperimentPK { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public String Name { get; set; }

        public String Description { get; set; }

        [ForeignKey("UserId")]
        public virtual UserProfile User { get; set; }
    }
}