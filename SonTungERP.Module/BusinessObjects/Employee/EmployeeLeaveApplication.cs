using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Reason))]
    [XafDisplayName("Xin nghỉ phép")]
    public class EmployeeLeaveApplication: SystemBaseObject
    {
        public enum LeaveApplicationStatusEnum
        {
            [XafDisplayName("Đang gửi xử lý")]
            Pending,
            [XafDisplayName("Chuyển tiếp")]
            Forward,
            [XafDisplayName("Phê duyệt")]
            Approved,
            [XafDisplayName("Không chấp nhận")]
            Rejected
        }

        public EmployeeLeaveApplication(Session session)
            : base(session)
        {

        }

        protected override void OnSaving()
        {
            base.OnSaving();
        }

        DateTime postingDate;
        string reason;
        DateTime toDate;
        DateTime fromDate;
        LeaveType leaveType;
        Employee employee;
        LeaveApplicationStatusEnum status;

        [XafDisplayName("Nhân viên")]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        [XafDisplayName("Loại nghỉ")]
        public LeaveType LeaveType
        {
            get => leaveType;
            set => SetPropertyValue(nameof(LeaveType), ref leaveType, value);
        }

        [XafDisplayName("Từ ngày")]
        public DateTime FromDate
        {
            get => fromDate;
            set => SetPropertyValue(nameof(FromDate), ref fromDate, value);
        }

        [XafDisplayName("Đến ngày")]
        public DateTime ToDate
        {
            get => toDate;
            set => SetPropertyValue(nameof(ToDate), ref toDate, value);
        }

        [XafDisplayName("Lý do")]
        public string Reason
        {
            get => reason;
            set => SetPropertyValue(nameof(Reason), ref reason, value);
        }

        [XafDisplayName("Ngày gửi")]
        public DateTime PostingDate
        {
            get => postingDate;
            set => SetPropertyValue(nameof(PostingDate), ref postingDate, value);
        }

        [XafDisplayName("Trạng thái")]
        public LeaveApplicationStatusEnum Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }
    }
}
