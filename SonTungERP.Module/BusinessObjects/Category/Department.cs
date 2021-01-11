﻿using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Bộ phận")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(DisplayName))]
    public class Department : SystemBaseObject
    {
        public Department(Session session) 
            : base(session)
        {

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string name;
        string code;
        Group group;

        [XafDisplayName("Mã quản lý")]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [XafDisplayName("Tên bộ phận")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [XafDisplayName("Nhóm")]
        public Group Group
        {
            get => group;
            set => SetPropertyValue(nameof(Group), ref group, value);
        }

        [NonPersistent]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public string DisplayName => this.Name;
    }
}
