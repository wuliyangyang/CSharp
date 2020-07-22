using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.EF.Interface;
using YY.EF.Models;

namespace YY.EF.Service
{
    public class ImageService:BaseService,IImageService
    {
        public ImageService(DbContext context) : base(context)
        {
        }
    }
}
