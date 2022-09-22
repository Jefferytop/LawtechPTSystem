
namespace LawtechPTSystem.Public
{
    public class LoginForm
    {
        private static Login _Login = null;

        public Login Login
       {
           get { return _Login; }
           set { _Login = value; }
       }
    }
}
