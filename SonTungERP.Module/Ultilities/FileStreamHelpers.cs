using DevExpress.Persistent.BaseImpl;
using SonTungERP.Module.DomainComponent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SonTungERP.Module.Ultilities
{
    public static class FileStreamHelpers
    {
        public static void SaveAsFile(this byte[] stream, string savePath)
        {
            File.WriteAllBytes(savePath, stream);
        }

        public static void SaveToPath(this FileData fileData, string savePath)
        {
            if (fileData != null)
            {
                using (Stream stream = new MemoryStream())
                {
                    fileData.SaveToStream(stream);

                    using (FileStream fileStream = File.Create(savePath, (int)stream.Length))
                    {
                        fileStream.Write(fileData.Content, 0, fileData.Content.Length);
                        fileStream.Close();
                    }
                }
            }
        }

        public static void SaveToPath(this CustomFileData fileData, string savePath)
        {
            if (fileData != null)
            {
                using (Stream stream = new MemoryStream())
                {
                    fileData.SaveToStream(stream);

                    using (FileStream fileStream = File.Create(savePath, (int)stream.Length))
                    {
                        fileStream.Write(fileData.Content, 0, fileData.Content.Length);
                        fileStream.Close();
                    }
                }
            }
        }
    }
}
