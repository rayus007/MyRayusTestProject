using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace MyRayusTestProject
{
    public static class TestOutputHelperExtensions
    {
        public static string GetTestName(this ITestOutputHelper Myoutput)
        {
            var type = Myoutput.GetType();
            var testMember = type.GetField("test", BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var test = (ITest)testMember.GetValue(Myoutput);
            return test.DisplayName.Split("Tests")[1].Remove(0, 1);
        }
    }
}
