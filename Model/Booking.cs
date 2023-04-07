﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarRentalApi.Model
{
    public class Booking
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Return date")]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "User Id")]
        public int UserId { get; set; }
    }
}
