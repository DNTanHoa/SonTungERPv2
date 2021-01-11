using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Kỹ năng")]
    [DefaultClassOptions]
    public class EmployeeSkill : SystemBaseObject
    {
        public EmployeeSkill(Session session) : base(session)
        {

        }
        Employee employee;
        Skill skill;
        SkillLevel level;

        [Association]
        [XafDisplayName("Nhân viên")]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        [XafDisplayName("Kỹ năng")]
        public Skill Skill
        {
            get => skill;
            set => SetPropertyValue(nameof(Skill), ref skill, value);
        }

        [XafDisplayName("Mức đánh giá")]
        public SkillLevel Level
        {
            get => level;
            set => SetPropertyValue(nameof(Level), ref level, value);
        }
    }
}
