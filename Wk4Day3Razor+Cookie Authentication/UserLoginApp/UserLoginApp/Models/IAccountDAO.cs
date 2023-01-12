namespace UserLoginApp.Models
{
    public interface IAccountDAO
    {
        public bool CreateAccount(Account account);
        public bool DeleteAccount(int id);
        public bool UpdateAccount(Account account);
        public Account GetAccountById(int id);
        public List<Account> GetAllAccounts();
        public bool ValidateAccount(string email, string password);
        void AddAccount(Account account);
    }
}
