using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace aqq
{
    public partial class learnerClassList : ContentPage
    {

		CourseManager cou;
        EnrolManager en;
        public learnerClassList()
        {
            InitializeComponent();
            cou = CourseManager.DefaultManager;
            en = EnrolManager.DefaultManager;
        }


		protected override async void OnAppearing()
		{
			base.OnAppearing();
			var email = Application.Current.Properties["Email"] as string;
			var skill = Application.Current.Properties["Skill"] as string;
			var status = Application.Current.Properties["Status"] as string;
			
				listview1.ItemsSource = await cou.GetSkillClassAsync(skill);
		}

		async void Enrol_Clicked(object sender, System.EventArgs e)
		{
			var menuItem = sender as MenuItem;
			var course = menuItem.CommandParameter as Course;
			var co1 = await cou.GetIDAsync(course.Email, course.Date, course.Time);
            var email = Application.Current.Properties["Email"] as string;
            var name = Application.Current.Properties["Name"] as string;
			var phone = Application.Current.Properties["Phone"] as string;
			Application.Current.Properties["classid"] = co1[0].Id;
			var id = Application.Current.Properties["classid"] as string;

			List<Enrol> enrol1 = await en.TestbyIDAsync(email,id);
            if (enrol1.Count > 0)
            {
                await DisplayAlert("Alert", "You have already enrolled this course!", "ok");
            }
            else
            {

                var enrol = new Enrol
                {
                    Teacher = co1[0].Name,
                    Location = co1[0].Location,
                    Date = co1[0].Date,
                    Time = co1[0].Time,
                    Topic = co1[0].Topic,
                    Email1 = email,
                    Email2 = co1[0].Email,
                    Learner = name,
                    Phone = phone,
                    Courseid = id
                };
                await en.SaveTaskAsync(enrol);
                await DisplayAlert("Notice", "Enrolled successful!", "ok");
            }
        }


        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            listview2.IsVisible = true;
            listview1.IsVisible = false;
			var email = Application.Current.Properties["Email"] as string;
            listview2.ItemsSource = await en.GetEmailClassAsync(email);
        }

        void Handle_Clicked2(object sender, System.EventArgs e)
        {
            listview1.IsVisible = true;
            listview2.IsVisible = false;
        }
    }
}

