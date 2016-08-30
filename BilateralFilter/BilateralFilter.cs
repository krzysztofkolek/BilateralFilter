namespace BilateralFilter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BilateralFilter
    {
        private BilateralFilterData _inputData { get; set; }
        private Bilateral _bilateral { get; set; }
        private ImageToDouble _im2Double { get; set; }
        private SaveImage _saveImage { get; set; }

        public BilateralFilter(BilateralFilterData input)
        {
            _inputData = input;
        }

        public void Run()
        {

        }
    }
}
