using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
/**/
namespace MuzBD
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            if (MainWindow.us)
            {
                button3.IsEnabled = false;
            }
            label2.Content = $"Вы вошли под именем {MainWindow.name}";
        }
        public static string Table = "";
        public static string Order = "";
        public static string Sort = "";
        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        public void button1_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source =LOCALHOST\SQLEXPRESS; Initial Catalog = MuzBD; Integrated Security = true;"))
            {
                connection.Open();
                string Where = "";
                int size = 2;
                int boolsearch = -1;
                int backcolorid = 0;
                string labncontent;
                switch (comboBox.Text)//запросы
                {
                    case "Библиотека":
                        Where = $@"Select * FROM [dbo].[Библиотека] {Order}";
                        break;
                    case "Группы":
                        Where = $@"Select * FROM [dbo].[Группы] {Order}";
                        break;
                    case "Договоры":
                        Where = $@"Select * FROM [dbo].[Договоры] {Order}";
                        break;
                    case "Должности":
                        Where = $@"Select * FROM [dbo].[Должности] {Order}";
                        break;
                    case "Занятия":
                        Where = $@"Select * FROM [dbo].[Занятия] {Order}";
                        break;
                    case "Заочники":
                        Where = $@"Select * FROM [dbo].[Заочники] {Order}";
                        break;
                    case "Кабинеты":
                        Where = $@"Select * FROM [dbo].[Кабинеты] {Order}";
                        break;
                    case "Мероприятия":
                        Where = $@"Select * FROM [dbo].[Мероприятия] {Order}";
                        break;
                    case "Музыкальные инструменты":
                        Where = $@"Select * FROM [dbo].[Музыкальные инструменты] {Order}";
                        break;
                    case "Назначение кабинета":
                        Where = $@"Select * FROM [dbo].[Назначение кабинета] {Order}";
                        break;
                    case "Направления":
                        Where = $@"Select * FROM [dbo].[Направления] {Order}";
                        break;
                    case "Оборудование":
                        Where = $@"Select * FROM [dbo].[Оборудование] {Order}";
                        break;
                    case "Организационная структура":
                        Where = $@"Select * FROM [dbo].[Организационная структура] {Order}";
                        break;
                    case "Очники":
                        Where = $@"Select * FROM [dbo].[Очники] {Order}";
                        break;
                    case "Паспортные данные":
                        Where = $@"Select * FROM [dbo].[Паспортные данные] {Order}";
                        break;
                    case "Под_успеваемость":
                        Where = $@"Select * FROM [dbo].[Под_успеваемость] {Order}";
                        break;
                    case "Предметы":
                        Where = $@"Select * FROM [dbo].[Предметы] {Order}";
                        break;
                    case "Рекламные кампании":
                        Where = $@"Select * FROM [dbo].[Рекламные кампании] {Order}";
                        break;
                    case "Сотрудники":
                        Where = $@"Select * FROM [dbo].[Сотрудники] {Order}";
                        break;
                    case "Тип договора":
                        Where = $@"Select * FROM [dbo].[Тип договора] {Order}";
                        break;
                    case "Тип музыкального инструмента":
                        Where = $@"Select * FROM [dbo].[Тип музыкального инструмента] {Order}";
                        break;
                    case "Тип рекламы":
                        Where = $@"Select * FROM [dbo].[Тип рекламы] {Order}";
                        break;
                    case "Успеваемость":
                        Where = $@"Select * FROM [dbo].[Успеваемость] {Order}";
                        break;
                    default:
                        break;
                }//запросы
                SqlCommand cmd = new SqlCommand($@"{Where}", connection);
                if (comboBox.Text != "")//показывает таблицы, если комбобокс не пустой
                {
                    Table = comboBox.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        StackPanel1.Children.Clear();
                        UserControl2 nam = new UserControl2();
                        string[] atribs = { "", "", "", "", "", "", "", "", "", "", "", "" };
                        switch (comboBox.Text) //добавление названия столбцов
                        {
                            case "Библиотека":
                                atribs[0] = "Код книги";
                                atribs[1] = "Название";
                                atribs[2] = "Автор";
                                atribs[3] = "Год изд.";
                                size = 4;
                                break;
                            case "Группы":
                                atribs[0] = "Название ";
                                atribs[1] = "Код направ.";
                                break;
                            case "Договоры":
                                atribs[0] = "Код договора";
                                atribs[1] = "Код типа договора";
                                atribs[2] = "Дата подписания";
                                atribs[3] = "Окончание действия";
                                atribs[4] = "Стоимость";
                                size = 5;
                                break;
                            case "Должности":
                                atribs[0] = "Код должности";
                                atribs[1] = "Код отдела";
                                atribs[2] = "Наименование";
                                size = 3;
                                break;
                            case "Занятия":
                                atribs[0] = "Дата занятия";
                                atribs[1] = "Код предмета";
                                atribs[2] = "Номер кабинета";
                                size = 3;
                                break;
                            case "Заочники":
                                atribs[0] = "Код заочника";
                                atribs[1] = "Код договора";
                                atribs[2] = "Серия и номер";
                                atribs[3] = "Фамилия";
                                atribs[4] = "Имя";
                                atribs[5] = "Отчество";
                                atribs[6] = "Дата рождения";
                                atribs[7] = "Номер телефона";
                                atribs[8] = "Email";
                                size = 9;
                                break;
                            case "Кабинеты":
                                atribs[0] = "Номер кабинета";
                                atribs[1] = "Код назначения";
                                break;
                            case "Мероприятия":
                                atribs[0] = "Дата проведения";
                                atribs[1] = "Место проведения";
                                atribs[2] = "Название";
                                size = 3;
                                break;
                            case "Музыкальные инструменты":
                                atribs[0] = "Код инструмента";
                                atribs[1] = "Тип инструмента";
                                atribs[2] = "";
                                size = 3;
                                break;
                            case "Назначение кабинета":
                                atribs[0] = "Код назначения";
                                atribs[1] = "Назначение";
                                break;
                            case "Направления":
                                atribs[0] = "Код направления";
                                atribs[1] = "Название";
                                break;
                            case "Оборудование":
                                atribs[0] = "Код оборудование";
                                atribs[1] = "Номер кабинета";
                                atribs[2] = "Название оборудования";
                                size = 3;
                                break;
                            case "Организационная структура":
                                atribs[0] = "Код отдела";
                                atribs[1] = "Название";
                                break;
                            case "Очники":
                                atribs[0] = "Код очника";
                                atribs[1] = "Код направления";
                                atribs[2] = "Название группы";
                                atribs[3] = "Серия и номер";
                                atribs[4] = "Фамилия";
                                atribs[5] = "Имя";
                                atribs[6] = "Отчество";
                                atribs[7] = "Дата рождения";
                                atribs[8] = "Адрес проживания";
                                atribs[9] = "Номер телефона";
                                atribs[10] = "Email";
                                size = 11;
                                break;
                            case "Паспортные данные":
                                atribs[0] = "Серия и номер";
                                atribs[1] = "Дата выдачи";
                                atribs[2] = "Кем выдано";
                                atribs[3] = "Место прописки";
                                size = 4;
                                break;
                            case "Под_успеваемость":
                                atribs[0] = "Код под_успеваемости";
                                atribs[1] = "Код успеваемости";
                                atribs[2] = "Код очника";
                                atribs[3] = "Оценка";
                                size = 4;
                                break;
                            case "Предметы":
                                atribs[0] = "Код предмета";
                                atribs[1] = "Название";
                                break;
                            case "Рекламные кампании":
                                atribs[0] = "Код кампании";
                                atribs[1] = "Тип рекламы";
                                atribs[2] = "Дата операции";
                                atribs[3] = "Стоимость";
                                size = 4;
                                break;
                            case "Сотрудники":
                                atribs[0] = "Код сотрудника";
                                atribs[1] = "Код должности";
                                atribs[2] = "Серия и номер";
                                atribs[3] = "Фамилия";
                                atribs[4] = "Имя";
                                atribs[5] = "Отчество";
                                atribs[6] = "Ставка";
                                atribs[7] = "Адрес проживания";
                                atribs[8] = "Дата рождения";
                                atribs[9] = "Номер телефона";
                                atribs[10] = "Email";
                                atribs[11] = "Образование";
                                size = 12;
                                break;
                            case "Тип договора":
                                atribs[0] = "Код типа договора";
                                atribs[1] = "Тип договора";
                                size = 2;
                                break;
                            case "Тип музыкального инструмента":
                                atribs[0] = "Код типа инструмента";
                                atribs[1] = "Название типа инструмента";
                                break;
                            case "Тип рекламы":
                                atribs[0] = "Код типа рекламы";
                                atribs[1] = "Тип рекламы";
                                break;
                            case "Успеваемость":
                                atribs[0] = "Код успеваемости";
                                atribs[1] = "Название группы";
                                atribs[2] = "Код предмета";
                                size = 3;
                                break;
                            default:
                                break;
                        }//добавление названия столбцов
                        nam.label.Content = atribs[0];
                        nam.label1.Content = atribs[1];
                        nam.label2.Content = atribs[2];
                        nam.label3.Content = atribs[3];
                        nam.label4.Content = atribs[4];
                        nam.label5.Content = atribs[5];
                        nam.label6.Content = atribs[6];
                        nam.label7.Content = atribs[7];
                        nam.label8.Content = atribs[8];
                        nam.label9.Content = atribs[9];
                        nam.label10.Content = atribs[10];
                        nam.label11.Content = atribs[11];
                        StackPanel1.Children.Add(nam);
                        for (int i = 0; i < atribs.Length - 1; i++)
                        {
                            atribs[i] = "";
                        }
                        while (reader.Read())//выгрузка таблиц
                        {
                            backcolorid++;
                            UserControl1 table = new UserControl1();
                            table.labn1.Text = "";
                            table.labn1.Width = nam.label.Width;
                            table.labn1.Visibility = Visibility.Hidden;
                            table.labn2.Text = "";
                            table.labn2.Width = nam.label1.Width;
                            table.labn2.Visibility = Visibility.Hidden;
                            table.labn3.Text = "";
                            table.labn3.Width = nam.label2.Width;
                            table.labn3.Visibility = Visibility.Hidden;
                            table.labn4.Text = "";
                            table.labn4.Width = nam.label3.Width;
                            table.labn4.Visibility = Visibility.Hidden;
                            table.labn5.Text = "";
                            table.labn5.Width = nam.label4.Width;
                            table.labn5.Visibility = Visibility.Hidden;
                            table.labn6.Text = "";
                            table.labn6.Width = nam.label5.Width;
                            table.labn6.Visibility = Visibility.Hidden;
                            table.labn7.Text = "";
                            table.labn7.Width = nam.label6.Width;
                            table.labn7.Visibility = Visibility.Hidden;
                            table.labn8.Text = "";
                            table.labn8.Width = nam.label7.Width;
                            table.labn8.Visibility = Visibility.Hidden;
                            table.labn9.Text = "";
                            table.labn9.Width = nam.label8.Width;
                            table.labn9.Visibility = Visibility.Hidden;
                            table.labn10.Text = "";
                            table.labn10.Width = nam.label9.Width;
                            table.labn10.Visibility = Visibility.Hidden;
                            table.labn11.Text = "";
                            table.labn11.Width = nam.label10.Width;
                            table.labn11.Visibility = Visibility.Hidden;
                            table.labn12.Text = "";
                            table.labn12.Width = nam.label11.Width;
                            table.labn12.Visibility = Visibility.Hidden;
                            if (backcolorid % 2 == 0)
                            {
                                table.labn1.Background = new SolidColorBrush(Colors.Aquamarine);
                                table.labn2.Background = new SolidColorBrush(Colors.Aquamarine);
                                table.labn3.Background = new SolidColorBrush(Colors.Aquamarine);
                                table.labn4.Background = new SolidColorBrush(Colors.Aquamarine);
                                table.labn5.Background = new SolidColorBrush(Colors.Aquamarine);
                                table.labn6.Background = new SolidColorBrush(Colors.Aquamarine);
                                table.labn7.Background = new SolidColorBrush(Colors.Aquamarine);
                                table.labn8.Background = new SolidColorBrush(Colors.Aquamarine);
                                table.labn9.Background = new SolidColorBrush(Colors.Aquamarine);
                                table.labn10.Background = new SolidColorBrush(Colors.Aquamarine);
                                table.labn11.Background = new SolidColorBrush(Colors.Aquamarine);
                                table.labn12.Background = new SolidColorBrush(Colors.Aquamarine);
                            }
                            switch (size)
                            {
                                case 2:
                                    {
                                        table.labn1.Text = reader[0].ToString();
                                        table.labn1.Width = nam.label.Width;
                                        table.labn1.Visibility = Visibility.Visible;
                                        table.labn2.Text = reader[1].ToString();
                                        table.labn2.Width = nam.label1.Width;
                                        table.labn2.Visibility = Visibility.Visible;
                                    }
                                    break;
                                case 3:
                                    {
                                        table.labn1.Text = reader[0].ToString();
                                        table.labn1.Width = nam.label.Width;
                                        table.labn1.Visibility = Visibility.Visible;
                                        table.labn2.Text = reader[1].ToString();
                                        table.labn2.Width = nam.label1.Width;
                                        table.labn2.Visibility = Visibility.Visible;
                                        table.labn3.Text = reader[2].ToString();
                                        table.labn3.Width = nam.label2.Width;
                                        table.labn3.Visibility = Visibility.Visible;
                                    }
                                    break;
                                case 4:
                                    {
                                        table.labn1.Text = reader[0].ToString();
                                        table.labn1.Width = nam.label.Width;
                                        table.labn1.Visibility = Visibility.Visible;
                                        table.labn2.Text = reader[1].ToString();
                                        table.labn2.Width = nam.label1.Width;
                                        table.labn2.Visibility = Visibility.Visible;
                                        table.labn3.Text = reader[2].ToString();
                                        table.labn3.Width = nam.label2.Width;
                                        table.labn3.Visibility = Visibility.Visible;
                                        table.labn4.Text = reader[3].ToString();
                                        table.labn4.Width = nam.label3.Width;
                                        table.labn4.Visibility = Visibility.Visible;
                                    }
                                    break;
                                case 5:
                                    {
                                        table.labn1.Text = reader[0].ToString();
                                        table.labn1.Width = nam.label.Width;
                                        table.labn1.Visibility = Visibility.Visible;
                                        table.labn2.Text = reader[1].ToString();
                                        table.labn2.Width = nam.label1.Width;
                                        table.labn2.Visibility = Visibility.Visible;
                                        table.labn3.Text = reader[2].ToString();
                                        table.labn3.Width = nam.label2.Width;
                                        table.labn3.Visibility = Visibility.Visible;
                                        table.labn4.Text = reader[3].ToString();
                                        table.labn4.Width = nam.label3.Width;
                                        table.labn4.Visibility = Visibility.Visible;
                                        table.labn5.Text = reader[4].ToString();
                                        table.labn5.Width = nam.label4.Width;
                                        table.labn5.Visibility = Visibility.Visible;
                                    }
                                    break;
                                case 6:
                                    {
                                        table.labn1.Text = reader[0].ToString();
                                        table.labn1.Width = nam.label.Width;
                                        table.labn1.Visibility = Visibility.Visible;
                                        table.labn2.Text = reader[1].ToString();
                                        table.labn2.Width = nam.label1.Width;
                                        table.labn2.Visibility = Visibility.Visible;
                                        table.labn3.Text = reader[2].ToString();
                                        table.labn3.Width = nam.label2.Width;
                                        table.labn3.Visibility = Visibility.Visible;
                                        table.labn4.Text = reader[3].ToString();
                                        table.labn4.Width = nam.label3.Width;
                                        table.labn4.Visibility = Visibility.Visible;
                                        table.labn5.Text = reader[4].ToString();
                                        table.labn5.Width = nam.label4.Width;
                                        table.labn5.Visibility = Visibility.Visible;
                                        table.labn6.Text = reader[5].ToString();
                                        table.labn6.Width = nam.label5.Width;
                                        table.labn6.Visibility = Visibility.Visible;
                                    }
                                    break;
                                case 7:
                                    {
                                        table.labn1.Text = reader[0].ToString();
                                        table.labn1.Width = nam.label.Width;
                                        table.labn1.Visibility = Visibility.Visible;
                                        table.labn2.Text = reader[1].ToString();
                                        table.labn2.Width = nam.label1.Width;
                                        table.labn2.Visibility = Visibility.Visible;
                                        table.labn3.Text = reader[2].ToString();
                                        table.labn3.Width = nam.label2.Width;
                                        table.labn3.Visibility = Visibility.Visible;
                                        table.labn4.Text = reader[3].ToString();
                                        table.labn4.Width = nam.label3.Width;
                                        table.labn4.Visibility = Visibility.Visible;
                                        table.labn5.Text = reader[4].ToString();
                                        table.labn5.Width = nam.label4.Width;
                                        table.labn5.Visibility = Visibility.Visible;
                                        table.labn6.Text = reader[5].ToString();
                                        table.labn6.Width = nam.label5.Width;
                                        table.labn6.Visibility = Visibility.Visible;
                                        table.labn7.Text = reader[6].ToString();
                                        table.labn7.Width = nam.label6.Width;
                                        table.labn7.Visibility = Visibility.Visible;
                                    }
                                    break;
                                case 8:
                                    {
                                        table.labn1.Text = reader[0].ToString();
                                        table.labn1.Width = nam.label.Width;
                                        table.labn1.Visibility = Visibility.Visible;
                                        table.labn2.Text = reader[1].ToString();
                                        table.labn2.Width = nam.label1.Width;
                                        table.labn2.Visibility = Visibility.Visible;
                                        table.labn3.Text = reader[2].ToString();
                                        table.labn3.Width = nam.label2.Width;
                                        table.labn3.Visibility = Visibility.Visible;
                                        table.labn4.Text = reader[3].ToString();
                                        table.labn4.Width = nam.label3.Width;
                                        table.labn4.Visibility = Visibility.Visible;
                                        table.labn5.Text = reader[4].ToString();
                                        table.labn5.Width = nam.label4.Width;
                                        table.labn5.Visibility = Visibility.Visible;
                                        table.labn6.Text = reader[5].ToString();
                                        table.labn6.Width = nam.label5.Width;
                                        table.labn6.Visibility = Visibility.Visible;
                                        table.labn7.Text = reader[6].ToString();
                                        table.labn7.Width = nam.label6.Width;
                                        table.labn7.Visibility = Visibility.Visible;
                                        table.labn8.Text = reader[7].ToString();
                                        table.labn8.Width = nam.label7.Width;
                                        table.labn8.Visibility = Visibility.Visible;
                                    }
                                    break;
                                case 9:
                                    {
                                        table.labn1.Text = reader[0].ToString();
                                        table.labn1.Width = nam.label.Width;
                                        table.labn1.Visibility = Visibility.Visible;
                                        table.labn2.Text = reader[1].ToString();
                                        table.labn2.Width = nam.label1.Width;
                                        table.labn2.Visibility = Visibility.Visible;
                                        table.labn3.Text = reader[2].ToString();
                                        table.labn3.Width = nam.label2.Width;
                                        table.labn3.Visibility = Visibility.Visible;
                                        table.labn4.Text = reader[3].ToString();
                                        table.labn4.Width = nam.label3.Width;
                                        table.labn4.Visibility = Visibility.Visible;
                                        table.labn5.Text = reader[4].ToString();
                                        table.labn5.Width = nam.label4.Width;
                                        table.labn5.Visibility = Visibility.Visible;
                                        table.labn6.Text = reader[5].ToString();
                                        table.labn6.Width = nam.label5.Width;
                                        table.labn6.Visibility = Visibility.Visible;
                                        table.labn7.Text = reader[6].ToString();
                                        table.labn7.Width = nam.label6.Width;
                                        table.labn7.Visibility = Visibility.Visible;
                                        table.labn8.Text = reader[7].ToString();
                                        table.labn8.Width = nam.label7.Width;
                                        table.labn8.Visibility = Visibility.Visible;
                                        table.labn9.Text = reader[8].ToString();
                                        table.labn9.Width = nam.label8.Width;
                                        table.labn9.Visibility = Visibility.Visible;
                                    }
                                    break;
                                case 10:
                                    {
                                        table.labn1.Text = reader[0].ToString();
                                        table.labn1.Width = nam.label.Width;
                                        table.labn1.Visibility = Visibility.Visible;
                                        table.labn2.Text = reader[1].ToString();
                                        table.labn2.Width = nam.label1.Width;
                                        table.labn2.Visibility = Visibility.Visible;
                                        table.labn3.Text = reader[2].ToString();
                                        table.labn3.Width = nam.label2.Width;
                                        table.labn3.Visibility = Visibility.Visible;
                                        table.labn4.Text = reader[3].ToString();
                                        table.labn4.Width = nam.label3.Width;
                                        table.labn4.Visibility = Visibility.Visible;
                                        table.labn5.Text = reader[4].ToString();
                                        table.labn5.Width = nam.label4.Width;
                                        table.labn5.Visibility = Visibility.Visible;
                                        table.labn6.Text = reader[5].ToString();
                                        table.labn6.Width = nam.label5.Width;
                                        table.labn6.Visibility = Visibility.Visible;
                                        table.labn7.Text = reader[6].ToString();
                                        table.labn7.Width = nam.label6.Width;
                                        table.labn7.Visibility = Visibility.Visible;
                                        table.labn8.Text = reader[7].ToString();
                                        table.labn8.Width = nam.label7.Width;
                                        table.labn8.Visibility = Visibility.Visible;
                                        table.labn9.Text = reader[8].ToString();
                                        table.labn9.Width = nam.label8.Width;
                                        table.labn9.Visibility = Visibility.Visible;
                                        table.labn10.Text = reader[9].ToString();
                                        table.labn10.Width = nam.label9.Width;
                                        table.labn10.Visibility = Visibility.Visible;
                                    }
                                    break;
                                case 11:
                                    {
                                        table.labn1.Text = reader[0].ToString();
                                        table.labn1.Width = nam.label.Width;
                                        table.labn1.Visibility = Visibility.Visible;
                                        table.labn2.Text = reader[1].ToString();
                                        table.labn2.Width = nam.label1.Width;
                                        table.labn2.Visibility = Visibility.Visible;
                                        table.labn3.Text = reader[2].ToString();
                                        table.labn3.Width = nam.label2.Width;
                                        table.labn3.Visibility = Visibility.Visible;
                                        table.labn4.Text = reader[3].ToString();
                                        table.labn4.Width = nam.label3.Width;
                                        table.labn4.Visibility = Visibility.Visible;
                                        table.labn5.Text = reader[4].ToString();
                                        table.labn5.Width = nam.label4.Width;
                                        table.labn5.Visibility = Visibility.Visible;
                                        table.labn6.Text = reader[5].ToString();
                                        table.labn6.Width = nam.label5.Width;
                                        table.labn6.Visibility = Visibility.Visible;
                                        table.labn7.Text = reader[6].ToString();
                                        table.labn7.Width = nam.label6.Width;
                                        table.labn7.Visibility = Visibility.Visible;
                                        table.labn8.Text = reader[7].ToString();
                                        table.labn8.Width = nam.label7.Width;
                                        table.labn8.Visibility = Visibility.Visible;
                                        table.labn9.Text = reader[8].ToString();
                                        table.labn9.Width = nam.label8.Width;
                                        table.labn9.Visibility = Visibility.Visible;
                                        table.labn10.Text = reader[9].ToString();
                                        table.labn10.Width = nam.label9.Width;
                                        table.labn10.Visibility = Visibility.Visible;
                                        table.labn11.Text = reader[10].ToString();
                                        table.labn11.Width = nam.label10.Width;
                                        table.labn11.Visibility = Visibility.Visible;
                                    }
                                    break;
                                case 12:
                                    {
                                        table.labn1.Text = reader[0].ToString();
                                        table.labn1.Width = nam.label.Width;
                                        table.labn1.Visibility = Visibility.Visible;
                                        table.labn2.Text = reader[1].ToString();
                                        table.labn2.Width = nam.label1.Width;
                                        table.labn2.Visibility = Visibility.Visible;
                                        table.labn3.Text = reader[2].ToString();
                                        table.labn3.Width = nam.label2.Width;
                                        table.labn3.Visibility = Visibility.Visible;
                                        table.labn4.Text = reader[3].ToString();
                                        table.labn4.Width = nam.label3.Width;
                                        table.labn4.Visibility = Visibility.Visible;
                                        table.labn5.Text = reader[4].ToString();
                                        table.labn5.Width = nam.label4.Width;
                                        table.labn5.Visibility = Visibility.Visible;
                                        table.labn6.Text = reader[5].ToString();
                                        table.labn6.Width = nam.label5.Width;
                                        table.labn6.Visibility = Visibility.Visible;
                                        table.labn7.Text = reader[6].ToString();
                                        table.labn7.Width = nam.label6.Width;
                                        table.labn7.Visibility = Visibility.Visible;
                                        table.labn8.Text = reader[7].ToString();
                                        table.labn8.Width = nam.label7.Width;
                                        table.labn8.Visibility = Visibility.Visible;
                                        table.labn9.Text = reader[8].ToString();
                                        table.labn9.Width = nam.label8.Width;
                                        table.labn9.Visibility = Visibility.Visible;
                                        table.labn10.Text = reader[9].ToString();
                                        table.labn10.Width = nam.label9.Width;
                                        table.labn10.Visibility = Visibility.Visible;
                                        table.labn11.Text = reader[10].ToString();
                                        table.labn11.Width = nam.label10.Width;
                                        table.labn11.Visibility = Visibility.Visible;
                                        table.labn12.Text = reader[11].ToString();
                                        table.labn12.Width = nam.label11.Width;
                                        table.labn12.Visibility = Visibility.Visible;
                                    }
                                    break;
                                default:
                                    break;

                            }
                            labncontent = (string)table.labn1.Text + " " + table.labn2.Text + " " + table.labn3.Text + " " + table.labn4.Text + " " + table.labn5.Text + " " + table.labn6.Text + " " + table.labn7.Text + " " + table.labn8.Text + " " + table.labn9.Text + " " + table.labn10.Text + " " + table.labn11.Text + " " + table.labn12.Text;
                            boolsearch = labncontent.ToLower().IndexOf(textBoxSearch.Text.ToLower());
                            if (boolsearch != -1)
                                StackPanel1.Children.Add(table);
                        }//выгрузка таблиц
                    }
                }//показывает таблицы, если комбобокс не пустой
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source =LOCALHOST\SQLEXPRESS; Initial Catalog = MuzBD; Integrated Security = true;"))
            {
                connection.Open();
                string Where = "";
                int size = 2;
                switch (comboBox.Text)//запросы
                {
                    case "Библиотека":
                        Where = $@"INSERT INTO [dbo].[Библиотека]";
                        break;
                    case "Группы":
                        Where = $@"INSERT INTO [dbo].[Группы]";
                        break;
                    case "Договоры":
                        Where = $@"INSERT INTO [dbo].[Договоры]";
                        break;
                    case "Должности":
                        Where = $@"INSERT INTO [dbo].[Должности]";
                        break;
                    case "Занятия":
                        Where = $@"INSERT INTO [dbo].[Занятия]'";
                        break;
                    case "Заочники":
                        Where = $@"INSERT INTO [dbo].[Заочники]";
                        break;
                    case "Кабинеты":
                        Where = $@"INSERT INTO [dbo].[Кабинеты]";
                        break;
                    case "Мероприятия":
                        Where = $@"INSERT INTO [dbo].[Мероприятия]";
                        break;
                    case "Музыкальные инструменты":
                        Where = $@"INSERT INTO [dbo].[Музыкальные инструменты]";
                        break;
                    case "Назначение кабинета":
                        Where = $@"INSERT INTO [dbo].[Назначение кабинета]";
                        break;
                    case "Направления":
                        Where = $@"INSERT INTO [dbo].[Направления]";
                        break;
                    case "Оборудование":
                        Where = $@"INSERT INTO [dbo].[Оборудование]";
                        break;
                    case "Организационная структура":
                        Where = $@"INSERT INTO [dbo].[Организационная структура]";
                        break;
                    case "Очники":
                        Where = $@"INSERT INTO [dbo].[Очники]";
                        break;
                    case "Паспортные данные":
                        Where = $@"INSERT INTO [dbo].[Паспортные данные]";
                        break;
                    case "Под_успеваемость":
                        Where = $@"INSERT INTO [dbo].[Под_успеваемость]";
                        break;
                    case "Предметы":
                        Where = $@"INSERT INTO [dbo].[Предметы]";
                        break;
                    case "Рекламные кампании":
                        Where = $@"INSERT INTO [dbo].[Рекламные кампании]";
                        break;
                    case "Сотрудники":
                        Where = $@"INSERT INTO [dbo].[Сотрудники]";
                        break;
                    case "Тип договора":
                        Where = $@"INSERT INTO [dbo].[Тип договора]";
                        break;
                    case "Тип музыкального инструмента":
                        Where = $@"INSERT INTO [dbo].[Тип музыкального инструмента]";
                        break;
                    case "Тип рекламы":
                        Where = $@"INSERT INTO [dbo].[Тип рекламы]";
                        break;
                    case "Успеваемость":
                        Where = $@"INSERT INTO [dbo].[Успеваемость]";
                        break;
                    default:
                        break;
                }//запросы
                SqlCommand cmd = new SqlCommand($@"{Where}", connection);
                if (comboBox.Text != "")//показывает таблицы, если комбобокс не пустой
                {
                    Table = comboBox.Text;
                    StackPanel1.Children.Clear();
                    UserControl2 nam = new UserControl2();
                    string[] atribs = { "", "", "", "", "", "", "", "", "", "", "", "" };
                    switch (comboBox.Text) //добавление названия столбцов
                    {
                        case "Библиотека":
                            atribs[0] = "Код книги";
                            atribs[1] = "Название";
                            atribs[2] = "Автор";
                            atribs[3] = "Год изд.";
                            size = 4;
                            break;
                        case "Группы":
                            atribs[0] = "Название ";
                            atribs[1] = "Код направ.";
                            break;
                        case "Договоры":
                            atribs[0] = "Код договора";
                            atribs[1] = "Код типа договора";
                            atribs[2] = "Дата подписания";
                            atribs[3] = "Окончание действия";
                            atribs[4] = "Стоимость";
                            size = 5;
                            break;
                        case "Должности":
                            atribs[0] = "Код должности";
                            atribs[1] = "Код отдела";
                            atribs[2] = "Наименование";
                            size = 3;
                            break;
                        case "Занятия":
                            atribs[0] = "Дата занятия";
                            atribs[1] = "Код предмета";
                            atribs[2] = "Номер кабинета";
                            size = 3;
                            break;
                        case "Заочники":
                            atribs[0] = "Код заочника";
                            atribs[1] = "Код договора";
                            atribs[2] = "Серия и номер";
                            atribs[3] = "Фамилия";
                            atribs[4] = "Имя";
                            atribs[5] = "Отчество";
                            atribs[6] = "Дата рождения";
                            atribs[7] = "Номер телефона";
                            atribs[8] = "Email";
                            size = 9;
                            break;
                        case "Кабинеты":
                            atribs[0] = "Номер кабинета";
                            atribs[1] = "Код назначения";
                            break;
                        case "Мероприятия":
                            atribs[0] = "Дата проведения";
                            atribs[1] = "Место проведения";
                            atribs[2] = "Название";
                            size = 3;
                            break;
                        case "Музыкальные инструменты":
                            atribs[0] = "Код инструмента";
                            atribs[1] = "Тип инструмента";
                            atribs[2] = "Полное название инструмента";
                            size = 3;
                            break;
                        case "Назначение кабинета":
                            atribs[0] = "Код назначения";
                            atribs[1] = "Назначение";
                            break;
                        case "Направления":
                            atribs[0] = "Код направления";
                            atribs[1] = "Название";
                            break;
                        case "Оборудование":
                            atribs[0] = "Код оборудование";
                            atribs[1] = "Номер кабинета";
                            atribs[2] = "Название оборудования";
                            size = 3;
                            break;
                        case "Организационная структура":
                            atribs[0] = "Код отдела";
                            atribs[1] = "Название";
                            break;
                        case "Очники":
                            atribs[0] = "Код очника";
                            atribs[1] = "Код направления";
                            atribs[2] = "Название группы";
                            atribs[3] = "Серия и номер";
                            atribs[4] = "Фамилия";
                            atribs[5] = "Имя";
                            atribs[6] = "Отчество";
                            atribs[7] = "Дата рождения";
                            atribs[8] = "Адрес проживания";
                            atribs[9] = "Номер телефона";
                            atribs[10] = "Email";
                            size = 11;
                            break;
                        case "Паспортные данные":
                            atribs[0] = "Серия и номер";
                            atribs[1] = "Дата выдачи";
                            atribs[2] = "Кем выдано";
                            atribs[3] = "Место прописки";
                            size = 4;
                            break;
                        case "Под_успеваемость":
                            atribs[0] = "Код под_успеваемости";
                            atribs[1] = "Код успеваемости";
                            atribs[2] = "Код очника";
                            atribs[3] = "Оценка";
                            size = 4;
                            break;
                        case "Предметы":
                            atribs[0] = "Код предмета";
                            atribs[1] = "Название";
                            break;
                        case "Рекламные кампании":
                            atribs[0] = "Код кампании";
                            atribs[1] = "Тип рекламы";
                            atribs[2] = "Дата операции";
                            atribs[3] = "Стоимость";
                            size = 4;
                            break;
                        case "Сотрудники":
                            atribs[0] = "Код сотрудника";
                            atribs[1] = "Код должности";
                            atribs[2] = "Серия и номер";
                            atribs[3] = "Фамилия";
                            atribs[4] = "Имя";
                            atribs[5] = "Отчество";
                            atribs[6] = "Ставка";
                            atribs[7] = "Адрес проживания";
                            atribs[8] = "Дата рождения";
                            atribs[9] = "Номер телефона";
                            atribs[10] = "Email";
                            atribs[11] = "Образование";
                            size = 12;
                            break;
                        case "Тип договора":
                            atribs[0] = "Код типа договора";
                            atribs[1] = "Тип договора";
                            size = 2;
                            break;
                        case "Тип музыкального инструмента":
                            atribs[0] = "Код типа инструмента";
                            atribs[1] = "Название типа инструмента";
                            break;
                        case "Тип рекламы":
                            atribs[0] = "Код типа рекламы";
                            atribs[1] = "Тип рекламы";
                            break;
                        case "Успеваемость":
                            atribs[0] = "Код успеваемости";
                            atribs[1] = "Название группы";
                            atribs[2] = "Код предмета";
                            size = 3;
                            break;
                        default:
                            break;
                    }//добавление названия столбцов
                    nam.label.Content = atribs[0];
                    nam.label1.Content = atribs[1];
                    nam.label2.Content = atribs[2];
                    nam.label3.Content = atribs[3];
                    nam.label4.Content = atribs[4];
                    nam.label5.Content = atribs[5];
                    nam.label6.Content = atribs[6];
                    nam.label7.Content = atribs[7];
                    nam.label8.Content = atribs[8];
                    nam.label9.Content = atribs[9];
                    nam.label10.Content = atribs[10];
                    nam.label11.Content = atribs[11];
                    StackPanel1.Children.Add(nam);
                    for (int i = 0; i < atribs.Length - 1; i++)
                    {
                        atribs[i] = "";
                    }
                    UserControl3 table = new UserControl3();
                    table.textBox.Text = "";
                    table.textBox.Width = nam.label.Width;
                    table.textBox.Visibility = Visibility.Hidden;
                    table.textBox1.Text = "";
                    table.textBox1.Width = nam.label1.Width;
                    table.textBox1.Visibility = Visibility.Hidden;
                    table.textBox2.Text = "";
                    table.textBox2.Width = nam.label2.Width;
                    table.textBox2.Visibility = Visibility.Hidden;
                    table.textBox3.Text = "";
                    table.textBox3.Width = nam.label3.Width;
                    table.textBox3.Visibility = Visibility.Hidden;
                    table.textBox4.Text = "";
                    table.textBox4.Width = nam.label4.Width;
                    table.textBox4.Visibility = Visibility.Hidden;
                    table.textBox5.Text = "";
                    table.textBox5.Width = nam.label5.Width;
                    table.textBox5.Visibility = Visibility.Hidden;
                    table.textBox6.Text = "";
                    table.textBox6.Width = nam.label6.Width;
                    table.textBox6.Visibility = Visibility.Hidden;
                    table.textBox7.Text = "";
                    table.textBox7.Width = nam.label7.Width;
                    table.textBox7.Visibility = Visibility.Hidden;
                    table.textBox8.Text = "";
                    table.textBox8.Width = nam.label8.Width;
                    table.textBox8.Visibility = Visibility.Hidden;
                    table.textBox9.Text = "";
                    table.textBox9.Width = nam.label9.Width;
                    table.textBox9.Visibility = Visibility.Hidden;
                    table.textBox10.Text = "";
                    table.textBox10.Width = nam.label10.Width;
                    table.textBox10.Visibility = Visibility.Hidden;
                    table.textBox11.Text = "";
                    table.textBox11.Width = nam.label11.Width;
                    table.textBox11.Visibility = Visibility.Hidden;
                    switch (size)
                    {
                        case 2:
                            {
                                table.textBox.Text = "";
                                table.textBox.Width = nam.label.Width;
                                table.textBox.Visibility = Visibility.Visible;
                                table.textBox1.Text = "";
                                table.textBox1.Width = nam.label1.Width;
                                table.textBox1.Visibility = Visibility.Visible;
                            }
                            break;
                        case 3:
                            {
                                table.textBox.Text = "";
                                table.textBox.Width = nam.label.Width;
                                table.textBox.Visibility = Visibility.Visible;
                                table.textBox1.Text = "";
                                table.textBox1.Width = nam.label1.Width;
                                table.textBox1.Visibility = Visibility.Visible;
                                table.textBox2.Text = "";
                                table.textBox2.Width = nam.label2.Width;
                                table.textBox2.Visibility = Visibility.Visible;
                            }
                            break;
                        case 4:
                            {
                                table.textBox.Text = "";
                                table.textBox.Width = nam.label.Width;
                                table.textBox.Visibility = Visibility.Visible;
                                table.textBox1.Text = "";
                                table.textBox1.Width = nam.label1.Width;
                                table.textBox1.Visibility = Visibility.Visible;
                                table.textBox2.Text = "";
                                table.textBox2.Width = nam.label2.Width;
                                table.textBox2.Visibility = Visibility.Visible;
                                table.textBox3.Text = "";
                                table.textBox3.Width = nam.label3.Width;
                                table.textBox3.Visibility = Visibility.Visible;
                            }
                            break;
                        case 5:
                            {
                                table.textBox.Text = "";
                                table.textBox.Width = nam.label.Width;
                                table.textBox.Visibility = Visibility.Visible;
                                table.textBox1.Text = "";
                                table.textBox1.Width = nam.label1.Width;
                                table.textBox1.Visibility = Visibility.Visible;
                                table.textBox2.Text = "";
                                table.textBox2.Width = nam.label2.Width;
                                table.textBox2.Visibility = Visibility.Visible;
                                table.textBox3.Text = "";
                                table.textBox3.Width = nam.label3.Width;
                                table.textBox3.Visibility = Visibility.Visible;
                                table.textBox4.Text = "";
                                table.textBox4.Width = nam.label4.Width;
                                table.textBox4.Visibility = Visibility.Visible;
                            }
                            break;
                        case 6:
                            {
                                table.textBox.Text = "";
                                table.textBox.Width = nam.label.Width;
                                table.textBox.Visibility = Visibility.Visible;
                                table.textBox1.Text = "";
                                table.textBox1.Width = nam.label1.Width;
                                table.textBox1.Visibility = Visibility.Visible;
                                table.textBox2.Text = "";
                                table.textBox2.Width = nam.label2.Width;
                                table.textBox2.Visibility = Visibility.Visible;
                                table.textBox3.Text = "";
                                table.textBox3.Width = nam.label3.Width;
                                table.textBox3.Visibility = Visibility.Visible;
                                table.textBox4.Text = "";
                                table.textBox4.Width = nam.label4.Width;
                                table.textBox4.Visibility = Visibility.Visible;
                                table.textBox5.Text = "";
                                table.textBox5.Width = nam.label5.Width;
                                table.textBox5.Visibility = Visibility.Visible;
                            }
                            break;
                        case 7:
                            {
                                table.textBox.Text = "";
                                table.textBox.Width = nam.label.Width;
                                table.textBox.Visibility = Visibility.Visible;
                                table.textBox1.Text = "";
                                table.textBox1.Width = nam.label1.Width;
                                table.textBox1.Visibility = Visibility.Visible;
                                table.textBox2.Text = "";
                                table.textBox2.Width = nam.label2.Width;
                                table.textBox2.Visibility = Visibility.Visible;
                                table.textBox3.Text = "";
                                table.textBox3.Width = nam.label3.Width;
                                table.textBox3.Visibility = Visibility.Visible;
                                table.textBox4.Text = "";
                                table.textBox4.Width = nam.label4.Width;
                                table.textBox4.Visibility = Visibility.Visible;
                                table.textBox5.Text = "";
                                table.textBox5.Width = nam.label5.Width;
                                table.textBox5.Visibility = Visibility.Visible;
                                table.textBox6.Text = "";
                                table.textBox6.Width = nam.label6.Width;
                                table.textBox6.Visibility = Visibility.Visible;
                            }
                            break;
                        case 8:
                            {
                                table.textBox.Text = "";
                                table.textBox.Width = nam.label.Width;
                                table.textBox.Visibility = Visibility.Visible;
                                table.textBox1.Text = "";
                                table.textBox1.Width = nam.label1.Width;
                                table.textBox1.Visibility = Visibility.Visible;
                                table.textBox2.Text = "";
                                table.textBox2.Width = nam.label2.Width;
                                table.textBox2.Visibility = Visibility.Visible;
                                table.textBox3.Text = "";
                                table.textBox3.Width = nam.label3.Width;
                                table.textBox3.Visibility = Visibility.Visible;
                                table.textBox4.Text = "";
                                table.textBox4.Width = nam.label4.Width;
                                table.textBox4.Visibility = Visibility.Visible;
                                table.textBox5.Text = "";
                                table.textBox5.Width = nam.label5.Width;
                                table.textBox5.Visibility = Visibility.Visible;
                                table.textBox6.Text = "";
                                table.textBox6.Width = nam.label6.Width;
                                table.textBox6.Visibility = Visibility.Visible;
                                table.textBox7.Text = "";
                                table.textBox7.Width = nam.label7.Width;
                                table.textBox7.Visibility = Visibility.Visible;
                            }
                            break;
                        case 9:
                            {
                                table.textBox.Text = "";
                                table.textBox.Width = nam.label.Width;
                                table.textBox.Visibility = Visibility.Visible;
                                table.textBox1.Text = "";
                                table.textBox1.Width = nam.label1.Width;
                                table.textBox1.Visibility = Visibility.Visible;
                                table.textBox2.Text = "";
                                table.textBox2.Width = nam.label2.Width;
                                table.textBox2.Visibility = Visibility.Visible;
                                table.textBox3.Text = "";
                                table.textBox3.Width = nam.label3.Width;
                                table.textBox3.Visibility = Visibility.Visible;
                                table.textBox4.Text = "";
                                table.textBox4.Width = nam.label4.Width;
                                table.textBox4.Visibility = Visibility.Visible;
                                table.textBox5.Text = "";
                                table.textBox5.Width = nam.label5.Width;
                                table.textBox5.Visibility = Visibility.Visible;
                                table.textBox6.Text = "";
                                table.textBox6.Width = nam.label6.Width;
                                table.textBox6.Visibility = Visibility.Visible;
                                table.textBox7.Text = "";
                                table.textBox7.Width = nam.label7.Width;
                                table.textBox7.Visibility = Visibility.Visible;
                                table.textBox8.Text = "";
                                table.textBox8.Width = nam.label8.Width;
                                table.textBox8.Visibility = Visibility.Visible;
                            }
                            break;
                        case 10:
                            {
                                table.textBox.Text = "";
                                table.textBox.Width = nam.label.Width;
                                table.textBox.Visibility = Visibility.Visible;
                                table.textBox1.Text = "";
                                table.textBox1.Width = nam.label1.Width;
                                table.textBox1.Visibility = Visibility.Visible;
                                table.textBox2.Text = "";
                                table.textBox2.Width = nam.label2.Width;
                                table.textBox2.Visibility = Visibility.Visible;
                                table.textBox3.Text = "";
                                table.textBox3.Width = nam.label3.Width;
                                table.textBox3.Visibility = Visibility.Visible;
                                table.textBox4.Text = "";
                                table.textBox4.Width = nam.label4.Width;
                                table.textBox4.Visibility = Visibility.Visible;
                                table.textBox5.Text = "";
                                table.textBox5.Width = nam.label5.Width;
                                table.textBox5.Visibility = Visibility.Visible;
                                table.textBox6.Text = "";
                                table.textBox6.Width = nam.label6.Width;
                                table.textBox6.Visibility = Visibility.Visible;
                                table.textBox7.Text = "";
                                table.textBox7.Width = nam.label7.Width;
                                table.textBox7.Visibility = Visibility.Visible;
                                table.textBox8.Text = "";
                                table.textBox8.Width = nam.label8.Width;
                                table.textBox8.Visibility = Visibility.Visible;
                                table.textBox9.Text = "";
                                table.textBox9.Width = nam.label9.Width;
                                table.textBox9.Visibility = Visibility.Visible;
                            }
                            break;
                        case 11:
                            {
                                table.textBox.Text = "";
                                table.textBox.Width = nam.label.Width;
                                table.textBox.Visibility = Visibility.Visible;
                                table.textBox1.Text = "";
                                table.textBox1.Width = nam.label1.Width;
                                table.textBox1.Visibility = Visibility.Visible;
                                table.textBox2.Text = "";
                                table.textBox2.Width = nam.label2.Width;
                                table.textBox2.Visibility = Visibility.Visible;
                                table.textBox3.Text = "";
                                table.textBox3.Width = nam.label3.Width;
                                table.textBox3.Visibility = Visibility.Visible;
                                table.textBox4.Text = "";
                                table.textBox4.Width = nam.label4.Width;
                                table.textBox4.Visibility = Visibility.Visible;
                                table.textBox5.Text = "";
                                table.textBox5.Width = nam.label5.Width;
                                table.textBox5.Visibility = Visibility.Visible;
                                table.textBox6.Text = "";
                                table.textBox6.Width = nam.label6.Width;
                                table.textBox6.Visibility = Visibility.Visible;
                                table.textBox7.Text = "";
                                table.textBox7.Width = nam.label7.Width;
                                table.textBox7.Visibility = Visibility.Visible;
                                table.textBox8.Text = "";
                                table.textBox8.Width = nam.label8.Width;
                                table.textBox8.Visibility = Visibility.Visible;
                                table.textBox9.Text = "";
                                table.textBox9.Width = nam.label9.Width;
                                table.textBox9.Visibility = Visibility.Visible;
                                table.textBox10.Text = "";
                                table.textBox10.Width = nam.label10.Width;
                                table.textBox10.Visibility = Visibility.Visible;
                            }
                            break;
                        case 12:
                            {
                                table.textBox.Text = "";
                                table.textBox.Width = nam.label.Width;
                                table.textBox.Visibility = Visibility.Visible;
                                table.textBox1.Text = "";
                                table.textBox1.Width = nam.label1.Width;
                                table.textBox1.Visibility = Visibility.Visible;
                                table.textBox2.Text = "";
                                table.textBox2.Width = nam.label2.Width;
                                table.textBox2.Visibility = Visibility.Visible;
                                table.textBox3.Text = "";
                                table.textBox3.Width = nam.label3.Width;
                                table.textBox3.Visibility = Visibility.Visible;
                                table.textBox4.Text = "";
                                table.textBox4.Width = nam.label4.Width;
                                table.textBox4.Visibility = Visibility.Visible;
                                table.textBox5.Text = "";
                                table.textBox5.Width = nam.label5.Width;
                                table.textBox5.Visibility = Visibility.Visible;
                                table.textBox6.Text = "";
                                table.textBox6.Width = nam.label6.Width;
                                table.textBox6.Visibility = Visibility.Visible;
                                table.textBox7.Text = "";
                                table.textBox7.Width = nam.label7.Width;
                                table.textBox7.Visibility = Visibility.Visible;
                                table.textBox8.Text = "";
                                table.textBox8.Width = nam.label8.Width;
                                table.textBox8.Visibility = Visibility.Visible;
                                table.textBox9.Text = "";
                                table.textBox9.Width = nam.label9.Width;
                                table.textBox9.Visibility = Visibility.Visible;
                                table.textBox10.Text = "";
                                table.textBox10.Width = nam.label10.Width;
                                table.textBox10.Visibility = Visibility.Visible;
                                table.textBox11.Text = "";
                                table.textBox11.Width = nam.label11.Width;
                                table.textBox11.Visibility = Visibility.Visible;
                            }
                            break;
                        default:
                            break;

                    }
                    StackPanel1.Children.Add(table);
                    //выгрузка таблиц

                }//показывает таблицы, если комбобокс не пустой
            }
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            Sort = textBox.Text;
            Order = $"ORDER BY {Sort}";
            button1_Click(sender, e);
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            Sort = textBox.Text;
            Order = $"ORDER BY {Sort} DESC";
            button1_Click(sender, e);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox.Text = "1";
        }
    }
}
