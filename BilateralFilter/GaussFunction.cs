namespace BilateralFilter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Implements function f = exp(-(X.^2+Y.^2)/(sigma_d^2)); 
    /// </summary>
    public class GaussFunction
    {
        private double _sigmaR { get; set; }
        public void SetGaussFunction(object input, double sigmaR)
        {

            _sigmaR = sigmaR;
        }
    }
}
