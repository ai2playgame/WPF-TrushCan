using NavigationTree;
using Prism.Ioc;
using Prism.Modularity;
using PrismPRJ02.Views;
using System.Windows;

namespace PrismPRJ02
{
    using Core.Models;
    using Core.Services;
    using EditorView;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        private string dataFilePath = string.Empty;

        protected override void OnStartup(StartupEventArgs e)
        {
            // 起動時引数をdataFilePathに指定する
            if (e.Args.Length == 1) { this.dataFilePath = e.Args[0]; }
            base.OnStartup(e);
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<WpfTestAppData>(DataLoader.Load(this.dataFilePath));
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<NavigationTreeModule>(InitializationMode.WhenAvailable);
            moduleCatalog.AddModule<EditorViewModule>(InitializationMode.WhenAvailable);
        }
    }
}
