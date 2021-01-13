using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Khen thưởng, kỷ luật")]
    public class EmployeeEvaluate : SystemBaseObject
    {
        public EmployeeEvaluate(Session session) : base(session)
        {

        }

        public enum EvaluateType
        {
            [XafDisplayName("Kỷ luật")]
            Discipline,
            [XafDisplayName("Khen thưởng")]
            Bonus
        }

        Employee employee;
        DateTime date;
        Employee decisionPerson;
        EvaluateType type;
        string filePath;

        [XafDisplayName("Nhân viên")]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        [XafDisplayName("Ngày")]
        public DateTime Date
        {
            get => date;
            set => SetPropertyValue(nameof(Date), ref date, value);
        }

        [XafDisplayName("Người ra quyết định")]
        public Employee DecisionPerson
        {
            get => decisionPerson;
            set => SetPropertyValue(nameof(DecisionPerson), ref decisionPerson, value);
        }

        [XafDisplayName("Loại")]
        public EvaluateType Type
        {
            get => type;
            set => SetPropertyValue(nameof(Type), ref type, value);
        }

        [XafDisplayName("Bản lưu")]
        public string FilePath
        {
            get => filePath;
            set => SetPropertyValue(nameof(FilePath), ref filePath, value);
        }
    }
}
