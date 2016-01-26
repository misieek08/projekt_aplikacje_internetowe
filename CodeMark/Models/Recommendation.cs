using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMark.Models
{
    public class Recommendation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}
