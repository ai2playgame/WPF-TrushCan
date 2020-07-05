using aiMVVMLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProject.Models
{
    class Book : NotificationObject
    {
        private string _name;
        public string Name { 
            get => _name;
            set 
            {
                SetProperty(ref _name, value); 
                // _name = value;
            }
        }
    }
}
