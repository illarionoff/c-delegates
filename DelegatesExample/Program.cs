using System;

namespace DelegatesExample
{
    public class Photo
    {
        public string Name { set; get; }

        public static Photo Load(string path)
        {
            return new Photo();
        }

        public void Save()
        {
            Console.WriteLine("Save");
        }
    }

    public class Photofilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Apply Brightness");
        }

        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Apply Contrast");
        }

        public void Resize(Photo photo)
        {
            Console.WriteLine("Resize Photo");
        }
    }

    public class PhotoProcessor
    {
        //public delegate void PhotoFilterHandler(Photo photo);

        // Use generic delegates



        public void Process(string path, Action<Photo> filterHandler)
        {
            //System.Action<>
            //System.Func<>

            var photo = Photo.Load(path);
            filterHandler(photo);
            photo.Save();
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var process = new PhotoProcessor();
            var filters = new Photofilters();
            //PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += filters.Resize;
            filterHandler -= filters.Resize;
            filterHandler += RemoveRedEye;


            process.Process("photo.jpg", filterHandler);
        }

        static void RemoveRedEye(Photo photo)
        {
            Console.WriteLine("Remove red eye");
        }

    }
}