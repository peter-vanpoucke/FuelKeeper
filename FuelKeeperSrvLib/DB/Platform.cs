using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be.subport.app.FuelKeeper.SrvLib.DB
{
    public abstract class Platform
    {
        protected abstract SQLite.Net.Interop.ISQLitePlatform InitPlatform();

        internal SQLite.Net.Interop.ISQLitePlatform GetPlatform()
        {
            return this.InitPlatform();
        }
    }
}
