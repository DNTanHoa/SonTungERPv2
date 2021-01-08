using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Hợp đồng nhân viên")]
    [DefaultClassOptions]
    public class EmployeeContract : SystemBaseObject
    {
        public EmployeeContract(Session session) : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        protected override void OnSaving()
        {
            base.OnSaving();
        }

        Employee employee;
        string contractNumber;
        ContractType type;
        Designation designation;
        DateTime? signedDate;
        DateTime? validFromDate;
        DateTime? expireDate;
        Employee companySignPerson;
        double baseSalary;
        double insurranceSalary;
        Job job;
        string attachFile;

        [XafDisplayName("Số hợp đồng")]
        public string ContractNumber
        {
            get => contractNumber;
            set => SetPropertyValue(nameof(ContractNumber), ref contractNumber, value);
        }

        [XafDisplayName("Loại hợp đồng")]
        public ContractType Type
        {
            get => type;
            set => SetPropertyValue(nameof(Type), ref type, value);
        }

        [Association]
        [XafDisplayName("Nhân viên")]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        [XafDisplayName("Vị trí")]
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

        [XafDisplayName("Ngày ký")]
        public DateTime? SignedDate
        {
            get => signedDate;
            set => SetPropertyValue(nameof(SignedDate), ref signedDate, value);
        }

        [XafDisplayName("Ngày hiệu lực")]
        public DateTime? ValidFromDate
        {
            get => validFromDate;
            set => SetPropertyValue(nameof(ValidFromDate), ref validFromDate, value);
        }

        [XafDisplayName("Ngày hết hạn")]
        public DateTime? ExpireDate
        {
            get => expireDate;
            set => SetPropertyValue(nameof(ExpireDate), ref expireDate, value);
        }

        [XafDisplayName("Đại diện công ty")]
        public Employee CompanySignPerson
        {
            get => companySignPerson;
            set => SetPropertyValue(nameof(CompanySignPerson), ref companySignPerson, value);
        }

        [XafDisplayName("Lương cơ bản")]
        public double BaseSalary
        {
            get => baseSalary;
            set => SetPropertyValue(nameof(BaseSalary), ref baseSalary, value);
        }

        [XafDisplayName("Lương bảo hiểm")]
        public double InsurranceSalary
        {
            get => insurranceSalary;
            set => SetPropertyValue(nameof(InsurranceSalary), ref insurranceSalary, value);
        }

        [XafDisplayName("File lưu trữ")]
        public string AttachFile
        {
            get => attachFile;
            set => SetPropertyValue(nameof(AttachFile), ref attachFile, value);
        }

        #region Support Function

        public void CalculateExpireDate()
        {
            if (this.Type != null &&
                this.ValidFromDate != null)
            {
                if (this.type.Day != null)
                {
                    int numberOfDay = (int)this.type.Day;
                    this.ExpireDate = ((DateTime)this.ValidFromDate).AddDays(numberOfDay);
                }
            }
        }

        #endregion
    }
}
