using System;
using System.Windows;
using System.Windows.Media.Animation;
using Microsoft.Phone.Controls;
using WP7.Calculator.ViewModel;

namespace WP7.Calculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly MainViewModel _mainViewModel;
        PageOrientation _lastOrientation;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            var locator = new ViewModelLocator();
            _mainViewModel = locator.Main;
            DataContext = _mainViewModel;

            OrientationChanged += MainPageOrientationChanged;
            _lastOrientation = Orientation;

            UpdateOrientation();
        }

        void MainPageOrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            //var newOrientation = e.Orientation;

            //var transitionElement = new RotateTransition();

            //switch (newOrientation)
            //{
            //    case PageOrientation.Landscape:
            //    case PageOrientation.LandscapeRight:
            //        transitionElement.Mode = _lastOrientation == PageOrientation.PortraitUp ? RotateTransitionMode.In90Counterclockwise : RotateTransitionMode.In180Clockwise;
            //        break;
            //    case PageOrientation.LandscapeLeft:
            //        transitionElement.Mode = _lastOrientation == PageOrientation.LandscapeRight ? RotateTransitionMode.In180Counterclockwise : RotateTransitionMode.In90Clockwise;
            //        break;
            //    case PageOrientation.Portrait:
            //    case PageOrientation.PortraitUp:
            //        transitionElement.Mode = _lastOrientation == PageOrientation.LandscapeLeft ? RotateTransitionMode.In90Counterclockwise : RotateTransitionMode.In90Clockwise;
            //        break;
            //    default:
            //        break;
            //}

            //var phoneApplicationPage = (PhoneApplicationPage)(((PhoneApplicationFrame)Application.Current.RootVisual)).Content;
            //var transition = transitionElement.GetTransition(phoneApplicationPage);
            //transition.Completed += delegate
            //{
            //    transition.Stop();
            //    UpdateOrientation();
            //};
            //transition.Begin();

            //_lastOrientation = newOrientation;
        }

        private void UpdateOrientation()
        {
            var land = false;
            switch (Orientation)
            {
                case PageOrientation.Landscape:
                case PageOrientation.LandscapeLeft:
                case PageOrientation.LandscapeRight:
                    land = true;
                    break;
            }

            verGridPage1.Visibility = land ? Visibility.Collapsed : Visibility.Visible;
            horGridPage1.Visibility = !land ? Visibility.Collapsed : Visibility.Visible;

            verGridPage2.Visibility = land ? Visibility.Collapsed : Visibility.Visible;
            horGridPage2.Visibility = !land ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}