using System;
using System.Collections.Generic;
using FirebaseDB.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirebaseDB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentList : ContentPage
    {
        StudentRepo studentRepo = new StudentRepo();


        public StudentList()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var students = await studentRepo.GetAll();
            StudentListView.ItemsSource = students;
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

