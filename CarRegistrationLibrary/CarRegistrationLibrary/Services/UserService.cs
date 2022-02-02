using CarRegistrationLibrary.Domain;
using CarRegistrationLibrary.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegistrationLibrary.Services
{


    public class UserService
    {

        private List<User> savedUsers;

        public UserService()
        {
            savedUsers = FileUtils.LoadFile("users.db").Select(line => User.FromDbLine(line)).ToList();
        }

        public Role CheckLogin(String login, String passwordRaw)
        {
            try
            {
                var found = savedUsers.Where(user => user.Login == login && user.Password == passwordRaw).Single();
                return found.Role;
            } catch
            {
                return Role.User;
            }
        }

        public void AddNewUser(String login, String passwordRaw, Role role)
        {
            if(!savedUsers.Exists(user => user.Login == login))
            {
                savedUsers.Add(new User(login, passwordRaw, role));
                Flush();
            }       
        }

        public List<string> GetAllUsers()
        {
            return savedUsers.Select(user => user.Login).ToList();
        }

        private void Flush()
        {
            FileUtils.SaveToFile("users.db", savedUsers.Select(user => user.ToDbLine()));
        }
    }
}
