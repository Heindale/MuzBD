using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MuzBD
{
    /// <summary>
    /// Логика взаимодействия для UserControl3.xaml
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source =LOCALHOST\SQLEXPRESS; Initial Catalog = MuzBD; Integrated Security = true;"))
                {
                    connection.Open();
                    string Where = "";
                    Window1 window1 = new Window1();
                    string tab = Window1.Table;
                    switch (tab)//запросы
                    {
                        case "Библиотека":
                            Where = $@"INSERT INTO [dbo].[Библиотека] ([Название], [Автор], [Год издания]) VALUES ('{textBox1.Text}', '{textBox2.Text}', {textBox3.Text})";
                            break;
                        case "Группы":
                            Where = $@"INSERT INTO [dbo].[Группы] VALUES ('{textBox.Text}', {textBox1.Text})";
                            break;
                        case "Договоры":
                            Where = $@"INSERT INTO [dbo].[Договоры] ([Код типа договора], [Дата подписания], [Дата окончания действия], [Стоимость]) VALUES ({textBox1.Text}, '{textBox2.Text}', '{textBox3.Text}', {textBox4.Text})";
                            break;
                        case "Должности":
                            Where = $@"INSERT INTO [dbo].[Должности] ([Код отдела], [Наименование должности]) VALUES ({textBox1.Text}, '{textBox2.Text}')";
                            break;
                        case "Занятия":
                            Where = $@"INSERT INTO [dbo].[Занятия] VALUES ('{textBox.Text}', {textBox1.Text}, {textBox2.Text})";
                            break;
                        case "Заочники":
                            Where = $@"INSERT INTO [dbo].[Заочники] ([Код договора], [Серия и номер], [Фамилия], [Имя], [Отчество], [Номер телефона], [Email]) VALUES ({textBox1.Text}, {textBox2.Text}, '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}', {textBox6.Text}, '{textBox7.Text}')";
                            break;
                        case "Кабинеты":
                            Where = $@"INSERT INTO [dbo].[Кабинеты] VALUES ({textBox.Text}, {textBox1.Text})";
                            break;
                        case "Мероприятия":
                            Where = $@"INSERT INTO [dbo].[Мероприятия] VALUES ('{textBox.Text}', '{textBox1.Text}', '{textBox2.Text}')";
                            break;
                        case "Музыкальные инструменты":
                            Where = $@"INSERT INTO [dbo].[Музыкальные инструменты] ([Код типа инструмента], [Полное название инструмента]) VALUES ({textBox1.Text}, '{textBox2.Text}')";
                            break;
                        case "Назначение кабинета":
                            Where = $@"INSERT INTO [dbo].[Назначение кабинета] ([Назначение]) VALUES ('{textBox1.Text}')";
                            break;
                        case "Направления":
                            Where = $@"INSERT INTO [dbo].[Направления] ([Название направления]) VALUES ('{textBox1.Text}')";
                            break;
                        case "Оборудование":
                            Where = $@"INSERT INTO [dbo].[Оборудование] ([Номер кабинета], [Название оборудования]) VALUES ({textBox1.Text}, '{textBox2.Text}')";
                            break;
                        case "Организационная структура":
                            Where = $@"INSERT INTO [dbo].[Организационная структура] ([Наименование отдела]) VALUES ('{textBox1.Text}')";
                            break;
                        case "Очники":
                            Where = $@"INSERT INTO [dbo].[Очники] ([Код направления], [Название группы], [Серия и номер], [Фамилия], [Имя], [Отчество], [Дата рождения], [Адрес проживания], [Номер телефона], [Email]) VALUES ({textBox1.Text}, '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}', '{textBox7.Text}', '{textBox8.Text}', '{textBox9.Text}', '{textBox10.Text}')";
                            break;
                        case "Паспортные данные":
                            Where = $@"INSERT INTO [dbo].[Паспортные данные] VALUES ({textBox.Text}, '{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}')";
                            break;
                        case "Под_успеваемость":
                            Where = $@"INSERT INTO [dbo].[Под_успеваемость] ([Код успеваемости], [Код очника], [Оценка]) VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}')";
                            break;
                        case "Предметы":
                            Where = $@"INSERT INTO [dbo].[Предметы] ([Название предмета]) VALUES ('{textBox1.Text}')";
                            break;
                        case "Рекламные кампании":
                            Where = $@"INSERT INTO [dbo].[Рекламные кампании] ([Код типа рекламы], [Дата операции], [Стоимость]) VALUES ({textBox1.Text}, '{textBox2.Text}', {textBox3.Text})";
                            break;
                        case "Сотрудники":
                            Where = $@"INSERT INTO [dbo].[Сотрудники] ([Код должности], [Серия и номер], [Фамилия], [Имя], [Отчество], [Ставка], [Адрес проживания], [Дата рождения], [Номер телефона], [Email], [Образование]) VALUES ({textBox1.Text}, {textBox2.Text}, {textBox3.Text}, '{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}', {textBox7.Text}, '{textBox8.Text}', '{textBox9.Text}', '{textBox10.Text}', '{textBox11.Text}')";
                            break;
                        case "Тип договора":
                            Where = $@"INSERT INTO [dbo].[Тип договора] ([Тип договора]) VALUES ('{textBox1.Text}')";
                            break;
                        case "Тип музыкального инструмента":
                            Where = $@"INSERT INTO [dbo].[Тип музыкального инструмента] ([Название типа инструмента]) VALUES ('{textBox1.Text}')";
                            break;
                        case "Тип рекламы":
                            Where = $@"INSERT INTO [dbo].[Тип рекламы] ([Тип рекламы]) VALUES ('{textBox1.Text}')";
                            break;
                        case "Успеваемость":
                            Where = $@"INSERT INTO [dbo].[Успеваемость] ([Название группы], [Код предмета]) VALUES ('{textBox1.Text}', {textBox2.Text})";
                            break;
                        default:
                            break;
                    }//запросы
                    SqlCommand cmd = new SqlCommand($"{Where}", connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    window1.button1_Click(sender, e);
                    MessageBox.Show("Данные внесены!", "Успех!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так :(", "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
