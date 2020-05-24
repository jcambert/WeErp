using MicroS_Common.Authentication;

namespace weerp.api.Framework
{
    public class AdminAuthAttribute : JwtAuthAttribute
    {
        public AdminAuthAttribute() : base("admin")
        {
        }
    }
}