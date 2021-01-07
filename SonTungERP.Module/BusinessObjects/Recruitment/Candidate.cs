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

        string fullName;
        string phone;
        string email;
        string identityNumber;
        string education;
        string school;
        string major;
        string originAddress;
        string temporaryAddress;
        DateTime? willJoinDate;

        [XafDisplayName("Họ tên")]
        public string FullName
        {
            get => fullName;
            set => SetPropertyValue(nameof(FullName), ref fullName, value);
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
        public string IdentityNumber
        {
            get => identityNumber;
            set => SetPropertyValue(nameof(IdentityNumber), ref identityNumber, value);
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
            get => education;
            set => SetPropertyValue(nameof(Education), ref education, value);
        }

        [XafDisplayName("Ngày vào làm (DK)")]
        public DateTime? WillJoinDate
        {
            get => willJoinDate;
            set => SetPropertyValue(nameof(WillJoinDate), ref willJoinDate, value);
        }
    }
}
