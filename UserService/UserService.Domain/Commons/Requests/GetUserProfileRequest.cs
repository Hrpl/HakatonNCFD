using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Commons.Requests;

public class GetUserProfileRequest
{
    public string JWT { get; set; }
}
