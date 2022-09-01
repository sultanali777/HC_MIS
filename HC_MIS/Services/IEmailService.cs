using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HC_MIS.Services
{

    public interface IEmailService
    {
        Task Send(string to, string subject, string html, string from = null, List<IFormFile> files = null);
    }
}
