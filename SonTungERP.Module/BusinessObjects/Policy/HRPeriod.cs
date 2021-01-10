using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Kỳ nhân sự")]
    [DefaultClassOptions]
    public class HRPeriod : SystemBaseObject
    {
        public HRPeriod(Session session)
            : base(session)
        {

        }

        string name;
        DateTime? fromDate;
        DateTime? toDate;
        bool isClosed;

        [XafDisplayName("Kỳ")]
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

        [XafDisplayName("Đóng kỳ")]
        public bool IsClosed
        {
            get => isClosed;
            set => SetPropertyValue(nameof(IsClosed), ref isClosed, value);
        }
    }
}
