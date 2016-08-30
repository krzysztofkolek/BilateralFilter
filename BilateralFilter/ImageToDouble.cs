namespace BilateralFilter
{
    using System.Drawing; 

    public class ImageToDouble
    {
        public double[,] LoadImage(string path)
        {
            Bitmap image = new Bitmap(path);
            int y = ((Image)image).Size.Height,
                x = ((Image)image).Size.Width;
            double[,] result = new double[y, x];

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    var pixel = image.GetPixel(j, i);

                    //
                    result[y, x] = 0;
                }
            }

            return result;
        }
    }
}
