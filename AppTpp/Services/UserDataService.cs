namespace AppTpp.Services
{
    internal class UserDataService
    {
        private static UserDataService instance;

        public static UserDataService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDataService();
                }

                return instance;
            }    
        }

        public string CurrentUsername { get; private set; }
        public string CurrentPrivilege { get; private set; }

        public void SetCurrentUser(string username, string privilege)
        {
            CurrentUsername = username;
            CurrentPrivilege = privilege;
        }
    }
}
