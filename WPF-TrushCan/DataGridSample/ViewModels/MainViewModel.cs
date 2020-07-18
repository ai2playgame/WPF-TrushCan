using DataGridSample.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DataGridSample.ViewModels
{
    class MainViewModel
    {
        public ObservableCollection<Person> People { get; private set; }
        public MainViewModel()
        {
            this.People = new ObservableCollection<Person>(
                Enumerable.Range(1, 100).Select(x => new Person { Name = "dummy" + x }));
        }
    }
}
