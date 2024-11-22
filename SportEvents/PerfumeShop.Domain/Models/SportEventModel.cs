﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportEvents.Domain.Models;

public class SportEventModel
{
    public int TypeId { get; set; } = 0;
    public int CompositionId { get; set; } = 0;
    public string EventName { get; set; } = string.Empty;
    public string EventDescription { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Country { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int Participants { get; set; } = 0;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set ; }
}