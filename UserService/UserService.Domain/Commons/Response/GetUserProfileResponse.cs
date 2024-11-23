using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Commons.Response;

public class GetUserProfileResponse
{
    public int AppUserId { get; set; }
    public string? Name { get; set; }
    public string Surname { get; set; }
    public string? Patronymic { get; set; }
    public int? Age { get; set; }
    public string? Male { get; set; }
    public string? City { get; set; }
}
