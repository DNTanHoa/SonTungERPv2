﻿using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Danh sách ca")]
    [DefaultClassOptions]
    public class ShiftType : SystemBaseObject
    {
        public ShiftType(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string name;
        string code;
        double maxWorkingHour;
        bool isOvernight;

        [XafDisplayName("Mã quản lý")]
        public string Code
        {
            get => name;
            set => SetPropertyValue(nameof(Code), ref name, value);
        }

        [XafDisplayName("Ca làm việc")]
        public string Name
        {
            get => code;
            set => SetPropertyValue(nameof(Name), ref code, value);
        }

        [XafDisplayName("Giờ làm tối đa")]
        public double MaxWorkingHour
        {
            get => maxWorkingHour;
            set => SetPropertyValue(nameof(MaxWorkingHour), ref maxWorkingHour, value);
        }

        [XafDisplayName("Qua đêm")]
        public bool IsOvernight
        {
            get => isOvernight;
            set => SetPropertyValue(nameof(IsOvernight), ref isOvernight, value);
        }

        [Association]
        [XafDisplayName("Giờ làm theo ca")]
        public XPCollection<ShiftTime> Times => GetCollection<ShiftTime>(nameof(Times));

        #region alias

        [NonPersistent]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public DateTime? AllowInTime 
            => Times.OrderBy(item => item.FromTime.TimeOfDay).FirstOrDefault()?.AllowedFromTime;

        #endregion
    }
}
