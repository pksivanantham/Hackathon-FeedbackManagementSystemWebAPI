using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Data
{
    public interface IFMSDBContext
    {
        DbSet<T> Set<T>() where T : class;
    }
}
