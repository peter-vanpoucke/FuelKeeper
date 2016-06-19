using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace be.subport.app.FuelKeeper.SrvLib
{
    public static class Helper
    {
        public static DirectoryInfo GetMainDir()
        {
            var myType = typeof(Helper);
            var program = new FileInfo(myType.Assembly.Location);
            var programDir = program.Directory;

            DirectoryInfo diMaindir = null;

            var searchDir = programDir;
            while (searchDir != null)
            {
                if (searchDir.EnumerateFiles("maindir.indicator").Count() == 1)
                {
                    diMaindir = searchDir;
                    break;
                }
                searchDir = searchDir.Parent;
            }

            return diMaindir;
        }
    }
}
