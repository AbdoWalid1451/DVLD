using DVLD_Business_Layer;

namespace DVLD_Presentation_Layer
{
    public class clsGlobal
    {
        static public  clsUser CurrentUser { get; private set; }

        public bool Login(string username, string password)
        {
            clsUser user = clsUser.Find(username, password);

            if (user == null)
                return false;
            if(!user.IsActive)
                return false;
            
             CurrentUser = user;

            return true;
        }

    }
}
