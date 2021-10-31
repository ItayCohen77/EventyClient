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
using EventyApp.Droid.Renderer;
using EventyApp.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedDatePicker), typeof(ExtendedDatePickerRenderer))]
namespace EventyApp.Droid.Renderer
{
    public class ExtendedDatePickerRenderer : DatePickerRenderer
    {

        public ExtendedDatePickerRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Text = "Select Birthdate";
                this.Control.SetBackground(null);
                //this.Control.CurrentTextColor
            }
        }
    }
}