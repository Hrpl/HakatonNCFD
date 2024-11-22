using SportEvents.Domain.Common.Request;
using SportEvents.Domain.Common.Response;
using SportEvents.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportEvents.Infrastructure.Services.Interfaces;

public interface ISportEventService
{
    public Task<List<SportEventResponse>> GetAllSportEventsAsync(PaginateRequest request);

}
