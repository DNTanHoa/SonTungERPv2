using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using SonTungERP.Module.Blazor.Editors;
using SonTungERP.Module.Blazor.Editors.ComponentModel;
using SonTungERP.Module.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.Blazor
{
    [PropertyEditor(typeof(DownloadTemplate), false)]
    public class LinkPropertyEditor : BlazorPropertyEditorBase
    {
        public LinkPropertyEditor(Type objectType, IModelMemberViewItem model)
            : base(objectType, model) { }
        protected override IComponentAdapter CreateComponentAdapter()
            => new LinkEditAdapter(new LinkInputModel());
    }
}
