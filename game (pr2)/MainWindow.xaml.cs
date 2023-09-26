using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using game__pr2_.Classes;

namespace game__pr2_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Classes.PersonInfo Player = new Classes.PersonInfo("Student", 100, 10, 1, 0, 0, 5);
        public Classes.PersonInfo Enemy;
        public List<Classes.PersonInfo> Enemies = new List<Classes.PersonInfo>();

        public MainWindow()
        {
            InitializeComponent();
            UserInfoPlayer();
            Enemies.Add(new Classes.PersonInfo("Ящер 1", 100, 20, 1, 15, 5, 20));
            Enemies.Add(new Classes.PersonInfo("Ящер 2", 20, 5, 1, 5, 2, 5));
            Enemies.Add(new Classes.PersonInfo("Ящер 3", 50, 3, 1, 10, 10, 15));
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += AttackPlayer;
            dispatcherTimer.Interval = new System.TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
            SelectEnemy();
        }
 

    public void UserInfoPlayer()
        {
            if (Player.Glasses > 100 * Player.Level)
            {
                Player.Level++;
                Player.Glasses = 0;
                Player.Health += 100;
                Player.Damage++;
                Player.Armor++;
            }
            playerHealth.Content = "Жизненные показатели: " + Player.Health;
            playerArmor.Content = "Броня: " + Player.Armor;
            playerLevel.Content = "Уровень: " + Player.Level;
            playerGlasses.Content = "Опыт: " + Player.Glasses;
            playerMoney.Content = "Монеты: " + Player.Money;
        }

        public void SelectEnemy()
        {
            int Id = new Random().Next(0, Enemies.Count);
            Enemy = new Classes.PersonInfo(
                Enemies[Id].Name,
                Enemies[Id].Health,
                Enemies[Id].Armor,
                Enemies[Id].Level,
                Enemies[Id].Glasses,
                Enemies[Id].Money,
                Enemies[Id].Damage);
            emptyHealth.Content = "Жизненные показатели: " + Enemy.Health;
            emptyArmor.Content = "Броня: " + Enemy.Armor;
        }

        private void AttackPlayer(object sender, EventArgs e)
        {
            Player.Health -= Convert.ToInt32(Enemy.Damage * 100f / (100f - Player.Armor));
            UserInfoPlayer();
        }

        private void AttackEnemy(object sender, MouseButtonEventArgs e)
        {
            Enemy.Health -= Convert.ToInt32(Player.Damage * 100f / (100f - Enemy.Armor));
            if (Enemy.Health <= 0)
            {
                Player.Glasses += Enemy.Glasses;
                Player.Money += Enemy.Money;
                UserInfoPlayer();
                SelectEnemy();
            }
            else
            {
                emptyHealth.Content = "Жизненные показатели: " + Enemy.Health;
                emptyArmor.Content = "Броня: " + Enemy.Armor;
            }
        }
    }
}