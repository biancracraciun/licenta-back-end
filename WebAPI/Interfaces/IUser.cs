namespace WebAPI.Interfaces
{
    public interface IUser
    {
        public bool VerifyUser(string username, string password);
        public string RegisterUser(string lastName, string firstName, string username, string password);
    }
}
