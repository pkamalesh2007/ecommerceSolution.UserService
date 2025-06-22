using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoriesContracts;
using eCommerce.Infrastruture.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastruture.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly DapperDbContext _dapperDbContext;
    public UserRepository(DapperDbContext dapperDbContext)
    {
        _dapperDbContext = dapperDbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser users)
    {
        users.UserID = Guid.NewGuid();
        string query = "INSERT INTO public " +
            ".\"Users\"(\"UserID\",\"Email\",\"PersonName\",\"Gender\",\"Password\") VALUES(@UserID,@Email,@PersonName,@Gender,@Password)";
        
     int rowCount=  await _dapperDbContext.DbConnection.ExecuteAsync(query,users);
        if (rowCount > 0)
        {
            return users;
        }

        else
        {
            return null;
        }
    }

    public async Task<ApplicationUser?> GetUserByEmailandPassword(string? email, string? password)
    {
        string query= "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email and \"Password\"=@Password";

        var parameters = new { Email = email, Password = password };

     ApplicationUser? user= await _dapperDbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
        return user;
    }
}
