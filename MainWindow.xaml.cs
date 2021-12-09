﻿using System;
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
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<Activity> activities = new List<Activity>();
        //dont really understand this concept
        internal List<Activity> Activities { get => activities; set => activities = value; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
            
            Activity kayaking = new Activity("Kayaking", 2021, 06, 21, "Half day lakeland kayak with island picnic", 40);
            Activity treking = new Activity("Treking", 2021, 07, 26, "Full day job treking hard", 25);
            Activity parachuting = new Activity("Parachuting", 2021, 02, 28, "Jumping from 20000ft", 165);
            Activity mountainBiking = new Activity("Mountain Biking", 2022, 02, 21, "3 hours of biking through the mountain woods", 70);
            Activity surfing = new Activity("Surfing", 2022, 10, 11, "2 hours of surfing swells in donegal", 30);
             Activity bjj = new Activity("Brazilian Jiu Jitsu", 2021, 12, 24, "No-gi rolling free session", 30);
             Activity hriding = new Activity("Horse-Riding", 2021, 10, 16, "Begginner lesson in malin stables", 30);
             Activity boxing = new Activity("Boxing", 2022, 01, 11, "HIT workout in clonmany gym", 30);
             Activity karake = new Activity("Karake", 2022, 10, 11, "Intermediate group session", 30);

           

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

        //Method to print out the description of the activity when selected
        private void ListActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Activity selectedActivity = activities[listActivities.SelectedIndex];
            Activity selectedActivity = listActivities.SelectedItem as Activity;

            if (selectedActivity != null)
            {
                txbkDescription.Text = selectedActivity.Description;
            }
           
            


        }

        //method to move the selected activity to the selected activity listbox when the button is clicked
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            Activity selectedActivity = activities[listActivities.SelectedIndex];

            listActivities.Items.Remove(listActivities.SelectedItem);
            if (selectedActivity == null)
            {
                string message = "You need to click on an activity to move!!";
                MessageBox.Show(message);
            }
            else
            {
                listSelected.Items.Add(selectedActivity);
            }

        }

        private void rb_Checked(object sender, RoutedEventArgs e)
        {
            //if all checked
            if (radioAll.IsChecked == true)
            {
                listActivities.ItemsSource = activities;
            }

            //if land checked
            else if (radioLand.IsChecked == true)
            {
                foreach (Activity activities in activities)
                {
                    if (activities.Type == 'Land')
                    {

                    }
                }
            }
            //if water checked

            //if air checked
        }
    }
}
