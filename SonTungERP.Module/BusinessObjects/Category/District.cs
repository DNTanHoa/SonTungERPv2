using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Quận - Huyện")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(DisplayName))]
    public class District : SystemBaseObject
    {
        public District(Session session) : base(session)
        {

        }

        string code;
        string name;
        Province province;

        [XafDisplayName("Mã quản lý")]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [XafDisplayName("Tên quận/huyện")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [Association]
        [XafDisplayName("Tỉnh")]
        public Province Province
        {
            get => province;
            set => SetPropertyValue(nameof(Province), ref province, value);
        }

        [NonPersistent]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public string DisplayName => this.Code + "-" + this.Name;

        [Association]
        [XafDisplayName("Danh sách xã/phường")]
        public XPCollection<Ward> Wards => GetCollection<Ward>(nameof(Wards));
    }
}
