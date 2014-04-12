﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace FestApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        private ViewModels.MainPage _viewModel;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DataContext = _viewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null) { return; }

            _viewModel = new ViewModels.MainPage();
            DataContext = _viewModel;
            using (Utils.LoadingIndicatorHelper.StartLoading("Refreshing data..."))
            {
                // TODO exceptions?
                await _viewModel.LoadData();
            }
        }
    }
}