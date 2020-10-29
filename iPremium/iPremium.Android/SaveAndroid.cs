using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using iPremium.Droid;
using iPremium.Interfaces;
using Java.IO;
using Xamarin.Forms;


[assembly: Dependency(typeof(SaveAndroid))]
namespace iPremium.Droid
{

    public class SaveAndroid : ISave
    {
        public async Task SaveAndView(string fileName, string contentType, MemoryStream stream)
        {
            string root = null;
            //Get the root path in android device.
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            //Create directory and file 
            Java.IO.File myDir = new Java.IO.File(root + "/iPrime");
            myDir.Mkdir();

            Java.IO.File file = new Java.IO.File(myDir, fileName);

            //Remove if the file exists
            if (file.Exists()) file.Delete();

            //Write the stream into the file
            FileOutputStream outs = new FileOutputStream(file);
            outs.Write(stream.ToArray());

            outs.Flush();
            outs.Close();

            //Invoke the created file for viewing
            if (file.Exists())
            {
                Android.Net.Uri path = Android.Net.Uri.FromFile(file);
                string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                Intent intent = new Intent(Intent.ActionView);
                intent.SetDataAndType(path, mimeType);
                Android.App.Application.Context.StartActivity(Intent.CreateChooser(intent, "Choose App"));
            }
        }
    }
}