using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Nhóm nhân sự")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(Name))]
    public class Group : SystemBaseObject
    {
        public Group(Session session) : base(session)
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

        [XafDisplayName("Tên nhóm")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
    }
}
