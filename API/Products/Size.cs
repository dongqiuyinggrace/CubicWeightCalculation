using System;
using System.Collections.Generic;
using System.Text;

namespace API.Products
{
    public class Size
    {
        private const int UNIT_CM2M = 1000000;

        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }

        public decimal GetVolumeInM()
        {
            return (Width * Height * Length) / UNIT_CM2M;
        }
    }
}
