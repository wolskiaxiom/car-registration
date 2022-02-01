using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegistrationLibrary.Domain
{
    internal struct User
    {

        internal static User FromDbLine(string line)
        {
            Console.WriteLine(line);
            var split = line.Trim().Split(',');
            return new User(split[0], split[1], strToRole(split[2]));
        }

        public User(string login, string password, Role role)
        {
            Login = login;
            Password = password;
            Role = role;
        }

        public string Login { get; }
        public string Password { get; }
        public Role Role { get; }

        public String ToDbLine()
        {
            return $"{Login},{Password},{Role}";
        }

        private static Role strToRole(string str)
        {
            switch (str)
            {
                case "Producer":
                    return Role.Producer;
                case "Clerk":
                    return Role.Clerk;
                case "Mechanic":
                    return Role.Mechanic;
                default:
                    throw new ArgumentException($"Invalid role {str}");
            }
        }
    }
}
