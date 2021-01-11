using DevExpress.Data.Filtering;
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

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            var candidates = Session.GetObjects(ClassInfo,
                CriteriaOperator.Parse("[Year] = ?", DateTime.Now.Year),
                null,
                0,
                false,
                false);

            this.Code = "UV"
                + DateTime.Now.ToString("yyyyMM")
                + (candidates.Count + 1).ToString().PadLeft(5, '0');
        }

        string code;
        string fullName;
        string phone;
        string email;
        string identity;
        IdentiyLicesenPlace identityLicesenPlace;
        DateTime idetityLicesenDate;
        DateTime dateOfBirth;
        Province placeOfBirth;
        string education;
        string school;
        string major;
        Gender gender;
        string originAddress;
        string temporaryAddress;
        MaritalStatus maritalStatus;
        string fileSavePath;
        Job job;
        Designation designation;
        Religion religion;
        #region self
        string quality;
        string strength;
        string weakness;
        string personalities;
        string gifted;
        string interests;
        #endregion

        #region salary require
        double probationarySalary;
        double officalSalary;
        double desiredSalary;
        DateTime? willJoinDate;
        ContractType desiredContractType;
        RecruitmentPlan recruitmentPlan;
        #endregion

        bool employee;
        string employeeCode;

        [XafDisplayName("Mã ứng viên")]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [XafDisplayName("Kế hoạch tuyển dụng")]
        [Association]
        public RecruitmentPlan RecruitmentPlan
        {
            get => recruitmentPlan;
            set => SetPropertyValue(nameof(RecruitmentPlan), ref recruitmentPlan, value);
        }

        [XafDisplayName("Chức vụ")]
        public Designation Designation
        {
            get => designation;
            set => SetPropertyValue(nameof(Designation), ref designation, value);
        }

        [XafDisplayName("Chức danh")]
        public Job Job
        {
            get => job;
            set => SetPropertyValue(nameof(Job), ref job, value);
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

        [XafDisplayName("Tình trạng hôn nhân")]
        public MaritalStatus MaritalStatus
        {
            get => maritalStatus;
            set => SetPropertyValue(nameof(MaritalStatus), ref maritalStatus, value);
        }

        public string FileSavePath
        {
            get => fileSavePath;
            set => SetPropertyValue(nameof(FileSavePath), ref fileSavePath, value);
        }

        public Province PlaceOfBirth
        {
            get => placeOfBirth;
            set => SetPropertyValue(nameof(PlaceOfBirth), ref placeOfBirth, value);
        }

        [XafDisplayName("Tôn giáo")]
        public Religion Religion
        {
            get => religion;
            set => SetPropertyValue(nameof(Religion), ref religion, value);
        }

        #region self implement
        [XafDisplayName("Phẩm chất")]
        public string Quality
        {
            get => quality;
            set => SetPropertyValue(nameof(Quality), ref quality, value);
        }

        [XafDisplayName("Điểm mạnh")]
        public string Strength
        {
            get => strength;
            set => SetPropertyValue(nameof(Strength), ref strength, value);
        }

        [XafDisplayName("Điểm yếu")]
        public string Weakness
        {
            get => weakness;
            set => SetPropertyValue(nameof(Weakness), ref weakness, value);
        }

        [XafDisplayName("Cá tính")]
        public string Personalities
        {
            get => personalities;
            set => SetPropertyValue(nameof(Personalities), ref personalities, value);
        }

        [XafDisplayName("Năng khiếu")]
        public string Gifted
        {
            get => gifted;
            set => SetPropertyValue(nameof(Gifted), ref gifted, value);
        }

        [XafDisplayName("Sở thích")]
        public string Interests
        {
            get => interests;
            set => SetPropertyValue(nameof(Interests), ref interests, value);
        }

        [XafDisplayName("Ngày sinh")]
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set => SetPropertyValue(nameof(DateOfBirth), ref dateOfBirth, value);
        }
        #endregion

        #region salary require implement
        [XafDisplayName("Lương TV mong muốn")]
        public double ProbationarySalary
        {
            get => probationarySalary;
            set => SetPropertyValue(nameof(ProbationarySalary),ref probationarySalary, value);
        }

        [XafDisplayName("Lương sau TV mong muốn")]
        public double OfficalSalary
        {
            get => officalSalary;
            set => SetPropertyValue(nameof(OfficalSalary), ref officalSalary, value);
        }

        [XafDisplayName("Lương mong muốn (sau khi phát huy)")]
        public double DesiredSalary
        {
            get => desiredSalary;
            set => SetPropertyValue(nameof(DesiredSalary), ref desiredSalary, value);
        }

        [XafDisplayName("Ngày vào làm (DK)")]
        public DateTime? WillJoinDate
        {
            get => willJoinDate;
            set => SetPropertyValue(nameof(WillJoinDate), ref willJoinDate, value);
        }

        [XafDisplayName("Loại hợp đồng mong muốn")]
        public ContractType DesiredContractType
        {
            get => desiredContractType;
            set => SetPropertyValue(nameof(DesiredContractType), ref desiredContractType, value);
        }
        #endregion

        #region Association

        [Association]
        [XafDisplayName("Quan hệ gia đình")]
        public XPCollection<CandidateRelative> Relatives 
            => GetCollection<CandidateRelative>(nameof(Relatives));

        [Association]
        [XafDisplayName("Kinh nghiệm")]
        public XPCollection<CandidateExperience> Experiences
            => GetCollection<CandidateExperience>(nameof(Experiences));

        [Association]
        [XafDisplayName("Chuyên môn")]
        public XPCollection<CandidateEducation> Educations
            => GetCollection<CandidateEducation>(nameof(Educations));

        [Association]
        [XafDisplayName("Kỹ năng")]
        public XPCollection<CandidateSkill> Skills
           => GetCollection<CandidateSkill>(nameof(Skills));

        #endregion

        #region Non persistent

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public int Year => this.CreateDate.Value.Year;

        #endregion
    }
}
