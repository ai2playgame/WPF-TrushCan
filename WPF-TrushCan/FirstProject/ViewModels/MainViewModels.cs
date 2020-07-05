using aiMVVMLib;

namespace FirstProject.ViewModels
{
    using Models;
    using System.Reflection.Metadata;
    using System.Windows.Navigation;

    class MainViewModels : NotificationObject
    {
        public MainViewModels()
        {

        }
        private Book _book1 = new Book();
        public Book Book1
        {
            get => _book1;
            private set { _book1 = value; }
        }
    }
}
