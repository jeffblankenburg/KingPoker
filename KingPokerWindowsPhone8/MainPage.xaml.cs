using System;
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
using Microsoft.Phone.Tasks;
#if DEBUG
using MockIAPLib;
using Store = MockIAPLib;
using System.Text;
#else
using Windows.ApplicationModel.Store;
using System.Text;
#endif

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
            UpdateLocks();
            ReviewCheck();
            CheckAdBox();
        }

        private void CheckAdBox()
        {
            if (App.settings.Contains("IAP_NOADS")) 
            {
                AdBox.Visibility = Visibility.Collapsed;
            }
            else
            {
#if DEBUG
                AdBox.AdUnitId = "Image480_80";
                AdBox.ApplicationId = "test_client";
#else
                AdBox.AdUnitId = App.AdUnitId;
                AdBox.ApplicationId = App.ApplicationId;
#endif
            }
        }

        private void UpdateLocks()
        {
            if (App.settings.Contains("IAP_ACESANDEIGHTSPOKER")) AcesAndEightsPoker_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_ALLAMERICANPOKER")) AllAmericanPoker_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_DEUCESANDJOKERPOKER")) DeucesAndJokerPoker_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_DOUBLEJOKERPOKER")) DoubleJokerPoker_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_SUPERDOUBLEDOUBLEBONUSPOKER")) SuperDoubleDoubleBonusPoker_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_TRIPLEDOUBLEBONUSPOKER")) TripleDoubleBonusPoker_Lock.Visibility = Visibility.Collapsed;

            if (App.settings.Contains("IAP_5XACESANDEIGHTSPOKER")) AcesAndEightsPoker_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XACESANDFACESPOKER")) AcesAndFacesPoker_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XALLAMERICANPOKER")) AllAmericanPoker_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XBLACKJACKBONUSPOKER")) BlackJackBonusPoker_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XBONUSPOKER")) BonusPoker_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XBONUSPOKERDELUXE")) BonusPokerDeluxe_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XDEUCESANDJOKERPOKER")) DeucesAndJokerPoker_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XDEUCESWILD")) DeucesWild_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XDEUCESWILDBONUSPOKER")) DeucesWildBonusPoker_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XDOUBLEBONUSDEUCESWILD")) DoubleBonusDeucesWild_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XDOUBLEBONUSPOKER")) DoubleBonusPoker_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XDOUBLEDOUBLEBONUSPOKER")) DoubleDoubleBonusPoker_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XDOUBLEJOKERPOKER")) DoubleJokerPoker_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XJOKERPOKER")) JokerPoker_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XROYALACESBONUSPOKER")) RoyalAcesBonusPoker_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XSUPERACESBONUSPOKER")) SuperAcesBonusPoker_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XSUPERDOUBLEDOUBLEBONUSPOKER")) SuperDoubleDoubleBonusPoker_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XTRIPLEBONUSPOKERPLUS")) TripleBonusPokerPlus_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XTRIPLEDOUBLEBONUSPOKER")) TripleDoubleBonusPoker_5X_Lock.Visibility = Visibility.Collapsed;
            if (App.settings.Contains("IAP_5XWHITEHOTACES")) WhiteHotAces_5X_Lock.Visibility = Visibility.Collapsed;

            if (App.settings.Contains("IAP_NOADS"))
            {
                Ad_Lock.Visibility = Visibility.Collapsed;
            }
        }

        private void ReviewCheck()
        {
            switch((int)App.settings["launchcount"])
            {
                case 5:
                case 15:
                case 30:
                case 50:
                case 75:
                case 100:
                case 140:
                case 200:
                    if (!(bool)App.settings["stopaskingaboutreviews"]) ShowReviewReminder();
                    break;
                case 201:
                    App.settings["launchcount"] = 0;
                    break;

            }
        }

        private void ShowReviewReminder()
        {
            RatingsBox.Visibility = Visibility.Visible;
        }

        private void DeucesWild_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.DeucesWild, UriKind.Relative));
        }

        private void JacksOrBetter_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.JacksOrBetter, UriKind.Relative));
        }

        private void BonusPokerDeluxe_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.BonusPokerDeluxe, UriKind.Relative));
        }

        private void DoubleBonusPoker_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.DoubleBonusPoker, UriKind.Relative));
        }

        private void TripleBonusPokerPlus_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.TripleBonusPokerPlus, UriKind.Relative));
        }

        private void RoyalAcesBonusPoker_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.RoyalAcesBonusPoker, UriKind.Relative));
        }

        private void BonusPoker_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.BonusPoker, UriKind.Relative));
        }

        private void SuperAcesBonusPoker_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.SuperAcesBonusPoker, UriKind.Relative));
        }

        private void WhiteHotAces_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.WhiteHotAces, UriKind.Relative));
        }

        private void AcesAndFacesPoker_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.AcesAndFacesPoker, UriKind.Relative));
        }

        private void DoubleBonusDeucesWild_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.DoubleBonusDeucesWild, UriKind.Relative));
        }

        private void DeucesWildBonusPoker_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.DeucesWildBonusPoker, UriKind.Relative));
        }

        private void JokerPoker_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.JokerPoker, UriKind.Relative));
        }

        private void DoubleDoubleBonusPoker_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.DoubleDoubleBonusPoker, UriKind.Relative));
        }

        private void BlackJackBonusPoker_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.BlackJackBonusPoker, UriKind.Relative));
        }

        private void PlayClick()
        {
            var stream = TitleContainer.OpenStream("Assets/audio/click.wav");
            SoundEffect effect = SoundEffect.FromStream(stream);
            FrameworkDispatcher.Update();
            effect.Play();
        }

        private void Rating_Click(object sender, RoutedEventArgs e)
        {
            CloseRatingsBox();
            App.settings["launchcount"] = 205;
            MarketplaceReviewTask mrt = new MarketplaceReviewTask();
            mrt.Show();
        }

        private void CloseRatingsBox()
        {
            RatingsBox.Visibility = Visibility.Collapsed;
            App.settings["launchcount"] = (int)App.settings["launchcount"] + 1;
        }

        private void NotNow_Click(object sender, RoutedEventArgs e)
        {
            CloseRatingsBox();
            if (NeverAgainBox.IsChecked.Value)
            {
                App.settings["stopaskingaboutreviews"] = true;
            }
        }

        private void ReportBug_Click(object sender, RoutedEventArgs e)
        {
            CloseRatingsBox();
            WebBrowserTask wbt = new WebBrowserTask();
            wbt.Uri = new Uri("https://kingpoker.uservoice.com/");
            wbt.Show();
        }

        private void DeucesWild_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.DeucesWild, UriKind.Relative));
        }

        private void SuperDoubleDoubleBonusPoker_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.SuperDoubleDoubleBonusPoker, UriKind.Relative));
        }

        private void TripleDoubleBonusPoker_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.TripleDoubleBonusPoker, UriKind.Relative));
        }

        private void AcesAndEightsPoker_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.AcesAndEightsPoker, UriKind.Relative));
        }

        private void DoubleJokerPoker_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.DoubleJokerPoker, UriKind.Relative));
        }

        private void DeucesAndJokerPoker_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.DeucesAndJokerPoker, UriKind.Relative));
        }

        private void AllAmericanPoker_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/Game.xaml?game=" + GameType.AllAmericanPoker, UriKind.Relative));
        }

        private void JacksOrBetter_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.JacksOrBetter, UriKind.Relative));
        }

        private void BonusPokerDeluxe_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.BonusPokerDeluxe, UriKind.Relative));
        }

        private void DoubleBonusPoker_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.DoubleBonusPoker, UriKind.Relative));
        }

        private void TripleBonusPokerPlus_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.TripleBonusPokerPlus, UriKind.Relative));
        }

        private void RoyalAcesBonusPoker_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.RoyalAcesBonusPoker, UriKind.Relative));
        }

        private void WhiteHotAces_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.WhiteHotAces, UriKind.Relative));
        }

        private void SuperAcesBonusPoker_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.SuperAcesBonusPoker, UriKind.Relative));
        }

        private void BonusPoker_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.BonusPoker, UriKind.Relative));
        }

        private void AcesAndFaces_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.AcesAndFacesPoker, UriKind.Relative));
        }

        private void DoubleBonusDeucesWild_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.DoubleBonusDeucesWild, UriKind.Relative));
        }

        private void DeucesWildBonusPoker_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.DeucesWildBonusPoker, UriKind.Relative));
        }

        private void JokerPoker_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.JokerPoker, UriKind.Relative));
        }

        private void BlackJackBonusPoker_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.BlackJackBonusPoker, UriKind.Relative));
        }

        private void DoubleDoubleBonusPoker_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.DoubleDoubleBonusPoker, UriKind.Relative));
        }

        private void SuperDoubleDoubleBonusPoker_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.SuperDoubleDoubleBonusPoker, UriKind.Relative));
        }

        private void TripleDoubleBonusPoker_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.TripleDoubleBonusPoker, UriKind.Relative));
        }

        private void AcesAndEightsPoker_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.AcesAndEightsPoker, UriKind.Relative));
        }

        private void AcesAndFacesPoker_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.AcesAndFacesPoker, UriKind.Relative));
        }

        private void DoubleJokerPoker_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.DoubleJokerPoker, UriKind.Relative));
        }

        private void DeucesAndJokerPoker_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.DeucesAndJokerPoker, UriKind.Relative));
        }

        private void AllAmericanPoker_5X_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PlayClick();
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.AllAmericanPoker, UriKind.Relative));
        }

