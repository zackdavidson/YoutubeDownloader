namespace YoutubeDownloader.Common.Link
{
    /// <summary>
    /// The default link validator
    /// </summary>
    public interface ILinkValidator
    {
        /// <summary>
        /// Validates a given link
        /// </summary>
        /// <param name="url">the link we need to validate</param>
        /// <returns>
        /// true if the link is a valid youtube link
        /// </returns>
        bool Validate(string url);
    }
}