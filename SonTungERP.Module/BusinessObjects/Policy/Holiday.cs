using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Đợt nghỉ lễ")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(Name))]
    public class Holiday : SystemBaseObject
    {
        public Holiday(Session session)
            : base(session)
        {

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string name;

        [XafDisplayName("Đợt nghỉ lễ")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [XafDisplayName("Chi tiết ngày nghỉ")]
        [Association]
        public XPCollection<HolidayDetail> HolidayDetails => GetCollection<HolidayDetail>(nameof(HolidayDetails));
    }
}
