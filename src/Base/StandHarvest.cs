/**
* Namespace: Landis.Extension.Landispro.Harvest 
* Class: StandHarvest
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
    class StandHarvest
    {
        public Stand itsStand;
        public SiteHarvester itsSiteHarvester;
        public HarvestPath itsPath;

        public StandHarvest()
        {
            itsStand = null;
            itsSiteHarvester = null;
            itsPath = null;
        }

        public virtual int Harvest()
        {
            return 0;
        }

        public void setStand(Stand stand)
        {
            itsStand = stand;
        }

        public void setSiteHarvester(SiteHarvester siteHarvester)
        {
            itsSiteHarvester = siteHarvester;
        }

        public void setPath(HarvestPath path)
        {
            itsPath = path;
        }

        public Stand getStand()
        {
            return itsStand;
        }

        public SiteHarvester getSiteHarvester()
        {
            return itsSiteHarvester;
        }

        public HarvestPath getPath()
        {
            //printf("StandHarvester::getPath(),itsPath = %d \n", itsPath);
            //fflush(stdout);

            return itsPath;
        }

    }
}
