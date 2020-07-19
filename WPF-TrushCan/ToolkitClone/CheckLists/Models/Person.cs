using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace CheckLists.Models
{
    class Person : BindableBase
    {
        // ---------------------------------------------------------------- //
        //  プロパティ
        // ---------------------------------------------------------------- //
        private int _ID;
        public int ID
        {
            get => _ID;
            set => SetProperty(ref _ID, value);
        }
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }
        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string ModelDisplay
        {
            get
            {
                string completeName = string.Format("{0} {1}", FirstName, LastName).PadRight(20);
                return string.Format(
                    "ID={0}, Name={1}", ID, completeName);
            }
        }

    }
}
