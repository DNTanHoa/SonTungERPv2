using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Khai báo ca")]
    [DefaultClassOptions]
    public class ShiftAssigment : SystemBaseObject
    {
        public ShiftAssigment(Session session) : base(session)
        {

        }

        Employee employee;
        DateTime? endDate;
        DateTime? startDate;
        bool active;
        ShiftType shiftType;

        [XafDisplayName("Nhân viên")]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        [XafDisplayName("Ca làm việc")]
        public ShiftType ShiftType
        {
            get => shiftType;
            set => SetPropertyValue(nameof(ShiftType), ref shiftType, value);
        }

        [XafDisplayName("Từ ngày")]
        public DateTime? StartDate
        {
            get => startDate;
            set => SetPropertyValue(nameof(StartDate), ref startDate, value);
        }

        [XafDisplayName("Đến ngày")]
        public DateTime? EndDate
        {
            get => endDate;
            set => SetPropertyValue(nameof(EndDate), ref endDate, value);
        }

        [XafDisplayName("Hiệu lực")]
        public bool Active
        {
            get => active;
            set => SetPropertyValue(nameof(Active), ref active, value);
        }
    }
}
