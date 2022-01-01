namespace AppStatus.Api.Framework.Constants
{
    public class Role
    {
        public const short CHRO = 1;
        public const short CTO = 2;
        public const short CEO = 3;

        public static string ToString(short id)
        {
            switch (id)
            {
                case 1: return "CHRO";
                case 2: return "CTO";
                case 3: return "CEO";
                default: return string.Empty;
            }
        }
    }
}
