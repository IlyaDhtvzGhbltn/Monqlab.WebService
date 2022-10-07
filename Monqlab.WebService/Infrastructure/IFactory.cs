using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Infrastructure
{
    /// <summary>
    /// Represents a factory
    /// </summary>
    /// <typeparam name="T">out type</typeparam>
    public interface IFactory<out T>
    {
        T Create();
    }
}
