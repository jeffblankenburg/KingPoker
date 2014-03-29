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
            ReviewCheck();
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
            NavigationService.Navigate(new Uri("/FiveHandsGame.xaml?game=" + GameType.DeucesWild_5X, UriKind.Relative));
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

        private void GamePack1_Unlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            OfferProduct("GAMEPACK1");
        }

        private async void OfferProduct(string s)
        {

            try
            {
                await CurrentApp.RequestProductPurchaseAsync(s, false);
                CompleteFulfillment(s);
            }
            catch (Exception ex)
            {

            }

            //            StringBuilder sb = new StringBuilder();
            //#if DEBUG
            //            var listing = await MockIAPLib.CurrentApp.LoadListingInformationAsync();
            //#else
            //            var listing = await CurrentApp.LoadListingInformationAsync();
            //#endif
            //            foreach (var product in listing.ProductListings)
            //            {
            //                sb.AppendLine(string.Format("{0}, {1}, {2},{3}, {4}",
            //                    product.Key,
            //                    product.Value.Name,
            //                    product.Value.FormattedPrice,
            //                    product.Value.ProductType,
            //                    product.Value.Description));
            //            }

            //            MessageBox.Show(sb.ToString(), "List all products", MessageBoxButton.OK);

            //#if DEBUG
            //            MockIAPLib.ListingInformation listings = await MockIAPLib.CurrentApp.LoadListingInformationByProductIdsAsync(new string[] { s });
            //#else
            //            ListingInformation listings = await CurrentApp.LoadListingInformationByProductIdsAsync(new string[] { s });
            //#endif
            //            try
            //            {


            //#if DEBUG
            //                await MockIAPLib.CurrentApp.RequestProductPurchaseAsync(listings.ProductListings.ToList()[0].Value.ProductId, false);
            //#else
            //                await CurrentApp.RequestProductPurchaseAsync(listings.ProductListings.ToList()[0].Value.ProductId, false);
            //#endif
            //                CompleteFulfillment();
            //            }
            //            catch (Exception ex)
            //            {

            //            }

        }

        private void CompleteFulfillment(string s)
        {
            App.settings["IAP_" + s] = true;
        }

        private void FivePlay_Unlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            OfferProduct("5XGAMEPACK");
        }

        private void GamePack1_Unlock_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            OfferProduct("GAMEPACK1");
        }

        private void DeucesWild_5X_Unlock(object sender, System.Windows.Input.GestureEventArgs e)
        {
            OfferProduct("5XDEUCESWILD");
        }
    }
}