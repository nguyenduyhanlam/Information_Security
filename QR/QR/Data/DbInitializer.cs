using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UserContext context)
        {
            context.Database.EnsureCreated();

            if (context.Demousers.Any())
            {
                return;
            }
        }
    }
}
