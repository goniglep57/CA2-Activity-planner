using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2_Activity_planner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int totalPrice = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<Activity> activities = new List<Activity>();
        private List<Activity> selectedactivities = new List<Activity>();
        private List<Activity> filteredList = new List<Activity>();

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
            
            Activity kayaking = new Activity("Kayaking", 2021, 06, 21, "Half day lakeland kayak with island picnic", 40, ActivityType.Water);
            Activity treking = new Activity("Treking", 2021, 07, 26, "Full day job treking hard", 25,ActivityType.Land);
            Activity parachuting = new Activity("Parachuting", 2021, 02, 28, "Jumping from 20000ft", 165, ActivityType.Air);
            Activity mountainBiking = new Activity("Mountain Biking", 2022, 02, 21, "3 hours of biking through the mountain woods", 70, ActivityType.Land);
            Activity surfing = new Activity("Surfing", 2022, 10, 11, "2 hours of surfing swells in donegal", 30, ActivityType.Water);
             Activity bjj = new Activity("Brazilian Jiu Jitsu", 2021, 12, 24, "No-gi rolling free session", 30, ActivityType.Land);
             Activity hriding = new Activity("Horse-Riding", 2021, 10, 16, "Begginner lesson in malin stables", 30, ActivityType.Land);
             Activity boxing = new Activity("Boxing", 2022, 01, 11, "HIT workout in clonmany gym", 30, ActivityType.Land);
             Activity karake = new Activity("Karake", 2022, 10, 11, "Intermediate group session", 30, ActivityType.Land);

           

            activities.Add(kayaking);
            activities.Add(treking);
            activities.Add(parachuting);
            activities.Add(mountainBiking);
            activities.Add(surfing);
            activities.Add(bjj);
             activities.Add(hriding);
             activities.Add(boxing);
             activities.Add(karake);





            activities.Sort();


            listActivities.ItemsSource = activities;

            
            
        }

        //Method to print out the description of the activity when selected from the original list
        private void ListActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Activity selectedActivity = listActivities.SelectedItem as Activity;
            
            if (selectedActivity != null)
            {
                txbkDescription.Text = selectedActivity.Description;
            }

           
            
           
            


        }

        //Method to print out the description of the activity when selected from the selected list
        private void ListSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            Activity selectedActivty2 = listSelected.SelectedItem as Activity;


            if (selectedActivty2 != null)
            {
                txbkDescription.Text = selectedActivty2.Description;
            }
        }

        //method to move the selected activity to the selected activity listbox when the button is clicked
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            Activity selectedActivity = listActivities.SelectedItem as Activity;

            
            if (selectedActivity == null)
            {
                string message = "You need to click on an activity to move!!";
                MessageBox.Show(message);
            }
            else
            {
                selectedactivities.Add(selectedActivity);
                totalPrice += selectedActivity.Cost;
                priceBox.Text = priceBox.Text = "$" + totalPrice.ToString();
                string message = " ";
                txbkDescription.Text = message;
                activities.Remove(selectedActivity);

                listActivities.ItemsSource = null;

                listActivities.ItemsSource = activities;

                listSelected.ItemsSource = null;

                listSelected.ItemsSource = selectedactivities;
                
                
            }

        }

        //method to move the selected activity from 2nd box back to original box
        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            Activity selectedActivity = listSelected.SelectedItem as Activity;

            if (selectedActivity == null)
            {
                string message = "You need to click on an activity to move!!";
                MessageBox.Show(message);
            }
            else
            {
                activities.Add(selectedActivity);

                totalPrice -= selectedActivity.Cost;
                priceBox.Text = "$" + totalPrice.ToString();
                string message = " ";
                txbkDescription.Text = message;

                selectedactivities.Remove(selectedActivity);

                listActivities.ItemsSource = null;

                listActivities.ItemsSource = activities;

                listSelected.ItemsSource = null;

                listSelected.ItemsSource = selectedactivities;


            }


        }



        //method to filter the activity box by TYPE
        private void rb_Checked(object sender, RoutedEventArgs e)
        {
            //RESETS THE FILTER
            filteredList.Clear();
            listActivities.ItemsSource = null;


            //if all checked
            if (radioAll.IsChecked == true)
            {
                listActivities.ItemsSource = activities;
            }

            //if land checked
            else if (radioLand.IsChecked == true)
            {
                foreach (Activity activity in activities)
                {
                    if (activity.Type == ActivityType.Land)
                    {
                        filteredList.Add(activity);

                    }
                    
                }
                listActivities.ItemsSource = filteredList;
            }
            //if water checked
            else if (radioWater.IsChecked == true)
            {
                foreach (Activity activity in activities)
                {
                    if (activity.Type == ActivityType.Water)
                    {
                        filteredList.Add(activity);

                    }
                    
                }
                listActivities.ItemsSource = filteredList;
            }

            //  if air checked
            else if (radioAir.IsChecked == true)
            {
                foreach (Activity activity in activities)
                {
                    if (activity.Type == ActivityType.Air)
                    {
                        filteredList.Add(activity);

                    }
                    
                }
                listActivities.ItemsSource = filteredList;
            }
        }

       
    }
}
