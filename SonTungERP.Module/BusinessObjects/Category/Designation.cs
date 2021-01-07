using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Chức vụ")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(DisplayName))]
    public class Designation : SystemBaseObject
    {
        public Designation(Session session) : base(session)
        {

        }

        string code;
        string name;

        [XafDisplayName("Mã quản lý")]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [XafDisplayName("Chức danh")]
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
