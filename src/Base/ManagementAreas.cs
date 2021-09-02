/**
* Namespace: Landis.Extension.Landispro.Harvest 
* Class: ManagementAreas
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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landis.Extension.Landispro.Harvest
{
    class ManagementAreas
    {
        private int numManagementAreas;
        private ManagementArea[] managementAreas;

        public ManagementAreas()
        {
            numManagementAreas = 0;
            managementAreas = null;
        }

        ~ManagementAreas()
        {
            managementAreas = null;
        }

        public int number()
        {
            return numManagementAreas;
        }

        public ManagementArea this[int n]
        {
            get
            {
                if (n<1 && n>numManagementAreas)
                    throw new Exception("Error: Invlide number of managementAreas");

                return managementAreas[n - 1];
            }
        }

        public void construct()
        {
            int i;
            int r;
            int c;
            uint id;
            int snr;
            int snc;

            if (BoundedPocketStandHarvester.pCoresites.number()<=0 || BoundedPocketStandHarvester.managementAreaMap.NumRows<=0)
                throw new Exception("error on numbers of sites");

            numManagementAreas = BoundedPocketStandHarvester.managementAreaMap.high();
            if (managementAreas != null)
                managementAreas = null;
            managementAreas = new ManagementArea[numManagementAreas];
            for (i=0;i<numManagementAreas;i++)
                managementAreas[i] = new ManagementArea();

            snr = (int)BoundedPocketStandHarvester.pCoresites.numRows;
            snc = (int)BoundedPocketStandHarvester.pCoresites.numColumns;
            //Console.WriteLine("{0}, {1}", snc, c);

            for (i = 0; i < numManagementAreas; i++)
            {
                managementAreas[i].itsId = i + 1;
            }

            for (r = 1; r <= snr; r++)
                for (c = 1; c <= snc; c++)
                {
                    //Console.WriteLine("{0}, {1}", r ,c);
                    id = BoundedPocketStandHarvester.managementAreaMap[(uint)r, (uint)c];
                    if (id > 0 && BoundedPocketStandHarvester.standMap.getvalue32out((uint)r, (uint)c) > 0)
                    {
                        managementAreas[id - 1].itsTotalSites++;
                        if (BoundedPocketStandHarvester.pCoresites.locateLanduPt((uint)r, (uint)c).active())
                            managementAreas[id - 1].itsActiveSites++;
                        managementAreas[id - 1].addStand((uint)BoundedPocketStandHarvester.standMap.getvalue32out((uint)r,(uint)c));
                    }
                }
            //for (int x = 1; x<=10; x++)
            //{
            //    Console.WriteLine("{0}, {1}", x, managementAreas[x-1].numberOfStands());

            //}
        }
    }
}
