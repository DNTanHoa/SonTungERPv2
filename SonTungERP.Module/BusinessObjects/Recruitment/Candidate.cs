using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Ứng viên")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(fullName))]
    public class Candidate : SystemBaseObject
    {
        public Candidate(Session session) : base(session)
        {

        }

        string code;
        string fullName;
        string phone;
        string email;
        string identity;
        IdentiyLicesenPlace identityLicesenPlace;
        DateTime idetityLicesenDate;
        string education;
        string school;
        string major;
        Gender gender;
        string originAddress;
        string temporaryAddress;
        DateTime? willJoinDate;

        bool employee;
        string employeeCode;

        [XafDisplayName("Mã nhân viên")]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [XafDisplayName("Họ tên")]
        public string FullName
        {
            get => fullName;
            set => SetPropertyValue(nameof(FullName), ref fullName, value);
        }

        [XafDisplayName("Giới tính")]
        public Gender Gender
        {
            get => gender;
            set => SetPropertyValue(nameof(Gender), ref gender, value);
        }

        [XafDisplayName("Điện thoại")]
        public string Phone
        {
            get => phone;
            set => SetPropertyValue(nameof(Phone), ref phone, value);
        }

        [XafDisplayName("Email")]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }

        [XafDisplayName("Thường trú")]
        public string OriginAddress
        {
            get => originAddress;
            set => SetPropertyValue(nameof(OriginAddress), ref originAddress, value);
        }

        [XafDisplayName("Tạm trú")]
        public string TemporaryAddress
        {
            get => temporaryAddress;
            set => SetPropertyValue(nameof(TemporaryAddress), ref temporaryAddress, value);
        }

        [XafDisplayName("CMND/CCCD")]
        public string Identity
        {
            get => identity;
            set => SetPropertyValue(nameof(Identity), ref identity, value);
        }

        [XafDisplayName("Nơi cấp")]
        public IdentiyLicesenPlace IdentiyLicesenPlace
        {
            get => identityLicesenPlace;
            set => SetPropertyValue(nameof(IdentiyLicesenPlace), ref identityLicesenPlace, value);
        }

        [XafDisplayName("Ngày cấp")]
        public DateTime IdetityLicesenDate
        {
            get => idetityLicesenDate;
            set => SetPropertyValue(nameof(IdetityLicesenDate), ref idetityLicesenDate, value);
        }

        [XafDisplayName("Học vấn")]
        public string Education
        {
            get => education;
            set => SetPropertyValue(nameof(Education), ref education, value);
        }

        [XafDisplayName("Chuyên ngành")]
        public string Major
        {
            get => major;
            set => SetPropertyValue(nameof(Major), ref major, value);
        }

        [XafDisplayName("Trường học")]
        public string School
        {
            get => school;
            set => SetPropertyValue(nameof(School), ref school, value);
        }

        [XafDisplayName("Ngày vào làm (DK)")]
        public DateTime? WillJoinDate
        {
            get => willJoinDate;
            set => SetPropertyValue(nameof(WillJoinDate), ref willJoinDate, value);
        }

        [XafDisplayName("Nhân viên")]
        public bool Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        [XafDisplayName("Mã nhân viên")]
        public string EmployeeCode
        {
            get => employeeCode;
            set => SetPropertyValue(nameof(EmployeeCode), ref employeeCode, value);
        }
    }
}
