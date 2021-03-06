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
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Http;
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
    public partial class ImportEmployee_ViewController : ViewController
    {
        EmployeeImportParam importParam { get; set; }
        public ImportEmployee_ViewController()
        {
            InitializeComponent();

            // Target required Views (via the TargetXXX properties) and create their Actions.
            PopupWindowShowAction importEmployeeAction = new PopupWindowShowAction(this, 
                "ImportEmployeeAction", PredefinedCategory.View)
            {
                Caption = "Import",
                TargetObjectType = typeof(Employee),
                TargetViewType = ViewType.ListView
            };
            importEmployeeAction.Execute += ImportEmployeeAction_Execute;
            importEmployeeAction.CustomizePopupWindowParams += ImportEmployeeAction_CustomParam;
        }

        private void ImportEmployeeAction_CustomParam(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(EmployeeImportParam));
            importParam = new EmployeeImportParam();
            importParam.Template = new DownloadTemplate()
            {
                DisplayName = "Download",
                Url = "Templates/EmployeeCollection.xlsx"
            };
            var detailView = Application.CreateDetailView(objectSpace, importParam);
            detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            e.View = detailView;
        }

        private void ImportEmployeeAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var fileData = importParam.FileImport;
            var savePath = "wwwroot\\Upload\\ImportEmployee"
                       + DateTime.Now.ToString("ddMMyyyyHHmmsstt")
                       + ".xlsx";

            fileData.SaveToPath(savePath);

            var configFilePath = "wwwroot\\Map\\EmployeeImportMap.xml";

            ProcessImportLib.process_read_employee_data(
                this.ObjectSpace,
                savePath,
                configFilePath,
                out List<Employee> employee);
            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
            View.Refresh();
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
    [FileAttachmentAttribute("FileImport")]
    public class EmployeeImportParam
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
