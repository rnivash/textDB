﻿using System;
using System.Collections.Generic;
using System.IO;

namespace textDb.Base
{
    public static class Write
    {
        public static void WriteData(Type entityType, string[] values)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(BaseFile.GetFullName(entityType), FileMode.Append, FileAccess.Write, FileShare.Read);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    fs = null;
                    sw.WriteLine(BaseFile.Encode(values));
                }
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
            
        }

        public static void WriteData(Type entityType, IList<string[]> values)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            FileStream fs = null;
            try
            {
                fs = new FileStream(BaseFile.GetFullName(entityType), FileMode.Append, FileAccess.Write, FileShare.Read);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    fs = null;
                    foreach (string[] lin in values)
                    {
                        sw.WriteLine(BaseFile.Encode(lin));
                    }
                }
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
        }
    }
}
