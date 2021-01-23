using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Giờ làm việc theo ca")]
    [DefaultClassOptions]
    public class ShiftTime : SystemBaseObject
    {
        public ShiftTime(Session session) : base(session)
        {

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        ShiftType type;
        string name;
        DateTime fromTime;
        DateTime toTime;
        int lateInTimeAllow;
        int earlyOutTimeAllow;
        double coefficient;
        bool isOvertime;
        bool isBreakTime;
        bool isOvernight;

        [Association]
        [NoForeignKey]
        public ShiftType Type
        {
            get => type;
            set => SetPropertyValue(nameof(Type), ref type, value);
        }

        [XafDisplayName("Tên giờ")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [XafDisplayName("Bắt đầu")]
        public DateTime FromTime
        {
            get => fromTime;
            set => SetPropertyValue(nameof(FromTime), ref fromTime, value);
        }

        [XafDisplayName("Kết thúc")]
        public DateTime ToTime
        {
            get => toTime;
            set => SetPropertyValue(nameof(ToTime), ref toTime, value);
        }

        [XafDisplayName("Ra sớm")]
        public int EarlyOutTime
        {
            get => earlyOutTimeAllow;
            set => SetPropertyValue(nameof(EarlyOutTime), ref earlyOutTimeAllow, value);
        }

        [XafDisplayName("Vào trễ")]
        public int LateInTimeAllow
        {
            get => lateInTimeAllow;
            set => SetPropertyValue(nameof(LateInTimeAllow), ref lateInTimeAllow, value);
        }

        [XafDisplayName("Hệ số giờ")]
        public double Coefficient
        {
            get => coefficient;
            set => SetPropertyValue(nameof(Coefficient), ref coefficient, value);
        }

        [XafDisplayName("Tăng ca")]
        public bool IsOvertime
        {
            get => isOvertime;
            set => SetPropertyValue(nameof(IsOvertime), ref isOvertime, value);
        }

        [XafDisplayName("Giờ nghỉ")]
        public bool IsBreakTime
        {
            get => isBreakTime;
            set => SetPropertyValue(nameof(IsBreakTime), ref isBreakTime, value);
        }

        [XafDisplayName("Ca qua đêm")]
        public bool IsOvernight
        {
            get => isOvernight;
            set => SetPropertyValue(nameof(IsOvernight), ref isOvernight, value);
        }

        #region alias

        [NonPersistent]
        [VisibleInListView(false)]
        public double TotalHours => this.isOvernight ? 
            (this.ToTime.AddDays(1) - this.FromTime).TotalHours : (this.ToTime - this.FromTime).TotalHours;

        [NonPersistent]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public DateTime AllowedFromTime => this.FromTime.AddMinutes(LateInTimeAllow);

        [NonPersistent]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public DateTime AllowedOutTime => this.ToTime.AddMinutes(-EarlyOutTime);

        #endregion
    }
}
