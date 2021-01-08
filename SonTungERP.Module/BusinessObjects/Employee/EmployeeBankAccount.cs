using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Tài khoản ngân hàng")]
    [DefaultClassOptions]
    public class EmployeeBankAccount : SystemBaseObject
    {
        public EmployeeBankAccount(Session session) : base(session)
        {
        }

        Employee employee;
        Bank bank;
        string account;
        string branchName;

        [Association]
        [XafDisplayName("Nhân viên")]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        [XafDisplayName("Ngân hàng")]
        public Bank Bank
        {
            get => bank;
            set => SetPropertyValue(nameof(Bank), ref bank, value);
        }

        [XafDisplayName("Số tài khoản")]
        public string Account
        {
            get => account;
            set => SetPropertyValue(nameof(Account), ref account, value);
        }

        [XafDisplayName("Chi nhánh")]
        public string BranchName
        {
            get => branchName;
            set => SetPropertyValue(nameof(BranchName), ref branchName, value);
        }
    }
}
