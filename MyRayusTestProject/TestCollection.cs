using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRayusTestProject
{
    [CollectionDefinition("Test Collection", DisableParallelization = true)]
    public class TestCollection : ICollectionFixture<TestHooks>
    {
    }
}
