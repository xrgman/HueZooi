using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HueDesign.Room
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RoomPage : Page
    {
        Point scrollMousePoint = new Point();
        double hOff = 1;
        double vOff = 1;
        bool isActive = false;

        public RoomPage()
        {
            this.InitializeComponent();
        }

        private void ScrollViewer_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            scrollViewer.CapturePointer(e.Pointer);
            scrollMousePoint = e.GetCurrentPoint(scrollViewer).Position;
            hOff = scrollViewer.HorizontalOffset;
            vOff = scrollViewer.VerticalOffset;

            isActive = true;
        }

        private void ScrollViewer_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (isActive)
                scrollViewer.ChangeView(hOff + (scrollMousePoint.X - e.GetCurrentPoint(scrollViewer).Position.X), vOff + (scrollMousePoint.Y - e.GetCurrentPoint(scrollViewer).Position.Y), scrollViewer.ZoomFactor);
        }

        private void ScrollViewer_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            scrollViewer.ReleasePointerCaptures();
            isActive = false;
        }
    }
}
