using System;
using System.Collections.Generic;
using SmartRetail.MagicMirror.Data.Interfaces;

namespace SmartRetail.MagicMirror.Data
{
    public class ColorRepository : IColorRepository
    {
        SmartRetailContext context = new SmartRetailContext();

        public Color Get(int id)
        {
            return context.Color.Find(id);
        }

        public IEnumerable<Color> GetAll()
        {
            return context.Color;
        }
    }
}
