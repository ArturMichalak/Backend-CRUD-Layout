using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Interfaces
{
    public interface ICommand<T> where T : class
    {
        T Run();
    }
}
