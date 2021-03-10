using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Models;

namespace HiveData.ViewModels
{
    public class DisplayImagesViewModel
    {
        public Image Image { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}
