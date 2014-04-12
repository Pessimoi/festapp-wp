﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using FestApp.Utils;

namespace FestApp.Pages
{
    public class DesignerArtistListVM
    {
        public DesignerArtistListVM()
        {
            ArtistGroups = AlphaKeyGroup<ArtistViewModel>.CreateGroups(new ArtistViewModel[] {
                new ArtistViewModel() { Name = "Matti Meikäläinen" }, new ArtistViewModel() { Name = "Kalle Ankka" }
            }, System.Threading.Thread.CurrentThread.CurrentUICulture,
                artist => artist.Name, true);
        }

        public List<AlphaKeyGroup<ArtistViewModel>> ArtistGroups { get; set; }
    }

    public partial class ArtistListPage : PhoneApplicationPage
    {
        public ArtistListPage()
        {
            InitializeComponent();
            DataContext = new DesignerArtistListVM();
            TestList.ItemsSource = new DesignerArtistListVM().ArtistGroups;
        }
    }
}