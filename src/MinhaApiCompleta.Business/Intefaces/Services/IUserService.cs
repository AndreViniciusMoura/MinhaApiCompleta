using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MinhaApiCompleta.Business.Intefaces.Services
{
    public interface IUserService
    {
        string Name { get; }

        Guid GetUserId();

        string GetUserEmail();

        bool IsAuthenticated();

        bool IsInRole(string role);

        IEnumerable<Claim> GetClaimsIdentity();
    }
}
