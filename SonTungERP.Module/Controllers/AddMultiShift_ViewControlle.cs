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
    public partial class AddMultiShift_ViewControlle : ViewController
    {
        AddMultiShiftParam param { get; set; }

        public AddMultiShift_ViewControlle()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            PopupWindowShowAction inputMultiCheckInAction = new PopupWindowShowAction(this,
                "InputMultiShiftAction", PredefinedCategory.Unspecified)
            {
                Caption = "Khai báo ca",
                TargetObjectType = typeof(ShiftAssigment),
                SelectionDependencyType = SelectionDependencyType.Independent
            };
            inputMultiCheckInAction.Execute += InputMultiShiftAction_Execute;
            inputMultiCheckInAction.CustomizePopupWindowParams += InputMultiShiftAction_CustomParam;
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
        
        private void InputMultiShiftAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var view = e.PopupWindowView as DetailView;
            var grid = view.Items
                .Where(item => item.Id == "Employees").FirstOrDefault();

            var listView = grid as ListPropertyEditor;

            if (listView != null)
            {

                var employees = listView.ListView.SelectedObjects.Cast<Employee>().ToList();

                ProcessShiftAssignmentLib.process_add_multi_shift(
                    this.ObjectSpace,
                    param.StartDate,
                    param.EndDate,
                    param.Type,
                    employees);

                ObjectSpace.CommitChanges();
                ObjectSpace.Refresh();
                View.Refresh();
            }
        }

        private void InputMultiShiftAction_CustomParam(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(AddMultiShiftParam));
            param = new AddMultiShiftParam()
            {
                ObjectSpace = this.ObjectSpace,
            };
            var detailView = Application.CreateDetailView(objectSpace, param);
            detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            e.View = detailView;
        }
    }

    [DomainComponent]
    [XafDisplayName("Khai báo ca")]
    public class AddMultiShiftParam : NotifyChangeParamModel
    {
        [XafDisplayName("Chọn nhân viên")]
        private List<Employee> employees;
        public List<Employee> Employees
        {
            get => employees;
            set
            {
                employees = value;
                OnPropertyChanged();
            }
        }

        [XafDisplayName("Chọn bộ phận")]
        private Department department;
        public Department Department
        {
            get => department;
            set
            {
                department = value;
                GetEmployees();
            }
        }

        [VisibleInDetailView(false)]
        public IObjectSpace ObjectSpace { get; set; }

        private DateTime startDate;
        [XafDisplayName("Từ ngày")]
        public DateTime StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
            }
        }

        [XafDisplayName("Loại ca")]
        public ShiftType Type { get; set; }

        [XafDisplayName("Đến ngày")]
        public DateTime? EndDate { get; set; }

        public void GetEmployees()
        {
            if (this.ObjectSpace != null)
            {
                if (this.Department != null)
                {
                    var department = ObjectSpace.GetObjectByKey<Department>(this.Department.Oid);
                    Employees = ObjectSpace.GetObjects<Employee>(
                        CriteriaOperator.Parse("[HasLeft] = ? And [Department] = ?", false,
                        department)).Cast<Employee>().ToList();
                }
                else
                {
                    Employees = ObjectSpace.GetObjects<Employee>(
                        CriteriaOperator.Parse("[HasLeft] = ?", false)).Cast<Employee>().ToList();
                }
            }
        }
    }
}
