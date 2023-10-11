using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRayusTestProject.Reports;

namespace MyRayusTestProject
{
    public class TestHooks : IAsyncLifetime
    {
        public Task DisposeAsync()
        {
            ReportUtils.FlushReport(); // Only flush if all tests are Done
            return Task.CompletedTask;
        }

        public Task InitializeAsync()
        {
            ReportUtils.Initialize(); //Nothing to Initialize at the start of the test execution
            return Task.CompletedTask;
        }
    }
}
