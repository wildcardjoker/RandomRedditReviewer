#region Information

// RandomRedditReviewer: SubRedditViewModel
// Created: 2016-07-31
// Modified: 2016-08-12 9:20 PM
#endregion

#region Using Directives
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

#endregion

namespace Wcj
{
    /// <summary>
    ///     ViewModel for RandomRedditReviewer
    /// </summary>
    public partial class SubRedditViewModel
    {
        /// <summary>
        ///     Get a random Subreddit
        /// </summary>
        /// <param name="retries">Number of times we have tried to get a random subreddit</param>
        /// <returns></returns>
        private async Task<SubReddit> GetRandomSubRedditAsync(int retries = 0)
        {
            if (retries == 3)
            {
                return new SubReddit("Failed to get subreddit", "");
            }
            try
            {
                string uri;
                switch (NsfwPreference)
                {
                    case NsfwPreference.Include:
                        uri = _random.Next() % 2 == 0 ? RandomNsfw : RandomSfw;
                        break;
                    case NsfwPreference.NsfwOnly:
                        uri = RandomNsfw;
                        break;
                    case NsfwPreference.No:
                    default:
                        uri = RandomSfw;
                        break;
                }
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                if (uri.Equals(RandomNsfw))
                {
                    string destination = Uri.UnescapeDataString(response.RequestMessage.RequestUri.Query.Substring(6));
                    string subName = destination.Substring(destination.LastIndexOf("/r/"));
                    return new SubReddit($"{subName.Substring(0, subName.Length - 1)} (NSFW)", destination);
                }
                return new SubReddit(response.RequestMessage.RequestUri);
            }
            catch (Exception exception)
            {
                Status = exception.Message;
                retries++;
                return await GetRandomSubRedditAsync(retries);
            }
        }

        /// <summary>
        ///     Get the specified number of subreddits
        /// </summary>
        /// <returns></returns>
        private async Task GetSubRedditsAsync()
        {
            SubReddits.Clear();
            SubRedditCount = 0;
            for (int i = 0; i < SubRedditsToGet; i++)
            {
                SubReddit subReddit = await Task.Run(() => GetRandomSubRedditAsync());
                if (subReddit != null)
                {
                    SubReddits.Add(subReddit);
                    SubRedditCount++;
                }
                Status = $"{SubRedditCount} subreddits collected.";
                Debug.WriteLine(Status);
            }
            SubRedditCount = 0;
        }

        /// <summary>
        ///     Launch the instructions and credits.
        /// </summary>
        private static void ShowInstructions()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "instructions.txt");
            Process.Start(path);
        }
    }
}