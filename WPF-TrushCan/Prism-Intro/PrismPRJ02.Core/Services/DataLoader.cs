using PrismPRJ02.Core.Models;

namespace PrismPRJ02.Core.Services
{
    public static class DataLoader
    {
        /// <summary>
        /// 新規のテストデータを生成する
        /// </summary>
        /// <returns></returns>
        private static WpfTestAppData createNewTestData()
        {
            var appData = new WpfTestAppData();
            appData.Student.Name = "新しい生徒";
            appData.Student.ClassNumber = "所属クラス";
            appData.Student.Sex = "男";

            appData.Physicals.Add(new PhysicalInformation() { Id = 1 });
            appData.TestPoints.Add(new TestPointInformation() { Id = 1, TestDate = "新しい試験日" });

            return appData;
        }

        /// <summary>
        /// データファイルからWpfTestAppDataにシリアライズする
        /// </summary>
        /// <param name="dataFilePath">データファイルのフルパス</param>
        /// <returns>生成したWpfTestAppData</returns>
        private static WpfTestAppData loadFromFile(string dataFilePath)
        {
            return new WpfTestAppData();
        }

        public static WpfTestAppData Load(string dataFilePath)
        {
            // 渡されたファイルパスが空ならダミーのインスタンスを生成
            if (dataFilePath == string.Empty) { return DataLoader.createNewTestData(); }
            return DataLoader.loadFromFile(dataFilePath);
        }
    }
}
