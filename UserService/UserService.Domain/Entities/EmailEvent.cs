using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Entities;

public class EmailEvent : BaseEntity
{
    public int Code { get; set; }
    public string Email { get; set; }
}
