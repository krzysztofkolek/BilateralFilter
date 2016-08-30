namespace BilateralFilter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Bilateral
    {
        private double[,] _inputImage { get; set; }
        private string _pathWithFileName { get; set; }
        private int _sizeOfMask {get;set;}
        private int _sigmaD { get;set;}
        private double _sigmaR { get;set;}

        private BilateralArrayHelper _helper { get; set; }
        private ImageToDouble _imageToDouble { get; set; }
        private Meshgrid _meshGrid { get; set; }
        private GaussFunction _gaussFunction { get; set; }



        public Bilateral(double[,] inputImage, string pathtoFile, int sizeOfMask, int sigmaD, double sigmaR)
        {
            _inputImage = inputImage;
            _pathWithFileName = pathtoFile;
            _sizeOfMask = sizeOfMask;
            _sigmaD = sigmaD;
            _sigmaR = sigmaR;
        }

        public void Run()
        {
            // Step 1
            //% Gaussian distance 
            //[X, Y] = meshgrid(-w:w,-w:w);
            int fromMask = _sizeOfMask * 1;
            int toMask = _sizeOfMask;
            var meshGridResult = _meshGrid.Run(fromMask, toMask, fromMask, toMask);

            // Step 2
            //% Gauss function f(x, y)
            //f = exp(-(X.^ 2 + Y.^ 2) / (sigma_d ^ 2));
            _gaussFunction.SetGaussFunction(meshGridResult, _sigmaR);

            // Step 3
            //% Applying the filter
            //Dimensions = size(A);
            int sizeY = _inputImage.GetLength(0),
                sizeX = _inputImage.GetLength(1);

            // Step 4
            // Zero filled matrix, for output 
            //OutputImage = zeros(Dimensions);
            var outputImage = _helper.Zeros(sizeX, sizeY);

            // Step 5
            // Iterate over image
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    // Step 6
                    // Extraction of the central point, with it's sorrunding
                    // iMin = max(i - w, 1);
                    // iMax = min(i + w, Dimensions(1));
                    // jMin = max(j - w, 1);
                    // jMax = min(j + w, Dimensions(2));
                    int iMin = _helper.Max(i - _sizeOfMask, 1),                        
                        iMax = _helper.Min(i + _sizeOfMask, sizeY),
                        jMin = _helper.Max(j - _sizeOfMask, 1),
                        jMax = _helper.Min(j + _sizeOfMask, sizeX);

                    // Step 7
                    // PixelsForReplacement = A(iMin: iMax, jMin: jMax);


                    // Step 8
                    // Calculating the intesity of the Gaussian weights for the region                     
                    // Gauss function g(t)
                    // g = exp(-(PixelsForReplacement - A(i, j)).^ 2 / (sigma_r ^ 2));



                    // Step 9
                    // Calculationg the filter response
                    // F = g.* f((iMin:iMax) - i + w + 1,(jMin:jMax)-j + w + 1);



                    // Step 10
                    // Single value in result image
                    // OutputImage(i, j) = sum(F(:).* PixelsForReplacement(:)) / sum(F(:));
                    
                }
            }
        }
    }
}
