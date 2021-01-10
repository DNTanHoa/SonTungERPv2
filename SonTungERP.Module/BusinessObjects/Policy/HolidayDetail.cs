using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Bộ phận")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(name))]
    public class HolidayDetail : SystemBaseObject
    {
        public HolidayDetail(Session session)
            : base(session)
        {

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string name;
        DateTime? fromDate;
        DateTime? toDate;
        Holiday holiday;

        [XafDisplayName("Ngày lễ")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [XafDisplayName("Từ ngày")]
        public DateTime? FromDate
        {
            get => fromDate;
            set => SetPropertyValue(nameof(FromDate), ref fromDate, value);
        }

        [XafDisplayName("Đến ngày")]
        public DateTime? ToDate
        {
            get => toDate;
            set => SetPropertyValue(nameof(ToDate), ref toDate, value);
        }

        [Association]
        public Holiday Holiday
        {
            get => holiday;
            set => SetPropertyValue(nameof(Holiday), ref holiday, value);
        }
    }
}
