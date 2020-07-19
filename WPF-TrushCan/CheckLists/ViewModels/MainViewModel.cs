using CheckLists.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CheckLists.ViewModels
{
    class MainViewModel : BindableBase
    {
        // ---------------------------------------------------------------- //
        //  プロパティ
        // ---------------------------------------------------------------- //
        
        // ListViewに入れるData
        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();

        public int IDCount { get; set; } = 0;
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                SetProperty(ref _firstName, value);
                this.AddPersonCommand.RaiseCanExecuteChanged();
            }
        }
        private string _lastName;
        public string LastName 
        {
            get => _lastName;
            set
            {
                SetProperty(ref _lastName, value);
                this.AddPersonCommand.RaiseCanExecuteChanged();
            }
        }

        // People追加用コマンド
        public DelegateCommand AddPersonCommand { get; private set; }

        // ---------------------------------------------------------------- //
        //  コンストラクタ
        // ---------------------------------------------------------------- //
        public MainViewModel()
        {
            AddPersonCommand = new DelegateCommand(this.AddPerson, this.CanAddPerson);
            People.Add(new Person() { ID = IDCount, FirstName = "Adam", LastName = "Eevee" });
            IDCount++;
        }

        // ---------------------------------------------------------------- //
        //  メソッド
        // ---------------------------------------------------------------- //
        
        /// <summary>
        /// Peopleに新たにPersonを追加
        /// </summary>
        private void AddPerson()
        {
            People.Add(new Person()
            {
                ID = IDCount,
                FirstName = this.FirstName,
                LastName = this.LastName
            });
            IDCount++;
        }
        /// <summary>
        /// AddCommmandの実行可否を返す
        /// </summary>
        private bool CanAddPerson()
        {
            return !string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.LastName);
        }

    }
}
