using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.RepositoriesContracts;

public interface IUserRepository
{
    Task<ApplicationUser?> AddUser(ApplicationUser users);

    Task<ApplicationUser?> GetUserByEmailandPassword(string? email, string? password);
}
