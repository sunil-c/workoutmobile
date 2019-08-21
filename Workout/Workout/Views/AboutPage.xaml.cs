using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Workout.Views
{
    [ContentProperty (nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
     public string Source { get; set; }
     public object ProvideValue (IServiceProvider serviceProvider)
     {
       if (Source == null)
       {
         return null;
       }

       // Do your translation lookup here, using whatever method you require
       var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);

       return imageSource;
     }
    }

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            //var embeddedImage = new Image { Source = ImageSource.FromResource("Workout.Assets.abs_action_athlete_2294363.jpg", typeof(ImageResourceExtension).GetTypeInfo().Assembly) };
            //image1.Source = embeddedImage.Source;

            // ...
            // NOTE: use for debugging, not in released app code!
            //var assembly = typeof(ImageResourceExtension).GetTypeInfo().Assembly;
            //foreach (var res in assembly.GetManifestResourceNames())
            //{
            //    System.Diagnostics.Debug.WriteLine("**** found resource ****: " + res);
            //}

            InitializeComponent();
        }
    }
}