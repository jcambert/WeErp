using RestEase;
using System;
using System.Threading.Tasks;
using weerp.api.Models.Operations;

namespace weerp.api.Services
{
    public interface IOperationsService
    {
        [AllowAnyStatusCode]
        [Get("operations/{id}")]
        Task<Operation> GetAsync([Path] Guid id);
    }
}
