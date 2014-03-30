using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using KingPoker;
using System.Windows.Media.Imaging;
#if DEBUG
using MockIAPLib;
using Store = MockIAPLib;
#else
using Windows.ApplicationModel.Store;
#endif

namespace KingPokerWindowsPhone8
{
    public partial class InAppPurchases : PhoneApplicationPage
    {
        string product;
        string group;
        
        public InAppPurchases()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("group")) group = NavigationContext.QueryString["group"].ToString();
            if (NavigationContext.QueryString.ContainsKey("product")) product = NavigationContext.QueryString["product"].ToString();
            BuildStore();
        }

        private void BuildStore()
        {
            switch(group)
            {
                case "GAMEPACK1":

                    GroupIcon.Source = new BitmapImage(new Uri("/Assets/products/GAMEPACK1.png", UriKind.Relative));
                    GroupTitle.Text = "GAME PACK 1 - SIX NEW GAMES!";
                    GroupPrice.Content = "Purchase for $2.99";

                    GameIcon.Source = new BitmapImage(new Uri("/Assets/products/" + product + ".png", UriKind.Relative));
                    GamePrice.Content = "Purchase for $0.99";
                
                    switch(product)
                    {
                        case "SUPERDOUBLEDOUBLEBONUSPOKER":
                            GameTitle.Text = "Super Double Double Bonus Poker";
                            GameDescription.Text = "This game puts heavy emphasis on four-of-a-kind combinations, and their 5th card kickers.";
                            break;
                        case "TRIPLEDOUBLEBONUSPOKER":
                            GameTitle.Text = "Triple Double Bonus Poker";
                            GameDescription.Text = "This game offers unique payouts on hands containing four Aces and a little kicker.";
                            break;
                        case "ACESANDEIGHTSPOKER":
                            GameTitle.Text = "Aces and Eights Poker";
                            GameDescription.Text = "This game offers similar payouts to Jacks or Better, with rewards for 4 Aces or Eights.";
                            break;
                        case "DOUBLEJOKERPOKER":
                            GameTitle.Text = "Double Joker Poker";
                            GameDescription.Text = "This game is like Joker Poker, but contains TWO Jokers in the deck instead of one.";
                            break;
                        case "DEUCESANDJOKERPOKER":
                            GameTitle.Text = "Deuces and Joker Poker";
                            GameDescription.Text = "This game is like Deuces Wild, but the deck also contains one wild Joker!";
                            break;
                        case "ALLAMERICANPOKER":
                            GameTitle.Text = "All American Poker";
                            GameDescription.Text = "This game is like Jacks or Better, but offers a bonus for a flush or straight.";
                            break;
                    }
                    GroupDescription.Text = "Unlocks six new video poker variations, including " + GameTitle.Text + "!";
                    break;
                case "5XGAMEPACK":

                    GroupIcon.Source = new BitmapImage(new Uri("/Assets/products/5XGAMEPACK.png", UriKind.Relative));
                    GroupTitle.Text = "FIVE PLAY GAME PACK - 21 NEW GAMES!";
                    GroupPrice.Content = "Purchase for $4.99";
                    
                    GameIcon.Source = new BitmapImage(new Uri("/Assets/products/" + product + ".png", UriKind.Relative));
                    GamePrice.Content = "Purchase for $0.99";

                    switch (product)
                    {
                        case "5XACESANDEIGHTSPOKER":
                            GameTitle.Text = "Five Play Aces and Eights Poker";
                            GameDescription.Text = "This game offers similar payouts to Jacks or Better, with rewards for 4 Aces or Eights.";
                            break;
                        case "5XACESANDFACESPOKER":
                            GameTitle.Text = "Five Play Aces and Faces Poker";
                            GameDescription.Text = "This game offers similar payouts to Jacks or Better, with rewards for 4 Aces or face cards.";
                            break;
                        case "5XALLAMERICANPOKER":
                            GameTitle.Text = "Five Play All American Poker";
                            GameDescription.Text = "This game is like Jacks or Better, but offers a bonus for a flush or straight.";
                            break;
                        case "5XBLACKJACKBONUSPOKER":
                            GameTitle.Text = "Five Play Black Jack Bonus Poker";
                            GameDescription.Text = "This game is similar to Jacks or Better, with bonuses for having a black Jack as a kicker.";
                            break;
                        case "5XBONUSPOKER":
                            GameTitle.Text = "Five Play Bonus Poker";
                            GameDescription.Text = "This game is similar to Jacks or Better, with bonuses for specific four-of-a-kind combos.";
                            break;
                        case "5XBONUSPOKERDELUXE":
                            GameTitle.Text = "Five Play Bonus Poker Deluxe";
                            GameDescription.Text = "This game is similar to Jacks or Better, with bonuses for a four-of-a-kind.";
                            break;
                        case "5XDEUCESANDJOKERPOKER":
                            GameTitle.Text = "Five Play Deuces and Joker Poker";
                            GameDescription.Text = "This game is like Deuces Wild, but the deck also contains one wild Joker.";
                            break;
                        case "5XDEUCESWILD":
                            GameTitle.Text = "Five Play Deuces Wild";
                            GameDescription.Text = "This game makes all of the 2s in the deck Wild cards.";
                            break;
                        case "5XDEUCESWILDBONUSPOKER":
                            GameTitle.Text = "Five Play Deuces Wild Bonus Poker";
                            GameDescription.Text = "This game is like Deuces Wild, with rewards for specific 5-of-a-kind combinations.";
                            break;
                        case "5XDOUBLEBONUSDEUCESWILD":
                            GameTitle.Text = "Five Play Double Bonus Deuces Wild";
                            GameDescription.Text = "This game is like Deuces Wild, with rewards for specific 5-of-a-kind combinations.";
                            break;
                        case "5XDOUBLEBONUSPOKER":
                            GameTitle.Text = "Five Play Double Bonus Poker";
                            GameDescription.Text = "This game is like Jacks or Better, with rewards for specific four-of-a-kind combinations.";
                            break;
                        case "5XDOUBLEDOUBLEBONUSPOKER":
                            GameTitle.Text = "Five Play Double Double Bonus Poker";
                            GameDescription.Text = "This game is like Jacks or Better, with big bonuses for specific four-of-a-kind combinations.";
                            break;
                        case "5XDOUBLEJOKERPOKER":
                            GameTitle.Text = "Five Play Double Joker Poker";
                            GameDescription.Text = "This game is like Joker Poker, but contains TWO Jokers in the deck instead of one.";
                            break;
                        case "5XJOKERPOKER":
                            GameTitle.Text = "Five Play Joker Poker";
                            GameDescription.Text = "This game is like Jacks or Better, but there is one wild Joker added to the deck.";
                            break;
                        case "5XROYALACESBONUSPOKER":
                            GameTitle.Text = "Five Play Royal Aces Bonus Poker";
                            GameDescription.Text = "This game is like Jacks or Better, with rewards for specific four-of-a-kind combinations.";
                            break;
                        case "5XSUPERACESBONUSPOKER":
                            GameTitle.Text = "Five Play Super Aces Bonus Poker";
                            GameDescription.Text = "This game is like Jacks or Better, with rewards for specific four-of-a-kind combinations.";
                            break;
                        case "5XSUPERDOUBLEDOUBLEBONUSPOKER":
                            GameTitle.Text = "5X Super Double Double Bonus Poker";
                            GameDescription.Text = "This game is like Jacks or Better, with rewards for specific four-of-a-kind combinations and kickers.";
                            break;
                        case "5XTRIPLEBONUSPOKERPLUS":
                            GameTitle.Text = "Five Play Triple Bonus Poker Plus";
                            GameDescription.Text = "This game is like Jacks or Better, with rewards for specific four-of-a-kind combinations.";
                            break;
                        case "5XTRIPLEDOUBLEBONUSPOKER":
                            GameTitle.Text = "Five Play Triple Double Bonus Poker";
                            GameDescription.Text = "This game is like Jacks or Better, with rewards for specific four-of-a-kind combinations and kickers.";
                            break;
                        case "5XWHITEHOTACES":
                            GameTitle.Text = "Five Play White Hot Aces";
                            GameDescription.Text = "This game is like Jacks or Better, with rewards for specific four-of-a-kind combinations.";
                            break;
                    }
                    GroupDescription.Text = "Unlocks all 21 variations of Five Play Video Poker, including " + GameTitle.Text + "!";
                    break;
                default:

                    Divider.Visibility = Visibility.Collapsed;
                    GroupTitle.Visibility = Visibility.Collapsed;
                    GroupBox.Visibility = Visibility.Collapsed;


                    switch(product)
                    {
                        case "NOADS":
                            GameTitle.Text = "No Ads (But Add Stats!)";
                            GameDescription.Text = "This will turn off all advertising in the game, and replace that space with statistics from your play.";
                            GameIcon.Source = new BitmapImage(new Uri("/Assets/products/NOADS.png", UriKind.Relative));
                            GamePrice.Content = "Purchase for $1.99";
                            break;
                    }
                    break;
            }
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
        }

        private void CompleteFulfillment(string s)
        {
            if (s == "GAMEPACK1")
            {
                App.settings["IAP_ACESANDEIGHTSPOKER"] = true;
                App.settings["IAP_ALLAMERICANPOKER"] = true;
                App.settings["IAP_DEUCESANDJOKERPOKER"] = true;
                App.settings["IAP_DOUBLEJOKERPOKER"] = true;
                App.settings["IAP_SUPERDOUBLEDOUBLEBONUSPOKER"] = true;
                App.settings["IAP_TRIPLEDOUBLEBONUSPOKER"] = true;
            }
            else if (s == "5XGAMEPACK")
            {
                App.settings["IAP_5XACESANDEIGHTSPOKER"] = true;
                App.settings["IAP_5XACESANDFACESPOKER"] = true;
                App.settings["IAP_5XALLAMERICANPOKER"] = true;
                App.settings["IAP_5XBLACKJACKBONUSPOKER"] = true;
                App.settings["IAP_5XBONUSPOKER"] = true;
                App.settings["IAP_5XBONUSPOKERDELUXE"] = true;
                App.settings["IAP_5XDEUCESANDJOKERPOKER"] = true;
                App.settings["IAP_5XDEUCESWILD"] = true;
                App.settings["IAP_5XDEUCESWILDBONUSPOKER"] = true;
                App.settings["IAP_5XDOUBLEBONUSDEUCESWILD"] = true;
                App.settings["IAP_5XDOUBLEBONUSPOKER"] = true;
                App.settings["IAP_5XDOUBLEDOUBLEBONUSPOKER"] = true;
                App.settings["IAP_5XDOUBLEJOKERPOKER"] = true;
                App.settings["IAP_5XJOKERPOKER"] = true;
                App.settings["IAP_5XROYALACESBONUSPOKER"] = true;
                App.settings["IAP_5XSUPERACESBONUSPOKER"] = true;
                App.settings["IAP_5XSUPERDOUBLEDOUBLEBONUSPOKER"] = true;
                App.settings["IAP_5XTRIPLEBONUSPOKERPLUS"] = true;
                App.settings["IAP_5XTRIPLEDOUBLEBONUSPOKER"] = true;
                App.settings["IAP_5XWHITEHOTACES"] = true;
            }
            else
            {
                App.settings["IAP_" + s] = true;
            }

            NavigationService.GoBack();
        }

        private void Game_Click(object sender, RoutedEventArgs e)
        {
            OfferProduct(product);
        }

        private void Group_Click(object sender, RoutedEventArgs e)
        {
            OfferProduct(group);
        }
    }
}