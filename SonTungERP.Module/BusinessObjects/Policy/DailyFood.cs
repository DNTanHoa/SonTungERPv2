using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [XafDisplayName("Suất ăn")]
    [DefaultClassOptions]
    public class DailyFood : SystemBaseObject
    {
        public DailyFood(Session session)
            : base(session)
        {

        }

        DateTime date;
        int numberOfEmployee;
        int numberOfPortionRice;
        int numberOfVegetarianRice;

        [XafDisplayName("Ngày đăng ký")]
        public DateTime Date
        {
            get => date;
            set => SetPropertyValue(nameof(Date), ref date, value);
        }

        [XafDisplayName("Tổng nhân viên")]
        public int NumberOfEmployee
        {
            get => numberOfEmployee;
            set => SetPropertyValue(nameof(NumberOfEmployee), ref numberOfEmployee, value);
        }

        [XafDisplayName("Tổng suất cơm")]
        public int NumberOfPortionRice
        {
            get => numberOfPortionRice;
            set => SetPropertyValue(nameof(NumberOfPortionRice), ref numberOfPortionRice, value);
        }

        [XafDisplayName("Cơm chay")]
        public int NumberOfVegetarianRice
        {
            get => numberOfVegetarianRice;
            set => SetPropertyValue(nameof(NumberOfVegetarianRice), ref numberOfVegetarianRice, value);
        }
    }
}
