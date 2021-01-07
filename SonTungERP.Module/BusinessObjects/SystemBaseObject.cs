using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.BusinessObjects
{
    [NonPersistent]
    public class SystemBaseObject : BaseObject
    {
        public SystemBaseObject(Session session) : base(session)
        {

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (SecuritySystem.CurrentUser != null)
            {
                var user = Session.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);

                if (Session.IsNewObject(this))
                {
                    this._createUser = user;
                    this._createDate = DateTime.Now;
                }
            }
        }

        protected override void OnSaving()
        {
            if (SecuritySystem.CurrentUser != null)
            {
                var user = Session.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);

                if (!Session.IsNewObject(this))
                {
                    this._updateUser = user;
                    this._updateDate = DateTime.Now;
                }
            }
        }

        [Persistent(nameof(CreateUser))]
        private PermissionPolicyUser _createUser;

        [Persistent(nameof(UpdateUser))]
        private PermissionPolicyUser _updateUser;

        [Persistent(nameof(CreateDate))]
        private DateTime? _createDate;

        [Persistent(nameof(UpdateDate))]
        private DateTime? _updateDate;
        
        [XafDisplayName("Người tạo")]
        public PermissionPolicyUser CreateUser
        {
            get => _createUser;
        }

        [XafDisplayName("Người cập nhật")]
        public PermissionPolicyUser UpdateUser
        {
            get => _updateUser;
        }

        [XafDisplayName("Ngày tạo")]
        public DateTime? CreateDate
        {
            get => _createDate;
        }

        [XafDisplayName("Ngày cập nhật")]
        public DateTime? UpdateDate
        {
            get => _updateDate;
        }
    }
}
