using DevExpress.ExpressApp.Blazor.Components.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.Blazor.Editors.ComponentModel
{
    public class TimeInputModel : ComponentModelBase
    {
        public DateTime? Value
        {
            get => GetPropertyValue<DateTime?>();
            set => SetPropertyValue(value);
        }
        public bool ReadOnly
        {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(value);
        }

        public void SetValueFromUI(DateTime? value)
        {
            SetPropertyValue(value, notify: false, nameof(Value));
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler ValueChanged;
    }
}
