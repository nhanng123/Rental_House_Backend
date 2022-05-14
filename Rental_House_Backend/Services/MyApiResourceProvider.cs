using Duende.IdentityServer.Models;
using IdentityModel;

namespace Rental_House_Backend.Services
{
    public class MyApiResourceProvider
    {
        public static IEnumerable<ApiScope> ApiScopes =>
         new List<ApiScope>
         {
            new ApiScope("myAPIs", "My API")
         };
        public static IEnumerable<ApiResource> ApiResources =>
       new List<ApiResource>
       {
            new ApiResource("myAPIs", "My API")
       };



        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile() // <-- usefull
    };
        }
    }
}
