using System.Security.Cryptography.X509Certificates;
using System;
using Npgsql;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;
using System.Data;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;
using System.Net;
using System.ComponentModel;
using System.Security.AccessControl;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private dynamic game;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public async Task InsertBd(string nickname, int difficult, string gameType, int score, int collectTreasure, string choosedString, bool hangman)
        {
            var connectionString = "Host=localhost;Username=postgres;Password=hsMo0;Database=postgres";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            bool tableExists;
            await using (var checkCommand = dataSource.CreateCommand("SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'Game' AND table_name = 'Games')"))
            {
                tableExists = (bool)await checkCommand.ExecuteScalarAsync();
            }

            if (tableExists)
            {
                await using (var ins = dataSource.CreateCommand("INSERT INTO \"Game\".\"Games\" (nickname, difficult, game_type, score, collectTreasure,choosedString,Hangman) VALUES (@nickname, @difficult, @gameType, @score, @collectTreasure, @choosedString, @hangman)"))
                {
                    ins.Parameters.AddWithValue("nickname", nickname);
                    ins.Parameters.AddWithValue("difficult", difficult);
                    ins.Parameters.AddWithValue("gameType", gameType);
                    ins.Parameters.AddWithValue("score", score);
                    ins.Parameters.AddWithValue("collectTreasure", collectTreasure);
                    ins.Parameters.AddWithValue("choosedString", choosedString);
                    ins.Parameters.AddWithValue("Hangman", hangman);
                    await ins.ExecuteNonQueryAsync();
                }
            }


        }

        public async Task<bool> IdCheck(int id)
        {
            var connectionString = "Host=localhost;Username=postgres;Password=hsMo0;Database=postgres";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            await using (var checkIdCommand = dataSource.CreateCommand("SELECT EXISTS (SELECT 1 FROM \"Game\".\"Games\" WHERE \"game_id\" = @game_id)"))
            {
                checkIdCommand.Parameters.AddWithValue("game_id", id);
                return (bool)await checkIdCommand.ExecuteScalarAsync();
            }

        }

        public async Task CreateBd()
        {
            var connectionString = "Host=localhost;Username=postgres;Password=hsMo0;Database=postgres";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            bool tableExists;
            await using (var checkCommand = dataSource.CreateCommand("SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'Game' AND table_name = 'Games')"))
            {
                tableExists = (bool)await checkCommand.ExecuteScalarAsync();
            }
            if (!tableExists)
            {
                await using (var cr = dataSource.CreateCommand("CREATE TABLE IF NOT EXISTS \"Game\".\"Games\" (" +
                    "game_id  SERIAL PRIMARY KEY," +
                    "nickname text NOT NULL," +
                    "difficult integer NOT NULL," +
                    "game_type text NOT NULL," +
                    "score integer NOT NULL," +
                    "collectTreasure integer," +
                    "choosedString text,"+
                    "lifeCount integer," +
                    "Hangman boolean)"))
                {
                    await cr.ExecuteNonQueryAsync();
                }
                MessageBox.Show("База данных создана.");
            }
            else
            {
                MessageBox.Show("База данных уже существует.");
            }


        }

        public async Task<DataTable> ShowRow(int id)
        {
            var connectionString = "Host=localhost;Username=postgres;Password=hsMo0;Database=postgres";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            DataTable dataTable = new DataTable();

            bool tableExists;
            await using (var checkCommand = dataSource.CreateCommand("SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'Game' AND table_name = 'Games')"))
            {
                tableExists = (bool)await checkCommand.ExecuteScalarAsync();
            }

            if (tableExists)
            {
                await using (var upd = dataSource.CreateCommand("SELECT \"collecttreasure\", \"lifecount\", \"hangman\" FROM  \"Game\".\"Games\" WHERE \"game_id\" = @game_id"))
                {
                    upd.Parameters.AddWithValue("game_id", id);

                    await using (var reader = await upd.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }


                }
            }

            return dataTable;

        }

        public async Task UpdateBd(int id, string nickname, int difficult, string game_type, int score, int collectTreasure, string choosedString)
        {
            var connectionString = "Host=localhost;Username=postgres;Password=hsMo0;Database=postgres";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            bool tableExists;
            await using (var checkCommand = dataSource.CreateCommand("SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'Game' AND table_name = 'Games')"))
            {
                tableExists = (bool)await checkCommand.ExecuteScalarAsync();
            }

            if (tableExists)
            {
                await using (var upd = dataSource.CreateCommand("UPDATE  \"Game\".\"Games\"" +
                    " SET  \"nickname\" = @nickname, \"difficult\" = @difficult, \"game_type\" = @gameType, \"score\" = @score, \"collectTreasure\" = @collectTreasure, \"choosedString\" = @choosedString " +
                    "WHERE \"game_id\" = @game_id"))
                {
                    upd.Parameters.AddWithValue("game_id", id);
                    upd.Parameters.AddWithValue("nickname", nickname);
                    upd.Parameters.AddWithValue("difficult", difficult);
                    upd.Parameters.AddWithValue("gameType", game_type);
                    upd.Parameters.AddWithValue("score", score);
                    upd.Parameters.AddWithValue("collectTreasure", collectTreasure);
                    upd.Parameters.AddWithValue("choosedString", choosedString);
                    await upd.ExecuteNonQueryAsync();

                }
            }



        }

        public async Task<DataTable> ShowColumn(int id)
        {
            var connectionString = "Host=localhost;Username=postgres;Password=hsMo0;Database=postgres";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);
            DataTable dataTable = new DataTable();

            bool tableExists;
            await using (var checkCommand = dataSource.CreateCommand("SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'Game' AND table_name = 'Games')"))
            {
                tableExists = (bool)await checkCommand.ExecuteScalarAsync();
            }

            if (tableExists)
            {

                await using (var shc = dataSource.CreateCommand("SELECT *  FROM \"Game\".\"Games\" WHERE \"game_id\" = @id"))
                {
                    shc.Parameters.AddWithValue("id", id);

                    await using (var reader = await shc.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }

                }


            }
            else
            {
                // Выводим сообщение о том, что таблица не существует
                MessageBox.Show("Таблица не существует.");
            }

            return dataTable;
        }

        public async Task DeleteBd()
        {
            var connectionString = "Host=localhost;Username=postgres;Password=hsMo0;Database=postgres";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            // Проверяем, существует ли таблица
            bool tableExists;
            await using (var checkCommand = dataSource.CreateCommand("SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'Game' AND table_name = 'Games')"))
            {
                tableExists = (bool)await checkCommand.ExecuteScalarAsync();
            }

            if (tableExists)
            {
                // Удаляем таблицу
                await using (var dl = dataSource.CreateCommand("DROP TABLE \"Game\".\"Games\""))
                {
                    await dl.ExecuteNonQueryAsync();
                }

                // Выводим сообщение о том, что таблица была удалена
                MessageBox.Show("Таблица Games была успешно удалена.");
            }
            else
            {
                // Выводим сообщение о том, что таблица не существует
                MessageBox.Show("Таблица не существует.");
            }
        }

        public async Task<DataTable> ShowBd()
        {
            var connectionString = "Host=localhost;Username=postgres;Password=hsMo0;Database=postgres";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);
            DataTable datatable = new DataTable();

            // Проверяем, существует ли таблица
            bool tableExists;
            await using (var checkCommand = dataSource.CreateCommand("SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'Game' AND table_name = 'Games')"))
            {
                tableExists = (bool)await checkCommand.ExecuteScalarAsync();
            }

            if (tableExists)
            {
                await using (var selectCommand = dataSource.CreateCommand("SELECT * FROM \"Game\".\"Games\""))
                {
                    await using (var reader = await selectCommand.ExecuteReaderAsync())
                    {
                        datatable.Load(reader);
                    }
                }
            }
            else
            {
                MessageBox.Show("Таблица не существует.");
            }


            return datatable;
        }

        public async Task DeleteBd(int id)
        {
            var connectionString = "Host=localhost;Username=postgres;Password=hsMo0;Database=postgres";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            // Проверяем, существует ли таблица
            bool tableExists;
            await using (var checkCommand = dataSource.CreateCommand("SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'Game' AND table_name = 'Games')"))
            {
                tableExists = (bool)await checkCommand.ExecuteScalarAsync();
            }

            if (tableExists)
            {

                bool idExists = await IdCheck(id);
                if (idExists)
                {
                    // Удаляем запись
                    await using (var dl = dataSource.CreateCommand("DELETE FROM \"Game\".\"Games\" WHERE \"game_id\" = @game_id"))
                    {
                        dl.Parameters.AddWithValue("game_id", id);
                        await dl.ExecuteNonQueryAsync();
                    }
                }
                else
                {
                    MessageBox.Show("Запись с данным ID не существует.");
                }
            }
            else
            {
                MessageBox.Show("Таблица не существует.");
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            CreateBd();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form2 form2 = new Form2();
            form2.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            game = new Treasure(0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Form3 form3 = new Form3();
            form3.ShowDialog();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            DeleteBd();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            game = new Hangman(0, 0, 0, 0, false, "", "");
            Form4 form4 = new Form4();
            form4.ShowDialog();


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

 
   
    }

    public class StringValid
    {
        public static bool IsCyrillic(string input)
        {
            return Regex.IsMatch(input, @"^[А-Яа-яЁё]+$");
        }

        public bool IsDigit(string input)
        {
            return Regex.IsMatch(input, @"^[0-9]+$");
        }
    }

    public abstract class Game
    {
        protected int difficult;
        protected static int setCount;
        public string nickName;
        protected int lifeCount;
        protected string diff;
        protected string sets;
        public dynamic form1;

        public Random random = new Random();

        public Game(int df,int sC, int lC, string dif, string st)
        {
            difficult = df;
            setCount = sC;
            lifeCount = lC;
            diff = dif;
            sets = st;

            
        }

      
        public virtual int CalculateScore()
        {
            int score = (lifeCount * 10 + difficult * 5) * setCount;
            return score;
        }

        public virtual void AwardBonusLife()
        {
            const int bounusTreshold = 100;
            int score = CalculateScore();
            if (score > bounusTreshold)
            {
                lifeCount++;
                MessageBox.Show("Поздравляем! Вы заработали бонусную жизнь. Теперь жизней: " + lifeCount);
            }
            else
            {
                MessageBox.Show("Бонусная жизнь не начислена. Ваши очки: " + score);
            }
        }


        public int SetDifficult(string diff)
        {
            if (string.IsNullOrEmpty(diff))
            {
                return 0;
            }

            try
            {
                difficult = Convert.ToInt32(diff);
            }
            catch (FormatException)
            {
                return 0;
            }
            catch (OverflowException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }

            if (difficult < 1 || difficult > 10)
            {
                return 0;
            }

            return difficult;
        }

        public int SetsSetter(string sets)
        {

            if (string.IsNullOrEmpty(sets))
            {
                return 0;
            }

            try
            {
                setCount = Convert.ToInt32(sets);
            }
            catch (FormatException)
            {
                return 0;
            }
            catch (OverflowException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }

            if (setCount < 1 || setCount > 999)
            {
                return 0;
            }

            return setCount;
        }

        public int GetSets()
        {
            return setCount;
        }

        public int GetDifficult()
        {
            return difficult;
        }

        public virtual void GameStart() { }
        public virtual void GameEnd() { }

    }
    public class Treasure: Game
    {
        private static readonly int height = 5;
        private static readonly int width = 5;
        private static readonly int M = 25;
        private int bombCount = 0;
        private int moveCount = 0;
        private int maxBombs = 0;
        private int collectTreasure = 0;
        private int localLife = 3;
        private int x, y = 0;
        private string X, Y;
        private int maxTreasure = 0;
        private int [,] array = new int[height,width];
        private int[] cordX = new int[M];
        private int[] cordY = new int[M];
        private int indexX = 0;
        private int indexY = 0;
        private dynamic form1;

        public Treasure(int bC,int mC, int mB, int cT, int lL, int x1, int y1, int mT, int iX, int iY) : base (3, 3, 3, "1","")
        {
            bombCount = bC;
            moveCount = mC;
            maxBombs = mB;
            collectTreasure = cT;
            localLife = lL;
            x = x1;
            y = y1;
            maxTreasure = mT;
            indexX = iX;
            indexY = iY;
        }
        public bool IsOpen(int i, int j)
        {
            for (int k = 0; k < indexX; k++)
            {
                if (cordX[k] == i && cordY[k] == j)
                {
                    return true;
                }
            }
            return false;
        }

        public void setCollectTreasure(int cT)
        {
            collectTreasure = cT;
        }

        public string ShowCell(int i, int j)
        {

            if (IsOpen(i,j))
            {
                string value = Convert.ToString(array[i,j]);
                return value;
            }
            else
            {
                return "x";
            }
        }

        public void HideTreasure()
        {
            for(int i = 0;i < height;i++)
            {
                for(int j = 0;j < width;j++)
                {
                    if (array[i,j] != 2)
                    {
                        if(maxTreasure < difficult)
                        {
                            array[i, j] = random.Next(0, 2);
                            if (array[i, j] == 1)
                            {
                                maxTreasure++;
                            }
                        }
                    }
                }
            }
        }

        public void HideBomb()
        {
            for(int i = 0;i < height; i++)
            {
                for( int j = 0;j < width; j++)
                {
                    if (array[i,j] != 1 && array[i,j] != 2 && maxBombs < difficult)
                    {
                        array[i,j] = random.Next(0,2) * 2;
                        if(array[i,j] == 2)
                        {
                            maxBombs++;
                        }
                    }
                }
            }
        }

        public override void GameStart()
        {
           // bombCount = 0;
          //  collectTreasure = 0;
          //  moveCount = 0;
         //   localLife = 3;
          //  indexX = indexY = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    array[i, j] = 0;
                }
            }

            for(int i = 0; i < M; i++)
            {
                cordX[i] = -1;
                cordY[i] = -1;
            }

            HideTreasure();
            HideBomb();

        }

        public void setNick(string nick)
        {
            nickName = nick;
        }
        public override void GameEnd()
        {
            form1 = new Form1();
            var sc = CalculateScore();
            AwardBonusLife();

 

            form1.InsertBd(nickName, difficult, "Поиск сокровищ", sc,collectTreasure,"-",localLife,false);
            
        }

        public int PlayTurn(string X,string Y)
        {
            if (localLife < 1 || collectTreasure == maxTreasure)
            {
                return 0; //завершение игры
            }

            if(string.IsNullOrEmpty(X) || string.IsNullOrEmpty(Y)) 
            { 
                return 2; //ошибка ввода координат
            }

            try
            {
                x = Convert.ToInt32(X);
                y = Convert.ToInt32(Y);
            }
            catch (FormatException)
            {
                return 2;
            }
            catch (OverflowException)
            {
                return 2;
            }
            catch(Exception ex)
            {
                return 2;
            }

            if (x < 0 || x > 4 || y < 0 || y > 4)
            { 
                return 2; 
            }

            if (array[x,y] == 2)
            {
                if (IsOpen(x,y))
                {
                    return 3; //попадание в уже открытую клетку
                }
                else
                {
                    cordX[indexX] = x;
                    cordY[indexY] = y;
                    indexX++;
                    indexY++;
                    return 4;  //попадание в бомбу
                }
            }
            else if (array[x,y] == 0)
            {
                if (IsOpen(x,y))
                {
                    return 3;
                }
                else
                {
                    cordX[indexX] = x;
                    cordY[indexY] = y;
                    indexX++;
                    indexY++;
                    return 5; //попадание в пустую клетку
                }
            }
            else
            {
                if (IsOpen(x, y))
                {
                    return 3;
                }
                else
                {
                    cordX[indexX] = x;
                    cordY[indexY] = y;
                    indexX++;
                    indexY++;
                    collectTreasure++;
                    return 6; //попадание в сокровище
                }
            }

  
        }

        public int GetMaxTreasure()
        {
            return maxTreasure;
        }

        public int GetCollectTreasure()
        {
            
            return collectTreasure;
        }

        public int GetBombCount()
        {
            return bombCount;
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetLife()
        {
            return localLife;
        }

        public void SetLife()
        {
            localLife--;
        }

        public void setsLife(int value)
        {
            localLife = value;
        }
        
        public void SetBombs()
        {
            bombCount++;
        }

        public void SetTreasure()
        {
            collectTreasure++;
        }


    }
    
    public class Hangman: Game
    {
        protected static readonly int M = 4;
        protected int wordLength;
        protected int life;
        protected int moves;
        protected int unknownCharacterCount;
        protected bool check;
        protected string[] technology = {"информатика","компьютер","процессор","биткоин"};
        protected string[] biology = {"млекопитающее","амфибия","клетка","семейство"};
        protected string[] cooking = {"торт","пирог","чизкейк","салат"};
        protected string choosedString;
        protected string choose;
        protected List<string> word = new List<string>();
        protected Random random = new Random();

        public Hangman(int wL,int lf,int mv, int uCC, bool ch,string cS, string cho)  :    base(3, 3, 3, "1", "")
        {
            wordLength = wL;
            life = lf;
            moves = mv;
            unknownCharacterCount = uCC;
            check = ch;
            choosedString = cS;
            choose = cho;

        }
        public int setLength(string choice,int index)
        {
            if (choice == "Технологии")
            {
                choose = "Технологии";
               return technology[index].Length;
            }
            else if (choice == "Биология")
            {
                choose = "Биология";
                return biology[index].Length;
            }
            else 
            {
                choose = "Готовка";
                return cooking[index].Length;
            }
        }

        public void setNick(string nick)
        {
            nickName = nick;
        }

        public int getLength(string choice)
        {
            if (choice == "Технологии")
            {
                return technology.Length;
            }
            else if (choice == "Биология")
            {
                return biology.Length;
            }
            else
            {
                return cooking.Length;
            }
        }

        public void setWord(int len)
        {
            for (int i = 0; i < len; i++)
            {
                word.Add("*");
            }
        }

 

        public (bool check1,int ind) CheckWord(string a)
        {   
            check = false;

            string trimmedInput = a.Trim();

            for (int i = 0; i < choosedString.Length; i++)
            {
                if (choosedString[i].ToString().Equals(trimmedInput, StringComparison.OrdinalIgnoreCase) && word[i].Equals("*"))
                {
                    word[i] = a;
                    unknownCharacterCount--;
                    check = true;
                    return (check,i);

                }
            }

            if(!check)
            {
                life--;
                return (check,0);
            }
            else 
            {
                return (true, 0);
            }
         

        }


        public void setUCC(int len)
        {
            unknownCharacterCount = len;
        }
        public int getUCC()
        {
            return unknownCharacterCount;
        }
        public int GetLife()
        {
            return life;
        }
        public void SetLn(int len)
        {
            wordLength = Convert.ToInt32(len);
        }

        public void chooseWord()
        {
            if (choose == "Технологии")
            { 
                while(choosedString.Length != wordLength)
                {
                   choosedString = technology[random.Next(0,technology.Length)];
                }
        
            }
            else if (choose == "Биология")
            {
                while(choosedString.Length != wordLength)
                {
                    choosedString = biology[random.Next(0,biology.Length)];
                }

            }
            else
            {
                while(choosedString.Length != wordLength)
                {
                    choosedString = cooking[random.Next(0,cooking.Length)];
                }

            }
        }

  
        public bool SetCharacter(string ch)
        {
            if (string.IsNullOrEmpty(ch))
            {
                return false;
            }

            if (ch.Length > 1)
            {
                return false;
            }

            if(!StringValid.IsCyrillic(ch))
            {
                return false;
            }

            return true;



        }
        public override void GameStart()
        {

            chooseWord();


        }

        public override void GameEnd()
        {
            form1 = new Form1();
            var sc = CalculateScore();
            AwardBonusLife();
            form1.InsertBd(nickName, wordLength, "Виселица", sc,-1,choosedString,life,true);
        }
    }

}
