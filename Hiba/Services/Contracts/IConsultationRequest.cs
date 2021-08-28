using Hiba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiba.Services.Contracts
{
    public interface IConsultationRequest
    {
        public Task<Page> ConsultationRequest();
    }
}
