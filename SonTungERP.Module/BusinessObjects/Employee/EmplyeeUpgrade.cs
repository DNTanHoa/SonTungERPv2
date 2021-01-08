using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Thăng tiến")]
    [DefaultClassOptions]
    public class EmplyeeUpgrade : SystemBaseObject
    {
        public EmplyeeUpgrade(Session session) : base(session)
        {

        }

        Employee employee;
        DateTime tranferDate;
        Designation oldDesignation;
        Designation newDesignation;

        [Association]
        [XafDisplayName("Nhân viên")]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        [XafDisplayName("Ngày chuyển")]
        public DateTime TransferDate
        {
            get => tranferDate;
            set => SetPropertyValue(nameof(TransferDate), ref tranferDate, value);
        }

        [XafDisplayName("Nhân viên")]
        public Designation OldDesignation
        {
            get => oldDesignation;
            set => SetPropertyValue(nameof(OldDesignation), ref oldDesignation, value);
        }

        [XafDisplayName("Sang")]
        public Designation NewDesignation
        {
            get => newDesignation;
            set => SetPropertyValue(nameof(NewDesignation), ref newDesignation, value);
        }
    }
}
