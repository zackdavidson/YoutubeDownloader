using System;
using NUnit.Framework;
using YoutubeDownloader.Common.Exceptions;
using YoutubeDownloader.Common.Link;

namespace YoutubeDownloader.Common.Tests.Link
{
    public class YoutubeLinkValidatorTests
    {
        private readonly ILinkValidator _youtubeLinkValidator = new YoutubeLinkValidator();

        [Test]
        public void Validate_NullLink_ThrowsArgumentNullException()
        {
            ILinkValidator yt = new YoutubeLinkValidator();
            Assert.Throws<ArgumentNullException>(() => _youtubeLinkValidator.Validate(null));
        }

        [Test]
        public void Validate_RandomString_ThrowsInvalidLinkException()
        {
            ILinkValidator yt = new YoutubeLinkValidator();
            Assert.Throws<InvalidLinkException>(() => _youtubeLinkValidator.Validate("not even a link"));
        }
        
        [Test]
        public void Validate_GoogleLink_ReturnsFalse()
        {
            var isMatch = _youtubeLinkValidator.Validate("https://google.co.uk/test");
            Assert.IsFalse(isMatch);
        }

        [Test]
        public void Validate_YoutubeLink_ReturnsTrue()
        {
            var validLinks = new string[]
            {
                "https://www.youtube.com/watch?v=OBl4pp0Sfko",
                "www.youtube.com/watch?v=OBl4pp0Sfko",
                "youtube.com/watch?v=OBl4pp0Sfko",
                "https://youtu.be/OBl4pp0Sfko"
            };

            foreach (var link in validLinks)
            {
                Assert.IsTrue(_youtubeLinkValidator.Validate(link));
            }
            
        }
    }
}