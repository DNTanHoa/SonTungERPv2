using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Kinh nghiệm")]
    [DefaultClassOptions]
    public class EmployeeExperience : SystemBaseObject
    {
        public EmployeeExperience(Session session) : base(session)
        {

        }

        Employee employee;
        string time;
        string company;
        string companyAddress;
        string companySize;
        string companyBussiness;
        string designation;
        string jobDescription;
        decimal salary;
        string reasonOfLeave;
        string contact;
        string contactPhone;
        string contactDesignation;
        string contactMobile;

        [Association]
        [XafDisplayName("Nhân viên")]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        [XafDisplayName("Thời gian")]
        public string Time
        {
            get => time;
            set => SetPropertyValue(nameof(Time), ref time, value);
        }

        [XafDisplayName("Công ty")]
        public string Company
        {
            get => company;
            set => SetPropertyValue(nameof(Company), ref company, value);
        }

        [Size(1000)]
        [XafDisplayName("Địa chỉ")]
        public string CompanyAddress
        {
            get => companyAddress;
            set => SetPropertyValue(nameof(CompanyAddress), ref companyAddress, value);
        }

        [XafDisplayName("Quy mô")]
        public string CompanySize
        {
            get => companySize;
            set => SetPropertyValue(nameof(CompanySize), ref companySize, value);
        }

        [XafDisplayName("Ngành nghề")]
        public string CompanyBussiness
        {
            get => companyBussiness;
            set => SetPropertyValue(nameof(CompanyBussiness), ref companyBussiness, value);
        }

        [XafDisplayName("Chức vụ")]
        public string Designation
        {
            get => designation;
            set => SetPropertyValue(nameof(Designation), ref designation, value);
        }

        [Size(1000)]
        [XafDisplayName("Mô tả công việc")]
        public string JobDescription
        {
            get => jobDescription;
            set => SetPropertyValue(nameof(JobDescription), ref jobDescription, value);
        }

        [XafDisplayName("Mức lương")]
        public decimal Salary
        {
            get => salary;
            set => SetPropertyValue(nameof(Salary), ref salary, value);
        }

        [XafDisplayName("Lý do nghỉ việc")]
        public string ReasonOfLeave
        {
            get => reasonOfLeave;
            set => SetPropertyValue(nameof(ReasonOfLeave), ref reasonOfLeave, value);
        }

        [XafDisplayName("Người tham khảo")]
        public string Contact
        {
            get => contact;
            set => SetPropertyValue(nameof(Contact), ref contact, value);
        }

        [XafDisplayName("Điện thoại bàn")]
        public string ContactPhone
        {
            get => contactPhone;
            set => SetPropertyValue(nameof(ContactPhone), ref contactPhone, value);
        }

        [XafDisplayName("Chức vụ người liên hệ")]
        public string ContactDesignation
        {
            get => contactDesignation;
            set => SetPropertyValue(nameof(ContactDesignation), ref contactDesignation, value);
        }

        [XafDisplayName("Di động người liên hệ")]
        public string ContactMobile
        {
            get => contactMobile;
            set => SetPropertyValue(nameof(ContactMobile), ref contactMobile, value);
        }
    }
}
