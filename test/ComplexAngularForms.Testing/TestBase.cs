using Microsoft.Extensions.DependencyInjection;

namespace ComplexAngularForms.Testing
{
    public class TestBase
    {
        protected ServiceCollection _serviceCollection;

        public TestBase()
        {
            _serviceCollection = new ServiceCollection();
        }
    }
}
