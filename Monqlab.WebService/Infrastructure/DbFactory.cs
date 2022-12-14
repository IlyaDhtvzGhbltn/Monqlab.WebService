using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Infrastructure
{
    public class DbFactory<DbContext> : IFactory<DbContext>
    {
        private readonly Func<DbContext> _factory;
        public DbFactory(Func<DbContext> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Creates DbContext
        /// </summary>
        /// <returns>DbContext</returns>
        public DbContext Create()
        {
            return _factory();
        }
    }
}