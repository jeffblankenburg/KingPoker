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

namespace KingPokerWindowsPhone8
{
    public partial class Game : PhoneApplicationPage
    {
        PokerGame pg;
        Player GamePlayer = new Player();
        GameType gametype;
        bool IsHoldRound = false;
        bool IsShowingCards = false;
        bool IsDrawingCredits = false;
        int handCounter = 0;

        SolidColorBrush Blue = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0x00, 0x00, 0x64));
        SolidColorBrush Red = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0xB0, 0x00, 0x00));
        
        
        public Game()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            gametype = (GameType)Enum.Parse(typeof(GameType), NavigationContext.QueryString["game"].ToString());
            GameSetup();
        }

        private void GameSetup()
        {
            if (pg == null) pg = new PokerGame(gametype);
            LoadPlayer();
            ChangeBetHighlight();
            LoadPayTable();
            LoadGameTitle();
            SetGameLogo();
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
            if (App.settings.Contains("credits"))
            {
                GamePlayer.SetCredits((int)App.settings["credits"]);
            }
        }

        private void LoadPayTable()
        {
            var paytable = pg.GetPayTable();

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
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)FindName("CoinBox" + GamePlayer.GetUnitsWagered());
            r.Fill = Red;
            BetText.Text = "BET   " + GamePlayer.GetCreditsWagered();
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
                        pg = new PokerGame(gametype);
                        handCounter++;
                        IsHoldRound = true;
                        //HandStart = new Hand(PokerGame.Hand.Cards, PokerGame.Hand.Held);
                    }
                    else
                    {
                        pg.Draw();
                        ResetCardBacks();
                        //ActivateShareButton();
                        IsHoldRound = false;
                        //HandEnd = new Hand(PokerGame.Hand.Cards, PokerGame.Hand.Held);
                    }
                    ShowCards(!IsHoldRound);
                }
            }
        }

        private void ShowCards(bool p)
        {
            throw new NotImplementedException();
        }

        private void ChargeCredits()
        {
            throw new NotImplementedException();
        }

        private void ResetCardBacks()
        {
            throw new NotImplementedException();
        }

        private void ClearHolds()
        {
            throw new NotImplementedException();
        }

        private void Card_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void Card_ImageOpened(object sender, RoutedEventArgs e)
        {

        }

        private void ResetBox_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void Help_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void MoreGames_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void BetOne_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void BetMax_Tapped(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

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