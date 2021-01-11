using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Trình độ học vấn")]
    [DefaultClassOptions]
    public class CandidateEducation : SystemBaseObject
    {
        public CandidateEducation(Session session) : base(session)
        {

        }

        Candidate candidate;
        string time;
        string school;
        string major;
        string level;
        string type;

        [Association]
        [XafDisplayName("Ứng viên")]
        public Candidate Candidate
        {
            get => candidate;
            set => SetPropertyValue(nameof(Candidate), ref candidate, value);
        }

        [XafDisplayName("Thời gian")]
        public string Time
        {
            get => time;
            set => SetPropertyValue(nameof(Time), ref time, value);
        }

        [XafDisplayName("Nơi đào tạo")]
        public string School
        {
            get => school;
            set => SetPropertyValue(nameof(School), ref school, value);
        }

        [Size(250)]
        [XafDisplayName("Chuyên ngành")]
        public string Major
        {
            get => major;
            set => SetPropertyValue(nameof(Major), ref major, value);
        }

        [XafDisplayName("Hạng tót nghiệp")]
        public string Level
        {
            get => level;
            set => SetPropertyValue(nameof(Level), ref level, value);
        }

        [XafDisplayName("Loại hình đào tạo")]
        public string Type
        {
            get => type;
            set => SetPropertyValue(nameof(Type), ref type, value);
        }
    }
}
