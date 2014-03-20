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
        bool IsHoldRound = false;
        bool IsShowingCards = false;
        bool IsDrawingCredits = false;
        bool ShouldPayUser = false;
        int handCounter = 0;
        int cardCounter = 0;
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
            GameSetup();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            App.settings["credits"] = player.GetCredits();
        }

        void CardPause_Completed(object sender, object e)
        {
            ShowCards(ShouldPayUser);
        }

        void CreditPause_Completed(object sender, object e)
        {
            UpdateCredits();
        }

        private void GameSetup()
        {
            if (pokergame == null) pokergame = new PokerGame(gametype);
            LoadPlayer();
            ChangeBetHighlight();
            LoadPayTable();
            LoadGameTitle();
            SetGameLogo();
            DrawCredits(player.GetCredits());
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

        private void ChangeBetHighlight()
        {
            ResetReds();
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)FindName("CoinBox" + player.GetUnitsWagered());
            r.Fill = Red;
            BetText.Text = "BET   " + player.GetCreditsWagered();
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
                        //HandStart = new Hand(PokerGame.Hand.Cards, PokerGame.Hand.Held);
                    }
                    else
                    {
                        pokergame.Draw();
                        ResetCardBacks();
                        //ActivateShareButton();
                        IsHoldRound = false;
                        //HandEnd = new Hand(PokerGame.Hand.Cards, PokerGame.Hand.Held);
                    }
                    ShowCards(!IsHoldRound);
                }
            }
        }

        private void ShowCards(bool shouldPayFlag)
        {
            ShouldPayUser = shouldPayFlag;
            IsShowingCards = true;

            if (cardCounter <= 4)
            {
                if (!pokergame.IsCardHeld(cardCounter))
                {
                    string x = String.Empty;

                    if (pokergame.AreDeucesWild())
                    {
                        if (pokergame.GetCardValue(cardCounter) == 2) x = "w";
                    }

                    Image image = (Image)FindName("Card" + cardCounter);
                    string imagepath = "Assets/cards/" + pokergame.GetCardSuit(cardCounter).ToString() + pokergame.GetCardValue(cardCounter).ToString() + x.ToString() + ".png";
                    BitmapImage imagesource = new BitmapImage(new Uri(imagepath, UriKind.Relative));
                    image.Source = imagesource;
                    cardCounter++;
                    PlayCardDeal();
                    CardPause.Begin();
                }
                else
                {
                    cardCounter++;
                    ShowCards(ShouldPayUser);
                }
            }
            else
            {
                cardCounter = 0;
                if ((!IsHoldRound) && player.GetCredits() == 0)
                {
                    ResetBox.Visibility = Visibility.Visible;
                    App.settings["credits"] = 10000;
                    DrawCredits(10000);
                }
                HighlightPayTable(PayTableNames, (ItemsControl)FindName("PayTableCoin" + player.GetUnitsWagered()), ShouldPayUser);
                //if (ShouldPayUser) SaveHands();
                IsShowingCards = false;
            }
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

        private void HighlightPayTable(DependencyObject target, DependencyObject target2, bool ShouldAwardWinnings)
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
                    HandOutcome outcome = pokergame.CheckHandForOutcome();
                    if (current == outcome)
                    {
                        Storyboard.SetTarget(PayTableTitleBlink, targetItem);
                        Storyboard.SetTarget(PayTableNumberBlink, targetItem2);
                        PayTableTitleBlink.Begin();
                        PayTableNumberBlink.Begin();

                        if (ShouldAwardWinnings)
                        {
                            AwardWinnings(Int32.Parse(targetItem2.Text));
                            //RecordHand(targetItem.Text.Replace(".", ""));
                        }
                        else PlayHoldAlert();
                        return;
                    }
                }
                else HighlightPayTable(child, child2, ShouldPayUser);

            }
        }

        private void AwardWinnings(int award)
        {
            int credits = player.GetCredits();
            OldCredits = credits;
            player.AwardCredits(award);
            UpdateCredits();
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
            }
            else
            {
                player.RemoveWageredCredits();
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

        }

        private void Help_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void MoreGames_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BetOne_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!IsHoldRound && !IsShowingCards && !IsDrawingCredits)
            {
                PlayOneBet();
                if (player.IncreaseUnitsWagered())
                {
                    if (player.GetUnitsWagered() == 5)
                    {
                        Deal();
                    }
                }
                ChangeBetHighlight();
            }
        }

        private void BetMax_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!IsHoldRound && !IsShowingCards && !IsDrawingCredits)
            {
                if (player.IncreaseUnitsWagered(5)) Deal();
                //TODO: Build an animation that shows the red box travel to the 5 coin slot.
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

        }

        private void Review_Click(object sender, EventArgs e)
        {

        }

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

        private void ChangeMuteStatus()
        {
            App.IsMuted = !App.IsMuted;
        }
    }
}