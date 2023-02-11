using EPiServer.VisitorGroupsCriteriaPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressReleases.Core.Models.ViewModels
{
    public class Pagination
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }

        public int SelectedPage { get; set; }
    }
}
