using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using CarRegistrationLibrary.Domain;

namespace CarRegistration.ViewModels
{
    public class AddNewCarFormViewModel
    {
        public bool CheckPrivileges(Role role)
        {
            if (role == Role.Producer)
            {
                return true;
            }
            return false;
        }
    }
}
