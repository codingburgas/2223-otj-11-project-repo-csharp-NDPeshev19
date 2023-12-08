namespace PC.Server.Services
{
    public class RoleManager
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public RoleManager(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }


    }
}
