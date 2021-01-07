using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Giới tính")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(DisplayName))]
    public class Gender : SystemBaseObject
    {
        public Gender(Session session) : base(session)
        {

        }

        string code;
        string name;

        [XafDisplayName("Ký hiệu")]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [XafDisplayName("Giới tính")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [NonPersistent]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public string DisplayName => this.Code + "-" + this.Name;
    }
}
