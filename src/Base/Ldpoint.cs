/**
* Namespace: Landis.Extension.Landispro.Harvest 
* Class: Ldpoint
* 
* Ver        Author         Date                Note
* --------------------------------------------------------------
* V1.0      Yao, Yifu      12/2018         Initial version
*
****************************************************************
*                         Description
****************************************************************
* LANDIS PRO HARVEST implemented within the LANDIS-II framework.
*
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landis.Extension.Landispro.Harvest
{
    class Ldpoint
    {
        public int x;
        public int y;

        public Ldpoint()
        {
            x = y = 0;
        }

        public Ldpoint(int tx, int ty)
        {
            x = tx;
            y = ty;
        }
    }
}
