using System.Data.SqlClient;

namespace UserLoginApp.Models
{
    // AccountDAO.cs
    public class AccountDAO : IAccountDAO
    {
        private readonly IConfiguration _config;
        private readonly ILogger<AccountDAO> _logger;

        public AccountDAO(IConfiguration config, ILogger<AccountDAO> logger)
        {
            _config = config;
            _logger = logger;
        }

        public bool CreateAccount(Account account)
        {
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conn.Open();

                string sql = "INSERT INTO Account (Email, Password) VALUES (@Email, @Password)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Email", account.Email);
                cmd.Parameters.AddWithValue("@Password", account.Password);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    _logger.LogInformation("A new account has been created.");
                    return true;
                }
                else
                {
                    _logger.LogInformation("Failed to create a new account.");
                    return false;
                }
            }
        }

        public bool DeleteAccount(int id)
        {
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conn.Open();

                string sql = "DELETE FROM Account WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    _logger.LogInformation("An account has been deleted.");
                    return true;
                }
                else
                {
                    _logger.LogInformation("Failed to delete an account.");
                    return false;
                }
            }
        }

        //public Account GetAccountById(int id)
        //{
        //    Account account = null;
        //    using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("SELECT * FROM Account WHERE Id = @id", conn);
        //        cmd.Parameters.AddWithValue("@id", id);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            account = new Account
        //            {
        //                Id = Convert.ToInt32(reader["Id"]),
        //                Email = Convert.ToString(reader["Email"]),
        //                Password = Convert.ToString(reader["Password"])
        //            };
        //        }
        //    }
        //    return account;
        //}

        public Account GetAccountById(int id)
        {
            Account account = null;
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Account WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    account = new Account
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        UserName = Convert.ToString(reader["UserName"]),
                        Email = Convert.ToString(reader["Email"]),
                        Password = Convert.ToString(reader["Password"]),
                    };
                }
            }
            return account;
        }

        public void AddAccount(Account account)
        {
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Account (UserName, Email, Password) VALUES (@userName, @email, @password)", conn);
                cmd.Parameters.AddWithValue("@userName", account.UserName);
                cmd.Parameters.AddWithValue("@email", account.Email);
                cmd.Parameters.AddWithValue("@password", account.Password);
                cmd.ExecuteNonQuery();
            }
        }


        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Account", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Account account = new Account
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Email = Convert.ToString(reader["Email"]),
                        Password = Convert.ToString(reader["Password"])
                    };
                    accounts.Add(account);
                }
            }
            return accounts;
        }

        public bool UpdateAccount(Account account)
        {
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conn.Open();

                string sql = "UPDATE Account SET Email = @Email, Password = @Password WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Email", account.Email);
                cmd.Parameters.AddWithValue("@Password", account.Password);
                cmd.Parameters.AddWithValue("@Id", account.Id);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    _logger.LogInformation("An account has been updated.");
                    return true;
                }
                else
                {
                    _logger.LogInformation("Failed to update an account.");
                    return false;


                }
            }
        }

        public bool ValidateAccount(string email, string password)
        {
            bool isValid = false;
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Account WHERE Email = @email AND Password = @password", conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    isValid = true;
                }
            }
            return isValid;
        }

    }
}
