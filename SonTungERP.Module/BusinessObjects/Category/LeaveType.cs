using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("Loại vắng mặt")]
    public class LeaveType : SystemBaseObject
    {
        public LeaveType(Session session)
            : base(session)
        {
        }

        bool isEarnedLeave;
        string name;
        string code;
        double? totalLeaveHours;

        [XafDisplayName("Ký hiệu")]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [XafDisplayName("Loại vắng mặt")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [XafDisplayName("Trả lương")]
        public bool IsEarnedLeave
        {
            get => isEarnedLeave;
            set => SetPropertyValue(nameof(IsEarnedLeave), ref isEarnedLeave, value);
        }

        [XafDisplayName("Tổng giờ công")]
        public double? TotalLeaveHours
        {
            get => totalLeaveHours;
            set => SetPropertyValue(nameof(TotalLeaveHours), ref totalLeaveHours, value);
        }
    }
}
