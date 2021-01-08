using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("Chấm công")]
    public class EmployeeAttendance : SystemBaseObject
    {
        public EmployeeAttendance(Session session) : base(session)
        {

        }

        bool inActive;
        double overtimeHours;
        DateTime? outTime;
        DateTime? inTime;
        ShiftType shift;
        DateTime attendanceDate;
        double workingHours;
        double overtimeBonus;
        LeaveType leaveType;
        Employee employee;

        [XafDisplayName("Nhân viên")]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        [XafDisplayName("Ngày")]
        public DateTime AttendanceDate
        {
            get => attendanceDate;
            set => SetPropertyValue(nameof(AttendanceDate), ref attendanceDate, value);
        }

        [XafDisplayName("Số giờ làm việc")]
        public double WorkingHours
        {
            get => workingHours;
            set => SetPropertyValue(nameof(WorkingHours), ref workingHours, value);
        }

        [XafDisplayName("Tăng ca")]
        public double OvertimeHours
        {
            get => overtimeHours;
            set => SetPropertyValue(nameof(OvertimeHours), ref overtimeHours, value);
        }

        [XafDisplayName("Ca làm việc")]
        public ShiftType Shift
        {
            get => shift;
            set => SetPropertyValue(nameof(Shift), ref shift, value);
        }

        [XafDisplayName("Giờ vào")]
        public DateTime? InTime
        {
            get => inTime;
            set => SetPropertyValue(nameof(InTime), ref inTime, value);
        }

        [XafDisplayName("Giờ ra")]
        public DateTime? OutTime
        {
            get => outTime;
            set => SetPropertyValue(nameof(OutTime), ref outTime, value);
        }

        [XafDisplayName("Vắng mặt")]
        public bool InActive
        {
            get => inActive;
            set => SetPropertyValue(nameof(InActive), ref inActive, value);
        }

        [XafDisplayName("Loại vắng mặt")]
        public LeaveType LeaveType
        {
            get => leaveType;
            set => SetPropertyValue(nameof(LeaveType), ref leaveType, value);
        }

        [XafDisplayName("Phụ cấp tăng ca")]
        public double OvertimeBonus
        {
            get => overtimeBonus;
            set => SetPropertyValue(nameof(OvertimeBonus), ref overtimeBonus, value);
        }
    }
}
