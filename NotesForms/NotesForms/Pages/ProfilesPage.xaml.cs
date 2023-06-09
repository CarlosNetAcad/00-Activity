﻿using System;
using System.Collections.Generic;
using NotesForms.Services;
using NotesForms.ViewModels;
using Xamarin.Forms;

namespace NotesForms.Pages
{	
	public partial class ProfilesPage : ContentPage
	{	
		public ProfilesPage ()
		{
			InitializeComponent ();

			var app = App.Current as App;

            var phoneDialer = DependencyService.Resolve<IPhoneDialer>();
            var sMS         = DependencyService.Resolve<ISMS>();
            var eMail       = DependencyService.Resolve<IEmail>();
            var textToSpeech= DependencyService.Resolve<ITextToSpeech>();

            var authService = DependencyService.Resolve<IAuthService>();
            var userService = DependencyService.Resolve<IUserService>();

            BindingContext  = new ProfileViewModel(
                phoneDialer,
                sMS,
                eMail,
                textToSpeech,
                authService,
                userService
            );
            //lblProfile.Text = $"Welcome {app.GetUsername()}";
		}

        void OnBack(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();

        }
    }
}

