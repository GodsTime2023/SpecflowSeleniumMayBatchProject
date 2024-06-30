using LivingDoc.Dtos;
using TechTalk.SpecFlow.Assist;
using static SpecflowSeleniumMayBatchProject.StepDefinitions.CalculatorStepDefinitions;

namespace SpecflowSeleniumMayBatchProject.ArgumentTranform
{
    [Binding]
    public class dataTransformer
    {
        [StepArgumentTransformation]
        public IEnumerable<tabDat> ReturnResult(Table table)
        {
            return table.CreateSet<tabDat>();
        }
    }
}
