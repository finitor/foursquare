﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Foursquare_Black.Resources;
using Foursquare_Black.ViewModels;
using System.Device.Location;
using System.Diagnostics;
using Foursquare_Black.ClassFolder;
using Windows.Devices.Geolocation;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Phone.Maps.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Foursquare_Black
{
    public partial class MainPage : PhoneApplicationPage
    {
        //make a variable of our UserViewModel
        UserViewModel userViewModel;
        //exploreViewModel
        ExploreViewModel exploreViewModel;
        //bool to keep check if user logged in
        bool loggedIn = false;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            Loaded += MainPage_Loaded;
            App.date = DateTime.Now.ToString("yyyyMMdd");
            //find location from gps
            FindLocation();

            //call new on view model
            exploreViewModel = new ExploreViewModel();
            ExplorePanorama.DataContext = exploreViewModel;
            exploreViewModel.loadExplore(exploreProgressBar, exploreList);

            //visibility of progress bar
            exploreProgressBar.Visibility = System.Windows.Visibility.Visible;
            exploreProgressBar.IsEnabled = true;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            //if back button is pressed and the screen isnt showing the profile grid
            //then that means we are viewing another grid. so close all other grids
            //and show the user profile grid
            if(userProfileGrid.Visibility == System.Windows.Visibility.Collapsed && loggedIn == true)
            {
                userProfileGrid.Visibility = System.Windows.Visibility.Visible;
                CheckInGrid.Visibility = System.Windows.Visibility.Collapsed;
                friendShowGrid.Visibility = System.Windows.Visibility.Collapsed;
                showTipGrid.Visibility = System.Windows.Visibility.Collapsed;
                showMayorGrid.Visibility = System.Windows.Visibility.Collapsed;
                //e.cancel stops app frem going back or backing out
                e.Cancel = true;
            }
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            
            //checks to see if accessToken is not null
            //the token will be null UNTIL the user signs in and grants permission to app
            if (App.accessToken != null)
            {
                //user is now logged in
                loggedIn = true;

                //call new on our view model
                userViewModel = new UserViewModel(locationMap);
                //set datacontext of the panorama
                UserPanorama.DataContext = userViewModel;
                //call method to load user data
                userViewModel.getSignedInUser(userProfileGrid, MainProgessBar);


                //change visibility of sign in grid.
                signInGrid.Visibility = System.Windows.Visibility.Collapsed;
                MainProgessBar.Visibility = System.Windows.Visibility.Visible;
                MainProgessBar.IsEnabled = true;


            }
        }


        
        //set map to location by phone gps
        public async void FindLocation()
        {
            Geolocator locator = new Geolocator();
            locator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await locator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10)
                    );

                locationMap.SetView(new GeoCoordinate() { Longitude = geoposition.Coordinate.Longitude, Latitude = geoposition.Coordinate.Latitude }, 15);
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x80004004)
                {
                    // the application does not have the right capability or the location master switch is off
                    MessageBox.Show("location  is disabled in phone settings.");
                }
                //else
                //{
                    // something else happened acquring the location
                //}
            }

        }


        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            //navigate to login page for authentication when sign in button is pressed
            NavigationService.Navigate(new Uri("/loginPage.xaml", UriKind.Relative));
        }

        private void checkInLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //just going to set the map to new location when item is chosen
            var selectedItem = checkInLongListSelector.SelectedItem as checkInItem;
            userViewModel.setMapToLastVisitedLocation(new GeoCoordinate() { Longitude = selectedItem.longitude, Latitude = selectedItem.latitude });
        }



        #region grid taps
        //all grid tabs for checkin, badge, tips, mayorship, and friends will 
        //start the progress bar, set the userprofile visibility to collapsed
        //and call their respective functions
        private void CheckInGrid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            userProfileGrid.Visibility = System.Windows.Visibility.Collapsed;
            MainProgessBar.Visibility = System.Windows.Visibility.Visible;
            MainProgessBar.IsEnabled = true;
            userViewModel.loadCheckIns(CheckInGrid, MainProgessBar);
        }

        private void badgeGrid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            userProfileGrid.Visibility = System.Windows.Visibility.Collapsed;
            MainProgessBar.Visibility = System.Windows.Visibility.Visible;
            MainProgessBar.IsEnabled = true;
            userViewModel.loadBadges(showBadgeGrid, MainProgessBar);
        }

        private void tipsGrid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            userProfileGrid.Visibility = System.Windows.Visibility.Collapsed;
            MainProgessBar.Visibility = System.Windows.Visibility.Visible;
            MainProgessBar.IsEnabled = true;
            userViewModel.loadTips(showTipGrid, MainProgessBar);
        }

        private void friendsGrid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            userProfileGrid.Visibility = System.Windows.Visibility.Collapsed;
            MainProgessBar.Visibility = System.Windows.Visibility.Visible;
            MainProgessBar.IsEnabled = true;
            userViewModel.loadFriends(friendShowGrid, MainProgessBar);
        }

        private void mayorshipGrid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            userProfileGrid.Visibility = System.Windows.Visibility.Collapsed;
            MainProgessBar.Visibility = System.Windows.Visibility.Visible;
            MainProgessBar.IsEnabled = true;
            userViewModel.loadMayorShip(showMayorGrid, MainProgessBar);
        }
        #endregion

        private void exploreList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = exploreList.SelectedItem as exploreItem;
            setMapToLastVisitedLocation(new GeoCoordinate() { Longitude = selectedItem.longitude, Latitude = selectedItem.latitude }, locationMap);
        }

        //We will use this method to set our map location on the ui
        public void setMapToLastVisitedLocation(GeoCoordinate coordinates, Map MyMap)
        {
            //clear any markings on the map
            MyMap.Layers.Clear();

            //create a new layer to place on the map
            MapLayer mapLayer = new MapLayer();

            //check if coordinates have a value
            if (coordinates != null)
            {
                DrawMapMarker(coordinates, Colors.Black, mapLayer);
            }

            //after marker is drawn add it to map layers
            MyMap.Layers.Add(mapLayer);
            MyMap.SetView(coordinates, 16);

        }

        private void DrawMapMarker(GeoCoordinate coordinate, Color color, MapLayer mapLayer)
        {
            // Create a map marker
            Polygon polygon = new Polygon();
            polygon.Points.Add(new Point(0, 0));
            polygon.Points.Add(new Point(0, 75));
            polygon.Points.Add(new Point(25, 0));
            polygon.Fill = new SolidColorBrush(color);

            // Create a MapOverlay and add marker
            MapOverlay overlay = new MapOverlay();
            overlay.Content = polygon;
            overlay.GeoCoordinate = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
            overlay.PositionOrigin = new Point(0.0, 1.0);
            mapLayer.Add(overlay);
        }

    }
}