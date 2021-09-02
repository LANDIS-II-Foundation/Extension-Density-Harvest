/**
* Namespace: Landis.Extension.Landispro.Harvest 
* Class: CohortRemovalMask
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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Landis.Extension.Landispro.Harvest
{
    class CohortRemovalMask
    {
        private Landis.Extension.Succession.Landispro.agelist mask;

        public CohortRemovalMask()
        {

        }

        ~CohortRemovalMask()
        {

        }

        public void read(StreamReader infile)
        {
            mask.read(infile);
        }

        public void dump()
        {
            mask.dump();
        }

        public int query()
        {
            if (mask.query())
                return 1;
            else return 0;
        }

        public int query(int n)
        {
            if (mask.query(n))
                return 1;
            else return 0;
        }
    }
}
