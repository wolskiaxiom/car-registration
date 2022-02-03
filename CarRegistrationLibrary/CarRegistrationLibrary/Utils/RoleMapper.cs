using CarRegistrationLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegistrationLibrary.Utils
{
    public class RoleMapper
    {
        public static string FromRoleToString(Role role)
        {
            switch (role)
            {
                case Role.User:
                    return "Użytkownik";
                case Role.Mechanic:
                    return "Mechanik";
                case Role.Clerk:
                    return "Urzędnik";
                case Role.Producer:
                    return "Producent";
                default:
                    return "";
            }
        }
        public static Role FromStringToRole(string role)
        {
            switch (role)
            {
                case "Użytkownik":
                    return Role.User;
                case "Mechanik":
                    return Role.Mechanic;
                case "Urzędnik":
                    return Role.Clerk;
                case "Producent":
                    return Role.Producer;
                default:
                    return Role.User;
            }
        }
    }
}
