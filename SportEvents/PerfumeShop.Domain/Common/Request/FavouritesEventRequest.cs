using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportEvents.Domain.Common.Request;

public class FavouritesEventRequest
{
    public string JWT { get; set; }
    public int SportEventId { get; set; }
}
