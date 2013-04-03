using RestSharp;
using System;

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

        public static void GetTopGames( Action<TopGames> success, Action<string> fail )
        {
            Execute<TopGames>( Urls.TopGames, Method.GET, success, fail );
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