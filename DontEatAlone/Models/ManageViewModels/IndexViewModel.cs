﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }

        public string Gender { get; set; }

        public bool Smoker { get; set; }

        public bool Drinker { get; set; }

        public bool Pet { get; set; }

        public string[] CuisineType { get; set; }

        public string Others { get; set; }

        public string StatusMessage { get; set; }
    }
}
