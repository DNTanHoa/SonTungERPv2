using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Bảo hiểm xã hội")]
    [DefaultClassOptions]
    public class EmployeeInsurance : SystemBaseObject
    {
        public EmployeeInsurance(Session session) : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        Employee employee;
        string socialInsuranceNumber;
        string healthInsuranceCardNumber;
        DateTime dateOfJoining;
        HealthInsuranceRegisterPlace healthInsuranceRegisterPlace;

        [Association]
        [XafDisplayName("Nhân viên")]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }

        [XafDisplayName("Số sổ BHXH")]
        public string SocialInsuranceNumber
        {
            get => socialInsuranceNumber;
            set => SetPropertyValue(nameof(SocialInsuranceNumber), ref socialInsuranceNumber, value);
        }

        [XafDisplayName("Số thẻ BHYT")]
        public string HealthInsuranceCardNumber
        {
            get => healthInsuranceCardNumber;
            set => SetPropertyValue(nameof(HealthInsuranceCardNumber), ref healthInsuranceCardNumber, value);
        }

        [XafDisplayName("Ngày tham gia")]
        public DateTime DateOfJoining
        {
            get => dateOfJoining;
            set => SetPropertyValue(nameof(DateOfJoining), ref dateOfJoining, value);
        }

        [XafDisplayName("Nơi đăng ký KCB")]
        public HealthInsuranceRegisterPlace HealthInsuranceRegisterPlace
        {
            get => healthInsuranceRegisterPlace;
            set => SetPropertyValue(nameof(HealthInsuranceRegisterPlace), ref healthInsuranceRegisterPlace, value);
        }
    }
}
