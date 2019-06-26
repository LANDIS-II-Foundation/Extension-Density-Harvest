/**
* Namespace: Landis.Extension.Landispro.Harvest 
* Class: StandRankingAlgorithm
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
using System.Text;
using System.Threading.Tasks;

namespace Landis.Extension.Landispro.Harvest
{
    class StandRankingAlgorithm
    {
        protected ManagementArea itsManagementArea = new ManagementArea();
        protected int itsRotationAge;
        protected int itsManagementId;
       

        public StandRankingAlgorithm(int someManagementAreaId, int someRotationAge)
        {

            itsManagementArea.itsId= BoundedPocketStandHarvester.managementAreas[someManagementAreaId].itsId;
            itsManagementArea.itsTotalSites = BoundedPocketStandHarvester.managementAreas[someManagementAreaId].itsTotalSites;
            itsManagementArea.itsActiveSites = BoundedPocketStandHarvester.managementAreas[someManagementAreaId].itsActiveSites;
            itsManagementArea.itsUpdateFlag = BoundedPocketStandHarvester.managementAreas[someManagementAreaId].itsUpdateFlag;
            BoundedPocketStandHarvester.managementAreas[someManagementAreaId].itsStandList.ForEach(i => itsManagementArea.itsStandList.Add(i));
            //itsManagementArea.itsStandList = BoundedPocketStandHarvester.managementAreas[someManagementAreaId].itsStandList;
            //Console.WriteLine("{0}, {1}",someManagementAreaId, BoundedPocketStandHarvester.managementAreas[someManagementAreaId].itsStandList.Count);
            itsRotationAge = someRotationAge;
            itsManagementId = someManagementAreaId;
        }

        public virtual void read(StreamReader infile)
        {

        }

        public virtual void rankStands(ref List<int> theRankedList)
        {

        }

        public void filter(ref IntArray theStandArray, ref IntArray theAgeArray, ref int theLength)
        {

            Stand stand = new Stand();

            int theNewLength = 0;

            List<int> it = new List<int>();
            it = itsManagementArea.itsStandList;
            for (int i = 0; i < it.Count; i++)
            {
                int id = it[i];
                stand.Copy(BoundedPocketStandHarvester.pstands[id]);
                if (stand.canBeHarvested() && stand.getAge() >= itsRotationAge)
                {
                    theNewLength++;
                    theStandArray[theNewLength] = id;
                    theAgeArray[theNewLength] = stand.getAge();
                }
            }
            theLength = theNewLength;
        }

        public void descendingSort_doubleArray(IntArray theStandArray, double[] theSortKeyArray, int theLength)
        { //Add by Qia
            int temp;
            double temp_double;
            for (int i = 1; i <= theLength - 1; i++)
            {
                for (int j = i + 1; j <= theLength; j++)
                {
                    if (theSortKeyArray[j] > theSortKeyArray[i])
                    {
                        temp = theStandArray[j];
                        theStandArray[j] = theStandArray[i];
                        theStandArray[i] = temp;

                        temp_double = theSortKeyArray[j];
                        theSortKeyArray[j] = theSortKeyArray[i];
                        theSortKeyArray[i] = temp_double;
                    }
                }
            }
        }


        public void assign(IntArray theStandArray, int theLength, ref List<int> theRankedList)
        {
            for (int i = 1; i <= BoundedPocketStandHarvester.pstands.number(); i++)
                BoundedPocketStandHarvester.pstands[i].setRank(0);
            int rank = 1;
            for (int i = 1; i <= theLength; i++)
            {
                BoundedPocketStandHarvester.pstands[theStandArray[i]].setRank(rank++);
                theRankedList.Add(theStandArray[i]);
            }
        }

    }
}
