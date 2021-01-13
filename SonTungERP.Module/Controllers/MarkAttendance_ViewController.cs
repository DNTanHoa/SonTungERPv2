using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using SonTungERP.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SonTungERP.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class MarkAttendance_ViewController : ViewController
    {
        MarkAttendanceParam markParam { get; set; }

        public MarkAttendance_ViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            PopupWindowShowAction importEmployeeAction = new PopupWindowShowAction(this,
                "MarkAttendanceAction", PredefinedCategory.View)
            {
                Caption = "Chấm công",
                TargetObjectType = typeof(EmployeeAttendance),
                TargetViewType = ViewType.ListView
            };
            importEmployeeAction.Execute += MarkAttendanceAction_Execute;
            importEmployeeAction.CustomizePopupWindowParams += MarkAttendanceAction_CustomParam;
        }

        private void MarkAttendanceAction_CustomParam(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(MarkAttendanceParam));
            markParam = new MarkAttendanceParam()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
            var detailView = Application.CreateDetailView(objectSpace, markParam);
            detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            e.View = detailView;
        }

        private void MarkAttendanceAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }

    [DomainComponent]
    [XafDisplayName("Chấm công nhân viên")]
    public class MarkAttendanceParam
    {
        [XafDisplayName("Từ ngày")]
        public DateTime StartDate { get; set; }

        [XafDisplayName("Đến ngày")]
        public DateTime EndDate { get; set; }
    }
}
