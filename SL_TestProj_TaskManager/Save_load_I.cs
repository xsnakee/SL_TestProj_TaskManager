using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SL_TestProj_TaskManager
{
    interface Saver_i<T>
    {
        bool Save(ref T data);
    }

    interface Loader_i<T>
    {
        bool Load(ref T data);
    }
}
