using Prism.Mvvm;
using System;
using PrismPRJ02.Core.Models;
using Reactive.Bindings;
using System.Collections.ObjectModel;
using Reactive.Bindings.Extensions;
using Prism.Commands;
using Unity;

namespace NavigationTree.ViewModels
{
    public class NavigationTreeViewModel : BindableBase, IDisposable
    {
        // ---------------------------------------------------------------- //
        //  プロパティ
        // ---------------------------------------------------------------- //
        /// <summary> TreeViewItemを保持するコレクション </summary>
        public ReadOnlyReactiveCollection<TreeViewItemViewModel> TreeNodes { get; }

        // ---------------------------------------------------------------- //
        //  コマンド
        // ---------------------------------------------------------------- //
        private DelegateCommand<object> selectedItemChangedCmd;
        public DelegateCommand<object> SelectedItemChanged =>
            selectedItemChangedCmd ??
                (selectedItemChangedCmd = new DelegateCommand<object>(ExecSelectedItemChanged, CanExecSelectedItemChanged));


        // ---------------------------------------------------------------- //
        //  privateメンバ変数
        // ---------------------------------------------------------------- //
        private WpfTestAppData appData = null;
        private TreeViewItemViewModel rootNode = null;

        /// <summary>ReactivePropertyの後始末用のDisposeリスト</summary>
        private System.Reactive.Disposables.CompositeDisposable disposables = new System.Reactive.Disposables.CompositeDisposable();

        /// <summary> Region動的切り替えの為のマネージャクラス </summary>
        private Prism.Regions.IRegionManager regionManager = null;

        // ---------------------------------------------------------------- //
        //  メンバメソッド
        // ---------------------------------------------------------------- //

        /// <summary>
        /// コンストラクタ（PrismによりWpfTestAppData引数は自動で割り当てられる）
        /// </summary>
        /// <param name="testAppData"></param>
        public NavigationTreeViewModel(WpfTestAppData testAppData, Prism.Regions.IRegionManager rm)
        {
            // DIコンテナ経由でこのVMに渡されるregionManagerをメンバに設定
            this.regionManager = rm;

            this.appData = testAppData;

            // 木構造を作成
            this.rootNode = TreeViewItemCreator.Create(this.appData);

            // 木のルートをListに追加
            var col = new ObservableCollection<TreeViewItemViewModel>();
            col.Add(this.rootNode);

            // ObservableCollectionをRx対応
            this.TreeNodes = col.ToReadOnlyReactiveCollection().AddTo(this.disposables);
        }

        public void Dispose()
        {
            this.disposables.Dispose();
        }

        private void ExecSelectedItemChanged(object obj)
        {
            var item = obj as ViewModels.TreeViewItemViewModel;
            var viewName = string.Empty;
			switch (item.SourceData)
            {
				case PersonalInformation p:
                    viewName = "PersonalEditor";
                    break;
				case PhysicalInformation ph:
                    viewName = "PhysicalEditor";
                    break;
                case TestPointInformation t:
                    viewName = "TestPointEditor";
                    break;
				case string s:
                    viewName = "CategoryPanel";
                    break;
            }

            // RegionManagerに対応するViewを設定
            this.regionManager.RequestNavigate("EditorArea", viewName);
        }

        private bool CanExecSelectedItemChanged(object arg)
        {
            return true;
        }

    }
}
