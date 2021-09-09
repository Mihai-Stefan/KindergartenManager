﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kindergarten_Client.Service.IService
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDTO> RegisterUser(UserRequestDTO userForRegisteration);

        Task<AuthenticationResponseDTO> Login(AuthenticationDTO userFromAuthentication);

        Task Logout();
    }
}
