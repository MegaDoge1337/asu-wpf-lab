namespace Willberries.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Willberries.Enities;

    internal sealed class Configuration : DbMigrationsConfiguration<Willberries.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Willberries.AppDbContext context)
        {
            var administratorLogin = "Administrator";
            var administratorPassword = "11111";

            if (!context.Users.Any(u => u.Login == administratorLogin)) 
            {
                var administrator = new User();
                using (var MD5 = System.Security.Cryptography.MD5.Create()) 
                {
                    byte[] passwordBytes = System.Text.Encoding.ASCII.GetBytes(administratorPassword);
                    byte[] hashBytes = MD5.ComputeHash(passwordBytes);

                    administrator.Login = administratorLogin;
                    administrator.Password = BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLower();
                    administrator.IsAdministartor = true;

                    context.Users.Add(administrator);
                    context.SaveChanges();
                }
            }
        }
    }
}
