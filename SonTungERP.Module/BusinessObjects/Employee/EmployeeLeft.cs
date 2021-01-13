using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Nghỉ việc")]
    [DefaultClassOptions]
    public class EmployeeLeft : SystemBaseObject
    {
        public EmployeeLeft(Session session) : base(session)
        {

        }

        protected override void OnSaving()
        {
            base.OnSaving();

            if (this.Employee != null)
            {
                var employee = Session.GetObjectByKey<Employee>(Employee.Oid);
                employee.HasLeft = true;
                employee.Status = null;
            }
        }

        Employee employee;
        DateTime dateOfLeave;
        LeftReasonType reasonType;
        string reasonNote;

        [XafDisplayName("Nhân viên")]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        [XafDisplayName("Ngày nghỉ")]
        public DateTime DateOfLeave
        {
            get => dateOfLeave;
            set => SetPropertyValue(nameof(DateOfLeave), ref dateOfLeave, value);
        }

        [XafDisplayName("Phân loại")]
        public LeftReasonType ReasonType
        {
            get => reasonType;
            set => SetPropertyValue(nameof(ReasonType), ref reasonType, value);
        }

        [XafDisplayName("Ghi chú lý do")]
        public string ReasonNote
        {
            get => reasonNote;
            set => SetPropertyValue(nameof(ReasonNote), ref reasonNote, value);
        }
    }
}