//GAMEPACK #1

        private void SuperDoubleDoubleBonusPoker_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=GAMEPACK1&game=&product=SUPERDOUBLEDOUBLEBONUSPOKER", UriKind.Relative));
        }

        private void TripleDoubleBonusPoker_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=GAMEPACK1&product=TRIPLEDOUBLEBONUSPOKER", UriKind.Relative));
        }

        private void AcesAndEightsPoker_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=GAMEPACK1&product=ACESANDEIGHTSPOKER", UriKind.Relative));
        }

        private void DoubleJokerPoker_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=GAMEPACK1&product=DOUBLEJOKERPOKER", UriKind.Relative));
        }

        private void DeucesAndJokerPoker_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=GAMEPACK1&product=DEUCESANDJOKERPOKER", UriKind.Relative));
        }

        private void AllAmericanPoker_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=GAMEPACK1&product=ALLAMERICANPOKER", UriKind.Relative));
        }

//5X GAME PACK

        private void DeucesWild_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XDEUCESWILD", UriKind.Relative));
        }

        private void BonusPokerDeluxe_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XBONUSPOKERDELUXE", UriKind.Relative));
        }

        private void DoubleBonusPoker_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XDOUBLEBONUSPOKER", UriKind.Relative));
        }

        private void RoyalAcesBonusPoker_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XROYALACESBONUSPOKER", UriKind.Relative));
        }

        private void TripleBonusPokerPlus_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XTRIPLEBONUSPOKERPLUS", UriKind.Relative));
        }

        private void WhiteHotAces_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XWHITEHOTACES", UriKind.Relative));
        }

        private void SuperAcesBonusPoker_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XSUPERACESBONUSPOKER", UriKind.Relative));
        }

        private void BonusPoker_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XBONUSPOKER", UriKind.Relative));
        }

        private void AcesAndFacesPoker_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XACESANDFACESPOKER", UriKind.Relative));
        }

        private void DoubleBonusDeucesWild_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XDOUBLEBONUSDEUCESWILD", UriKind.Relative));
        }

        private void DeucesWildBonusPoker_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XDEUCESWILDBONUSPOKER", UriKind.Relative));
        }

        private void JokerPoker_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XJOKERPOKER", UriKind.Relative));
        }

        private void BlackJackBonusPoker_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XBLACKJACKBONUSPOKER", UriKind.Relative));
        }

        private void DoubleDoubleBonusPoker_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XDOUBLEDOUBLEBONUSPOKER", UriKind.Relative));
        }

        private void SuperDoubleDoubleBonusPoker_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XSUPERDOUBLEDOUBLEBONUSPOKER", UriKind.Relative));
        }

        private void TripleDoubleBonusPoker_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XTRIPLEDOUBLEBONUSPOKER", UriKind.Relative));
        }

        private void AcesAndEightsPoker_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XACESANDEIGHTSPOKER", UriKind.Relative));
        }

        private void DoubleJokerPoker_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XDOUBLEJOKERPOKER", UriKind.Relative));
        }

        private void DeucesAndJokerPoker_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XDEUCESANDJOKERPOKER", UriKind.Relative));
        }

        private void AllAmericanPoker_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?group=5XGAMEPACK&product=5XALLAMERICANPOKER", UriKind.Relative));
        }

//NO ADS

        private void Ad_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InAppPurchases.xaml?product=NOADS", UriKind.Relative));
        }
    }
}