﻿using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Difi.Oppslagstjeneste.Klient.Tests.Fakes
{
    public abstract class FakeHttpClientHandler : DelegatingHandler
    {
        public HttpStatusCode? ResultCode { get; set; }

        public HttpContent HttpContent { get; set; }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage
            {
                Content = HttpContent ?? GetContent(),
                StatusCode = ResultCode ?? HttpStatusCode.OK
            };
            return await Task.FromResult(response);
        }

        public abstract HttpContent GetContent();
    }
}