using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Xps.Serialization;
using Unity;

namespace PrismFirstProject.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<string> _nameList;
        public ObservableCollection<string> NameList
        {
            get { return _nameList; }
            set { SetProperty(ref _nameList, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public DelegateCommand PushNameCommand { get; private set; }

        public MainWindowViewModel()
        {
            System.Diagnostics.Debug.WriteLine("Construct VM");
            NameList = new ObservableCollection<string>() { "a", "b" };
            PushNameCommand = new DelegateCommand(PushName, CanPushName)
                                    .ObservesProperty(() => Name);
            Name = "sample name";
        }

        private void PushName()
        {
            System.Diagnostics.Debug.WriteLine("PushName()");
            NameList.Add(Name);
        }
        private bool CanPushName()
        {
            System.Diagnostics.Debug.WriteLine("CanPushName()");
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
