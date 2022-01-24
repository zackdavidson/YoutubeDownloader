using System;

namespace YoutubeDownloader.Common.Exceptions
{
    public class InvalidLinkException : Exception
    {
        public InvalidLinkException(string exception) : base(exception)
        {
        }
    }
}