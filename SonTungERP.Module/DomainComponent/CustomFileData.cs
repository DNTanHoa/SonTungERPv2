using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace SonTungERP.Module.DomainComponent
{
    [DomainComponent]
    public class CustomFileData : IFileData
    {
        public CustomFileData()
        {
        }

        string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public int Size
        {
            get { return Content == null ? 0 : Content.Length; }
        }

        [Browsable(false)]
        public byte[] Content { get; set; }

        public void Clear()
        {
            this.Content = null;
            this.FileName = string.Empty;
        }

        public void LoadFromStream(string fileName, Stream stream)
        {
            Guard.ArgumentNotNull(stream, "stream");
            Guard.ArgumentNotNullOrEmpty(fileName, "fileName");
            this.FileName = fileName;
            byte[] array = new byte[stream.Length];
            stream.Read(array, 0, array.Length);
            this.Content = array;
        }

        public void SaveToStream(Stream stream)
        {
            if (string.IsNullOrEmpty(this.FileName))
            {
                throw new InvalidOperationException();
            }
            stream.Write(this.Content, 0, this.Size);
            stream.Flush();
        }

        public override string ToString()
        {
            return this.FileName;
        }
    }
}
