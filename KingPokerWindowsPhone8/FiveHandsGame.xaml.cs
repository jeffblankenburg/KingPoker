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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace KingPokerWindowsPhone8
{
    public partial class FiveHandsGame : PhoneApplicationPage
    {
        Player player;
        FiveHandsPokerGame pokergame;
        GameType gametype;

        bool IsShowingCards = false;
        bool IsHoldRound = false;
        bool IsDrawingCredits = false;
        int ShowCardsCounter = 0;
        int ShowHandsCounter = 0;
        int OldCredits = 0;

        public FiveHandsGame()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            gametype = (GameType)Enum.Parse(typeof(GameType), NavigationContext.QueryString["game"].ToString());
            CreditPause.Completed += CreditPause_Completed;
            CardPause.Completed += CardPause_Completed;
            GameSetup();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            App.settings["credits"] = player.GetCredits();
        }

        private void GameSetup()
        {
            if (pokergame == null) pokergame = new FiveHandsPokerGame(gametype);
            LoadPlayer();
            ChangeBetHighlight();
            LoadPayTable();
            LoadGameTitle();
            SetGameLogo();
            LoadHelpContent();
            DrawCredits(player.GetCredits());
        }

        private void LoadPlayer()
        {
            player = new Player();

            if (App.settings.Contains("credits"))
            {
                player.SetCredits((int)App.settings["credits"]);
            }
            else player.SetCredits(10000);
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

        SolidColorBrush Blue = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0x00, 0x00, 0x64));
        SolidColorBrush Red = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0xB0, 0x00, 0x00));
        
        
        void CardPause_Completed(object sender, object e)
        {
            ShowCards();
        }

        void CreditPause_Completed(object sender, object e)
        {
            UpdateCredits();
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

        private void LoadGameTitle()
        {
            GameName.Text = gametype.ToString().ToUpper();
        }

        private void SetGameLogo()
        {
            string imagepath = "Assets/gamelogo/" + gametype + ".png";
            BitmapImage imagesource = new BitmapImage(new Uri(imagepath, UriKind.Relative));
            GameLogo.Source = imagesource;
        }

        private void ChangeBetHighlight()
        {
            ResetReds();
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)FindName("CoinBox" + player.GetUnitsWagered());
            r.Fill = Red;
            BetText.Text = "BET   " + (5*player.GetUnitsWagered());

            BetCircleText0.Text = player.GetUnitsWagered().ToString();
            BetCircleText1.Text = player.GetUnitsWagered().ToString();
            BetCircleText2.Text = player.GetUnitsWagered().ToString();
            BetCircleText3.Text = player.GetUnitsWagered().ToString();
            BetCircleText4.Text = player.GetUnitsWagered().ToString();
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
                        ClearHolds();
                        ClearOutcomes();
                        ResetCardBacks();
                        ChargeCredits();
                        pokergame = new FiveHandsPokerGame(gametype);
                        pokergame.Deal();
                        IsHoldRound = true;
                        ShowCards();
                    }
                }
            }
        }

        private void Draw()
        {
            if (!IsShowingCards)
            {
                if (!IsDrawingCredits)
                {
                    pokergame.Draw();
                    ResetCardBacks();
                    IsHoldRound = false;
                    ShowCards();
                }
            }
        }

        private void ShowCards()
        {
            IsShowingCards = true;

            if (ShowCardsCounter <= 4)
            {
                DrawCard(ShowHandsCounter, ShowCardsCounter);
                ShowCardsCounter++;
                if ((!pokergame.IsCardHeld(ShowCardsCounter-1)))
                {
                    PlayCardDeal();
                    CardPause.Begin();
                }
                else ShowCards();
            }
            else if ((ShowHandsCounter <= 4) && (!IsHoldRound))
            {
                EvaluateHand(ShowHandsCounter);
                ShowHandsCounter++;
                ShowCardsCounter = 0;
                if (ShowHandsCounter < 5) ShowCards();
            }
            else ShowHandsCounter = 5;

            if  (ShowHandsCounter == 5)
            {
                HighlightPayTable(PayTableNames, (ItemsControl)FindName("PayTableCoin" + player.GetUnitsWagered()));
                if (!IsHoldRound) UpdateCredits();
                ShowHandsCounter = 0;
                ShowCardsCounter = 0;
                IsShowingCards = false;
            }
        }

        private void EvaluateHand(int ShowHandsCounter)
        {
            string outcome = pokergame.PokerGames[ShowHandsCounter].GetUserFriendlyHandOutcome();
            string credits = pokergame.PokerGames[ShowHandsCounter].GetPayBasedOnHandOutCome(player.WageredUnits);
            if (outcome != "")
            {
                PlayHoldAlert();
                TextBlock t = (TextBlock)FindName("OutcomeText" + ShowHandsCounter);
                TextBlock p = (TextBlock)FindName("PayoutText" + ShowHandsCounter);
                Border b = (Border)FindName("Outcome" + ShowHandsCounter);
                t.Text = outcome;
                p.Text = credits;
                b.Visibility = Visibility.Visible;
                player.AwardCredits(pokergame.PokerGames[ShowHandsCounter].Hand);
            }
        }

        

        

        //private void SaveHands()
        //{
        //    List<BothHands> handhistory = (List<BothHands>)App.settings["handhistory"];
        //    BothHands bothhands = new BothHands { OpeningHand = HandStart, ClosingHand = HandEnd, GameType = gametype, Outcome = HandEnd.CheckForOutcome(), CreditCount = player.GetCredits(), IsSnapped = false, IsOnline = false };
        //    handhistory.Add(bothhands);
        //    App.settings["handhistory"] = handhistory;
        //}

        

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
            //TODO: This logic really shouldn't be here.  We need to have the "logic" tell the UI which items to highlight.

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
                    HandOutcome outcome = pokergame.CheckHandForOutcome(0);
                    if (current == outcome)
                    {
                        if (IsHoldRound)
                        {
                            PlayHoldAlert();
                            Storyboard.SetTarget(PayTableTitleBlink, targetItem);
                            Storyboard.SetTarget(PayTableNumberBlink, targetItem2);
                            PayTableTitleBlink.Begin();
                            PayTableNumberBlink.Begin();
                        }
                        else StopPayTableAnimations();
                        return;
                    }
                }
                else HighlightPayTable(child, child2);

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
                player.RemoveWageredCredits(5);
                OldCredits = player.GetCredits();
                DrawCredits(OldCredits);
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

        private void ClearOutcomes()
        {
            Outcome0.Visibility = Visibility.Collapsed;
            Outcome1.Visibility = Visibility.Collapsed;
            Outcome2.Visibility = Visibility.Collapsed;
            Outcome3.Visibility = Visibility.Collapsed;
            Outcome4.Visibility = Visibility.Collapsed;
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
                if (pokergame.IsCardHeld(i))
                {
                    hold.Opacity = 1;
                    for (int j = 1; j <= 4; j++)
                    {
                        DrawCard(j, i);
                    }
                }
                else
                {
                    hold.Opacity = .024;
                    for (int j = 1; j <= 4; j++)
                    {
                        ResetCard(j, i);
                    }
                }
            }
        }

        private void ResetCard(int group, int card)
        {
            Image image = (Image)FindName("Card" + (group * 10 + card));
            string imagepath = "Assets/cards/BACK.png";
            BitmapImage imagesource = new BitmapImage(new Uri(imagepath, UriKind.Relative));
            image.Source = imagesource;
        }

        private void DrawCard(int group, int card)
        {
            string x = String.Empty;

            if (pokergame.PokerGames[0].AreDeucesWild())
            {
                if (pokergame.GetCardValue(group, card) == 2) x = "w";
            }

            Image image = (Image)FindName("Card" + (group * 10 + card));
            string imagepath = "Assets/cards/" + pokergame.GetCardSuit(group, card).ToString() + pokergame.GetCardValue(group, card).ToString() + x.ToString() + ".png";
            BitmapImage imagesource = new BitmapImage(new Uri(imagepath, UriKind.Relative));
            image.Source = imagesource;
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

                    ResetCard(1, i);
                    ResetCard(2, i);
                    ResetCard(3, i);
                    ResetCard(4, i);
                }


            }
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
                if (player.CanIncreaseUnits(amount, 5))
                {
                    player.IncreaseUnitsWagered(amount);
                    if ((player.GetUnitsWagered() == 5) || (player.GetUnitsWagered()*5 == player.GetCredits()))
                    {
                        Deal();
                    }
                    else PlayOneBet();
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
            if (IsHoldRound) Draw();
            else Deal();
        }

        //private void Login_Click(object sender, EventArgs e)
        //{

        //}

        //private void Stats_Click(object sender, EventArgs e)
        //{

        //}

        private void About_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        //private void Review_Click(object sender, EventArgs e)
        //{

        //}

        private void PlayOneBet()
        {
            if (!App.IsMuted)
            {
                var stream = TitleContainer.OpenStream("Assets/audio/onebet.wav");
                SoundEffect effect = SoundEffect.FromStream(stream);
                FrameworkDispatcher.Update();
                effect.Play();
            }
        }

        private void PlayCardDeal()
        {
            if (!App.IsMuted)
            {
                var stream = TitleContainer.OpenStream("Assets/audio/carddeal.wav");
                SoundEffect effect = SoundEffect.FromStream(stream);
                FrameworkDispatcher.Update();
                effect.Play();
            }
        }

        private void PlayHoldAlert()
        {
            if (!App.IsMuted)
            {
                var stream = TitleContainer.OpenStream("Assets/audio/holdalert.wav");
                SoundEffect effect = SoundEffect.FromStream(stream);
                FrameworkDispatcher.Update();
                effect.Play();
            }
        }

        //private void ChangeMuteStatus()
        //{
        //    App.IsMuted = !App.IsMuted;
        //}

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
    }
}