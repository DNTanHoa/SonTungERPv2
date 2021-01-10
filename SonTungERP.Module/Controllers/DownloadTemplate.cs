using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.Controllers
{
    [DomainComponent]
    public class DownloadTemplate
    {
        public string DisplayName { get; set; }

        public string Url { get; set; }
    }
}
