using Prism.Mvvm;
using PrismPRJ02.Core.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;

namespace NavigationTree.ViewModels
{
    public class TreeViewItemViewModel : BindableBase, IDisposable
	{
        // ---------------------------------------------------------------- //
        //  プロパティ
        // ---------------------------------------------------------------- //

        /// <summary>TreeViewItemのテキストを取得します。</summary>
        public ReadOnlyReactivePropertySlim<string> ItemText { get; }

		/// <summary>子ノードを取得します。</summary>
		public ReactiveCollection<TreeViewItemViewModel> Children { get; }

		/// <summary>TreeViewItem の元データを取得します。</summary>
		public object SourceData { get; } = null;

		/// <summary>TreeViewItem の元データを取得します。</summary>
		public ReactiveProperty<System.Windows.Media.ImageSource> ItemImage { get; }

		/// <summary>TreeViewItemをはじめから展開するかどうか</summary>
		public ReactivePropertySlim<bool> IsExpanded { get; set; }

        // ---------------------------------------------------------------- //
        //  メンバ変数
        // ---------------------------------------------------------------- //

        /// <summary>ReactivePropertyのDispose用リスト</summary>
        private System.Reactive.Disposables.CompositeDisposable disposables
			= new System.Reactive.Disposables.CompositeDisposable();

        // ---------------------------------------------------------------- //
        //  publicメソッド
        // ---------------------------------------------------------------- //

        /// <summary>コンストラクタ</summary>
        /// <param name="treeItem">TreeViewItem の元データを表すobject。</param>
        public TreeViewItemViewModel(object treeItem)
		{
			// 子ノードインスタンスを作成（初期値）
			this.Children = new ReactiveCollection<TreeViewItemViewModel>()
				.AddTo(this.disposables);

			// 最初からTreeViewItemを展開して表示するようにする
			this.IsExpanded = new ReactivePropertySlim<bool>(true).AddTo(this.disposables);

			// ItemTextに対応するファイル名を保持する文字列型
			var imageFileName = string.Empty;

			// Modelの型に合わせてItemTextのフォーマットを指定
			this.SourceData = treeItem;
			switch (this.SourceData)
			{
				case PersonalInformation p:
					this.ItemText = p.ObserveProperty(x => x.Name) // IObservable<string>に変更 （拡張メソッドとして実装）
						.ToReadOnlyReactivePropertySlim()		   // ReadOnlyReactivePropertySlim<string>に変更
						.AddTo(this.disposables);                  // 購読終了処理はdisposablesに丸投げする
					imageFileName = "user.png";
					break;
				case PhysicalInformation ph:
					this.ItemText = ph.ObserveProperty(x => x.MeasurementDate)
						.Select(d => d.HasValue ? d.Value.ToString("yyy年MM月dd日") : "新しい測定")
						.ToReadOnlyReactivePropertySlim()
						.AddTo(this.disposables);
					imageFileName = "heart.png";
					break;
				case TestPointInformation t:
					this.ItemText = t.ObserveProperty(x => x.TestDate)
						.ToReadOnlyReactivePropertySlim()
						.AddTo(this.disposables);
					imageFileName = "test.png";
					break;
				case string s:
					this.ItemText = this.ObserveProperty(x => x.SourceData)
						.Select(v => v as string)
						.ToReadOnlyReactivePropertySlim()
						.AddTo(this.disposables);
					if (s == "身体測定") { imageFileName = "physical_folder.png"; }
					else if (s == "試験結果") { imageFileName = "test_folder.png"; }
					break;
			}

            // image生成
			if (!string.IsNullOrEmpty(imageFileName))
            {
				var image = new System.Windows.Media.Imaging.BitmapImage(
					new Uri("pack://application:,,,/NavigationTree;component/Resources/" + imageFileName,
							UriKind.Absolute));
				this.ItemImage = new ReactiveProperty<System.Windows.Media.ImageSource>(image)
										.AddTo(this.disposables);
            }

		}

		/// <summary>オブジェクトを破棄します。</summary>
		void IDisposable.Dispose() { this.disposables.Dispose(); }
	}
}
