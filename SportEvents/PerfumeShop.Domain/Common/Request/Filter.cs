using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportEvents.Domain.Common.Request;

public class Filter
{
    public string? TypeSport {  get; set; }
    public string? Country { get; set; }
    public int? CountPeopleMin { get; set; }
    public int? CountPeopleMax { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
}
