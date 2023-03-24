using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Utils.UserLogged
{
    public class UserLoggedExtensions : IUserLoggedExtensions
    {
        private readonly IHttpContextAccessor _httpContextAcessor;

        public UserLoggedExtensions(IHttpContextAccessor httpContextAcessor)
        {
            _httpContextAcessor = httpContextAcessor ?? throw new ArgumentNullException(nameof(httpContextAcessor));
        }

        public int getIdEscola()
        {
            return Convert.ToInt32(_httpContextAcessor.HttpContext.User.FindFirst(x => x.Type == "idEscola")?.Value);
        }
    }
}
