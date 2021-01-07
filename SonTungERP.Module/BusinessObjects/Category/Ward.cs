using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Xã - Phường")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(DisplayName))]
    public class Ward : SystemBaseObject
    {
        public Ward(Session session) : base(session)
        {

        }

        string code;
        string name;
        District district;

        [XafDisplayName("Mã quản lý")]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [XafDisplayName("Xã/Phường/Thị trấn")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [Association]
        public District District
        {
            get => district;
            set => SetPropertyValue(nameof(District), ref district, value);
        }

        [NonPersistent]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public string DisplayName => this.Code + "-" + this.Name;
    }
}
