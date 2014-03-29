﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using KingPoker;

namespace KingPokerWindowsPhone8
{
    public partial class HandHistory : PhoneApplicationPage
    {
        public HandHistory()
        {
            InitializeComponent();
            Loaded += Stats_Loaded;
        }

        void Stats_Loaded(object sender, RoutedEventArgs e)
        {
            ShowContent.Begin();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (App.settings.Contains("IAP_NOADS"))
            {
                AdBox.Visibility = Visibility.Collapsed;
            }
            
            List<BothHands> history = App.settings["handhistory"] as List<BothHands>;
            StatsList.ItemsSource = (from p in history
                                    orderby p.TimeStamp descending
                                    select p).Take(50);
        }
    }
}