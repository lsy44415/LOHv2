using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace aqq
{
    public partial class Login : TabbedPage
    {
        PersonManager per;
       
        VolunteerManager vol;


        public Login()
        {
            InitializeComponent();
            Application.Current.Properties.Clear();
            NavigationPage.SetHasBackButton(this, false);
            per = PersonManager.DefaultManager;
           // men = MentorManager.DefaultManager;
            vol = VolunteerManager.DefaultManager;

        }
        async void Skip(object sender, System.EventArgs e)

        {
            Application.Current.Properties["skip"] = "true";
            await Navigation.PushAsync(new SkillPage());
            //Navigation.RemovePage(this);
        }
        async void Terms_click(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Terms());
        }
        


        async void Submit(object sender, System.EventArgs e)
        {
            try
            {
                if (email.Text.isEmail())
                {
                    label1.IsVisible = false;
                    if (phone.Text.IsPhone())
                    {
                        label2.IsVisible = false;

                        if (picker.SelectedItem.ToString().Equals("Mentor"))
                        {
                            List<Volunteer> v1 = await vol.GetIDAsync(email.Text);
                            if (v1.Count > 0)
                            {
                                if (!v1[0].Phone.Equals(phone.Text))
                                {
                                    await DisplayAlert("Sorry", " This email is in use please enter another one.", "Ok");
                                }
                                else
                                {
                                    List<Volunteer> v2 = await vol.GetbyPhoneAsync(phone.Text, email.Text);
                                    if (v2.Count > 0)
                                    {
                                        await DisplayAlert("Sorry", " This phone number is in use please enter another one.", "Ok");
                                    }
                                    else
                                    {
                                        Application.Current.Properties["skip"] = "false";
                                        Application.Current.Properties["Status"] = picker.SelectedItem.ToString();
                                        Application.Current.Properties["Email"] = email.Text;
                                        Application.Current.Properties["Phone"] = phone.Text;

                                        await Navigation.PushAsync(new HomePage());
                                        Navigation.RemovePage(this);
                                    }
                                }

                            }
                            else
                            {
                                List<Volunteer> v2 = await vol.GetbyPhoneAsync(phone.Text, email.Text);
                                if (v2.Count > 0)
                                {
                                    await DisplayAlert("Sorry", " This phone number is in use please enter another one.", "Ok");
                                }
                                else
                                {
                                    var people = new Volunteer
                                    {
                                        Status = "Mentor",
                                        Email = email.Text,
                                        Phone = phone.Text,
                                        Name = "",
                                        Postcode="",
                                        Skill=""
                                    };


                                    await vol.SaveTaskAsync(people);
                                    Application.Current.Properties["skip"] = "false";
                                    Application.Current.Properties["Status"] = picker.SelectedItem.ToString();
                                    Application.Current.Properties["Email"] = email.Text;
                                    Application.Current.Properties["Phone"] = phone.Text;
                                    await Navigation.PushAsync(new HomePage());
                                    Navigation.RemovePage(this);
                                }
                            }
                        }
                        if (picker.SelectedItem.ToString().Equals("Volunteer"))
                        {
                            List<Volunteer> v1 = await vol.GetIDAsync(email.Text);
                            if (v1.Count > 0)
                            {
                                if (!v1[0].Phone.Equals(phone.Text))
                                {
                                    await DisplayAlert("Sorry", " This email is in use please enter another one.", "Ok");
                                }
                                else
                                {
                                    List<Volunteer> v2 = await vol.GetbyPhoneAsync(phone.Text, email.Text);
                                    if (v2.Count > 0)
                                    {
                                        await DisplayAlert("Sorry", " This phone number is in use please enter another one.", "Ok");
                                    }
                                    else
                                    {
                                        Application.Current.Properties["skip"] = "false";
                                        Application.Current.Properties["Status"] = picker.SelectedItem.ToString();
                                        Application.Current.Properties["Email"] = email.Text;
                                        Application.Current.Properties["Phone"] = phone.Text;
                                        await Navigation.PushAsync(new HomePage());
                                        Navigation.RemovePage(this);
                                    }
                                }
                            }
                            else
                            {
                                List<Volunteer> v2 = await vol.GetbyPhoneAsync(phone.Text, email.Text);
                                if (v2.Count > 0)
                                {
                                    await DisplayAlert("Sorry", " This phone number is in use please enter another one.", "Ok");
                                }
                                else
                                {
                                    var people = new Volunteer
                                    {
                                        Status = "Volunteer",
                                        Email = email.Text,
                                        Phone = phone.Text,
										Name = "",
										Postcode = "",
										Skill = ""
                                    };

                                    await vol.SaveTaskAsync(people);
                                    Application.Current.Properties["skip"] = "false";
                                    Application.Current.Properties["Status"] = picker.SelectedItem.ToString();
                                    Application.Current.Properties["Email"] = email.Text;
                                    Application.Current.Properties["Phone"] = phone.Text;
                                    await Navigation.PushAsync(new HomePage());
                                    Navigation.RemovePage(this);
                                }
                            }
                        }
                        if (picker.SelectedItem.ToString().Equals("Learner"))
                        {
                            List<Learner> l1 = await per.GetIDAsync(email.Text);
                            if (l1.Count > 0)
                            {
                                if (!l1[0].Phone.Equals(phone.Text))
                                {
                                    await DisplayAlert("Sorry", " This email is in use please enter another one.", "Ok");
                                }
                                else
                                {
                                    List<Learner> l2 = await per.GetbyPhoneAsync(phone.Text, email.Text);
                                    if (l2.Count > 0)
                                    {
                                        await DisplayAlert("Sorry", " This phone number is in use please enter another one.", "Ok");
                                    }
                                    else
                                    {
                                        Application.Current.Properties["skip"] = "false";
                                        Application.Current.Properties["Status"] = picker.SelectedItem.ToString();
                                        Application.Current.Properties["Email"] = email.Text;
                                        Application.Current.Properties["Phone"] = phone.Text;
                                        await Navigation.PushAsync(new HomePage());
                                        Navigation.RemovePage(this);
                                    }
                                }
                            }
                            else
                            {

                                List<Learner> l2 = await per.GetbyPhoneAsync(phone.Text, email.Text);
                                if (l2.Count > 0)
                                {
                                    await DisplayAlert("Sorry", " This phone number is in use please enter another one.", "Ok");
                                }
                                else
                                {
                                    var people = new Learner
                                    {
                                        Status = "Learner",
                                        Email = email.Text,
                                        Phone = phone.Text,
										Name = "",
										Postcode = "",
										Skill = ""
                                    };

                                    await per.SaveTaskAsync(people);
                                    Application.Current.Properties["skip"] = "false";
                                    Application.Current.Properties["Status"] = picker.SelectedItem.ToString();
                                    Application.Current.Properties["Email"] = email.Text;
                                    Application.Current.Properties["Phone"] = phone.Text;
                                    await Navigation.PushAsync(new HomePage());
                                    Navigation.RemovePage(this);
                                }
                            }

                        }
                    }
                    else
                        label2.IsVisible = true;
                }

                else
                    label1.IsVisible = true;
            }
            catch(NullReferenceException ex){
                await DisplayAlert("Alert", "you need to choose status and finish the form", "ok");  
            }
        }
    }
}