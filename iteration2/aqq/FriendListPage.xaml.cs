using System;
using System.Collections.Generic;
using Plugin.Messaging;
using Xamarin.Forms;

namespace aqq
{
    public partial class FriendListPage : ContentPage
    {
        FriendManager fri;
        EnrolManager en;
        public FriendListPage()
        {
            InitializeComponent();
            fri = FriendManager.DefaultManager;
            en = EnrolManager.DefaultManager;
        }
		
		

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			var status = Application.Current.Properties["Status"] as string;
            var email = Application.Current.Properties["Email"] as string;
            if (status.Equals("Learner"))
            {
                listview.IsVisible = true;
                listview2.IsVisible = false;
                listview.ItemsSource = await fri.GetPeersAsync(email);
				tip.Text = "Choose a contact and swift left to sms or email your peer.";
            }
            else
            {
				listview2.IsVisible = true;
				listview.IsVisible = false;
                listview2.ItemsSource = await en.GetTeacherEmailClassAsync(email);
                tip.Text = "Choose a contact and swift left to sms or email users who enrolled your course.";
            }
		}

		async void Email_Clicked(object sender, System.EventArgs e)
		{
			var senderEmail = Application.Current.Properties["Email"] as string;
			listview.ItemsSource = await fri.GetPeersAsync(senderEmail);
			var menuItem = sender as MenuItem;
			var course = menuItem.CommandParameter as Friend;

			

			string receiver = course.Email2;
			var emailMessenger = CrossMessaging.Current.EmailMessenger;
			if (emailMessenger.CanSendEmail)
			{
				emailMessenger.SendEmail(receiver);

			}


		}
		async void Phone_Clicked(object sender, System.EventArgs e)
		{
			var smsMessenger = CrossMessaging.Current.SmsMessenger;

			var senderPhone = Application.Current.Properties["Phone"] as string;
			var senderEmail = Application.Current.Properties["Email"] as string;

			listview.ItemsSource = await fri.GetPeersAsync(senderPhone);

			var menuItem = sender as MenuItem;
			var course = menuItem.CommandParameter as Friend;

			

			string receiverPhone = course.Phone2;

			if (smsMessenger.CanSendSms)

				smsMessenger.SendSms(receiverPhone);
		}

		async void Email_Clicked2(object sender, System.EventArgs e)
		{
			var senderEmail = Application.Current.Properties["Email"] as string;
			listview.ItemsSource = await fri.GetPeersAsync(senderEmail);

			var menuItem = sender as MenuItem;
			var course = menuItem.CommandParameter as Enrol;
            string receiver = course.Email1;
			var emailMessenger = CrossMessaging.Current.EmailMessenger;
			if (emailMessenger.CanSendEmail)
			{
				emailMessenger.SendEmail(receiver);

			}

		}

		async void Phone_Clicked2(object sender, System.EventArgs e)
		{
			var smsMessenger = CrossMessaging.Current.SmsMessenger;

			var senderPhone = Application.Current.Properties["Phone"] as string;
			var senderEmail = Application.Current.Properties["Email"] as string;

			listview.ItemsSource = await fri.GetPeersAsync(senderPhone);

			var menuItem = sender as MenuItem;
			var course = menuItem.CommandParameter as Enrol;


			string receiverPhone = course.Phone;

			if (smsMessenger.CanSendSms)

				smsMessenger.SendSms(receiverPhone);
		}


	}
    }
