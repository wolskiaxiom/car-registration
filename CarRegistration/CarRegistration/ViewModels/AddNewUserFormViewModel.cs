using CarRegistrationLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRegistration.ViewModels
{
    class AddNewUserFormViewModel
    {
        
        public bool CheckPrivileges(Role role)
        {
            if (role == Role.Clerk)
            {
                return true;
            }
            return false;
        }
    }
}
