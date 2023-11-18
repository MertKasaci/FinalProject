using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public interface EfOrderDal : EfEntityRepositoryBase<Order,NortwindContext>,IOrderDal
    {
    }
}
