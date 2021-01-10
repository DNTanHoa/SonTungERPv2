﻿using DevExpress.Data.Filtering;
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
using SonTungERP.Module.Controllers.Process;
using SonTungERP.Module.DomainComponent;
using SonTungERP.Module.Ultilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SonTungERP.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ImportDepartment_ViewController : ViewController
    {
        DepartmentImportParam importParam { get; set; }
        public ImportDepartment_ViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions
            PopupWindowShowAction importEmployeeAction = new PopupWindowShowAction(this,
                "ImportDepartmentAction", PredefinedCategory.View)
            {
                Caption = "Import",
                TargetObjectType = typeof(Department),
                TargetViewType = ViewType.ListView
            };
            importEmployeeAction.Execute += ImportDepartmentAction_Execute;
            importEmployeeAction.CustomizePopupWindowParams += ImportDepartmentAction_CustomParam;
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

        private void ImportDepartmentAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var fileData = importParam.FileImport;
            var savePath = "wwwroot\\Upload\\ImportDepartment"
                       + DateTime.Now.ToString("ddMMyyyyHHmmsstt")
                       + ".xlsx";

            fileData.SaveToPath(savePath);

            var configFilePath = "wwwroot\\Map\\DepartmentImportMap.xml";

            ProcessImportLib.process_read_department_data(
                this.ObjectSpace,
                savePath,
                configFilePath);
            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
            View.Refresh();
        }

        private void ImportDepartmentAction_CustomParam(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(DepartmentImportParam));
            importParam = new DepartmentImportParam();
            importParam.Template = new DownloadTemplate()
            {
                DisplayName = "Download",
                Url = "Templates/BankAccountCollection.xlsx"
            };
            var detailView = Application.CreateDetailView(objectSpace, importParam);
            detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            e.View = detailView;
        }
    }

    [DomainComponent]
    [XafDisplayName("Import bộ phận")]
    [FileAttachmentAttribute("FileImport")]
    public class DepartmentImportParam
    {
        [XafDisplayName("Tải biểu mẫu")]
        public DownloadTemplate Template { get; set; }

        private CustomFileData file;

        [XafDisplayName("Chọn file")]
        public CustomFileData FileImport
        {
            get => file;
            set => this.file = value;
        }
    }
}
