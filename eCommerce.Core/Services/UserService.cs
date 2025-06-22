using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoriesContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository,IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
      ApplicationUser? user= await _userRepository.GetUserByEmailandPassword(loginRequest.email, loginRequest.password);

        if (user == null) { 
          return null;
        }

        return _mapper.Map<AuthenticationResponse>(user) with { Success=true,Token="token"};
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);

        ApplicationUser? registerUser= await _userRepository.AddUser(user);

        if (registerUser == null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(registerUser) with { Success=true,Token="token"};
    }
}
