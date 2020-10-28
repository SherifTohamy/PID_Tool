﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PIDDb.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime timeStamp
        {
            get
            {
                return timeStamp;
            }
            set
            {
                timeStamp = DateTime.Now;
            }
        }
    }
}