using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using SonTungERP.Module.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        byte[] avartar;
        MaritalStatus maritalStatus;

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
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.DropDownPictureEdit,
            DetailViewImageEditorFixedWidth = 220,
            DetailViewImageEditorFixedHeight = 220,
            DetailViewImageEditorMode = ImageEditorMode.DropDownPictureEdit)]
        public byte[] Avartar
        {
            get => avartar;
            set  
            {
                if(value != null)
                {
                    byte[] data = value as byte[];
                    data.SaveAsFile(PathHelper.GetApplicationFolder() + "image.jpg");
                }    
            }
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
    }
}
