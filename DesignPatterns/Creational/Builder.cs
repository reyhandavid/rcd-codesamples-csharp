namespace DesignPatterns.Creational.Builder
{
    /// <summary>
    /// Product class with many optional parameters
    /// </summary>
    public class HttpRequest
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string Body { get; set; }
        public int Timeout { get; set; }
        public bool FollowRedirects { get; set; }
        public Dictionary<string, string> QueryParameters { get; set; }

        public override string ToString()
        {
            var result = $"{Method} {Url}";
            if (QueryParameters?.Count > 0)
            {
                result += "?" + string.Join("&", QueryParameters.Select(kv => $"{kv.Key}={kv.Value}"));
            }
            result += $"\nTimeout: {Timeout}ms";
            result += $"\nFollow Redirects: {FollowRedirects}";
            if (Headers?.Count > 0)
            {
                result += "\nHeaders:\n  " + string.Join("\n  ", Headers.Select(h => $"{h.Key}: {h.Value}"));
            }
            if (!string.IsNullOrEmpty(Body))
            {
                result += $"\nBody: {Body}";
            }
            return result;
        }
    }

    /// <summary>
    /// Builder for constructing HttpRequest objects.
    /// Provides a fluent interface for step-by-step construction.
    /// </summary>
    public class HttpRequestBuilder
    {
        private readonly HttpRequest _request;

        public HttpRequestBuilder()
        {
            _request = new HttpRequest
            {
                Headers = new Dictionary<string, string>(),
                QueryParameters = new Dictionary<string, string>(),
                Method = "GET",
                Timeout = 30000,
                FollowRedirects = true
            };
        }

        public HttpRequestBuilder SetUrl(string url)
        {
            _request.Url = url;
            return this;
        }

        public HttpRequestBuilder SetMethod(string method)
        {
            _request.Method = method;
            return this;
        }

        public HttpRequestBuilder AddHeader(string key, string value)
        {
            _request.Headers[key] = value;
            return this;
        }

        public HttpRequestBuilder AddQueryParameter(string key, string value)
        {
            _request.QueryParameters[key] = value;
            return this;
        }

        public HttpRequestBuilder SetBody(string body)
        {
            _request.Body = body;
            return this;
        }

        public HttpRequestBuilder SetTimeout(int milliseconds)
        {
            _request.Timeout = milliseconds;
            return this;
        }

        public HttpRequestBuilder SetFollowRedirects(bool follow)
        {
            _request.FollowRedirects = follow;
            return this;
        }

        public HttpRequest Build()
        {
            if (string.IsNullOrEmpty(_request.Url))
            {
                throw new InvalidOperationException("URL is required");
            }
            return _request;
        }
    }

    /// <summary>
    /// Example usage of Builder Pattern
    /// </summary>
    public class BuilderPatternExample
    {
        public static void RunExample()
        {
            Console.WriteLine("=== Builder Pattern Example ===\n");

            // Simple GET request
            var simpleRequest = new HttpRequestBuilder()
                .SetUrl("https://api.example.com/users")
                .Build();

            Console.WriteLine("Simple Request:");
            Console.WriteLine(simpleRequest);

            // Complex POST request with many options
            var complexRequest = new HttpRequestBuilder()
                .SetUrl("https://api.example.com/users")
                .SetMethod("POST")
                .AddHeader("Content-Type", "application/json")
                .AddHeader("Authorization", "Bearer token123")
                .AddQueryParameter("include", "profile")
                .AddQueryParameter("fields", "id,name,email")
                .SetBody("{\"name\": \"John Doe\", \"email\": \"john@example.com\"}")
                .SetTimeout(60000)
                .SetFollowRedirects(false)
                .Build();

            Console.WriteLine("\n\nComplex Request:");
            Console.WriteLine(complexRequest);

            // Builder pattern benefits:
            // 1. Readable, fluent API
            // 2. Step-by-step construction
            // 3. Immutable final product (if desired)
            // 4. Can have validation in Build() method
            // 5. No need for multiple constructors or long parameter lists
        }
    }
}
