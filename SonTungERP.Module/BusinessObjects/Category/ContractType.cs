using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Loại hợp đồng")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(DisplayName))]
    public class ContractType : SystemBaseObject
    {
        public ContractType(Session session) : base(session)
        {

        }

        string code;
        string name;
        int? month;
        int? day;

        [XafDisplayName("Mã quản lý")]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [XafDisplayName("Loại hợp đồng")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [XafDisplayName("Số tháng")]
        public int? Month
        {
            get => month;
            set => SetPropertyValue(nameof(Month), ref month, value);
        }

        [XafDisplayName("Số ngày")]
        public int? Day
        {
            get => day;
            set => SetPropertyValue(nameof(Day), ref day, value);
        }

        [NonPersistent]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public string DisplayName => this.Code + "-" + this.Name;
    }
}
