// Contributors:
//   James Domingo, Green Code LLC
//   Robert M. Scheller
 

using Landis.Utilities;
using Landis.Core;
using Landis.Library.DensityHarvestManagement;
using Landis.Library.DensitySiteHarvest;
using Landis.Library.Succession;
using System.Collections.Generic;
using System.Text;


namespace Landis.Extension.DensityHarvest
{
    /// <summary>
    /// A parser that reads the extension's parameters from text input.
    /// </summary>
    public class ParametersParser
        : Landis.Library.DensityHarvestManagement.InputParametersParser
    {
        public override string LandisDataValue
        {
            get
            {
                return PlugIn.ExtensionName;
            }
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="speciesDataset">
        /// The dataset of species to look up species' names in.
        /// </param>
        public ParametersParser(ISpeciesDataset speciesDataset)
            : base(PlugIn.ExtensionName, speciesDataset)
        {
        }

        //---------------------------------------------------------------------

        protected override Landis.Library.DensityHarvestManagement.InputParameters CreateEmptyParameters()
        {
            return new Parameters();
        }

        //---------------------------------------------------------------------

        protected override ICohortCutter CreateCohortCutter(ICohortSelector cohortSelector)
        {
            return CohortCutterFactory.CreateCutter(cohortSelector, HarvestExtensionMain.ExtType);
        }

        protected override ICohortCutter CreateAdditionalCohortCutter(ICohortSelector cohortSelector)
        {
            return CohortCutterFactory.CreateAdditionalCutter(cohortSelector, HarvestExtensionMain.ExtType);
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// Creates a cohort selection method for a specific set of ages and
        /// age ranges.
        /// </summary>
        /// <remarks>
        /// This overrides the base method so it can use the PartialThinning
        /// class to handle cohort selections with percentages.
        /// </remarks>
        /// 
        // JSF - FIXME override not needed
/*        protected override void CreateCohortSelectionMethodFor(ISpecies species,
                                                               IList<ushort> ages,
                                                               IList<AgeRange> ranges)
        {
            if (!DensityThinning.CreateCohortSelectorFor(species, ages, ranges))
            {
                // There were no percentages specified for this species' ages
                // and ranges.  So just create and store a whole cohort
                // selector using the base method.
                base.CreateCohortSelectionMethodFor(species, ages, ranges);
            }
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// Creates a cohort selection method for a specific set of ages and
        /// age ranges.
        /// </summary>
        /// <remarks>
        /// This overrides the base method so it can use the PartialThinning
        /// class to handle cohort selections with percentages.
        /// </remarks>
        protected void CreateAdditionalCohortSelectionMethodFor(ISpecies species,
                                                               IList<ushort> ages,
                                                               IList<AgeRange> ranges)
        {
            if (!DensityThinning.CreateAdditionalCohortSelectorFor(species, ages, ranges))
            {
                // There were no percentages specified for this species' ages
                // and ranges.  So just create and store a whole cohort
                // selector using the base method.
                
                //JSF - FIXME
                //base.CreateAdditionalCohortSelectionMethodFor(species, ages, ranges);
            }
        }*/

        //---------------------------------------------------------------------

        /// <summary>
        /// Puts filename for BiomassMaps into the parameters
        /// </summary>
        /// <remarks>
        /// This overrides the base method in harvest-mgmt-lib
        /// </remarks>
        protected override void ReadBiomassMaps(InputParameters baseParameters)
        {
            InputVar<string> biomassMapNames = new InputVar<string>("BiomassMaps");
            if (ReadOptionalVar(biomassMapNames))
            {
                // Get the biomass harvest implementation of the InputParameters so we can set the biomassMaps property 
                Parameters parameters = baseParameters as Parameters;
                parameters.BiomassMapNames = biomassMapNames.Value;
            }
        }
    }
}
