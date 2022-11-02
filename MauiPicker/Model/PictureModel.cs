using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPicker.Model
{
    public class PictureModel
    {
        public PictureObject PictureObject { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public ImageSource PictureUrl { get; set; }

    }

    public enum PictureObject
    {
        Person,
        Location,
        Object
    }
}
