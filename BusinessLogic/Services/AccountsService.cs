using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    internal class AccountsService : IAccountsService
    {
        private readonly UserManager<Client> userManager;
        private readonly SignInManager<Client> signInManager;
        private readonly IMapper mapper;
        private readonly IJwtService jwtService;

        public AccountsService(UserManager<Client> userManager,
                                SignInManager<Client> signInManager,
                                IMapper mapper,
                                IJwtService jwtService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.jwtService = jwtService;
        }

        public async Task Register(RegisterModel model)
        {
            // TODO: validation

            // check user
            var client = await userManager.FindByEmailAsync(model.Email);

            if (client != null)
                throw new HttpException("Email is already exists.", HttpStatusCode.BadRequest);

            // create user
            var newClient = mapper.Map<Client>(model);
            var result = await userManager.CreateAsync(newClient, model.Password);

            if (!result.Succeeded)
                throw new HttpException(string.Join(" ", result.Errors.Select(x => x.Description)), HttpStatusCode.BadRequest);
        }

        public async Task<LoginResponseDto> Login(LoginModel model)
        {
            var client = await userManager.FindByEmailAsync(model.Email);

            if (client == null || !await userManager.CheckPasswordAsync(client, model.Password))
                throw new HttpException("Invalid user login or password.", HttpStatusCode.BadRequest);

            await signInManager.SignInAsync(client, true);

            return new LoginResponseDto
            {
                Token = jwtService.CreateToken(jwtService.GetClaims(client))
            };
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
