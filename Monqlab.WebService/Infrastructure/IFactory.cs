using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Infrastructure
{
    public interface IFactory<out T>
    {
        T Create();
    }
}
