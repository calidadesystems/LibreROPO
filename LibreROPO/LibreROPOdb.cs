using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LibreROPO
{
    class LibreROPOdb
    {
        private String path;
        public LibreROPOdb(String path) 
        {
            this.path = path;
        }

        public bool fileExists()
        {
            return File.Exists(this.path);
        }

        public bool isValidDb() 
        {
            bool toret = false;
            return toret;
        }
    }
}
