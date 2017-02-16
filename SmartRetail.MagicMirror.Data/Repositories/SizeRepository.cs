using SmartRetail.MagicMirror.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace SmartRetail.MagicMirror.Data
{
    public class SizeRepository : ISizeRepository
    {
        SmartRetailContext context = new SmartRetailContext();

        public Size Get(int id)
        {
            return context.Size.Find(id);
        }

        public IEnumerable<Size> GetAll()
        {
            return context.Size;
        }
    }
}
