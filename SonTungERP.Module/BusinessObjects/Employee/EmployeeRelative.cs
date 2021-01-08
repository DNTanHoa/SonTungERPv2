using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Người thân")]
    [DefaultClassOptions]
    public class EmployeeRelative : SystemBaseObject
    {
        public EmployeeRelative(Session session) : base(session)
        {
        }

        Employee employee;
        RelativeType type;
        string fullName;
        DateTime dateOfBirth;
        string originAddress;
        string temporaryAddress;
        string phone;
        string email;
        bool isDependentperson;

        [Association]
        [XafDisplayName("Nhân viên")]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        [XafDisplayName("Mối quan hệ")]
        public RelativeType Type
        {
            get => type;
            set => SetPropertyValue(nameof(Type), ref type, value);
        }

        [XafDisplayName("Họ tên")]
        public string FullName
        {
            get => fullName;
            set => SetPropertyValue(nameof(FullName), ref fullName, value);
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

        [XafDisplayName("Là người phụ thuộc")]
        public bool IsDependentPerson
        {
            get => isDependentperson;
            set => SetPropertyValue(nameof(IsDependentPerson), ref isDependentperson, value);
        }

        [XafDisplayName("Ngày sinh")]
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set => SetPropertyValue(nameof(DateOfBirth), ref dateOfBirth, value);
        }
    }
}
