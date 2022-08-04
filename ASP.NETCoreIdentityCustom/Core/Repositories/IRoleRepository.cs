using Microsoft.AspNetCore.Identity;

namespace ASP.NETCoreIdentityCustom.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
