using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Điểm danh")]
    [DefaultClassOptions]
    public class EmployeeCheckIn : SystemBaseObject
    {
        public EmployeeCheckIn(Session session) : base(session)
        {

        }

        Employee employee;
        DateTime date;
        DateTime time;
        string attendanceDeviceID;

        [XafDisplayName("Nhân viên")]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        [XafDisplayName("Mã điểm danh")]
        public string AttendanceDeviceID
        {
            get => attendanceDeviceID;
            set => SetPropertyValue(nameof(AttendanceDeviceID), ref attendanceDeviceID, value);
        }

        [XafDisplayName("Ngày")]
        public DateTime Date
        {
            get => date;
            set => SetPropertyValue(nameof(Date), ref date, value);
        }

        [XafDisplayName("Giờ")]
        public DateTime Time
        {
            get => time;
            set
            {
                SetPropertyValue(nameof(Time), ref time, value);
                this.Date = value;
            }
        }
        
    }
}
