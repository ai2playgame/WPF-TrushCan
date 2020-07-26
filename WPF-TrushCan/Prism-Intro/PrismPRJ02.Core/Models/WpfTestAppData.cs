using System.Collections.ObjectModel;

namespace PrismPRJ02.Core.Models
{
    [System.Runtime.Serialization.DataContract]
    public class WpfTestAppData
    {
        /// <summary>
        /// 生徒の情報を保持するプロパティ
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public PersonalInformation Student { get; set; } = new PersonalInformation();

        /// <summary>
        /// 身体測定の結果を保持するコレクション
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public ObservableCollection<PhysicalInformation> Physicals { get; private set; } = new ObservableCollection<PhysicalInformation>();

        /// <summary>
        /// 試験の得点を保持するコレクション
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public ObservableCollection<TestPointInformation> TestPoints { get; private set; } = new ObservableCollection<TestPointInformation>();
    }
}
