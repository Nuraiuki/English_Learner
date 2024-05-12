using CommunityToolkit.Maui.Core.Primitives;
using System;
using System.ComponentModel;
using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.Logging;
using LayoutAlignment = Microsoft.Maui.Primitives.LayoutAlignment;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Core;

namespace english
{
    public partial class VideoPage : ContentPage
    {
        public VideoPage()
        {
            InitializeComponent();
        }


        private void OnVolumeMinusClicked(object sender, EventArgs e)
        {
            if (mediaElement.Volume >= 0)
            {
                if (mediaElement.Volume < .1)
                {
                    mediaElement.Volume = 0;
                    return;
                }
                mediaElement.Volume -= .1;
            }
        }

        private void OnVolumePlusClicked(object sender, EventArgs e)
        {
            if (mediaElement.Volume <= 0.9)
            {
                mediaElement.Volume += 0.1;
            }
        }

        private void OnSpeedPlusClicked(object sender, EventArgs e)
        {
            if (mediaElement.Speed < 10)
            {
                mediaElement.Speed += 1;
            }
        }

        private void OnSpeedMinusClicked(object sender, EventArgs e)
        {
            if (mediaElement.Speed > 0)
            {
                mediaElement.Speed -= 1;
            }
        }

        private void OnVolumeSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            mediaElement.Volume = e.NewValue;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            if (mediaElement.CurrentState == MediaElementState.Playing)
                mediaElement.Pause();
            else if (mediaElement.CurrentState == MediaElementState.Paused)
                mediaElement.Play();
        }



    }
}