using System;
using System.Collections.Generic;
using FirebaseDB.Model;
using Xamarin.Forms;

namespace FirebaseDB.Views
{
    public partial class StudentEntry : ContentPage
    {
        StudentRepo repository = new StudentRepo();
        public StudentEntry()
        {
            InitializeComponent();
        }
        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            string Lname = txtLName.Text;
            string Fname = txtFName.Text;
            string Email = txtEmail.Text;
            string Phone = txtPhone.Text;
            if (String.IsNullOrEmpty(Lname))
            {
                await DisplayAlert("Required", "Enter last name", "Cancel");
            }
            if (String.IsNullOrEmpty(Fname))
            {
                await DisplayAlert("Required", "Enter first name", "Cancel");
            }
            if (String.IsNullOrEmpty(Email))
            {
                await DisplayAlert("Required", "Enter email", "Cancel");
            }
            if (String.IsNullOrEmpty(Phone))
            {
                await DisplayAlert("Required", "Enter phone", "Cancel");
            }
            Student student = new Student();
            student.LastName = Lname;
            student.FirstName = Fname;
            student.Email = Email;
            student.Phone = Phone;

            var isSaved = await repository.Save(student);
            if (isSaved)
            {
                await DisplayAlert("Success", "Saved", "Cancel");
            }
            else
            {
                await DisplayAlert("Failed", "Did not save", "Cancel");
            }
            ClearStudent();
        }
        private void ClearStudent()
        {  
            txtLName.Text = String.Empty;
            txtFName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtPhone.Text = String.Empty;
        }

        private void AddToolBarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StudentEntry());
        }
        private void EditToolBarItem_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushModalAsync(new StudentEntry());
        }
        private void DeleteToolBarItem_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushModalAsync(new StudentEntry());
        }
    }
}