using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using SonTungERP.Module.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Nhân viên")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(DisplayName))]
    public class Employee : SystemBaseObject
    {
        public Employee(Session session) : base(session)
        {

        }

        string code;
        string fullName;
        Gender gender;
        DateTime dateOfBirth;
        DateTime dateOfJoining;
        string taxCode;
        Department department;
        Designation designation;
        Job job;
        Nation nation;
        Religion religion;
        string identity;
        IdentiyLicesenPlace identityLicesenPlace;
        DateTime idetityLicesenDate;
        string social;
        EducationLevel educationLevel;
        School school;
        string major;
        string avartar;
        byte[] avartarData;
        MaritalStatus maritalStatus;
        EmployeeStatus status;
        Group group;

        bool hasLeft;

        [XafDisplayName("Mã nhân viên")]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [XafDisplayName("Họ và tên")]
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

        [XafDisplayName("Ngày sinh")]
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set => SetPropertyValue(nameof(DateOfBirth), ref dateOfBirth, value);
        }

        [XafDisplayName("Ngày vào làm")]
        public DateTime DateOfJoining
        {
            get => dateOfJoining;
            set => SetPropertyValue(nameof(DateOfJoining), ref dateOfJoining, value);
        }

        [XafDisplayName("Mã số thuế")]
        public string TaxCode
        {
            get => taxCode;
            set => SetPropertyValue(nameof(TaxCode), ref taxCode, value);
        }

        [XafDisplayName("Bộ phận")]
        public Department Department
        {
            get => department;
            set => SetPropertyValue(nameof(Department), ref department, value);
        }

        [XafDisplayName("Chức vụ")]
        public Designation Designation
        {
            get => designation;
            set => SetPropertyValue(nameof(Designation), ref designation, value);
        }

        [XafDisplayName("Công việc")]
        public Job Job
        {
            get => job;
            set => SetPropertyValue(nameof(Job), ref job, value);
        }

        [XafDisplayName("Dân tộc")]
        public Nation Nation
        {
            get => nation;
            set => SetPropertyValue(nameof(Nation), ref nation, value);
        }

        [XafDisplayName("Tôn giáo")]
        public Religion Religion
        {
            get => religion;
            set => SetPropertyValue(nameof(Religion), ref religion, value);
        }

        [XafDisplayName("Chứng minh")]
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

        [XafDisplayName("Trình độ văn hóa")]
        public string Social
        {
            get => social;
            set => SetPropertyValue(nameof(Social), ref social, value);
        }

        [XafDisplayName("Trình độ học vấn")]
        public EducationLevel EducationLevel
        {
            get => educationLevel;
            set => SetPropertyValue(nameof(EducationLevel), ref educationLevel, value);
        }

        [XafDisplayName("Nơi đào tạo")]
        public School School
        {
            get => school;
            set => SetPropertyValue(nameof(School), ref school, value);
        }

        [XafDisplayName("Chuyên ngành")]
        public string Major
        {
            get => major;
            set => SetPropertyValue(nameof(Major), ref major, value);
        }

        [XafDisplayName("Ảnh đại diện")]
        [VisibleInListView(false)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.DropDownPictureEdit,
            DetailViewImageEditorFixedWidth = 220,
            DetailViewImageEditorFixedHeight = 220,
            DetailViewImageEditorMode = ImageEditorMode.DropDownPictureEdit)]
        [NonPersistent]
        public byte[] AvartarData
        {
            get
            {
                if(!string.IsNullOrEmpty(this.Avartar))
                {
                    return File.ReadAllBytes(PathHelper.GetApplicationFolder() + this.Avartar);
                }
                else
                {
                    return null;
                }    
            }
            set  
            {
                SetPropertyValue(nameof(AvartarData), ref avartarData, value);
                if(value != null)
                {
                    byte[] data = value as byte[];
                    var path = PathHelper.GetApplicationFolder()
                        + "wwwroot/Upload/Images/" + DateTime.Now.ToString("yyyyMMddHHmmsstt") + ".jpg";
                    using (FileStream stream = File.Create(path))
                    {
                        stream.Close();
                        File.WriteAllBytes(path, value);
                    }
                    this.Avartar = path.Replace(PathHelper.GetApplicationFolder(),"");
                }
                else
                {
                    this.Avartar = string.Empty;
                }
            }
        }

        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [Size(1000)]
        public string Avartar
        {
            get => avartar;
            set => SetPropertyValue<string>(nameof(Avartar), ref avartar, value);
        }

        [XafDisplayName("Tình trạng hôn nhân")]
        public MaritalStatus MaritalStatus
        { 
            get => maritalStatus;
            set => SetPropertyValue(nameof(MaritalStatus), ref maritalStatus, value);
        }

        [NonPersistent]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public string DisplayName => this.Code + "-" + this.FullName;

        [XafDisplayName("Nghỉ việc")]
        public bool HasLeft
        {
            get => hasLeft;
            set => SetPropertyValue(nameof(HasLeft), ref hasLeft, value);
        }

        [XafDisplayName("Nhóm")]
        public Group Group
        {
            get => group;
            set => SetPropertyValue(nameof(Group), ref group, value);
        }

        [XafDisplayName("Trạng thái")]
        public EmployeeStatus Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }

        #region Association
        [Association]
        [XafDisplayName("Hợp đồng")]
        public XPCollection<EmployeeContract> Contracts => GetCollection<EmployeeContract>(nameof(Contracts));

        [Association]
        [XafDisplayName("Bảo hiểm")]
        public XPCollection<EmployeeInsurance> Insurances => GetCollection<EmployeeInsurance>(nameof(Insurances));

        [Association]
        [XafDisplayName("Quan hệ")]
        public XPCollection<EmployeeRelative> Relatives => GetCollection<EmployeeRelative>(nameof(Relatives));

        [Association]
        [XafDisplayName("Liên hệ")]
        public XPCollection<EmployeeContact> Contacts => GetCollection<EmployeeContact>(nameof(Contacts));

        [Association]
        [XafDisplayName("Tài khoản ngân hàng")]
        public XPCollection<EmployeeBankAccount> BankAccounts => GetCollection<EmployeeBankAccount>(nameof(BankAccounts));

        [Association]
        [XafDisplayName("Chuyển bộ phận")]
        public XPCollection<EmployeeTransfer> EmployeeTransfers => GetCollection<EmployeeTransfer>(nameof(EmployeeTransfers));

        [Association]
        [XafDisplayName("Thăng tiến")]
        public XPCollection<EmplyeeUpgrade> EmplyeeUpgrades => GetCollection<EmplyeeUpgrade>(nameof(EmplyeeUpgrades));
        #endregion
    }
}
