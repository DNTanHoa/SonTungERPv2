using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Kế hoạch tuyển dụng")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(Code))]
    public class RecruitmentPlan : SystemBaseObject
    {
        public RecruitmentPlan(Session session): base(session)
        {

        }

        string code;
        string title;
        Job job;
        Designation designation;
        DateTime? fromDate;
        DateTime? toDate;
        int quantity;
        double plannedCost;
        double realCost;
        string description;
        RecruitmentPlanStatus status;

        [XafDisplayName("Mã kế hoạch")]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }

        [XafDisplayName("Kế hoạch")]
        public string Title
        {
            get => title;
            set => SetPropertyValue(nameof(Title), ref title, value);
        }

        [XafDisplayName("Công việc")]
        public Job Job
        {
            get => job;
            set => SetPropertyValue(nameof(Job), ref job, value);
        }

        [XafDisplayName("Vị trí")]
        public Designation Designation
        {
            get => designation;
            set => SetPropertyValue(nameof(Designation), ref designation, value);
        }

        [XafDisplayName("Từ ngày")]
        public DateTime? FromDate
        {
            get => fromDate;
            set => SetPropertyValue(nameof(FromDate), ref fromDate, value);
        }

        [XafDisplayName("Đến ngày")]
        public DateTime? ToDate
        {
            get => toDate;
            set => SetPropertyValue(nameof(ToDate), ref toDate, value);
        }

        [XafDisplayName("Số lượng")]
        public int Quantity
        {
            get => quantity;
            set => SetPropertyValue(nameof(Quantity), ref quantity, value);
        }

        [XafDisplayName("Yêu cầu")]
        [Size(4000)]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }

        [XafDisplayName("Chi phí dự kiến")]
        public double PlannedCost
        {
            get => plannedCost;
            set => SetPropertyValue(nameof(PlannedCost), ref plannedCost, value);
        }

        [XafDisplayName("Chi phí thực tế")]
        public double RealCost
        {
            get => realCost;
            set => SetPropertyValue(nameof(RealCost), ref realCost, value);
        }

        [XafDisplayName("Trạng thái")]
        public RecruitmentPlanStatus Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }
    }
}
