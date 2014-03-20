﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using KingPokerWindowsPhone8.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using KingPoker;

namespace KingPokerWindowsPhone8
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void DeucesWild_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.DeucesWild, UriKind.Relative));
        }

        private void JacksOrBetter_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //PlayClick();
            //NavigationService.Navigate(new Uri("/Game.xaml?game=JACKSORBETTER", UriKind.Relative));
        }

        private void BonusPokerDeluxe_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //PlayClick();
            //NavigationService.Navigate(new Uri("/Game.xaml?game=BONUSPOKERDELUXE", UriKind.Relative));
        }

        private void DoubleBonusPoker_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //PlayClick();
            //NavigationService.Navigate(new Uri("/Game.xaml?game=DOUBLEBONUSPOKER", UriKind.Relative));
        }

        private void TripleBonusPokerPlus_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //PlayClick();
            //NavigationService.Navigate(new Uri("/Game.xaml?game=TRIPLEBONUSPOKERPLUS", UriKind.Relative));
        }

        private void RoyalAcesBonusPoker_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //PlayClick();
            //NavigationService.Navigate(new Uri("/Game.xaml?game=ROYALACESBONUSPOKER", UriKind.Relative));
        }

        private void BonusPoker_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //PlayClick();
            //NavigationService.Navigate(new Uri("/Game.xaml?game=BONUSPOKER", UriKind.Relative));
        }

        private void SuperAcesBonusPoker_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //PlayClick();
            //NavigationService.Navigate(new Uri("/Game.xaml?game=SUPERACESBONUSPOKER", UriKind.Relative));
        }

        private void WhiteHotAces_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //PlayClick();
            //NavigationService.Navigate(new Uri("/Game.xaml?game=WHITEHOTACES", UriKind.Relative));
        }

        private void AcesAndFacesPoker_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //PlayClick();
            //NavigationService.Navigate(new Uri("/Game.xaml?game=ACESANDFACESPOKER", UriKind.Relative));
        }

        private void DoubleBonusDeucesWild_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //PlayClick();
            //NavigationService.Navigate(new Uri("/Game.xaml?game=DOUBLEBONUSDEUCESWILD", UriKind.Relative));
        }

        private void DeucesWildBonusPoker_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //PlayClick();
            //NavigationService.Navigate(new Uri("/Game.xaml?game=DEUCESWILDBONUSPOKER", UriKind.Relative));
        }

        private void JokerPoker_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //PlayClick();
            //NavigationService.Navigate(new Uri("/Game.xaml?game=JOKERPOKER", UriKind.Relative));
        }

        private void DoubleDoubleBonusPoker_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //PlayClick();
            //NavigationService.Navigate(new Uri("/Game.xaml?game=DOUBLEDOUBLEBONUSPOKER", UriKind.Relative));
        }

        private void BlackJackBonusPoker_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //PlayClick();
            //NavigationService.Navigate(new Uri("/Game.xaml?game=BLACKJACKBONUSPOKER", UriKind.Relative));
        }

        private void PlayClick()
        {
            var stream = TitleContainer.OpenStream("Assets/audio/click.wav");
            SoundEffect effect = SoundEffect.FromStream(stream);
            FrameworkDispatcher.Update();
            effect.Play();
        }
    }
}