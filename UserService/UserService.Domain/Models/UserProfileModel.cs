using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Models;

public class UserProfileModel
{
    public int AppUserId { get; set; }
    public string? Name { get; set; }
    public string Surname { get; set; }
    public string? Patronymic { get; set; }
    public int? Age { get; set; }
    public string? Male { get; set; }
    public string? City { get; set; }
    public string? BackgroundColor { get; set; }
    public string? FontColor { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt{get; set;}
}
