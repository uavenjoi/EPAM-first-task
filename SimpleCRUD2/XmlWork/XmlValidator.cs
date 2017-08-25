using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SimpleCRUD2.XmlWork
{
    public static class XmlValidator
    {
        public static bool IsXmlFile(HttpPostedFileBase file)
        {
            return Path.GetExtension(file.FileName).Equals(".xml");
        }
    }
}