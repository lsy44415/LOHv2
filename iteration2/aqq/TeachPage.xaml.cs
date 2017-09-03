using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace aqq
{
    public partial class TeachPage : ContentPage
    {
        CourseManager cou;
        LocalData lo;
       
        public TeachPage()
        {
            InitializeComponent();
            lo = new LocalData();
            location1.ItemsSource = lo.librarylist;
            cou = CourseManager.DefaultManager;
           
        }

        //void Handle_Clicked(object sender, System.EventArgs e)
        //{
            
        //    i++;
        //    if (i == 1)
        //        s2.IsVisible = true;
        //    if (i == 2)
        //        s3.IsVisible = true;
        //    if (i == 3)
        //        s4.IsVisible = true;
        //   // Navigation.PushAsync(new TeachPage());
        //}
         
        async void Submit_Clicked1(object sender, System.EventArgs e)
        {
            try
            {
                if (!topic1.Text.Equals(""))
                {
                    var email = Application.Current.Properties["Email"] as string;
                    var phone = Application.Current.Properties["Phone"] as string;
                    var name = Application.Current.Properties["Name"] as string;
                    var skill = Application.Current.Properties["Skill"] as string;

                    var newdate = date1.Date.Day.ToString().FormatDate() + "/" + date1.Date.Month.ToString().FormatDate() + "/" + date1.Date.Year.ToString();
                    List<Course> c1 = await cou.GetIDAsync(email,newdate,time1.Time.ToString());
                    if (c1.Count > 0)
                        await DisplayAlert("Sorry", "This date and time are in use. Please choose another one", "Ok");
                    else
                    {
                        var course = new Course
                        {


                            Topic = topic1.Text,
                            Email = email,
                            Location = location1.SelectedItem.ToString(),
                            Skill = skill,
                            Name = name,
                            Date = newdate,
                            Time = time1.Time.ToString()
                        };
                        await cou.SaveTaskAsync(course);
                        await DisplayAlert("Thanks", "Submit successful!", "OK");
                        topic1.Text = "";
                        location1.SelectedItem = "";

                    }
                }
                else
                    label1.IsVisible = true;
            }
			catch (NullReferenceException ex)
			{
				await DisplayAlert("Alert", "you need to finish the form and choose the location", "ok");
			}
        }

       async void Handle_Clicked2(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ClassListPage());
        }

  //      async void Submit_Clicked2(object sender, System.EventArgs e)
  //      {
		//	try
		//	{
		//		if (!topic2.Text.Equals(""))
		//		{
		//			var email = Application.Current.Properties["Email"] as string;
		//			var phone = Application.Current.Properties["Phone"] as string;
		//			var name = Application.Current.Properties["Name"] as string;
		//			var skill = Application.Current.Properties["Skill"] as string;

		//			var newdate = date2.Date.Day.ToString().FormatDate() + "/" + date2.Date.Month.ToString().FormatDate() + "/" + date2.Date.Year.ToString();
		//			List<Course> c1 = await cou.GetIDAsync(email, newdate, time2.Time.ToString());
  //                  if (c1.Count > 0)
  //                      await DisplayAlert("Sorry", "This date and time are in use. Please choose another one", "Ok");
  //                  else
  //                  {
  //                      var course = new Course
  //                      {


  //                          Topic = topic2.Text,
  //                          Email = email,
  //                          Location = location1.SelectedItem.ToString(),
  //                          Skill = skill,
  //                          Name = name,
  //                          Date = newdate,
  //                          Time = time2.Time.ToString()
  //                      };
  //                      await cou.SaveTaskAsync(course);
  //                  }
		//		}
		//		else
		//			label1.IsVisible = true;
		//	}
		//	catch (NullReferenceException ex)
		//	{
		//		await DisplayAlert("Alert", "you need to finish the form and choose the location", "ok");
		//	}
  //      }
		//async void Submit_Clicked3(object sender, System.EventArgs e)
		//{
		//	try
		//	{
		//		if (!topic3.Text.Equals(""))
		//		{
		//			var email = Application.Current.Properties["Email"] as string;
		//			var phone = Application.Current.Properties["Phone"] as string;
		//			var name = Application.Current.Properties["Name"] as string;
		//			var skill = Application.Current.Properties["Skill"] as string;

		//			var newdate = date3.Date.Day.ToString().FormatDate() + "/" + date3.Date.Month.ToString().FormatDate() + "/" + date3.Date.Year.ToString();
		//			List<Course> c1 = await cou.GetIDAsync(email, newdate, time3.Time.ToString());
  //                  if (c1.Count > 0)
  //                      await DisplayAlert("Sorry", "This date and time are in use. Please choose another one", "Ok");
  //                  else
  //                  {
  //                      var course = new Course
  //                      {


  //                          Topic = topic3.Text,
  //                          Email = email,
  //                          Location = location1.SelectedItem.ToString(),
  //                          Skill = skill,
  //                          Name = name,
  //                          Date = newdate,
  //                          Time = time3.Time.ToString()
  //                      };
  //                      await cou.SaveTaskAsync(course);
  //                  }
		//		}
		//		else
		//			label1.IsVisible = true;
		//	}
		//	catch (NullReferenceException ex)
		//	{
		//		await DisplayAlert("Alert", "you need to finish the form and choose the location", "ok");
		//	}
		//}
		//async void Submit_Clicked4(object sender, System.EventArgs e)
		//{
		//	try
		//	{
		//		if (!topic4.Text.Equals(""))
		//		{
		//			var email = Application.Current.Properties["Email"] as string;
		//			var phone = Application.Current.Properties["Phone"] as string;
		//			var name = Application.Current.Properties["Name"] as string;
		//			var skill = Application.Current.Properties["Skill"] as string;

		//			var newdate = date4.Date.Day.ToString().FormatDate() + "/" + date4.Date.Month.ToString().FormatDate() + "/" + date4.Date.Year.ToString();
		//			List<Course> c1 = await cou.GetIDAsync(email, newdate, time4.Time.ToString());
  //                  if (c1.Count > 0)
  //                      await DisplayAlert("Sorry", "This date and time are in use. Please choose another one", "Ok");
  //                  else
  //                  {
  //                      var course = new Course
  //                      {


  //                          Topic = topic4.Text,
  //                          Email = email,
  //                          Location = location1.SelectedItem.ToString(),
  //                          Skill = skill,
  //                          Name = name,
  //                          Date = newdate,
  //                          Time = time4.Time.ToString()
  //                      };
  //                      await cou.SaveTaskAsync(course);
  //                  }
		//		}
		//		else
		//			label1.IsVisible = true;
		//	}
		//	catch (NullReferenceException ex)
		//	{
		//		await DisplayAlert("Alert", "you need to finish the form and choose the location", "ok");
		//	}
		//}

    }
}
