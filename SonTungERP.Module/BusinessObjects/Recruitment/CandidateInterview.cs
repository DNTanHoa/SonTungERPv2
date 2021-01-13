using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Phỏng vấn")]
    public class CandidateInterview : SystemBaseObject
    {
        public CandidateInterview(Session session) : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        public enum ResultEnum
        {
            [XafDisplayName("Phỏng vấn đạt")]
            Passed,
            [XafDisplayName("Rớt")]
            Failed,
            [XafDisplayName("Phỏng vấn vòng sau")]
            WaitForNext
        }

        Candidate candidate;
        DateTime interviewDate;
        Employee interviewPerson;
        ResultEnum result;
        string note;

        [XafDisplayName("Ứng viên")]
        public Candidate Candidate
        {
            get => candidate;
            set => SetPropertyValue(nameof(Candidate), ref candidate, value);
        }

        [XafDisplayName("Ngày phỏng vấn")]
        public DateTime InterviewDate
        {
            get => interviewDate;
            set => SetPropertyValue(nameof(InterviewDate), ref interviewDate, value);
        }

        [XafDisplayName("Người phỏng vấn")]
        public Employee InterviewPerson
        {
            get => interviewPerson;
            set => SetPropertyValue(nameof(InterviewPerson), ref interviewPerson, value);
        }

        [XafDisplayName("Kết quả")]
        public ResultEnum Result
        {
            get => result;
            set => SetPropertyValue(nameof(Result), ref result, value);
        }

        [XafDisplayName("Người phỏng vấn")]
        public string Note
        {
            get => Note;
            set => SetPropertyValue(nameof(Note), ref note, value);
        }
    }
}