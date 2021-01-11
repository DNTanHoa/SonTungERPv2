using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Quan hệ ứng viên")]
    [DefaultClassOptions]
    public class CandidateRelative : SystemBaseObject
    {
        public CandidateRelative(Session session) : base(session)
        {

        }

        Candidate candidate;
        RelativeType type;
        string fullName;
        DateTime dateOfBirth;
        string originAddress;
        string temporaryAddress;
        string phone;
        string email;
        string job;

        [Association]
        [XafDisplayName("Ứng viên")]
        public Candidate Candidate
        {
            get => candidate;
            set => SetPropertyValue(nameof(Candidate), ref candidate, value);
        }

        [XafDisplayName("Mối quan hệ")]
        public RelativeType Type
        {
            get => type;
            set => SetPropertyValue(nameof(Type), ref type, value);
        }

        [XafDisplayName("Họ tên")]
        [Size(250)]
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
        
        [XafDisplayName("Ngày sinh")]
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set => SetPropertyValue(nameof(DateOfBirth), ref dateOfBirth, value);
        }

        [XafDisplayName("Nghề nghiệp")]
        public string Job
        {
            get => job;
            set => SetPropertyValue(nameof(Job), ref job, value);
        }
    }
}
