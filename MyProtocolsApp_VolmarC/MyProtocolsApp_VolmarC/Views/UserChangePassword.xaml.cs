using MyProtocolsApp_VolmarC.ViewModels;
using MyProtocolsApp_VolmarC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Xml.Linq;

namespace MyProtocolsApp_VolmarC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserChangePassword : ContentPage
    {
        UserViewModel viewModel;
        public UserChangePassword()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {


            if (ValidateFields() && ValidatePasswords())
            {

                try
                {
                    GlobalObjects.MyLocalUser.Contrasennia = TxtnewPassword2.Text.Trim();

                    var answer = await DisplayAlert("???", "Are you sure to continue updating user password?", "Yes", "No");

                    if (answer)
                    {
                        bool R = await viewModel.UpdateUser(GlobalObjects.MyLocalUser);

                        if (R)
                        {
                            await DisplayAlert(":)", "Password Updated!!!", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert(":(", "Something went wrong...", "OK");
                            await Navigation.PopAsync();
                        }

                    }

                }
                catch (Exception) 
                { 
               
                    throw;
                }



            } 
        }

        private bool ValidateFields()
        {
            bool R = false;
            if (TxtOldPassword.Text != null && !string.IsNullOrEmpty(TxtOldPassword.Text.Trim()) &&
                TxtNewPassword.Text != null && !string.IsNullOrEmpty(TxtNewPassword.Text.Trim()) &&
                TxtnewPassword2.Text != null && !string.IsNullOrEmpty(TxtnewPassword2.Text.Trim()))
            {
                R = true;
            }
            else
            {
                if (TxtOldPassword.Text == null || string.IsNullOrEmpty(TxtOldPassword.Text.Trim()))
                {
                    DisplayAlert("Validation Failed!", "The old password is required", "OK");
                    TxtOldPassword.Focus();
                    return false;
                }

                if (TxtNewPassword.Text == null || string.IsNullOrEmpty(TxtNewPassword.Text.Trim()))
                {
                    DisplayAlert("Validation Failed!", "The new password is required", "OK");
                    TxtNewPassword.Focus();
                    return false;
                }

                if (TxtnewPassword2.Text == null || string.IsNullOrEmpty(TxtnewPassword2.Text.Trim()))
                {
                    DisplayAlert("Validation Failed!", "Confirm the password is required", "OK");
                    TxtnewPassword2.Focus();
                    return false;
                }


            } return R;

        }

            private bool ValidatePasswords() { 
            {
                bool R = false;

                if (TxtOldPassword.Text == GlobalObjects.MyLocalUser.Contrasennia &&
                    TxtNewPassword.Text == TxtnewPassword2.Text)
                {
                    R = true;
                }
               
                if (TxtOldPassword.Text != GlobalObjects.MyLocalUser.Contrasennia)
                {
                    DisplayAlert("Validation Failed!", "The old password is not the same one, plaese try again", "OK");
                    TxtOldPassword.Focus();
                    return false;
                }

                if (TxtNewPassword.Text != TxtnewPassword2.Text)
                {
                    DisplayAlert("Validation Failed!", "The both password must be identical required", "OK");
                    TxtNewPassword.Focus();
                    return false;
                }


                if (TxtNewPassword.Text == null || string.IsNullOrEmpty(TxtNewPassword.Text.Trim()))
                {
                    DisplayAlert("Validation Failed!", "The new password is required", "OK");
                    TxtNewPassword.Focus();
                    return false;
                }


                return R;
            } 

            
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserManagmentPage());

        }

        private void BtnShow_Clicked(object sender, EventArgs e)
        {

            TxtNewPassword.IsPassword = !TxtNewPassword.IsPassword;
            TxtnewPassword2.IsPassword = !TxtnewPassword2.IsPassword;
         
        }
    }
}
  