using Xunit;
using ForgeSharp.Commands;
using DNet.Structures;

namespace ForgeSharp.Tests
{
    public class CommandParserTests
    {
        [Theory]
        [InlineData("!test", "!", "test")]
        [InlineData("!test with arguments", "!", "test")]
        [InlineData("~@#$%test with crazy prefix", "~@#$%", "test")]
        [InlineData("test", "", "test")]
        [InlineData(null, "!", null)]
        [InlineData("!test", null, null)]
        [InlineData("!123 first second", "!", "123")]
        [InlineData("!!base first second", "!", "!base")]
        public void GetBase_ShouldExtractCommandBaseFromString(string commandString, string prefix, string expected)
        {
            // Act
            string actual = CommandParser.GetBase(commandString, prefix);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("!hello world", "!", "hello")]
        [InlineData("!123 first second", "!", "123")]
        [InlineData("!_~!@#$% first second", "!", "_~!@#$%")]
        [InlineData("test", "", "test")]
        [InlineData(null, "!", null)]
        [InlineData("!test", null, null)]
        public void GetBase_ShouldExtractCommandBaseFromMessage(string messageContent, string prefix, string expected)
        {
            // Act
            string actual = CommandParser.GetBase(new Message() {
                Content = messageContent
            }, prefix);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("base first second", new string[] { "first", "second" })]
        [InlineData("first second third", new string[] { "second", "third" })]
        [InlineData("first", new string[] { })]
        [InlineData(null, null)]
        [InlineData("first second third forth fifth", new string[] { "second", "third", "forth", "fifth"})]
        [InlineData("base 1 second 3 forth", new string[] { "1", "second", "3", "forth" })]
        public void GetArguments_ShouldExtractArgumentsFromString(string commandString, string[] expected)
        {
            // Act
            string[] actual = CommandParser.GetArguments(commandString);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
