using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Tình trạng hôn nhân")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(DisplayName))]
    public class MaritalStatus : SystemBaseObject
    {
        public MaritalStatus(Session session) : base(session)
        {

        }

        string name;
        string code;

        [XafDisplayName("Ký hiệu")]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [XafDisplayName("Tình trạng hôn nhân")]
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
