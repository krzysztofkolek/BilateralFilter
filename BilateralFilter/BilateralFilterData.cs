namespace BilateralFilter
{
    public class BilateralFilterData
    {
        public double[,] InputImage { get; set; }
        public string PathWithFileName { get; set; }
        public int SizeOfMask { get; set; }
        public int SigmaD { get; set; }
        public double SigmaR { get; set; }
    }
}
