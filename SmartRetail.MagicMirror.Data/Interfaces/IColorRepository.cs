using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRetail.MagicMirror.Data.Interfaces
{
    public interface IColorRepository
    {
        IEnumerable<Color> GetAll();
        Color Get(int id);
    }
}
