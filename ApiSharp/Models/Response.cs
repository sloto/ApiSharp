﻿namespace ApiSharp.Models;

/// <summary>
/// Response object, wrapper for HttpResponseMessage
/// </summary>
internal class Response : IResponse
{
    private readonly HttpResponseMessage response;

    /// <inheritdoc />
    public HttpStatusCode StatusCode => response.StatusCode;

    /// <inheritdoc />
    public bool IsSuccessStatusCode => response.IsSuccessStatusCode;

    /// <inheritdoc />
    public IEnumerable<KeyValuePair<string, IEnumerable<string>>> ResponseHeaders => response.Headers;

    /// <summary>
    /// Create response for a http response message
    /// </summary>
    /// <param name="response">The actual response</param>
    public Response(HttpResponseMessage response)
    {
        this.response = response;
    }

    /// <inheritdoc />
    public async Task<System.IO.Stream> GetResponseStreamAsync()
    {
        return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
    }

    /// <inheritdoc />
    public void Close()
    {
        response.Dispose();
    }
}