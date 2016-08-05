using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ImagesServer.Data;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ImagesServer.Controllers
{
    public class ImagesController : Controller
    {
        private ImagesContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public ImagesController(ImagesContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("api/Images")]
     //   [Produces("multipart/form-data")]
        public IActionResult Get()
        {
            List<byte[]> images = new List<byte[]>();
            List<Images> dbImages = _context.Images.ToList();
            MultipartResult result = new MultipartResult();
            foreach (var item in dbImages)
            {
                var stream = OpenFile(item.path);
                result.Add(new MultipartContent() { ContentType = "image/png", Stream = stream, FileName = item.path });
            }
            return result;
        }


        //public IActionResult Get()
        //{
        //    List<byte[]> images = new List<byte[]>();
        //    List<Images> dbImages = _context.Images.ToList();

        //    return new MultipartResult()
        //    {
        //        dbImages.ForEach(dbImage =>
        //        {
        //            new MultipartContent()
        //            {
        //                ContentType = "image/png",
        //                Stream = OpenFile(dbImage.path)
        //            }
        //        });
        //    }
        //}



        private Stream OpenFile(string relativePath)
        {
               return System.IO.File.Open(
               Path.Combine(this.hostingEnvironment.WebRootPath, relativePath),
               FileMode.Open,
               FileAccess.Read);          
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //
        //    return "value";
        //}

        // POST api/values
        [HttpPost("api/Images")]
        public void Post()
        {
            byte[] newImageBytes = new byte[Request.ContentLength.GetValueOrDefault()];
            Request.Body.Read(newImageBytes, 0, (int)Request.ContentLength.GetValueOrDefault());

            string imageName = Guid.NewGuid().ToString();
            string imagePath = @"D:\ImagesStorage\" + imageName + ".bin";

            FileStream imageStream = new FileStream(imagePath, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(imageStream);

            writer.Write(newImageBytes);

            writer.Dispose();
            imageStream.Dispose();

            Images dbImage = new Images();
            dbImage.path = imagePath;

            _context.Images.Add(dbImage);
            _context.SaveChanges();
        }
    }
}
