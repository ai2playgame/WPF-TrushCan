using Prism.Mvvm;
using PrismPRJ02.Core.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace NavigationTree.ViewModels
{
    public class TreeViewItemViewModel : BindableBase, IDisposable
	{
		/// <summary>TreeViewItemのテキストを取得します。</summary>
		public ReadOnlyReactivePropertySlim<string> ItemText { get; }

		/// <summary>子ノードを取得します。</summary>
		public ReactiveCollection<TreeViewItemViewModel> Children { get; }

		/// <summary>TreeViewItem の元データを取得します。</summary>
		public object SourceData { get; } = null;

		/// <summary>ReactivePropertyのDispose用リスト</summary>
		private System.Reactive.Disposables.CompositeDisposable disposables
			= new System.Reactive.Disposables.CompositeDisposable();

        /// <summary>コンストラクタ</summary>
		/// <param name="treeItem">TreeViewItem の元データを表すobject。</param>
		public TreeViewItemViewModel(object treeItem)
		{
			// 子ノードインスタンスを作成（初期値）
			this.Children = new ReactiveCollection<TreeViewItemViewModel>()
				.AddTo(this.disposables);

			// Modelの型に合わせてItemTextのフォーマットを指定
			this.SourceData = treeItem;
			switch (this.SourceData)
			{
				case PersonalInformation p:
					this.ItemText = p.ObserveProperty(x => x.Name) // IObservable<string>に変更
						.ToReadOnlyReactivePropertySlim()	// ReadOnlyReactivePropertySlim<string>に変更
						.AddTo(this.disposables);	// 購読終了処理はdisposablesに丸投げする
					break;
				case PhysicalInformation ph:
					this.ItemText = ph.ObserveProperty(x => x.MeasurementDate)
						.Select(d => d.HasValue ? d.Value.ToString("yyy年MM月dd日") : "新しい測定")
						.ToReadOnlyReactivePropertySlim()
						.AddTo(this.disposables);
					break;
				case TestPointInformation t:
					this.ItemText = t.ObserveProperty(x => x.TestDate)
						.ToReadOnlyReactivePropertySlim()
						.AddTo(this.disposables);
					break;
				case string s:
					this.ItemText = this.ObserveProperty(x => x.SourceData)
						.Select(v => v as string)
						.ToReadOnlyReactivePropertySlim()
						.AddTo(this.disposables);
					break;
			}
		}

		/// <summary>オブジェクトを破棄します。</summary>
		void IDisposable.Dispose() { this.disposables.Dispose(); }
	}
}
