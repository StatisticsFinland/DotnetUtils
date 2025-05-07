using Microsoft.Azure.Functions.Worker.Http;

namespace AzureNetIsolatedFunctionMockTools.Internal
{
    internal class MockHttpCookies : HttpCookies
    {
        public override void Append(string name, string value)
        {
            throw new NotImplementedException();
        }

        public override void Append(IHttpCookie cookie)
        {
            throw new NotImplementedException();
        }

        public override IHttpCookie CreateNew()
        {
            throw new NotImplementedException();
        }
    }
}
