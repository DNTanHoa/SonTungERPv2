using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using SonTungERP.Module.Blazor.Editors;
using SonTungERP.Module.Blazor.Editors.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.Blazor
{
    [PropertyEditor(typeof(DateTime), false)]
    public class TimePropertyEditor : BlazorPropertyEditorBase {
        public TimePropertyEditor(Type objectType, IModelMemberViewItem model) 
            : base(objectType, model) { }
        protected override IComponentAdapter CreateComponentAdapter() 
            => new TimeEditAdapter(new TimeInputModel());
    }
}
