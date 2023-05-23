using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
    public partial class Product
    {
        public string FullInfo
        {
            get
            {

                return Name + " " + Price;
            }
        }
        public byte[] MainPhoto
        {
            get
            {
                var firstphoto = this.ProductPhoto.FirstOrDefault();
                if (firstphoto != null)
                    return firstphoto.Photo;
                return null;
            }
        }
    }
}
