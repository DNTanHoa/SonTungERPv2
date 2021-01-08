using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Ngân hàng")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(Name))]
    public class Bank : SystemBaseObject
    {
        public Bank(Session session) : base(session)
        {

        }

        string code;
        string name;

        [XafDisplayName("Ký hiệu")]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [XafDisplayName("Tên ngân hàng")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
    }
}
