using RestSharp;
using System;
using System.Net;

namespace TwitchRest.Api
{
    public static class RestFactory
    {
        #region Constructor

        static RestFactory()
        {
            var client = new RestClient( "https://api.twitch.tv/kraken" );
            client.AddDefaultHeader( "x-api-version", "2" );

            Client = client;
        }

        #endregion

        #region Properties

        private static IRestClient Client { get; set; }

        #endregion

        /// <summary>
        /// Gets the top featured games
        /// </summary>
        /// <param name="success">action to take if the request succeeds</param>
        /// <param name="fail">action to take if the request failed</param>
        public static void GetTopGames( Action<TopGames> success, Action<string> fail )
        {
            Execute<TopGames>( Urls.TopGames, Method.GET, success, fail );
        }

        /// <summary>
        /// Gets a list of streams for the given game
        /// </summary>
        /// <param name="gameName">Streams categorized under 'game'</param>
        /// <param name="channel">Streams from a comma separated list of channels.</param>
        /// <param name="limit">Maximum number of objects in array. Default is 25. Maximum is 100.</param>
        /// <param name="offset">Object offset for pagination. Default is 0.</param>
        /// <param name="embeddable">If set to true, only returns streams that can be embedded</param>
        /// <param name="hls">If set to true, only returns streams using HLS</param>
        public static void GetStreams( string gameName, Action<StreamsResponse> success, Action<string> fail)//, string channel = null, int? limit = 25, int? offset = null, bool embeddable = false, bool hls = false )
        {
            var url = string.Format( Urls.GameStreams, WebUtility.UrlEncode( gameName ) );

            //if( channel != null )
            //{
            //    url += "&channel=" + channel;
            //}

            //if( offset != null )
            //{
            //    url += "&offset=" + offset;
            //}

            //if( embeddable )
            //{
            //    url += "&embeddable=true";
            //}

            //if( hls )
            //{
            //    url += "&hls=true";
            //}

            Execute<StreamsResponse>( url, Method.GET, success, fail );
        }

        /// <summary>
        /// Executes the request
        /// </summary>
        /// <typeparam name="T">Expected data type</typeparam>
        /// <param name="url">the url - aka resource - to hit</param>
        /// <param name="method">request method to use; GET, POST, etc</param>
        /// <param name="success">delegate to call if the request succeeded</param>
        /// <param name="fail">delegate to call if there was any error</param>
        private static void Execute<T>( string url, Method method, Action<T> success, Action<string> fail ) where T : new()
        {
            var request = new RestRequest( url, method );

            Client.ExecuteAsync<T>( request, response =>
            {
                if( response.ResponseStatus == ResponseStatus.Error )
                {
                    fail( response.ErrorMessage );
                }
                else
                {
                    success( response.Data );
                }
            } );
        }
    }
}