using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;

namespace SonTungERP.Module.Imports
{
    public class SheetTemplateImport
    {
        public string SheetName { get; set; }

        public List<ColumnTemplateImport> Columns { get; set; }

        public SheetTemplateImport(string Url)
        {
            readXmlTemplate(Url);
        }

        private void readXmlTemplate(string Url)
        {
            try
            {
                var xml = XDocument.Load(Url);

                this.SheetName = (string)xml.Root.Attribute("name");

                var query = from c in xml.Root.Descendants("Column")
                            select new ColumnTemplateImport()
                            {
                                propertyName = (string)c.Attribute("propertyName"),
                                excelHeader = (string)c.Attribute("excelHeader")
                            };

                this.Columns = query?.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
