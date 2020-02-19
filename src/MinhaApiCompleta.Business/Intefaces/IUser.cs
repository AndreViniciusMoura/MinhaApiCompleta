using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace MinhaApiCompleta.Business.Intefaces.Services
{
    public interface IUserServices
    {
        string Name { get; }

        Guid GetUserId();

        string GetUserEmail();

        bool IsAuthenticated();

        bool IsInRole(string role);

        IEnumerable<Claim> GetClaimsIdentity();
    }
}
