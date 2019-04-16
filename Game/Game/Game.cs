using SFML.Graphics;
using System.Windows.Forms;

namespace Game
{
    class Game
    {
        public Enemy[] enemies = new Enemy[8];
        public Map map;
        public Player p;
        static bool IsWin = false;
        public Game()
        {
            Content.Load();
            map = new Map();
            NewGame();
        }

        public void NewGame()
        {
            enemies[0] = new EnemyMario(700, 20 * 32 + 19, 1f);
            enemies[1] = new EnemyMario(32 * 75, 32 * 16 + 16, 5f);
            enemies[2] = new EnemyMario(32 * 97, 20 * 32 + 19, 2f);
            enemies[3] = new Bat(900, 400, 5f, 5f);
            enemies[4] = new Bat(32 * 160, 500, 3f, 3f);
            enemies[5] = new Bat(32 * 155, 300, -3f, 3f);
            enemies[6] = new EnemyMario(32 * 155, 20 * 32 + 19, 2f);
            enemies[7] = new EnemyMario(32 * 169, 20 * 32 + 19, -2f);
            map.GenerateWorld();
            p = new Player(64, 300, this);
            Player.offsetX = 0;
            Program.k = 0;
        }

        public void Win()
        {
            if (!IsWin)
            {
                MessageBox.Show("Вы победили!\nСоздатель: Пренко Вячеслав (ПП22)", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsWin = true;
                Program.win.Close();
            }
        }

        public void Restart()
        {
            if (!IsWin)
            {
                if(MessageBox.Show("Вы проиграли!\nБудете еще пробовать пройти заново?","Проигрыш", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    NewGame();
                }
                else
                {
                    Program.win.Close();
                }
            }
        }
    }
}
