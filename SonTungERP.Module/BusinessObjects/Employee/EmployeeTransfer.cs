using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Chuyển bộ phận")]
    [DefaultClassOptions]
    public class EmployeeTransfer : SystemBaseObject
    {
        public EmployeeTransfer(Session session) : base(session)
        {

        }

        Employee employee;
        DateTime tranferDate;
        Department oldDepartment;
        Department newDepartment;

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

        [XafDisplayName("Chuyển từ BP")]
        public Department OldDepartment
        {
            get => oldDepartment;
            set => SetPropertyValue(nameof(OldDepartment), ref oldDepartment, value);
        }

        [XafDisplayName("Sang BP")]
        public Department NewDepartment
        {
            get => newDepartment;
            set => SetPropertyValue(nameof(NewDepartment), ref newDepartment, value);
        }
    }
}
