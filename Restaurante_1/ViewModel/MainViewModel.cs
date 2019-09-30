using MySql.Data.MySqlClient;
using Restaurante_1.Controls;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Prism.Mvvm;
using Restaurante_1.Model;
using Prism.Commands;
using Restaurante_1.View;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows.Media;

namespace Restaurante_1.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private static MySqlConnection conn;
        private static bool _is_manager = false;
        private static bool _is_waiter = false;
        public string state_global;

        #region Collections

        private static ObservableCollection<Workers> _workers = new ObservableCollection<Workers>();
        public static ObservableCollection<Workers> Workers
        {
            get { return _workers; }
            set { _workers = value; }
        }

        private static ObservableCollection<New_order_details> _neworder = new ObservableCollection<New_order_details>();
        public static ObservableCollection<New_order_details> New_Order_Details
        {
            get { return _neworder; }
            set { _neworder = value; }
        }

        private static ObservableCollection<Orders> _orders = new ObservableCollection<Orders>();
        public static ObservableCollection<Orders> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }


        private static ObservableCollection<Food_list> _foods = new ObservableCollection<Food_list>();
        public static ObservableCollection<Food_list> ListofFood
        {
            get { return _foods; }
            set { _foods = value; }
        }

        private static ObservableCollection<Order_details_model> _details = new ObservableCollection<Order_details_model>();
        public static ObservableCollection<Order_details_model> Details
        {
            get { return _details; }
            set { _details = value; }
        }
        private static ObservableCollection<New_order_details> _details2 = new ObservableCollection<New_order_details>();
        public static ObservableCollection<New_order_details> Details2
        {
            get { return _details2; }
            set { _details2 = value; }
        }

        #endregion

        #region Commands
        public ICommand LoginCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand Change_PW_Command { get; set; }
        public ICommand Change_PW_Window_Command { get; set; }

        public ICommand Table_Click_Command { get; set; }
        public ICommand New_Order_Command { get; set; }
        public ICommand CloseCommand { get; private set; }
        public ICommand Load_Food_List_Command { get; set; }
        public ICommand SelectedProduct_Command { get; set; }
        public ICommand Confirm_NewOrder_Command { get; set; }
        public ICommand View_UserMenu_Command { get; set; }
        public ICommand View_LoginMenu_Command { get; set; }
        public ICommand View_Details_Command { get; set; }
        public ICommand Delete_details_Command { get; set; }
        public ICommand CheckOut_Command { get; set; }
        public ICommand Cancel_Order_Command { get; set; }
        public ICommand Print_Command { get; set; }
        public ICommand NewO_Add_Button_Command { get; set; }
        public ICommand OD_Add_Button_Command { get; set; }
        public ICommand Delete_from_newO_Command { get; set; }
        public ICommand Confirm_Edit_Command { get; set; }
        public ICommand Get_Stock_Command { get; set; }
        public ICommand Add_Button_Command { get; set; }
        public ICommand Minus_Button_Command { get; set; }
        public ICommand Delete_User_Command { get; set; }
        public ICommand Add_User_Command { get; set; }
        public ICommand New_Food_Command { get; set; }
        public ICommand Order_more_Command { get; set; }

        #endregion

        #region Properties

        

        private Page _displayPage;
        public Page DisplayPage
        {
            get
            {
                return _displayPage;
            }
            set
            {
                if (Equals(_displayPage, value))
                {
                    return;
                }

                this._displayPage = value;
                RaisePropertyChanged("DisplayPage");
            }
        }


        private static string _display_user;
        public static string Display_User
        {
            get { return _display_user; }
            set { _display_user = value; }
        }

        private string _display_message;
        public string Display_Message
        {
            get { return _display_message; }
            set
            {
                _display_message = value;
                RaisePropertyChanged("Display_Message");                
            }
        }

        private static string _username;
        public static string Username_VM
        {
            get { return _username; }
            set { _username = value; }
        }
        private static string _pw;
        public static string Password_VM
        {
            get { return _pw; }
            set { _pw = value; }
        }

        private static string _new_password;
        public static string New_Password
        {
            get { return _new_password; }
            set { _new_password = value; }
        }

        private static string _new_password_again;
        public static string New_Password_again
        {
            get { return _new_password_again; }
            set { _new_password_again = value; }
        }


        private string _customer_name;
        public string Current_Customer
        {
            get { return _customer_name; }
            set { _customer_name = value; }
        }

        private static int _row_num = 0;
        public static int Row_num
        {
            get { return _row_num; }
            set { _row_num = value; }
        }

        private static int _row_num_o;
        public static int Row_num_order
        {
            get { return _row_num_o; }
            set { _row_num_o = value; }
        }

        private static string _selected_food;
        public static string Selected_food
        {
            get { return _selected_food; }
            set { _selected_food = value; }
        }

        private static int _selected_food_index;
        public static int Selected_food_index
        {
            get { return _selected_food_index; }
            set { _selected_food_index = value; }
        }
        private int _selected_count = 1;
        public int Selected_Count
        {
            get { return _selected_count; }
            set { _selected_count = value; }
        }
        private int _selected_waiter;
        public int Selected_waiter
        {
            get { return _selected_waiter; }
            set { _selected_waiter = value; }
        }
        private int _selected_table;
        public int Selected_table
        {
            get { return _selected_table; }
            set { _selected_table = value; }
        }

        private static int _price;
        public static int Summed_Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private static int _slider_max;
        public static int Slider_max
        {
            get { return _slider_max; }
            set { _slider_max = value; }
        }

        #region New_User
        private static string _new_username;
        public static string New_Username
        {
            get { return _new_username; }
            set { _new_username = value; }
        }
        private static string _realname;
        public static string Real_Name
        {
            get { return _realname; }
            set { _realname = value; }
        }

        private static string _password_new;
        public static string New_Passwordd
        {
            get { return _password_new; }
            set { _password_new = value; }
        }

        private static int _new_salary;
        public static int Salary
        {
            get { return _new_salary; }
            set { _new_salary = value; }
        }

        private static string _new_title;
        public static string Title
        {
            get { return _new_title; }
            set { _new_title = value; }
        }
        #endregion

        #region New_Food
        private static string _foodname;
        public static string Food_name
        {
            get { return _foodname; }
            set { _foodname = value; }
        }

        private static int _foodprice;
        public static int Food_price
        {
            get { return _foodprice; }
            set { _foodprice = value; }
        }

        private static string _category;
        public static string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        private static int _instock;
        public static int In_Stock
        {
            get { return _instock; }
            set { _instock = value; }
        }
        #endregion

        private Boolean _textbox_enabled = true;
        public Boolean TextboxEnabled
        {
            get { return _textbox_enabled; }
            set
            {
                _textbox_enabled = value;
                RaisePropertyChanged("TextboxEnabled");
            }
        }

        //private Boolean _display_message_Visibility = false;
        //public Boolean Display_Message_Visibility
        //{
        //    get { return _display_message_Visibility; }
        //    set
        //    {
        //        _display_message_Visibility = value;
        //        RaisePropertyChanged("Display_Message_Visibility");
        //    }
        //}
        #endregion

        public MainViewModel()
        {
            LoginCommand = new RelayCommand(CheckLogin);
            LogoutCommand = new DelegateCommand(Logout);
            Table_Click_Command = new DelegateCommand(GetAllOrders);
            CloseCommand = new DelegateCommand(CloseWindow);
            Load_Food_List_Command = new DelegateCommand(Select_foodlist);
            View_UserMenu_Command = new DelegateCommand(View_Waiters);
            View_LoginMenu_Command = new DelegateCommand(View_LoginWindow);
            View_Details_Command = new DelegateCommand(Select_Details);
            Change_PW_Window_Command = new DelegateCommand(View_change_pw_window);
            Change_PW_Command = new DelegateCommand(Change_Password);
            CheckOut_Command = new DelegateCommand(CheckOut);
            Cancel_Order_Command = new DelegateCommand(Cancel_order);
            Print_Command = new DelegateCommand(Print_Bill);
            New_Order_Command = new DelegateCommand(View_NewOrder_Window);
            Confirm_NewOrder_Command = new DelegateCommand(New_Order);
            NewO_Add_Button_Command = new DelegateCommand(NewO_Add_button);
            Delete_from_newO_Command = new DelegateCommand(Delete_from_newO);
            OD_Add_Button_Command = new DelegateCommand(OD_Add_button);
            Delete_details_Command = new DelegateCommand(Delete_from_details);
            Confirm_Edit_Command = new DelegateCommand(Edit_Details_Grid);
            Add_Button_Command = new DelegateCommand(Add_button);
            Minus_Button_Command = new DelegateCommand(Minus_button);
            Delete_User_Command = new DelegateCommand(Delete_User);
            Add_User_Command = new DelegateCommand(Add_User);
            New_Food_Command = new DelegateCommand(Add_new_food);
            Order_more_Command = new DelegateCommand(View_New_Food);
        }


        private void Select_State()
        {
            conn = new MySqlConnection("Server=localhost;Database=szakdoga_db;Uid=root;Pwd=;SslMode=none");
            string q_select = String.Format("SELECT state FROM orders WHERE Order_no={0}", Details[0].Order_no);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(q_select, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    state_global = (dataReader["State"].ToString());
                }
                dataReader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Change_Password()
        {
            if (_is_waiter == true || _is_manager == true)
            {
                conn = new MySqlConnection("Server=localhost;Database=szakdoga_db;Uid=root;Pwd=;SslMode=none");
                if (New_Password != New_Password_again)
                {
                    Display_Message = "Passwords are not the same!";
                }
                else
                {
                    string q_update = String.Format("UPDATE workers SET Password='{0}' WHERE Username='{1}'", New_Password, Username_VM);
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(q_update, conn);
                        cmd.ExecuteNonQuery();
                        Display_Message = "Succesfull password change!";

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                conn.Close();
            }
        }
        private void CloseWindow()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this)
                {
                    item.Close();
                }
            }
        }
        private void CheckLogin(object parameter1)
        {
            var passwordbox = parameter1 as PasswordBox;
            var password = passwordbox.Password;
            if ((Username_VM == null || Username_VM == "") && (password == null || password == ""))
            {
                Display_Message = "Please enter your username and password!";
            }
            else if (Authenticate(Username_VM, password) == false)
            {
                Display_Message = "Username or password is incorrect!";
            }
            else
            {
                Display_Message = "Succesfully logged in!";
            }

        }
        private bool Authenticate(string UserName, string Password)
        {
            for (int i = 0; i < Workers.Count; i++)
            {
                if (UserName == Workers[i].Username && Password == Workers[i].Password)
                {
                    Display_User = Workers[i].Realname;
                    Password_VM = Password;
                    TextboxEnabled = false;
                    if (Workers[i].Title == "Manager")
                    {
                        _is_manager = true;
                    }
                    else
                    {
                        _is_waiter = true;
                    }
                    return true;
                }
            }
            return false;
        }
        private void GetAllWorkers()
        {
            conn = new MySqlConnection("Server=localhost;Database=szakdoga_db;Uid=root;Pwd=;SslMode=none");
            string q_select = "SELECT * FROM workers";
            Workers.Clear();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(q_select, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Workers.Add(new Model.Workers
                    {
                        Worker_ID = Convert.ToInt32(dataReader["Worker_ID"]),
                        Username = (dataReader["Username"]).ToString(),
                        Password = (dataReader["Password"]).ToString(),
                        Registration_Date = DateTime.Parse(dataReader["Registration_Date"].ToString()),
                        Salary = Convert.ToInt32(dataReader["Salary"]),
                        Title = (dataReader["Title"]).ToString(),
                        Realname = (dataReader["Realname"]).ToString()
                    });
                }
                dataReader.Close();
                this.DisplayPage = new Menu_users();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void GetAllOrders()
        {
            if (_is_waiter == true || _is_manager == true)
            {
                Details.Clear();
                Details2.Clear();
                Orders.Clear();
                conn = new MySqlConnection("Server=localhost;Database=szakdoga_db;Uid=root;Pwd=;SslMode=none");
                string q_select = "SELECT o.Order_no, o.Table_no, o.State, w.Realname as Waiter, o.Time FROM orders o INNER JOIN workers w ON w.Worker_ID = o.Waiter ORDER BY o.Order_no";
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(q_select, conn);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Orders.Add(new Model.Orders
                        {
                            Order_no = Convert.ToInt32(dataReader["Order_no"]),
                            Table_no = Convert.ToInt32(dataReader["Table_no"]),
                            State = dataReader["State"].ToString(),
                            Waiter = dataReader["Waiter"].ToString(),
                            Time = Convert.ToDateTime(dataReader["Time"]).ToString("MM.dd, H:mm"),

                        });
                    }
                    dataReader.Close();
                    this.DisplayPage = new Orders_Grid();
                    conn.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void CheckOut()
        {
            Select_State();
            if (state_global == "In Progress")
            {
                conn = new MySqlConnection("Server=localhost;Database=szakdoga_db;Uid=root;Pwd=;SslMode=none");
                string q = String.Format("UPDATE orders SET state='Completed', Customer='{0}' WHERE Order_no={1}", Details[0].Customer, Details[0].Order_no);
                try
                {
                    conn.Open();
                    MySqlCommand cmd2 = new MySqlCommand(q, conn);
                    cmd2.ExecuteNonQuery();
                    Display_Message = "Checkout completed!";
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else if (state_global == "Canceled")
            {
                Display_Message = "Order is canceled!";
            }
            else
            {
                Display_Message = "Order is already completed!";
            }
        }
        private void Cancel_order()
        {
            Select_State();
            if (state_global == "In Progress")
            {
                conn = new MySqlConnection("Server=localhost;Database=szakdoga_db;Uid=root;Pwd=;SslMode=none");
                string q_update = String.Format("UPDATE orders SET state='Canceled', Cancel_Reason='{0}', Customer='{1}' WHERE Order_no={2}", Details[0].C_Reason, Details[0].Customer, Details[0].Order_no);
                try
                {
                    conn.Open();
                    MySqlCommand cmd2 = new MySqlCommand(q_update, conn);
                    cmd2.ExecuteNonQuery();
                    Display_Message = "Order canceled!";
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state_global == "Canceled")
            {
                Display_Message = "Order is already canceled!";
            }
            else
            {
                Display_Message = "Order is completed, you cannot cancel it!";
            }
        }
        private void Print_Bill()
        {
            Select_State();
            if (state_global == "Completed")
            {
                PrintDialog printDlg = new PrintDialog();
                FlowDocument doc = CreateFlowDocument();
                IDocumentPaginatorSource idpSource = doc;
                printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
                Display_Message = "Printing completed!";
            }
            else if (state_global == "Canceled")
            {
                Display_Message = "Order canceled! Cannot print bill!";
            }
            else
            {
                Display_Message = "Order is in progress! Check out first!";
            }
        }

        private FlowDocument CreateFlowDocument()
        {
            FlowDocument doc = new FlowDocument();
            Paragraph p = new Paragraph(new Run("Bill!"));
            p.FontSize = 36;
            doc.Blocks.Add(p);

            p = new Paragraph(new Run("Summary"));
            p.FontSize = 20;
            p.FontStyle = FontStyles.Italic;
            p.TextAlignment = TextAlignment.Left;
            p.Foreground = Brushes.Gray;
            doc.Blocks.Add(p);

            p = new Paragraph(new Run("Order number: " + Details[0].Order_no.ToString()));
            doc.Blocks.Add(p);

            p = new Paragraph(new Run("Table number: " + Details[0].Table_no.ToString()));
            doc.Blocks.Add(p);

            p = new Paragraph(new Run("Waiter: " + Details[0].Waiter.ToString()));
            doc.Blocks.Add(p);

            p = new Paragraph(new Run("Total Price: " + Details[0].Price.ToString() + "Ft."));
            doc.Blocks.Add(p);

            return doc;
        }
        private void Select_Details()
        {
            GetAllWorkers();
            Select_foodlist();
            New_Order_Details.Clear();
            conn = new MySqlConnection("Server=localhost;Database=szakdoga_db;Uid=root;Pwd=;SslMode=none");
            string q_select = String.Format("SELECT od.ID, od.Order_no, o.Table_no, f.Name as Food, SUM(f.Price * od.Count) as Price, o.Cancel_Reason, w.Realname as Waiter, o.Customer, o.State FROM order_details od INNER JOIN food_list f ON f.Food_ID = od.Food INNER JOIN orders o ON o.Order_no = od.Order_no INNER JOIN workers w ON w.Worker_ID = o.Waiter GROUP BY Order_no LIMIT {0},1 ", Row_num_order);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(q_select, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Details.Add(new Model.Order_details_model
                    {
                        ID = Convert.ToInt32(dataReader["ID"]),
                        Order_no = Convert.ToInt32(dataReader["Order_no"]),
                        Table_no = Convert.ToInt32(dataReader["Table_no"]),
                        Food = (dataReader["Food"].ToString()),
                        Price = Convert.ToInt32(dataReader["Price"]),
                        C_Reason = (dataReader["Cancel_Reason"].ToString()),
                        Waiter = (dataReader["Waiter"].ToString()),
                        Customer = (dataReader["Customer"].ToString()),
                        State = (dataReader["State"].ToString())
                    });

                }
                dataReader.Close();
                Select_More_Details();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Select_More_Details()
        {
            conn = new MySqlConnection("Server=localhost;Database=szakdoga_db;Uid=root;Pwd=;SslMode=none");
            string q_select = String.Format("SELECT f.Name as Food, od.Count, f.Food_ID, f.Price FROM order_details od INNER JOIN food_list f ON f.Food_ID = od.Food WHERE Order_no={0}", Details[0].Order_no);
            try
            {
                conn.Open();
                MySqlCommand cmd2 = new MySqlCommand(q_select, conn);
                MySqlDataReader dataReader2 = cmd2.ExecuteReader();
                while (dataReader2.Read())
                {
                    Details2.Add(new Model.New_order_details
                    {
                        Food = (dataReader2["Food"].ToString()),
                        Count = Convert.ToInt32(dataReader2["Count"]),
                        Food_ID = Convert.ToInt32(dataReader2["Food_ID"]),
                        Price = Convert.ToInt32(dataReader2["Price"]),
                    });
                }
                dataReader2.Close();
                Sum_Prices();
                conn.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void Sum_Prices()
        {
            Summed_Price = 0;
            for (int i = 0; i < Details2.Count; i++)
            {
                Summed_Price += (Details2[i].Price * Details2[i].Count);
            }
        }
        private void Edit_Details_Grid()
        {
            Select_State();
            if (state_global == "In Progress")
            {
                conn = new MySqlConnection("Server=localhost;Database=szakdoga_db;Uid=root;Pwd=;SslMode=none");
                string q_delete = String.Format("DELETE FROM order_details WHERE Order_no={0}", Details[0].Order_no);
                string q_insert_orderdetails;
                string q_update = String.Format("UPDATE orders SET Table_no={0}, Waiter={1} WHERE Order_no={2}", (Selected_table + 1), Selected_waiter, Details[0].Order_no);
                try
                {
                    conn.Open();
                    MySqlCommand cmd1 = new MySqlCommand(q_delete, conn);
                    cmd1.ExecuteNonQuery();

                    for (int i = 0; i < Details2.Count; i++)
                    {
                        q_insert_orderdetails = String.Format("INSERT INTO order_details(ID, Order_no, Food, Count) VALUES(NULL, '" + Details[0].Order_no + "', '" + Details2[i].Food_ID + "', '" + Details2[i].Count + "')");
                        MySqlCommand cmd2 = new MySqlCommand(q_insert_orderdetails, conn);
                        cmd2.ExecuteNonQuery();
                    }
                    MySqlCommand cmd3 = new MySqlCommand(q_update, conn);
                    cmd3.ExecuteNonQuery();
                    conn.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                Sum_Prices();
                Display_Message = "Confirm completed";
            }
            else
            {
                Display_Message = "Not editablee! Order canceled or completed!";
            }
        }
        private void Delete_from_details()
        {
            Select_State();
            if (state_global == "In Progress")
            {
                if (Details2.Count != 0)
                {
                    Details2.RemoveAt(Row_num);
                    conn = new MySqlConnection("Server=localhost;Database=szakdoga_db;Uid=root;Pwd=;SslMode=none");
                    string q_delete = String.Format("DELETE FROM order_details WHERE Order_no={0} AND Food = 1", Details[0].Order_no);
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(q_delete, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    Sum_Prices();
                }
                else
                {
                    Display_Message = "The list is empty!";
                }
            }
            else
            {
                Display_Message = "Not editable! Order is canceled or completed!";
            }
        }
        private void Delete_User()
        {
            if (Workers.Count != 0)
            {
                List<string> name = new List<string>();
                Workers.RemoveAt(Row_num);
                conn = new MySqlConnection("Server=localhost;Database=szakdoga_db;Uid=root;Pwd=;SslMode=none");
                string q2 = String.Format("SELECT Username FROM workers");
                try
                {
                    conn.Open();
                    MySqlCommand cmd2 = new MySqlCommand(q2, conn);
                    MySqlDataReader dataReader2 = cmd2.ExecuteReader();
                    while (dataReader2.Read())
                    {
                        name.Add(dataReader2["Username"].ToString());
                    }
                    dataReader2.Close();

                    string q = String.Format("DELETE FROM workers WHERE Username='{0}'", name[Row_num]);
                    MySqlCommand cmd = new MySqlCommand(q, conn);
                    //cmd.ExecuteNonQuery(); //ha olyan embert tölünk ki, akihez tartozik már rendelés, akkor hibát okoz az idegen kulcs miatt
                    conn.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
        private void Add_User()
        {
            conn = new MySqlConnection("Server=localhost;Database=szakdoga_db;Uid=root;Pwd=;SslMode=none");
            string query = String.Format("INSERT INTO workers(Worker_ID, Username, Password, Registration_Date, Salary, Title, Realname) VALUES(NULL, '" + New_Username + "', '" + New_Passwordd + "', NOW(), " + Salary + ", '" + Title + "', '" + Real_Name + "')");
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Delete_from_newO()
        {
            if (New_Order_Details.Count != 0)
            {
                New_Order_Details.RemoveAt(Row_num);
            }
            else
            {
                Display_Message = "The list is empty.";
            }
        }
        private void Select_foodlist()
        {
            if (_is_manager == true || _is_waiter == true)
            {
                conn = new MySqlConnection("Server=localhost;Database=szakdoga_db;Uid=root;Pwd=;SslMode=none");
                string q_select = "SELECT * FROM food_list ORDER BY Food_ID ASC";
                ListofFood.Clear();
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(q_select, conn);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        ListofFood.Add(new Model.Food_list
                        {
                            Food_ID = Convert.ToInt32(dataReader["Food_ID"]),
                            Name = (dataReader["Name"].ToString()),
                            Price = Convert.ToInt32(dataReader["Price"]),
                            Category = (dataReader["Category"].ToString()),
                            In_Stock = Convert.ToInt32(dataReader["In_Stock"]),

                        });
                    }
                    dataReader.Close();
                    conn.Close();
                    this.DisplayPage = new Food_List_Grid();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void New_Order()
        {
            if (New_Order_Details.Count != 0)
            {
                conn = new MySqlConnection("Server=localhost;Database=szakdoga_db;Uid=root;Pwd=;SslMode=none");
                string q_insert_orders = String.Format("INSERT INTO orders(Order_no, Table_no, State, Waiter, Time) VALUES(NULL, '" + (Selected_table + 1) + "', 'In Progress', '" + Selected_waiter + "', NOW())");
                string q_select_max = String.Format("SELECT MAX(Order_no) AS Order_no FROM order_details");
                string q_select_state = String.Format("SELECT State FROM orders WHERE Table_no ={0} AND State='In Progress'", (Selected_table + 1));
                int next_order_num = 0;
                bool _table_free = true;
                string q_insert_orderdetails;

                try
                {
                    conn.Open();

                    MySqlCommand cmd1 = new MySqlCommand(q_select_max, conn);
                    MySqlDataReader dataReader1 = cmd1.ExecuteReader();
                    while (dataReader1.Read())
                    {
                        next_order_num = Convert.ToInt32(dataReader1["Order_no"]) + 1;
                    }
                    dataReader1.Close();

                    MySqlCommand cmd2 = new MySqlCommand(q_select_state, conn);
                    MySqlDataReader dataReader2 = cmd2.ExecuteReader();
                    while (dataReader2.Read())
                    {
                        _table_free = false;
                    }
                    dataReader2.Close();


                    if (_table_free == true)
                    {
                        MySqlCommand cmd3 = new MySqlCommand(q_insert_orders, conn);
                        cmd3.ExecuteNonQuery();

                        for (int i = 0; i < New_Order_Details.Count; i++)
                        {
                            q_insert_orderdetails = String.Format("INSERT INTO order_details(ID, Order_no, Food, Count) VALUES(NULL, '" + next_order_num + "', '" + New_Order_Details[i].Food_ID + "', '" + New_Order_Details[i].Count + "')");
                            MySqlCommand cmd4 = new MySqlCommand(q_insert_orderdetails, conn);
                            cmd4.ExecuteNonQuery();

                        }
                        Display_Message = "New order has been created!";
                    }
                    else
                    {
                        Display_Message = "The table is still busy!";
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Display_Message = "The order cannot be empty!";
            }
        }
        private void Add_button()
        {
            if (New_Order_Details.Count != 0)
            {
                List<New_order_details> nod_list = new List<New_order_details>();
                for (int i = 0; i < New_Order_Details.Count; i++)
                {
                    nod_list.Add(New_Order_Details[i]);
                }
                int asd = Row_num;
                nod_list[Row_num].Count += 1;
                New_Order_Details.Clear();

                for (int i = 0; i < nod_list.Count; i++)
                {
                    New_Order_Details.Add(new Model.New_order_details
                    {
                        Food = nod_list[i].Food,
                        Count = nod_list[i].Count,
                        Food_ID = nod_list[i].Food_ID,
                        Price = nod_list[i].Price
                    });
                }
            }
            else if (Details2.Count != 0)
            {
                Select_State();
                if (state_global == "In Progress")
                {
                    List<New_order_details> list = new List<New_order_details>();
                    for (int i = 0; i < Details2.Count; i++)
                    {
                        list.Add(Details2[i]);
                    }
                    list[Row_num].Count += 1;
                    Details2.Clear();

                    for (int i = 0; i < list.Count; i++)
                    {
                        Details2.Add(new Model.New_order_details
                        {
                            Food = list[i].Food,
                            Count = list[i].Count,
                            Food_ID = list[i].Food_ID,
                            Price = list[i].Price
                        });
                    }
                    Sum_Prices();
                }
                else if (state_global == "Completed")
                {
                    Display_Message = "Not editable! Order completed!";
                }
                else
                {
                    Display_Message = "Not editable! Order canceled!";
                }
            }
        }
        private void Minus_button()
        {
            if (New_Order_Details.Count != 0)
            {
                if (New_Order_Details[Row_num].Count > 1)
                {
                    List<New_order_details> nod_list = new List<New_order_details>();
                    for (int i = 0; i < New_Order_Details.Count; i++)
                    {
                        nod_list.Add(New_Order_Details[i]);
                    }
                    int asd = Row_num;
                    nod_list[Row_num].Count -= 1;
                    New_Order_Details.Clear();

                    for (int i = 0; i < nod_list.Count; i++)
                    {
                        New_Order_Details.Add(new Model.New_order_details
                        {
                            Food = nod_list[i].Food,
                            Count = nod_list[i].Count,
                            Food_ID = nod_list[i].Food_ID,
                            Price = nod_list[i].Price
                        });
                    }
                }
                else
                {
                    Display_Message = "Cannot be less than 1.";
                }
            }
            else if (Details2.Count != 0)
            {
                Select_State();
                if (state_global == "In Progress")
                {
                    if (Details2[Row_num].Count > 1)
                    {
                        List<New_order_details> list = new List<New_order_details>();
                        for (int i = 0; i < Details2.Count; i++)
                        {
                            list.Add(Details2[i]);
                        }
                        list[Row_num].Count -= 1;
                        Details2.Clear();

                        for (int i = 0; i < list.Count; i++)
                        {
                            Details2.Add(new Model.New_order_details
                            {
                                Food = list[i].Food,
                                Count = list[i].Count,
                                Food_ID = list[i].Food_ID,
                                Price = list[i].Price
                            });
                        }
                        Sum_Prices();
                    }
                    else
                    {
                        Display_Message = "Cannot be less than 1.";
                    }
                }
                else if (state_global == "Completed")
                {
                    Display_Message = "Not editable! Order completed!";
                }
                else
                {
                    Display_Message = "Not editable! Order canceled!";
                }

            }
        }
        private void NewO_Add_button()
        {
            bool empty = true;
            bool n = true;
            bool z = true;
            for (int i = 0; i < New_Order_Details.Count; i++)
            {
                int u = New_Order_Details[i].Count;
                if (New_Order_Details[i].Food.Equals(Selected_food) && z == true)
                {
                    New_Order_Details.RemoveAt(i);
                    New_Order_Details.Add(new Model.New_order_details
                    {
                        Food = Selected_food,
                        Count = Selected_Count + u,
                        Food_ID = Selected_food_index + 1,
                        Price = ListofFood[Selected_food_index + 1].Price
                    });
                    n = true;
                    z = false;
                    empty = false;
                }
                else
                {
                    n = false;
                }
            }
            if ((n == false && z == true) || empty == true)
            {
                New_Order_Details.Add(new Model.New_order_details
                {
                    Food = Selected_food,
                    Count = Selected_Count,
                    Food_ID = Selected_food_index + 1,
                    Price = ListofFood[Selected_food_index + 1].Price
                });
            }
        }
        private void OD_Add_button()
        {
            bool n = true;
            bool z = true;

            if (Details[0].State == "In Progress")
            {
                for (int i = 0; i < Details2.Count; i++)
                {
                    int u = Details2[i].Count;
                    if (Details2[i].Food.Equals(Selected_food) && z == true)
                    {
                        Details2.RemoveAt(i);
                        Details2.Add(new Model.New_order_details
                        {
                            Food = Selected_food,
                            Count = Selected_Count + u,
                            Food_ID = Selected_food_index + 1,
                            Price = ListofFood[Selected_food_index + 1].Price
                        });
                        n = true;
                        z = false;
                    }
                    else
                    {
                        n = false;
                    }
                }
                if (n == false && z == true)
                {
                    Details2.Add(new Model.New_order_details
                    {
                        Food = Selected_food,
                        Count = Selected_Count,
                        Food_ID = Selected_food_index + 1,
                        Price = ListofFood[Selected_food_index + 1].Price

                    });
                }
            }
            else
            {
                Display_Message = "Not editable! Order canceled or completed!";
            }


        }
        private void Add_new_food()
        {
            int counter = 0; //találat jelző
            Select_foodlist();
            conn = new MySqlConnection("Server=localhost;Database=szakdoga_db;Uid=root;Pwd=;SslMode=none");
            for (int i = 0; i < ListofFood.Count; i++)
            {
                if (ListofFood[i].Name == Food_name)
                {
                    string query1 = String.Format("UPDATE food_list SET In_Stock={0} WHERE Name='{1}'", In_Stock, Food_name);
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(query1, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Display_Message = "Update succesfull!";
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    counter++;
                }
            }
            if (counter == 0)
            {
                string query = String.Format("INSERT INTO food_list(Food_ID, Name, Price, Category, In_Stock) VALUES(NULL, '" + Food_name + "', " + Food_price + ", '" + Category + "', " + In_Stock + ")");
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Display_Message = "New product added!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void View_LoginWindow()
        {
            if (_is_manager == false && _is_waiter == false)
            {
                Workers.Clear();
                GetAllWorkers();
                this.DisplayPage = new Login();
            }
            else
            {
                Display_Message = "You have to log out first!";
            }

        }
        private void View_Waiters()
        {
            if (_is_manager == true)
            {
                Workers.Clear();
                GetAllWorkers();
                this.DisplayPage = new Menu_users();
            }
            else
            {
                Display_Message = "Manager only!";
            }

        }
        private void View_New_Food()
        {
            if (_is_manager == true)
            {
                Food_name = "";
                Food_price = 0;
                Category = "";
                In_Stock = 0;
                this.DisplayPage = new New_Food();
            }
            else
            {
                Display_Message = "Manager only!";
            }
        }
        private void View_NewOrder_Window()
        {
            if (_is_waiter == true || _is_manager == true)
            {
                New_Order_Details.Clear();
                GetAllWorkers();
                Select_foodlist();
                this.DisplayPage = new New_Order();
            }
            else
            {
                Display_Message = "You have to log in first!";
            }
        }
        private void View_change_pw_window()
        {
            New_Password = "";
            New_Password_again = "";
            if (_is_manager == true || _is_waiter == true)
            {
                this.DisplayPage = new Change_Password();
            }
            else
            {
                Display_Message = "You have to log in first!";
            }
        }
        private void Logout()
        {
            if (_is_waiter == true || _is_manager == true)
            {
                Username_VM = null;
                Password_VM = null;
                TextboxEnabled = true;
                _is_manager = false;
                _is_waiter = false;
                Display_User = "";
                this.DisplayPage = new Login();
                Display_Message = "Succesfull logout!";
            }
            else
            {
                Display_Message = "You have to log in first!";
            }
        }

    }
}

