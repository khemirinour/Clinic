﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinic.Models
{
    public class Login
    {

        public string? Name { get; set; }
        public int? ServiceId { get; set; }

        public SelectList? ServiceList { get; set; } // Modifier le type pour SelectList
    }
   
}
