using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportEvents.Domain.Common.Response;

public class SportEventResponse
{
    public string TypeEvent { get; set; } = string.Empty;
    public string Composition { get; set; } = string.Empty;
    public string EventName { get; set; } = string.Empty;
    public string EventDescription { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Country { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int Participants { get; set; } = 0;
}
