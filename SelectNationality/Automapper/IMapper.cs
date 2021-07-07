using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelectNationality.Automapper
{
    public interface IMapper<in TIn,out TOut>
    {
        TOut Map(TIn sourceModel);
    }
}
