using CKSource.CKFinder.Connector.Core;
using CKSource.CKFinder.Connector.Core.Authentication;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace FonNature
{
    public class CustomCKFinderAuthenticator : IAuthenticator
    {
        public Task<IUser> AuthenticateAsync(ICommandRequest commandRequest, CancellationToken cancellationToken)
        {
            /*
             * It should be safe to assume the IPrincipal is a ClaimsPrincipal.
             */
            var claimsPrincipal = commandRequest.Principal as ClaimsPrincipal;

            /*
             * Extract role names from claimsPrincipal.
             */
            var roles = claimsPrincipal?.Claims?.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToArray();

            /*
             * It is strongly suggested to change this in a way to allow only certain users access to CKFinder.
             * For example you may check commandRequest.RemoteIPAddress to limit access only to your local network.
             */
            var isAuthenticated = true;

            /*
             * Create and return the user.
             */
            var user = new User(isAuthenticated, roles);
            return Task.FromResult((IUser)user);
        }
    }
}