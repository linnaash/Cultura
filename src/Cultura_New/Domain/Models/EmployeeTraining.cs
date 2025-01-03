﻿using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class EmployeeTraining
    {
        public int TrainingId { get; set; }
        public int? EmployeeId { get; set; }
        public string? TrainingName { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
