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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;

namespace KingPokerWindowsPhone8
{
    public partial class Game : PhoneApplicationPage
    {
        Player player;
        PokerGame pokergame;
        GameType gametype;
        Hand HandStart;
        Hand HandEnd;
        bool IsHoldRound = false;
        bool IsShowingCards = false;
        bool IsDrawingCredits = false;
        int handCounter = 0;
        int cardCounter = 0;
        int payTableCounter = 0;
        int OldCredits;

        SolidColorBrush Blue = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0x00, 0x00, 0x64));
        SolidColorBrush Red = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0xB0, 0x00, 0x00));
        
        
        public Game()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            gametype = (GameType)Enum.Parse(typeof(GameType), NavigationContext.QueryString["game"].ToString());
            CreditPause.Completed += CreditPause_Completed;
            CardPause.Completed += CardPause_Completed;
            StatsPause.Completed += StatsPause_Completed;
            StatsPause5Seconds.Completed += StatsPause5Seconds_Completed;
            GameSetup();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            CreditPause.Completed -= CreditPause_Completed;
            CardPause.Completed -= CardPause_Completed;
            StatsPause.Completed -= StatsPause_Completed;
            StatsPause5Seconds.Completed -= StatsPause5Seconds_Completed;
            App.settings["credits"] = player.GetCredits();
            App.settings.Save();
        }

        void CardPause_Completed(object sender, object e)
        {
            ShowCards();
        }

        void CreditPause_Completed(object sender, object e)
        {
            UpdateCredits();
        }

        void StatsPause_Completed(object sender, EventArgs e)
        {
            StatsAnimation();
        }

        void StatsPause5Seconds_Completed(object sender, EventArgs e)
        {
            StatsAnimation();
        }

        private void GameSetup()
        {
            if (pokergame == null) pokergame = new PokerGame(gametype);
            LoadPlayer();
            CheckAdBox();
            UpdateMuteStatus();
            ChangeBetHighlight();
            LoadPayTable();
            LoadHelpContent();
            DrawCredits(player.GetCredits());
        }

        private void CheckAdBox()
        {
            if (App.settings.Contains("IAP_NOADS")) 
            {
                StatsText1.Text = "YOUR STATISTICS";
                StatsText2.Text = gametype.ToString().ToUpper();    
                AdBox.Visibility = Visibility.Collapsed;
                StatsPause5Seconds.Begin();
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

        private void StatsAnimation()
        {
            var x1 = Canvas.GetLeft(StatsText1);
            var x2 = Canvas.GetLeft(StatsText2);

            x1 -= 25;
            x2 -= 25;

            Canvas.SetLeft(StatsText1, x1);
            Canvas.SetLeft(StatsText2, x2);

            if (x1 == 0)
            {
                Canvas.SetLeft(StatsText2, 500);
                LoadNextStatistic(StatsText2);
                StatsPause5Seconds.Begin();
            }
            else if (x2 == 0)
            {
                Canvas.SetLeft(StatsText1, 500);
                LoadNextStatistic(StatsText1);
                StatsPause5Seconds.Begin();
            }
            else
            {
                StatsPause.Begin();
            }
        }

        private void LoadNextStatistic(TextBlock tb)
        {
            if (App.settings.Contains("COUNT_" + gametype.ToString() + "_" + pokergame.GetPayTable()[payTableCounter].Outcome.ToString()))
            {
                tb.Text = pokergame.GetPayTable()[payTableCounter].Title.Replace(".", "") + " : " + ((int)App.settings["COUNT_" + gametype.ToString() + "_" + pokergame.GetPayTable()[payTableCounter].Outcome]).ToString();
            }
            else
            {
                tb.Text = pokergame.GetPayTable()[payTableCounter].Title.Replace(".", "") + " : 0";
            }
            
            payTableCounter++;
            if (payTableCounter >= pokergame.GetPayTable().Count())
            {
                payTableCounter = 0;
            }
        }

        private void LoadHelpContent()
        {
            GameName.Text = gametype.ToString().ToUpper();

            string imagepath = "Assets/gamelogo/" + gametype + ".png";
            BitmapImage imagesource = new BitmapImage(new Uri(imagepath, UriKind.Relative));
            GameLogo.Source = imagesource;

            HelpFactory h = new HelpFactory(gametype);
            HelpTitle.Text = h.Title;
            HelpList.ItemsSource = h.HelpItems;
        }

        private void LoadPlayer()
        {
            player = new Player();
            if (App.settings.Contains("credits"))
            {
                player.SetCredits((int)App.settings["credits"]);
            }
            //else player.SetCredits(10000);

            //player.SetCredits(9);
        }

        private void LoadPayTable()
        {
            var paytable = pokergame.GetPayTable();

            PayTableNames.ItemsSource = paytable;
            PayTableCoin1.ItemsSource = paytable;
            PayTableCoin2.ItemsSource = paytable;
            PayTableCoin3.ItemsSource = paytable;
            PayTableCoin4.ItemsSource = paytable;
            PayTableCoin5.ItemsSource = paytable;
        }

        private void ChangeBetHighlight()
        {
            ResetReds();
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)FindName("CoinBox" + player.GetUnitsWagered());
            r.Fill = Red;
            BetText.Text = "BET   " + player.GetUnitsWagered();
        }

        private void ResetReds()
        {
            StopPayTableAnimations();
            CoinBox1.Fill = Blue;
            CoinBox2.Fill = Blue;
            CoinBox3.Fill = Blue;
            CoinBox4.Fill = Blue;
            CoinBox5.Fill = Blue;
        }

        private void StopPayTableAnimations()
        {
            PayTableTitleBlink.Stop();
            PayTableNumberBlink.Stop();
        }

        private void Deal()
        {
            if (player.GetCreditsWagered() <= player.GetCredits())
            {
                if (!IsShowingCards)
                {
                    if (!IsDrawingCredits)
                    {
                        StopPayTableAnimations();
                        ResetBox.Visibility = Visibility.Collapsed;

                        if (!IsHoldRound)
                        {
                            ClearHolds();
                            ResetCardBacks();
                            ChargeCredits();
                            //DisableShareButton();
                            pokergame = new PokerGame(gametype);
                            pokergame.Deal();
                            handCounter++;
                            IsHoldRound = true;
                            HandStart = pokergame.GetEntireHand();
                        }
                        else
                        {
                            Draw();
                        }
                        ShowCards();
                    }
                }
            }
            else if (player.CanIncreaseUnits(player.GetCreditsWagered()-1))
            {
                player.IncreaseUnitsWagered(player.GetCreditsWagered() - 1);
                Deal();
            }
        }

        private void Draw()
        {
            //if (!IsShowingCards)
            //{
            //    if (!IsDrawingCredits)
            //    {
            //        StopPayTableAnimations();
            //        ResetBox.Visibility = Visibility.Collapsed;
                    
                    pokergame.Draw();
                    ResetCardBacks();
                    //ActivateShareButton();
                    IsHoldRound = false;
                    HandEnd = pokergame.GetEntireHand();
                    SaveHands();
            //    }
            //}
        }

        private void ShowCards()
        {
            IsShowingCards = true;
            
            if (cardCounter <= 4)
            {
                if (!pokergame.IsCardHeld(cardCounter))
                {
                    DrawCard(cardCounter);
                    cardCounter++;
                    PlayCardDeal();
                    CardPause.Begin();
                }
                else
                {
                    cardCounter++;
                    ShowCards();
                }
            }
            else
            {
                cardCounter = 0;
                AwardWinnings();
                HighlightPayTable(PayTableNames, (ItemsControl)FindName("PayTableCoin" + player.GetUnitsWagered()));
                if ((!IsHoldRound) && player.GetCredits() == 0)
                {
                    ResetBox.Visibility = Visibility.Visible;
                    player.SetCredits(10000);
                    DrawCredits(player.GetCredits());
                }
                IsShowingCards = false;
            }
        }

        

        //private void ShowCards(bool shouldPayFlag)
        //{
        //    ShouldPayUser = shouldPayFlag;
        //    IsShowingCards = true;

        //    if (cardCounter <= 4)
        //    {
        //        if (!pokergame.IsCardHeld(cardCounter))
        //        {
        //            DrawCard(cardCounter);
        //            cardCounter++;
        //            PlayCardDeal();
        //            CardPause.Begin();
        //        }
        //        else
        //        {
        //            cardCounter++;
        //            ShowCards(ShouldPayUser);
        //        }
        //    }
        //    else
        //    {
        //        cardCounter = 0;
        //        HighlightPayTable(PayTableNames, (ItemsControl)FindName("PayTableCoin" + player.GetUnitsWagered()), ShouldPayUser);
        //        if ((!IsHoldRound) && player.GetCredits() == 0)
        //        {
        //            ResetBox.Visibility = Visibility.Visible;
        //            player.SetCredits(10000);
        //            DrawCredits(player.GetCredits());
        //        }
                
        //        if (ShouldPayUser) SaveHands();
        //        IsShowingCards = false;
        //    }
        //}

        private void DrawCard(int card)
        {
            string x = String.Empty;

            if (pokergame.AreDeucesWild())
            {
                if (pokergame.GetCardValue(cardCounter) == 2) x = "w";
            }

            Image image = (Image)FindName("Card" + card);
            string imagepath = "Assets/cards/" + pokergame.GetCardSuit(card).ToString() + pokergame.GetCardValue(card).ToString() + x.ToString() + ".png";
            BitmapImage imagesource = new BitmapImage(new Uri(imagepath, UriKind.Relative));
            image.Source = imagesource;
        }

        private void DrawCredits(int credits)
        {
            CreditsPanel.Children.Clear();
            for (int i = credits.ToString().Length - 1; i >= 0; i--)
            {
                Image j = new Image { Width = 19 };
                string imagepath = "Assets/numbers/" + credits.ToString()[i] + ".png";
                BitmapImage imagesource = new BitmapImage(new Uri(imagepath, UriKind.Relative));
                j.Source = imagesource;
                CreditsPanel.Children.Add(j);
            }
        }

        private void HighlightPayTable(DependencyObject target, DependencyObject target2)
        {
            var count = VisualTreeHelper.GetChildrenCount(target);
            if (count == 0) return;

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(target, i);
                var child2 = VisualTreeHelper.GetChild(target2, i);

                if (child is TextBlock)
                {
                    TextBlock targetItem = (TextBlock)child;
                    TextBlock targetItem2 = (TextBlock)child2;
                    HandOutcome current = ((PayTableItem)targetItem.DataContext).Outcome;
                    HandOutcome outcome = pokergame.CheckHandForOutcome();
                    if (current == outcome)
                    {
                        Storyboard.SetTarget(PayTableTitleBlink, targetItem);
                        Storyboard.SetTarget(PayTableNumberBlink, targetItem2);
                        PayTableTitleBlink.Begin();
                        PayTableNumberBlink.Begin();

                        if (IsHoldRound) PlayHoldAlert();
                        return;
                    }
                }
                else HighlightPayTable(child, child2);

            }
        }

        private void AwardWinnings()
        {
            if (!IsHoldRound)
            {
                int credits = player.GetCredits();
                OldCredits = credits;
                player.AwardCredits(pokergame.GetEntireHand());
                RecordHand(pokergame.CheckHandForOutcome());
                UpdateCredits();
            }
        }

        private void UpdateCredits()
        {
            IsDrawingCredits = true;
            if (OldCredits < player.GetCredits())
            {
                OldCredits++;
                DrawCredits(OldCredits);
                PlayOneBet();
                CreditPause.Begin();
            }
            else
            {
                IsDrawingCredits = false;
            }
        }

        private void ChargeCredits()
        {
            int bet = player.GetCreditsWagered();

            if (bet == 0)
            {
                //TODO: DO WHATEVER IT IS WE SHOULD DO WHEN THE USER DOESN'T HAVE ENOUGH CREDITS TO MAKE THIS BET.
                //RIGHT NOW, NOTHING HAPPENS, AND THE USER IS LEFT TO FIGURE OUT WHY.
            }
            else
            {
                App.settings["totalcreditsplayed"] = (int)App.settings["totalcreditsplayed"] + bet;
                player.RemoveWageredCredits();
                App.settings["credits"] = player.GetCredits();
                DrawCredits(player.GetCredits());
                pokergame.Deal();
            }
        }

        private void ClearHolds()
        {
            Hold0.Opacity = 0.024;
            Hold1.Opacity = 0.024;
            Hold2.Opacity = 0.024;
            Hold3.Opacity = 0.024;
            Hold4.Opacity = 0.024;
            pokergame.SetCardHoldState(0, false);
            pokergame.SetCardHoldState(1, false);
            pokergame.SetCardHoldState(2, false);
            pokergame.SetCardHoldState(3, false);
            pokergame.SetCardHoldState(4, false);
        }

        private void Card_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            HoldCard(sender as Image);
        }

        private void HoldCard(Image image)
        {
            if (!IsShowingCards)
            {
                if (IsHoldRound)
                {
                    int place = Int32.Parse(image.Name.Substring(4, 1));
                    if (pokergame.IsCardHeld(place)) pokergame.SetCardHoldState(place, false);
                    else pokergame.SetCardHoldState(place, true);
                    UpdateHold();
                }
            }
        }

        private void UpdateHold()
        {
            for (int i = 0; i <= 4; i++)
            {
                TextBlock hold = (TextBlock)FindName("Hold" + i);
                if (pokergame.IsCardHeld(i)) hold.Opacity = 1;
                else hold.Opacity = .024;
            }
        }

        private void ResetCardBacks()
        {
            for (int i = 0; i <= 4; i++)
            {
                if (!pokergame.IsCardHeld(i))
                {
                    Image image = (Image)FindName("Card" + i);
                    string imagepath = "Assets/cards/BACK.png";
                    BitmapImage imagesource = new BitmapImage(new Uri(imagepath, UriKind.Relative));
                    image.Source = imagesource;
                }
            }
        }

        private void SaveHands()
        {
            List<BothHands> handhistory = (List<BothHands>)App.settings["handhistory"];
            BothHands bothhands = new BothHands { OpeningHand = HandStart, ClosingHand = HandEnd, GameType = gametype, Outcome = HandEnd.CheckForOutcome(), CreditCount = player.GetCredits(), IsSnapped = false, IsOnline = false };
            handhistory.Add(bothhands);
            App.settings["handhistory"] = handhistory;
        }

        private void Card_ImageOpened(object sender, RoutedEventArgs e)
        {
            ResizeSingleCard(sender as Image);
        }

        private void ResizeSingleCard(Image i)
        {
            i.MinWidth = i.ActualWidth;
            i.MaxWidth = i.ActualWidth;
            i.MinHeight = i.ActualHeight;
            i.MaxHeight = i.ActualHeight;
        }

        private void ResetBox_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ResetBox.Visibility = Visibility.Collapsed;
        }

        private void Help_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            HelpBox.Visibility = Visibility.Visible;
        }

        private void MoreGames_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BetOne_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            IncreaseBet(1);
        }

        private void BetMax_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            IncreaseBet(5);
        }

        private void IncreaseBet(int amount)
        {
            if (!IsHoldRound && !IsShowingCards && !IsDrawingCredits)
            {
                if (player.CanIncreaseUnits(amount))
                {
                    player.IncreaseUnitsWagered(amount);
                    if (amount != 5) PlayOneBet();
                    if ((player.GetUnitsWagered() == 5) || (player.GetUnitsWagered() == player.GetCredits()))
                    {
                        Deal();
                    }
                }
                else
                {
                    amount--;
                    IncreaseBet(amount);
                }
                ChangeBetHighlight();
            }
        }

        private void Deal_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Deal();
        }

        private void Login_Click(object sender, EventArgs e)
        {

        }

        private void Stats_Click(object sender, EventArgs e)
        {

        }

        private void About_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void Review_Click(object sender, EventArgs e)
        {

        }

        private void PlayOneBet()
        {
            if (!(bool)App.settings["ismuted"])
            {
                var stream = TitleContainer.OpenStream("Assets/audio/onebet.wav");
                SoundEffect effect = SoundEffect.FromStream(stream);
                FrameworkDispatcher.Update();
                effect.Play();
            }
        }

        private void PlayCardDeal()
        {
            if (!(bool)App.settings["ismuted"])
            {
                var stream = TitleContainer.OpenStream("Assets/audio/carddeal.wav");
                SoundEffect effect = SoundEffect.FromStream(stream);
                FrameworkDispatcher.Update();
                effect.Play();
            }
        }

        private void PlayHoldAlert()
        {
            if (!(bool)App.settings["ismuted"])
            {
                var stream = TitleContainer.OpenStream("Assets/audio/holdalert.wav");
                SoundEffect effect = SoundEffect.FromStream(stream);
                FrameworkDispatcher.Update();
                effect.Play();
            }
        }

        private void ChangeMuteStatus()
        {
            App.settings["ismuted"] = !(bool)App.settings["ismuted"];
            UpdateMuteStatus();
        }

        private void UpdateMuteStatus()
        {
            ApplicationBarIconButton mutebutton = (ApplicationBarIconButton)ApplicationBar.Buttons[0];

            if (!(bool)App.settings["ismuted"])
            {
                mutebutton.Text = "unmute";
                mutebutton.IconUri = new Uri("/Assets/AppBar/volume_off.png", UriKind.Relative);
            }
            else
            {
                mutebutton.Text = "mute";
                mutebutton.IconUri = new Uri("/Assets/AppBar/volume_on.png", UriKind.Relative);
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            if (HelpBox.Visibility == Visibility.Visible)
            {
                HelpBox.Visibility = Visibility.Collapsed;
            }
            else NavigationService.GoBack();
        }

        private void History_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/HandHistory.xaml", UriKind.Relative));
        }

        private void Mute_Click(object sender, EventArgs e)
        {
            ChangeMuteStatus();
        }

        private void RecordHand(HandOutcome outcome)
        {

            if (App.settings.Contains("COUNT_" + gametype.ToString() + "_" + outcome.ToString()))
                App.settings["COUNT_" + gametype.ToString() + "_" + outcome.ToString()] = (int)App.settings["COUNT_" + gametype.ToString() + "_" + outcome.ToString()] + 1;
            else
                App.settings["COUNT_" + gametype.ToString() + "_" + outcome.ToString()] = 1;
        }
    }
}