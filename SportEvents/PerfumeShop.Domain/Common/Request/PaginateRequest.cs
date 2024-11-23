using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportEvents.Domain.Common.Request;

public class PaginateRequest : Filter
{
    public int Page { get; set; }
    public int Count { get; set; }
}
