using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YY.EF.Core.Interface;
using YY.EF.Core.Service;
using YY.EF.Core.Model;

namespace YY.NetCore.WebApi.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class ImageUrlController : ControllerBase
    {
        private readonly ILogger<ImageUrlController> _logger;
        private readonly IImageService _imageService;
        public ImageUrlController(ILogger<ImageUrlController> logger, IImageService imageService)
        {
            _logger = logger;
            _imageService = imageService;
        }

        [HttpGet]
        [Route("api/imageurl/GetUrl/")]//restful风格
        public IQueryable<QuanTuWang> GetUrl()
        {
            int index = new Random().Next(100, 1000);
            ImageTitle imageTitle = _imageService.Find<ImageTitle>(index);
            _logger.LogInformation(imageTitle.ImageTitle1);
            if (imageTitle != null)
            {
                var ret = _imageService.Query<QuanTuWang>(c => c.Name.Equals(imageTitle.ImageTitle1));
                return ret;
            }
            return null;
        }

        [HttpGet]
        [Route("api/imageurl/GetUrl/Id/{id:int}")]//restful风格
        public IQueryable<QuanTuWang> GetUrl(int? id)
        {
            int index = id ??100;
            ImageTitle imageTitle = _imageService.Find<ImageTitle>(index);
            _logger.LogInformation(imageTitle.ImageTitle1);
            if (imageTitle!=null)
            {
                var ret = _imageService.Query<QuanTuWang>(c => c.Name.Equals(imageTitle.ImageTitle1));
                return ret;
            }
            return null;
        }

        [HttpGet]
        [Route("api/imageurl/GetUrl/Name/{name}")]
        public IQueryable<QuanTuWang> GetUrl(string name)
        {
            var ret = _imageService.Query<QuanTuWang>(c => c.Name.Equals(name));
            return ret;
        }
    }
}