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
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using Microsoft.AspNetCore.Http;
using SonTungERP.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SonTungERP.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ImportEmployee_ViewController : ViewController
    {
        EmployeeImportParam importParam { get; set; }
        public ImportEmployee_ViewController()
        {
            InitializeComponent();

            SimpleAction downloadTemplateAction = new SimpleAction(this, "DownloadEmployeeImportTemplate", PredefinedCategory.Unspecified)
            {
                Caption = "Tải file mẫu",
                TargetObjectType = typeof(EmployeeImportParam)
            };
            downloadTemplateAction.Execute += DownloadTemplateAction_Execute;

            // Target required Views (via the TargetXXX properties) and create their Actions.
            PopupWindowShowAction importEmployeeAction = new PopupWindowShowAction(this, "ImportEmployeeAction", PredefinedCategory.Unspecified)
            {
                Caption = "Import",
                TargetObjectType = typeof(Employee),
                TargetViewType = ViewType.ListView
            };
            importEmployeeAction.Execute += ImportEmployeeAction_Execute;
            importEmployeeAction.CustomizePopupWindowParams += ImportEmployeeAction_CustomParam;
        }

        private void DownloadTemplateAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ImportEmployeeAction_CustomParam(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(EmployeeImportParam));
            importParam = new EmployeeImportParam();
            var detailView = Application.CreateDetailView(objectSpace, importParam);
            detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            e.View = detailView;
        }

        private void ImportEmployeeAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
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
    [XafDisplayName("Import nhân viên")]
    public class EmployeeImportParam
    {
        [XafDisplayName("Chọn file")]
        public FileData FileImport { get; set; }
    }
}
