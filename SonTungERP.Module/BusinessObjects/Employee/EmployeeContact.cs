﻿using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Liên hệ")]
    [DefaultClassOptions]
    public class EmployeeContact : SystemBaseObject
    {
        public EmployeeContact(Session session) : base(session)
        {
        }

        Employee employee;
        string personalPhone;
        string personalEmail;
        string companyPhone;
        string companyEmail;
        string temporaryAddress;
        string originAddress;

        [Association]
        [XafDisplayName("Nhân viên")]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        public string PersonalPhone
        {
            get => personalPhone;
            set => SetPropertyValue(nameof(PersonalPhone), ref personalPhone, value);
        }

        public string PersonalEmail
        {
            get => personalEmail;
            set => SetPropertyValue(nameof(PersonalEmail), ref personalEmail, value);
        }

        public string CompanyPhone
        {
            get => companyPhone;
            set => SetPropertyValue(nameof(CompanyPhone), ref companyPhone, value);
        }

        public string CompanyEmail
        {
            get => companyEmail;
            set => SetPropertyValue(nameof(CompanyEmail), ref companyEmail, value);
        }

        public string OriginAddress
        {
            get => originAddress;
            set => SetPropertyValue(nameof(OriginAddress), ref originAddress, value);
        }

        public string TemporaryAddress
        {
            get => temporaryAddress;
            set => SetPropertyValue(nameof(TemporaryAddress), ref temporaryAddress, value);
        }
    }
}