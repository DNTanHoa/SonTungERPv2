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
    public class CandidateSkill : SystemBaseObject
    {
        public CandidateSkill(Session session) : base(session)
        {

        }

        Candidate candidate;
        Skill skill;
        SkillLevel level;

        [Association]
        [XafDisplayName("Ứng viên")]
        public Candidate Candidate
        {
            get => candidate;
            set => SetPropertyValue(nameof(Candidate), ref candidate, value);
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
