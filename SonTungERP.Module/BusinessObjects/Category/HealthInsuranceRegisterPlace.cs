using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Nơi đăng ký KCB")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(Name))]
    public class HealthInsuranceRegisterPlace : SystemBaseObject
    {
        public HealthInsuranceRegisterPlace(Session session) : base(session)
        {
        }

        string code;
        string name;
        Province province;

        [XafDisplayName("Mã quản lý")]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [Size(1000)]
        [XafDisplayName("Tên bệnh viện")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [XafDisplayName("Tỉnh")]
        public Province Province
        {
            get => province;
            set => SetPropertyValue(nameof(Province), ref province, value);
        }
    }
}
