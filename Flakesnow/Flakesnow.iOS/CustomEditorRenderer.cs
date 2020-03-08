using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Flakesnow;
using Flakesnow.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace Flakesnow.iOS
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {

            base.OnElementChanged(e);
            if (Control != null)
            {
                //Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}
