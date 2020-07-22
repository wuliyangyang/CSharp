using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.EF.Core.Interface;
using YY.EF.Core.Model;

namespace YY.EF.Core.Service
{
    public class ImageService:BaseService,IImageService
    {
        public ImageService(DbContext context) : base(context)
        {
        }
    }
}
