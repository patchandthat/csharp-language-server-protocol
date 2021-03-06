using FluentAssertions;
using OmniSharp.Extensions.LanguageServer.Protocol.Client.Capabilities;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using OmniSharp.Extensions.LanguageServer.Protocol.Serialization;
using Xunit;

namespace Lsp.Tests.Models
{
    public class MessageActionItemTests
    {
        [Theory, JsonFixture]
        public void SimpleTest(string expected)
        {
            var model = new MessageActionItem() {
                Title = "abc"
            };
            var result = Fixture.SerializeObject(model);

            result.Should().Be(expected);

            var deresult = new Serializer(ClientVersion.Lsp3).DeserializeObject<MessageActionItem>(expected);
            deresult.Should().BeEquivalentTo(model);
        }
    }
}
