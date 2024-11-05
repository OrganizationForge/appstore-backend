using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IRazorViewRenderer
    {
        Task<string> RenderViewAsync<TModel>(string viewName, TModel model);
    }
}
