using System;
using System.Text.RegularExpressions;
using YoutubeDownloader.Common.Exceptions;

namespace YoutubeDownloader.Common.Link
{
    public class YoutubeLinkValidator : ILinkValidator
    {
        public bool Validate(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }
            if (!Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                throw new InvalidLinkException($"invalid link: {url}");
            }
            
            var regex = new Regex(Constants.YoutubeLinkValidatorRegex);
            return regex.IsMatch(url);
        }
    }
}