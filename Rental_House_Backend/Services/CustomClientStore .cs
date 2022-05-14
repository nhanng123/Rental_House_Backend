using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;

namespace Rental_House_Backend.Services
{
    public class CustomClientStore : IClientStore
    {
        public static IEnumerable<Duende.IdentityServer.Models.Client> AllClients { get; } = new[]
        {
        new Duende.IdentityServer.Models.Client
        {
            ClientId = "myClient",
            ClientName = "My Custom Client",
            AccessTokenLifetime = 60 * 60 * 24,
            AllowedGrantTypes = new string[]{GrantType.ResourceOwnerPassword },
            RequireClientSecret = false,
              AllowedScopes =
            {
                "myAPIs"
            }
        }
    };

        public Task<Duende.IdentityServer.Models.Client> FindClientByIdAsync(string clientId)
        {
            return Task.FromResult(AllClients.FirstOrDefault(c => c.ClientId == clientId));
        }

    }
}
