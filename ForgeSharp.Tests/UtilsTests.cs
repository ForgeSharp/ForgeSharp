using ForgeSharp.Core;
using Xunit;

namespace ForgeSharp.Tests
{
    public class UtilsTests
    {
        // TODO: Should user ids be longs?
        [Theory]
        [InlineData("12345", "<@12345>")]
        [InlineData("helloworld", "<@helloworld>")]
        [InlineData("", "<@>")]
        [InlineData(null, null)]
        [InlineData("johndoe", "<@!johndoe>", false)]
        public void Mention_ShouldReturnAValidMentionString(string userId, string expected, bool verifiedEmail = true)
        {
            // Act
            string actual = Utils.Mention(userId, verifiedEmail);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("12345", "<#12345>")]
        [InlineData("hello-world", "<#hello-world>")]
        [InlineData(null, null)]
        public void MentionChannel_ShouldReturnAValidMentionString(string channelId, string expected)
        {
            // Act
            string actual = Utils.MentionChannel(channelId);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("12345", "<@&12345>")]
        [InlineData("hello-world", "<@&hello-world>")]
        [InlineData("", "<@&>")]
        [InlineData(null, null)]
        public void MentionRole_ShouldReturnAValidMentionString(string roleId, string expected)
        {
            // Act
            string actual = Utils.MentionRole(roleId);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
