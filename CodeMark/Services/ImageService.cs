using CodeMark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CodeMark.Services
{
    public interface IImageService
    {
        bool SaveImage(HttpPostedFileBase file);
        List<Image> GetImagesList();
        byte[] GetImageContent(int imageId);
    }
    public class ImageService : IImageService
    {
        private CodeMarkContext db = new CodeMarkContext();

        public byte[] GetImageContent(int imageId)
        {
            Image image = db.Images.Find(imageId);
            return image.Content;
        }

        public List<Image> GetImagesList()
        {
            var result = new List<Image>();
            var images = db.Images;
            if (images != null && images.Any())
            {
                result = db.Images.ToList().Select(x => new Image() { Id = x.Id, FileName = x.FileName }).ToList();
            }
            return result;
        }

        public bool SaveImage(HttpPostedFileBase file)
        {
            var images = db.Images;
            var image = new Image(file.FileName, file.InputStream);
            db.Images.Add(image);
            db.SaveChanges();
            return true;
        }
    }
}
