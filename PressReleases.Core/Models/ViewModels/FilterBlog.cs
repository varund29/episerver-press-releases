using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressReleases.Core.Models.ViewModels
{
    public class FilterBlog
    {
        public int FilterbyTopics { get; set; }
        public int FilterbyAuthor { get; set; }
        public int FilterbySegments { get; set; }
    }
}
