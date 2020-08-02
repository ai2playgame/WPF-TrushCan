using Prism.Mvvm;
using System;
using PrismPRJ02.Core.Models;
using Reactive.Bindings;
using System.Collections.ObjectModel;
using Reactive.Bindings.Extensions;

namespace NavigationTree.ViewModels
{
    public class NavigationTreeViewModel : BindableBase, IDisposable
    {
        /// <summary>
        /// TreeViewItemを取得する
        /// </summary>
        public ReadOnlyReactiveCollection<TreeViewItemViewModel> TreeNodes { get; }

        private WpfTestAppData appData = null;
        private TreeViewItemViewModel rootNode = null;

        /// <summary>
        /// ReactivePropertyの為のDispose用リスト
        /// </summary>
        private System.Reactive.Disposables.CompositeDisposable disposables = new System.Reactive.Disposables.CompositeDisposable();

        /// <summary>
        /// コンストラクタ（PrismによりWpfTestAppData引数は自動で割り当てられる）
        /// </summary>
        /// <param name="testAppData"></param>
        public NavigationTreeViewModel(WpfTestAppData testAppData)
        {
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
    }
}
