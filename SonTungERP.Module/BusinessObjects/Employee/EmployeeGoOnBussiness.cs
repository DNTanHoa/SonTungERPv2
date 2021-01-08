using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Phiếu công tác")]
    public class EmployeeGoOnBussiness : SystemBaseObject
    {
        public EmployeeGoOnBussiness(Session session) : base(session)
        {

        }

        public enum OutsideDocumentAppprovedStatusEnum
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

        Employee employee;
        DateTime outDate;
        DateTime outTime;
        DateTime? inTime;
        string place;
        string note;
        Employee manager;
        OutsideDocumentAppprovedStatusEnum status;

        [XafDisplayName("Nhân viên")]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        [XafDisplayName("Ngày đi")]
        public DateTime OutDate
        {
            get => outDate;
            set => SetPropertyValue(nameof(OutDate), ref outDate, value);
        }

        [XafDisplayName("Giờ đi")]
        public DateTime OutTime
        {
            get => outTime;
            set => SetPropertyValue(nameof(OutTime), ref outTime, value);
        }

        [XafDisplayName("Giờ về")]
        public DateTime? InTime
        {
            get => inTime;
            set => SetPropertyValue(nameof(InTime), ref inTime, value);
        }

        [XafDisplayName("Nơi đi")]
        public string Place
        {
            get => place;
            set => SetPropertyValue(nameof(Place), ref place, value);
        }

        [XafDisplayName("Ghi chú")]
        public string Note
        {
            get => note;
            set => SetPropertyValue(nameof(Note), ref note, value);
        }

        [XafDisplayName("Trưởng bộ phận")]
        public Employee Manager
        {
            get => manager;
            set => SetPropertyValue(nameof(Manager), ref manager, value);
        }

        [XafDisplayName("Trạng thái")]
        public OutsideDocumentAppprovedStatusEnum Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }
    }
}
