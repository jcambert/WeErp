
using Chronicle;
using MicroS_Common.Authentication;
using MicroS_Common.Messages;
using MicroS_Common.RabbitMq;
using MicroS_Common.Types;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace weerp.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [JwtAuth]
    public abstract class BaseController : ControllerBase
    {
        private const string AcceptLanguageHeader = "accept-language";
        private const string OperationHeader = "X-Operation";
        private const string ResourceHeader = "X-Resource";
        private const string DefaultCulture = "fr-fr";
        private const string PageLink = "page";
        private readonly IBusPublisher _busPublisher;
        private readonly ITracer _tracer;

        protected BaseController(IBusPublisher busPublisher, ITracer tracer)
        {
            _busPublisher = busPublisher;
            _tracer = tracer;
        }

        protected IActionResult Single<T>(T model, Func<T, bool> criteria = null)
        {
            if (model == null)
            {
                return NotFound();
            }
            var isValid = criteria == null || criteria(model);
            if (isValid)
            {
                return Ok(model);
            }

            return NotFound();
        }

        protected IActionResult Collection<T>(PagedResult<T> pagedResult, Func<PagedResult<T>, bool> criteria = null)
        {
            if (pagedResult == null)
            {
                return NotFound();
            }
            var isValid = criteria == null || criteria(pagedResult);
            if (!isValid)
            {
                return NotFound();
            }
            if (pagedResult.IsEmpty)
            {
                return Ok(Enumerable.Empty<T>());
            }
            Response.Headers.Add("Link", GetLinkHeader(pagedResult));
            Response.Headers.Add("X-Total-Count", pagedResult.TotalResults.ToString());

            return Ok(pagedResult.Items);
        }

        protected async Task<IActionResult> SendAsync<T>(T command,
            Guid? resourceId = null, string resource = "") where T : ICommand
        {
            var context = GetContext<T>(resourceId, resource);
             await _busPublisher.SendAsync(command, context);

            return Accepted(context);
        }

        protected IActionResult Accepted(ICorrelationContext context)
        {
            if (context == null)
                throw new ArgumentNullException($"{nameof(BaseController) }->Accepted context cannot be null");

            Response.Headers.Add(OperationHeader, $"operations/{context.Id}");
            if (!string.IsNullOrWhiteSpace(context.Resource))
            {
                Response.Headers.Add(ResourceHeader, context.Resource);
            }

            return base.Accepted();
        }

        protected ICorrelationContext GetContext<T>(Guid? resourceId = null, string resource = "") where T : ICommand
        {
            if (!string.IsNullOrWhiteSpace(resource))
            {
                resource = $"{resource}/{resourceId}";
            }

            return CorrelationContext.Create<T>(/*Guid.NewGuid()*/SagaId.NewSagaId(), UserId, resourceId ?? Guid.Empty,
               HttpContext.TraceIdentifier, HttpContext.Connection.Id, _tracer?.ActiveSpan?.Context?.ToString() ??"",
               Request.Path.ToString(), Culture, resource);
        }

        protected bool IsAdmin
            => User.IsInRole("admin");

        protected Guid UserId
            => string.IsNullOrWhiteSpace(User?.Identity?.Name) ?
                Guid.Empty :
                Guid.Parse(User.Identity.Name);

        protected string Culture
            => Request.Headers.ContainsKey(AcceptLanguageHeader) ?
                    Request.Headers[AcceptLanguageHeader].First().ToLowerInvariant() :
                    DefaultCulture;

        protected string GetLinkHeader(PagedResultBase result)
        {
            var first = GetPageLink(result.CurrentPage, 1);
            var last = GetPageLink(result.CurrentPage, result.TotalPages);
            var prev = string.Empty;
            var next = string.Empty;
            if (result.CurrentPage > 1 && result.CurrentPage <= result.TotalPages)
            {
                prev = GetPageLink(result.CurrentPage, result.CurrentPage - 1);
            }
            if (result.CurrentPage < result.TotalPages)
            {
                next = GetPageLink(result.CurrentPage, result.CurrentPage + 1);
            }

            return $"{FormatLink(next, "next")}{FormatLink(last, "last")}" +
                   $"{FormatLink(first, "first")}{FormatLink(prev, "prev")}";
        }

        private string GetPageLink(int currentPage, int page)
        {
            var path = Request.Path.HasValue ? Request.Path.ToString() : string.Empty;
            var queryString = Request.QueryString.HasValue ? Request.QueryString.ToString() : string.Empty;
            var conjunction = string.IsNullOrWhiteSpace(queryString) ? "?" : "&";
            var fullPath = $"{path}{queryString}";
            var pageArg = $"{PageLink}={page}";
            var link = fullPath.Contains($"{PageLink}=",StringComparison.InvariantCulture)
                ? fullPath.Replace($"{PageLink}={currentPage}", pageArg, StringComparison.InvariantCulture)
                : fullPath += $"{conjunction}{pageArg}";

            return link;
        }

        private static string FormatLink(string path, string rel)
            => string.IsNullOrWhiteSpace(path) ? string.Empty : $"<{path}>; rel=\"{rel}\",";
    }
}
