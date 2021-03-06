﻿using System;
using System.IO;

namespace textDb.Base
{
    public static class Delete
    {
        public static void DeleteFile(Type entityType)
        {
            string tableFullName = BaseFile.GetFullName(entityType);

            if (File.Exists(tableFullName))
            {
                File.Delete(tableFullName);
            }
        }
    }
}
