namespace Scheduler.Dal
{
    public static class BCryptTool
    {
        public static string GenerateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }

        public static string HashPassword(string password, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        public static bool ValidateHashPassword(string hashpassword, string storedHashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(hashpassword, storedHashPassword);
        }
    }
}
