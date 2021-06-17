using Task4.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Test.Transformations
{
    [Binding]
    public class TableTransformations
    {
        [StepArgumentTransformation]
        public Birth TransformModel(Table inputTable) => inputTable.CreateInstance<Birth>();
    }
}
