using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Workout.ViewModels;
using System.Diagnostics;

namespace Workout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseListPage: ContentPage
    {
        ExerciseListViewModel viewModel;

        //these two are used to track the currently edited record
        private string action;
        private int selectedId;

        public ExerciseListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ExerciseListViewModel();
        }

        //public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    selectedId = (e.SelectedItem as Workout.Models.ExerciseListItem).Id;
        //}

        async void Delete_Clicked(object sender, EventArgs e)
        {
            int param = int.Parse(((sender as Button).CommandParameter).ToString());
            MessagingCenter.Send(this, "DeleteExercise", viewModel.ListOfExercises.FirstOrDefault(s => s.Id == param));
            action = "";
            selectedId = -1;
        }

        //async void Edit_Clicked(object sender, EventArgs e)
        //{
        //    /*
        //     * This event exists to capture the item id for the row being edited
        //     * The loop through the controls has a dependency on the controls being in a grid
        //     */

        //     //we're binding the record id to the command parameter prop
        //    selectedId = int.Parse(((sender as Button).CommandParameter).ToString());
        //    action = action != "ADD" ? "UPDATE" : action;

        //    //loop the controls in the grid and turn the read-only property to false
        //    foreach (View v in (((sender as Button).Parent as Grid).Children))
        //    {
        //        if (v.GetType() == typeof(Editor))
        //        {
        //            (v as Editor).IsReadOnly = false;
        //            (v as Editor).Focus();
        //        }
        //    }
        //}

        async void Save_Clicked(object sender, EventArgs e)
        {
            //send the appropriate message to the viewmodel using the Messaging Center service
            //use the action flag to send the right message
            switch (action)
            {
                case "ADD": 
                    //add a dummy record to the database and let the user edit it
                    MessagingCenter.Send(this, "AddExercise", viewModel.ListOfExercises.FirstOrDefault(s => s.Id == -1));
                    action = "UPDATE";
                    selectedId = -1;
                    viewModel.LoadExercisesCommand.Execute(null);
                    break;
                case "UPDATE":
                    MessagingCenter.Send(this, "UpdateExercise", viewModel.ListOfExercises.FirstOrDefault(s => s.Id == selectedId));
                    action = "UPDATE";
                    selectedId = -1;
                    viewModel.LoadExercisesCommand.Execute(null);
                    break;
                default:
                    action = "UPDATE";
                    selectedId = -1;
                    break;
            }
        }

        public void OnEditorFocused(object sender, FocusEventArgs e)
        {
            /*
             * This event exists to capture the item id for the row being edited
             * The loop through the controls has a dependency on the controls being in a grid
             */

            action = action != "ADD" ? "UPDATE" : action;
            
            //loop the controls in the grid and turn the read-only property to false
            foreach (View v in (((sender as Editor).Parent as Grid).Children))
            {
                if (v.GetType() == typeof(Label))
                {
                    selectedId = int.Parse((v as Label).Text);
                }
            }
        }

        async void Add_Clicked(object sender, EventArgs e)
        {
            //action = "ADD";
            //viewModel.ListOfExercises.Insert(0, new Models.ExerciseListItem{Id=-1,Value="Exercise Name"});

            EnteredName.Text = string.Empty;

            overlay.IsVisible = true;

            EnteredName.Focus();

        }

        void OnOKButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = false;

            DisplayAlert("Result", string.Format("You entered {0}", EnteredName.Text), "OK");
        }

        void OnCancelButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = false;
        }
    }
}