using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Đánh giá")]
    [DefaultClassOptions]
    [XafDefaultProperty("Name")]
    public class SkillLevel : SystemBaseObject
    {
        public SkillLevel(Session session) : base(session)
        {

        }

        string name;
        [XafDisplayName("Đánh giá")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
    }
}
