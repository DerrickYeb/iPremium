using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using iPremium.Controls;
using iPremium.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(BorderlessPicker),typeof(BorderlessPickerRenderer))]
namespace iPremium.Droid.Renderers
{
    public class BorderlessPickerRenderer:PickerRenderer
    {
        public BorderlessPickerRenderer(Context context):base(context) 
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }
}