namespace AppStatus.Api.Framework.Constants
{
    public class State
    {
        public const short Wishlist = 1;
        public const short Applied = 2;
        public const short Interview = 3;
        public const short Offer = 4;
        public const short Rejected = 5;

        public static string ToString(short id)
        {
            switch (id)
            {
                case 1: return "Wishlist";
                case 2: return "Applied";
                case 3: return "Interview";
                case 4: return "Offer";
                case 5: return "Rejected";
                default: return "";
            }
        }
    }
}
