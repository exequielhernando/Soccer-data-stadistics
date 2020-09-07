using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerData.Models
{
    public class Stadistics
    {
        public int id { get; set; }

        [Display(Name = "League")]
        public string league { get; set; }

        [Display(Name = "Teams Number")]
        public int teams_no { get; set; }
        [Display(Name = "Date")]
        public string date { get; set; }
        [Display(Name = "Home Team")]
        public string home_team { get; set; }
        [Display(Name = "Away Team")]
        public string away_team { get; set; }
        [Display(Name = "Result")]
        public string result { get; set; }
        [Display(Name = "Final Home Goals")]
        public int h_final { get; set; }
        [Display(Name = "Final Away Goals")]
        public int a_final { get; set; }
        [Display(Name = "Home Extra Time Goals")]
        public int h_half { get; set; }
        [Display(Name = "Away Extra Time Goals")]
        public int a_half { get; set; }
        [Display(Name = "Home Goals In First Half")]
        public int h1h { get; set; }
        [Display(Name = "Away Goals In First Half")]
        public int a1h { get; set; }
        [Display(Name = "Home Goals In Second Half")]
        public int h2h { get; set; }
        [Display(Name = "Away Goals In Second Half")]
        public int a2h { get; set; }
    }
}
