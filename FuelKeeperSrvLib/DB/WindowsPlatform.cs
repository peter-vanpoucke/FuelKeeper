using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;

namespace be.subport.app.FuelKeeper.SrvLib.DB
{
    public class WindowsPlatform : Platform
    {
        protected override ISQLitePlatform InitPlatform()
        {
            return new SQLite.Net.Platform.Win32.SQLitePlatformWin32();
        }
    }
}
