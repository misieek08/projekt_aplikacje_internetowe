using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMark.Models
{
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        public string FileName { get; set; }
        public byte[] Content { get; set; }

        public Image()
        {
        }

        public Image(string fileName, Stream inputStream)
        {
            FileName = fileName;
            if (inputStream != null && inputStream.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    inputStream.CopyTo(memoryStream);
                    Content = memoryStream.ToArray();
                }
            }
        }

    }
}
