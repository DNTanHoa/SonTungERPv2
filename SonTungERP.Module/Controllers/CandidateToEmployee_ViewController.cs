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
using SonTungERP.Module.Controllers.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SonTungERP.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CandidateToEmployee_ViewController : ViewController
    {
        ConvertEmployeeParam convertParam;

        private IObjectSpace additionalObjectSpace;

        public CandidateToEmployee_ViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            PopupWindowShowAction convertCandidateAction = new PopupWindowShowAction(this,
                "ConvertCandidateAction", PredefinedCategory.View)
            {
                Caption = "Chuyển nhân viên",
                TargetObjectType = typeof(Candidate),
                SelectionDependencyType = SelectionDependencyType.RequireSingleObject
            };
            convertCandidateAction.Execute += ConvertCandidateAction_Execute;
            convertCandidateAction.CustomizePopupWindowParams += ConvertCandidateAction_CustomParam;
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

        private void ConvertCandidateAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            if(!string.IsNullOrEmpty(convertParam.EmpID))
            {
                if(convertParam.Department != null)
                {
                    var candidate = View.SelectedObjects.Cast<Candidate>().FirstOrDefault();

                    ProcessCandidateLib.process_convert_to_employee(
                        this.ObjectSpace,
                        candidate,
                        convertParam.Department,
                        convertParam.EmpID);

                    ObjectSpace.CommitChanges();
                    ObjectSpace.Refresh();
                    View.Refresh();
                }
                else
                {
                    throw new Exception("Vui lòng chọn bộ phận");
                }
            }
            else
            {
                throw new Exception("Mã nhân viên không được để trống");
            }
        }

        private void ConvertCandidateAction_CustomParam(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(ConvertEmployeeParam));
            convertParam = new ConvertEmployeeParam();
            var detailView = Application.CreateDetailView(objectSpace, convertParam);
            detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            e.View = detailView;
        }
    }

    [DomainComponent]
    [XafDisplayName("Chuyển thành nhân viên")]
    public class ConvertEmployeeParam
    {
        [XafDisplayName("Bộ phận")]
        public Department Department { get; set; }

        [XafDisplayName("Mã nhân viên")]
        public string EmpID { get; set; }
    }
}
