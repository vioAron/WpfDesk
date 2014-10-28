using NUnit.Framework;
using WpfDesk.Model;
using WpfDesk.TypeConverters;

namespace WpfDeskTests
{
    public class ClientTypeConverterTests
    {
        [Test]
        public void ConvertFrom_ClientString_Client()
        {
            var converter = new ClientTypeConverter();

            var client = converter.ConvertFrom("Id1,ClientId1IsGreat") as Client;

            Assert.IsNotNull(client);
            Assert.AreEqual("Id1", client.Id);
            Assert.AreEqual("ClientId1IsGreat", client.Description);
        }
    }
}
