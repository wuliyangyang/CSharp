using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;


namespace YY.Framework
{
    public class ImageHelper
    {
        public static byte[] ImageToBinary(string file)
        {
            byte[] imageData = null;

            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        imageData = br.ReadBytes(Convert.ToInt32(fs.Length));
                        return imageData;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return imageData;
            }
        }

        public static Image BinaryToImage(byte[] ImageBytes)
        {
            try
            {
                MemoryStream stream = new MemoryStream(ImageBytes);
                return Image.FromStream(stream);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
