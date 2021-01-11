using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Kỹ năng")]
    [DefaultClassOptions]
    [XafDefaultProperty("Name")]
    public class Skill : SystemBaseObject
    {
        public Skill(Session session) : base(session)
        {

        }

        string name;
        [XafDisplayName("Tên kỹ năng")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
    }
}
