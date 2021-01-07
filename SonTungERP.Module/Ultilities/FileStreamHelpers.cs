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
    }
}
