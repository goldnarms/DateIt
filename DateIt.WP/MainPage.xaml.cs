using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DateIt.WP.Resources;
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

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            InitAppBar();
            //Create new instance of CameraCaptureClass
            _ctask = new CameraCaptureTask();

            //Create new event handler for capturing a photo
            _ctask.Completed += new EventHandler<PhotoResult>(ctask_Completed);
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void InitAppBar()
        {
            var appBar = new ApplicationBar();
            _cameraButton = new ApplicationBarIconButton(new Uri("Assets/appbar.feature.camera.rest.png", UriKind.Relative));
            _cameraButton.Click += CameraButton_Click;
            _cameraButton.Text = "Capture";
            appBar.Buttons.Add(_cameraButton);
            ApplicationBar = appBar;
        }

        private void CameraButton_Click(object sender, EventArgs e)
        {
            _ctask.Show();

            //Set progress bar to visible to show time between user snapshot and decoding
            //of image into a writeable bitmap object.
            progressBar1.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Event handler for retrieving the JPEG photo stream.
        /// Also to for decoding JPEG stream into a writeable bitmap and displaying.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ctask_Completed(object sender, PhotoResult e)
        {

            if (e.TaskResult == TaskResult.OK && e.ChosenPhoto != null)
            {

                //Take JPEG stream and decode into a WriteableBitmap object
                App.CapturedImage = PictureDecoder.DecodeJpeg(e.ChosenPhoto);

                //Collapse visibility on the progress bar once writeable bitmap is visible.
                progressBar1.Visibility = Visibility.Collapsed;


                //Populate image control with WriteableBitmap object.
                //MainImage.Source = App.CapturedImage;

                //Once writeable bitmap has been rendered, the crop button
                //is enabled.
                //btnCrop.IsEnabled = true;

                //textStatus.Text = "Tap the crop button to proceed";
            }
            else
            {
                //textStatus.Text = "You decided not to take a picture.";
            }
        }
    }
}