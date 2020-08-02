using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismPRJ02.Core.Models;

namespace NavigationTree
{
    public class NavigationTreeModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            // DIコンテナに"NaviTree"という文字列でNavigationTreeをRegionとして登録する
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("NaviTree", typeof(Views.NavigationTree));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}