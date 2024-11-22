using PerfumeShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportEvents.Domain.Entities;

public class FavouritesEvent : BaseEntity
{
    public int UserId { get; set; }
    public int SportEventId { get; set; }
}
