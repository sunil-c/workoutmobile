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
        private string action = "UPDATE";
        private int selectedId;

        public ExerciseListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ExerciseListViewModel();
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            int param = int.Parse(((sender as Button).CommandParameter).ToString());
            MessagingCenter.Send(this, "DeleteExercise", viewModel.ListOfExercises.FirstOrDefault(s => s.Id == param));
            action = "";
            selectedId = -1;
        }

        async void Edit_Clicked(object sender, EventArgs e)
        {
            /*
             * This event exists to capture the item id for the row being edited
             * The loop through the controls has a dependency on the controls being in a grid
             */

            //we're binding the record id to the command parameter prop
            selectedId = int.Parse(((sender as Button).CommandParameter).ToString());
            //action = action != "ADD" ? "UPDATE" : action;

            //loop the controls in the grid and turn the read-only property to false
            foreach (View v in (((sender as Button).Parent as Grid).Children))
            {
                if (v.GetType() == typeof(Editor))
                {
                    (v as Editor).IsReadOnly = false;
                    (v as Editor).Focus();
                }
            }
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            //send the appropriate message to the viewmodel using the Messaging Center service
            //use the action flag to send the right message
            switch (action)
            {
                case "UPDATE":
                    if (selectedId > -1)
                        MessagingCenter.Send(this, "UpdateExercise", viewModel.ListOfExercises.FirstOrDefault(s => s.Id == selectedId));
                    action = "UPDATE";
                    selectedId = -1;
                    //viewModel.LoadExercisesCommand.Execute(null);
                    break;
                default:
                    action = "UPDATE";
                    selectedId = -1;
                    break;
            }
        }

        public void OnEditorUnfocused(object sender, FocusEventArgs e)
        {
            (sender as Editor).IsReadOnly = true;
        }

        async void Add_Clicked(object sender, EventArgs e)
        {
            EnteredName.Text = string.Empty;
            //turn on overlay
            overlay.IsVisible = true;
            EnteredName.Focus();

        }

        void OnOKButtonClicked(object sender, EventArgs args)
        {
            //turn off overlay
            overlay.IsVisible = false;

            if (EnteredName.Text.Length > 0)
            {
                MessagingCenter.Send(this, "AddExercise", new Models.ExerciseListItem{Id=-1, Value=EnteredName.Text});
                viewModel.LoadExercisesCommand.Execute(null);
            }
        }

        void OnCancelButtonClicked(object sender, EventArgs args)
        {
            //turn off overlay
            overlay.IsVisible = false;
        }
    }
}