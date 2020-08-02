using EditorView.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace EditorView
{
    public class EditorViewModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PersonalEditor>();
            containerRegistry.RegisterForNavigation<PhysicalEditor>();
            containerRegistry.RegisterForNavigation<TestPointEditor>();
            containerRegistry.RegisterForNavigation<CategoryPanel>();
        }
    }
}