// Contributors:
//   James Domingo, Green Code LLC
//   Robert M. Scheller
 

namespace Landis.Extension.DensityHarvest
{
    /// <summary>
    /// The parameters for biomass harvest.
    /// </summary>
    public interface IParameters
        : Landis.Library.DensityHarvestManagement.IInputParameters
    {
        /// <summary>
        /// Template for pathnames for biomass-removed maps.
        /// </summary>
        string BiomassMapNames
        {
            get;
        }

    }
}
