using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Commons.Requests;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Services.Interfaces;

public interface IUserProfileService
{
    public Task CreateUserProfileAsync(UserProfileModel model);
    public Task<int> UpdateUserProfileAsync(UpdateUserProfileRequest model);
}
