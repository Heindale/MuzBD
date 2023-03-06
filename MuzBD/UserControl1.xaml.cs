using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MuzBD
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            if (MainWindow.us)
            {
                button.IsEnabled = false;
                button1.IsEnabled = false;
            }
        }
        private protected void button_Click(object sender, RoutedEventArgs e)
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
                            Where = $@"UPDATE [dbo].[Библиотека] SET [Название] = '{labn2.Text}', [Автор] = '{labn3.Text}', [Год издания] = {labn4.Text} WHERE [Код книги] = {labn1.Text}";
                            break;
                        case "Группы":
                            Where = $"UPDATE [dbo].[Группы] SET [Код направления] = {labn2.Text} WHERE [Название группы] = '{labn1.Text}'";
                            break;
                        case "Договоры":
                            Where = $"UPDATE [dbo].[Договоры] SET [Код типа договора] = {labn2.Text}, [Дата подписания] = '{labn3.Text}', [Дата окончания действия] = '{labn4.Text}', [Стоимость] = {labn5.Text} WHERE [Код договора] = {labn1.Text}";
                            break;
                        case "Должности":
                            Where = $"UPDATE [dbo].[Должности] SET [Код отдела] = {labn2.Text}, [Наименование должности] = '{labn3.Text}' WHERE [Код должности] = {labn1.Text}";
                            break;
                        case "Занятия":
                            Where = $"UPDATE [dbo].[Занятия] SET [Код предмета] = {labn2.Text}, [Номер кабинета] = {labn3.Text} WHERE [Дата занятия] = '{labn1.Text}'";
                            break;
                        case "Заочники":
                            Where = $"UPDATE [dbo].[Заочники] SET [Код договора] = {labn2.Text}, [Серия и номер] = '{labn3.Text}', [Фамилия] = '{labn4.Text}', [Имя] = '{labn5.Text}', [Отчество] = '{labn6.Text}', [Дата рождения] = '{labn7.Text}', [Номер телефона] = '{labn8.Text}', [Email] = '{labn9.Text}' WHERE [Код заочника] = {labn1.Text}";
                            break;
                        case "Кабинеты":
                            Where = $"UPDATE [dbo].[Кабинеты] SET [Код назначения] = {labn2.Text} WHERE [Номер кабинета] = {labn1.Text}";
                            break;
                        case "Мероприятия":
                            Where = $"UPDATE [dbo].[Мероприятия] SET [Место проведения] = '{labn2.Text}', [Название] = '{labn3.Text}' WHERE [Дата проведения] = '{labn1.Text}'";
                            break;
                        case "Музыкальные инструменты":
                            Where = $"UPDATE [dbo].[Музыкальные инструменты] SET [Код типа инструмента] = {labn2.Text}, [Полное название инструмента] = '{labn3.Text}' WHERE [Код музыкального инструмента] = {labn1.Text}";
                            break;
                        case "Назначение кабинета":
                            Where = $"UPDATE [dbo].[Назначение кабинета] SET [Назначение] = '{labn2.Text}' WHERE [Код назначения] = {labn1.Text}";
                            break;
                        case "Направления":
                            Where = $"UPDATE [dbo].[Направления] SET [Название направления] = '{labn2.Text}' WHERE [Код направления] = {labn1.Text}";
                            break;
                        case "Оборудование":
                            Where = $"UPDATE [dbo].[Оборудование] SET [Номер кабинета] = {labn2.Text}, [Название оборудования] = '{labn3.Text}' WHERE [Код оборудования] = {labn1.Text}";
                            break;
                        case "Организационная структура":
                            Where = $"UPDATE [dbo].[Организационная структура] SET [Наименование отдела] = '{labn2.Text}' WHERE [Код отдела] = {labn1.Text}";
                            break;
                        case "Очники":
                            Where = $"UPDATE [dbo].[Очники] SET [Код направления] = {labn2.Text}, [Название группы] = '{labn3.Text}', [Серия и номер] = '{labn4.Text}', [Фамилия] = '{labn5.Text}', [Имя] = '{labn6.Text}', [Отчество] = '{labn7.Text}', [Дата рождения] = '{labn8.Text}', [Адрес проживания] = '{labn9.Text}', [Номер телефона] = '{labn10.Text}', [Email] = '{labn11.Text}' WHERE [Код очника] = {labn1.Text}";
                            break;
                        case "Паспортные данные":
                            Where = $"UPDATE [dbo].[Паспортные данные] SET [Дата выдачи] = '{labn2.Text}', [Кем выдано] = '{labn3.Text}', [Место прописки] = '{labn4.Text}' WHERE [Серия и номер] = '{labn1.Text}'";
                            break;
                        case "Под_успеваемость":
                            Where = $"UPDATE [dbo].[Под_успеваемость] SET [Код успеваемости] = {labn2.Text}, [Код очника] = {labn3.Text}, [Оценка] = {labn4.Text} WHERE [Код под_успеваемости] = {labn1.Text}";
                            break;
                        case "Предметы":
                            Where = $"UPDATE [dbo].[Предметы] SET [Название предмета] = '{labn2.Text}' WHERE [Код предмета] = {labn1.Text}";
                            break;
                        case "Рекламные кампании":
                            Where = $"UPDATE [dbo].[Рекламные кампании] SET [Код типа рекламы] = {labn2.Text}, [Дата операции] = '{labn3.Text}', [Стоимость] = {labn4.Text} WHERE [Код рекламной кампании] = {labn1.Text}";
                            break;
                        case "Сотрудники":
                            Where = $"UPDATE [dbo].[Сотрудники] SET [Код должности] = {labn2.Text}, [Серия и номер] = '{labn3.Text}', [Фамилия] = '{labn4.Text}', [Имя] = '{labn5.Text}', [Отчество] = '{labn6.Text}', [Ставка] = {labn7.Text}, [Адрес проживания] = '{labn8.Text}', [Дата рождения] = '{labn9.Text}', [Номер телефона] = '{labn10.Text}', [Email] = '{labn11.Text}', [Образование] = '{labn12.Text}' WHERE [Код сотрудника] = {labn1.Text}";
                            break;
                        case "Тип договора":
                            Where = $"UPDATE [dbo].[Тип договора] SET [Тип договора] = '{labn2.Text}' WHERE [Код типа договора] = {labn1.Text}";
                            break;
                        case "Тип музыкального инструмента":
                            Where = $"UPDATE [dbo].[Тип музыкального инструмента] SET [Название типа инструмента] = '{labn2.Text}' WHERE [Код типа инструмента] = {labn1.Text}";
                            break;
                        case "Тип рекламы":
                            Where = $"UPDATE [dbo].[Тип рекламы] SET [Тип рекламы] = '{labn2.Text}' WHERE [Код тпа рекламы] = {labn1.Text}";
                            break;
                        case "Успеваемость":
                            Where = $"UPDATE [dbo].[Успеваемость] SET [Название группы] = '{labn2.Text}', [Код предмета] = {labn3.Text} WHERE [Код успеваемости] = {labn1.Text}";
                            break;
                        default:
                            break;
                    }
                    SqlCommand cmd = new SqlCommand($"{Where}", connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    window1.button1_Click(sender, e);
                    MessageBox.Show("Данные обновлены!", "Успех!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так :(", "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
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
                            Where = $@"DELETE FROM [dbo].[Библиотека] WHERE [Код книги] = {labn1.Text}";
                            break;
                        case "Группы":
                            Where = $"DELETE FROM [dbo].[Группы] WHERE [Название группы] = '{labn1.Text}'";
                            break;
                        case "Договоры":
                            Where = $"DELETE FROM [dbo].[Договоры] WHERE [Код договора] = {labn1.Text}";
                            break;
                        case "Должности":
                            Where = $"DELETE FROM [dbo].[Должности] WHERE [Код должности] = {labn1.Text}";
                            break;
                        case "Занятия":
                            Where = $"DELETE FROM [dbo].[Занятия] WHERE [Дата занятия] = '{labn1.Text}'";
                            break;
                        case "Заочники":
                            Where = $"DELETE FROM [dbo].[Заочники] WHERE [Код заочника] = {labn1.Text}";
                            break;
                        case "Кабинеты":
                            Where = $"DELETE FROM [dbo].[Кабинеты] WHERE [Номер кабинета] = {labn1.Text}";
                            break;
                        case "Мероприятия":
                            Where = $"DELETE FROM [dbo].[Мероприятия] WHERE [Дата проведения] = '{labn1.Text}'";
                            break;
                        case "Музыкальные инструменты":
                            Where = $"DELETE FROM [dbo].[Музыкальные инструменты] WHERE [Код музыкального инструмента] = {labn1.Text}";
                            break;
                        case "Назначение кабинета":
                            Where = $"DELETE FROM [dbo].[Назначение кабинета] WHERE [Код назначения] = {labn1.Text}";
                            break;
                        case "Направления":
                            Where = $"DELETE FROM [dbo].[Направления] WHERE [Код направления] = {labn1.Text}";
                            break;
                        case "Оборудование":
                            Where = $"DELETE FROM [dbo].[Оборудование] WHERE [Код оборудования] = {labn1.Text}";
                            break;
                        case "Организационная структура":
                            Where = $"DELETE FROM [dbo].[Организационная структура] WHERE [Код отдела] = {labn1.Text}";
                            break;
                        case "Очники":
                            Where = $"DELETE FROM [dbo].[Очники] WHERE [Код очника] = {labn1.Text}";
                            break;
                        case "Паспортные данные":
                            Where = $"DELETE FROM [dbo].[Паспортные данные] WHERE [Серия и номер] = '{labn1.Text}'";
                            break;
                        case "Под_успеваемость":
                            Where = $"DELETE FROM [dbo].[Под_успеваемость] WHERE [Код под_успеваемости] = {labn1.Text}";
                            break;
                        case "Предметы":
                            Where = $"DELETE FROM [dbo].[Предметы] WHERE [Код предмета] = {labn1.Text}";
                            break;
                        case "Рекламные кампании":
                            Where = $"DELETE FROM [dbo].[Рекламные кампании] WHERE [Код рекламной кампании] = {labn1.Text}";
                            break;
                        case "Сотрудники":
                            Where = $"DELETE FROM [dbo].[Сотрудники] WHERE [Код сотрудника] = {labn1.Text}";
                            break;
                        case "Тип договора":
                            Where = $"DELETE FROM [dbo].[Тип договора] WHERE [Код типа договора] = {labn1.Text}";
                            break;
                        case "Тип музыкального инструмента":
                            Where = $"DELETE FROM [dbo].[Тип музыкального инструмента] WHERE [Код типа инструмента] = {labn1.Text}";
                            break;
                        case "Тип рекламы":
                            Where = $"DELETE FROM [dbo].[Тип рекламы] WHERE [Код тпа рекламы] = {labn1.Text}";
                            break;
                        case "Успеваемость":
                            Where = $"DELETE FROM [dbo].[Успеваемость] WHERE [Код успеваемости] = {labn1.Text}";
                            break;
                        default:
                            break;
                    }
                    SqlCommand cmd = new SqlCommand($"{Where}", connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    MessageBox.Show("Строка удалена!", "Успех!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так :(", "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
