using DevExpress.ExpressApp.Blazor.Components.Models;
using SonTungERP.Module.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.Blazor.Editors.ComponentModel
{
    public class LinkInputModel : ComponentModelBase
    {
        public DownloadTemplate Value
        {
            get => GetPropertyValue<DownloadTemplate>();
            set => SetPropertyValue(value);
        }
        public bool ReadOnly
        {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(value);
        }

        public void SetValueFromUI(DownloadTemplate value)
        {
            SetPropertyValue(value, notify: false, nameof(Value));
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler ValueChanged;
    }
}
