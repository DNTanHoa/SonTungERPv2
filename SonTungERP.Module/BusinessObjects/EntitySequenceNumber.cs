using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.ComponentModel;

namespace SonTungERP.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("Quản lý mã")]
    public class EntitySequenceNumber : SystemBaseObject
    {
        public EntitySequenceNumber(Session session)
            : base(session)
        {

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        protected override void OnSaving()
        {
            base.OnSaving();
        }

        private Type _entity;
        private string _prefixCode;
        private string _subfixCode;
        private string _lastNumber;

        [ValueConverter(typeof(TypeToStringConverter))]
        [TypeConverter(typeof(LocalizedClassInfoTypeConverter))]
        public Type Entity
        {
            get => _entity;
            set => SetPropertyValue(nameof(Entity), ref _entity, value);
        }

        [XafDisplayName("Tiền tố")]
        public string PrefixCode
        {
            get => _prefixCode;
            set => SetPropertyValue(nameof(PrefixCode), ref _prefixCode, value);
        }

        [XafDisplayName("Ký hiệu phụ")]
        public string SubfixCode
        {
            get => _subfixCode;
            set => SetPropertyValue(nameof(SubfixCode), ref _subfixCode, value);
        }

        [XafDisplayName("Số hiện tại")]
        public string LastNumber
        {
            get => _lastNumber;
            set => SetPropertyValue(nameof(LastNumber), ref _lastNumber, value);
        }
    }
}
