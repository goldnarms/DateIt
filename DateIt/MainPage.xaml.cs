using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace DateIt.WP
{
    public partial class MainPage : PhoneApplicationPage
    {
        private ApplicationBarIconButton _cameraButton;
        CameraCaptureTask _ctask;
        public MainPage()
        {
            InitializeComponent();
        }
        private void InitAppBar()
        {
            var appBar = new ApplicationBar();
            _cameraButton = new ApplicationBarIconButton(new Uri("Assets/appbar.feature.camera.rest.png", UriKind.Relative));
            _cameraButton.Click += CameraButton_Click;
            _cameraButton.Text = "Capture";
            appBar.Buttons.Add(_cameraButton);

        }

        private void CameraButton_Click(object sender, EventArgs e)
        {
            _ctask.Show();

            //Set progress bar to visible to show time between user snapshot and decoding
            //of image into a writeable bitmap object.
            //progressBar1.Visibility = Visibility.Visible;
        }
    }
}