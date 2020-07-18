using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataGridSample.Models
{
    class Person : BindableBase
    {
        // ---------------------------------------------------------------- //
        //  プロパティ
        // ---------------------------------------------------------------- //
        private string id;
        public string ID
        {
            get => this.id;
            set => this.SetProperty(ref this.id, value);
        }
        private string name;
        public string Name
        {
            get => this.name;
            set => this.SetProperty(ref this.name, value);
        }
        private string parentID;
        public string ParentID
        {
            get => this.parentID;
            set => this.SetProperty(ref this.parentID, value);
        }

        // ---------------------------------------------------------------- //
        //  コンストラクタ
        // ---------------------------------------------------------------- //
        public Person()
        {
            this.ID = Guid.NewGuid().ToString();
        }
    }
}
