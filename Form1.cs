using TodoApp.Models;

namespace TodoApp
{
    public partial class Form1 : Form
    {
        public TodoRepo todoRepo;
        public Form1()
        {
            todoRepo = new TodoRepo(new TodoContext());

            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime date;
            var todolist = todoRepo.GetAllTodos();
            bool check = DateTime.TryParse(textBox3.Text, out date);

            if (check)
            {
                try
                {
                    Todo todo = (from item in todolist
                                 where item.CreatedDate.Date == date.Date
                                 select item).First();

                    textBox4.Text = todo.Id.ToString();
                    textBox5.Text = todo.Title;
                    textBox6.Text = todo.Description;
                }
                catch
                {
                    MessageBox.Show("Sorry! No entry found");
                    textBox3.Clear();
                }
            }
            else
            {
                try
                {
                    Todo todo = (from item in todolist
                                 where item.Title.ToLower().Contains(textBox3.Text.ToLower())
                                 select item).First();

                    textBox4.Text = todo.Id.ToString();
                    textBox5.Text = todo.Title;
                    textBox6.Text = todo.Description;
                }
                catch
                {
                    MessageBox.Show("Sorry! No entry found");
                    textBox3.Clear();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "")
            {
                Todo todo = new Todo
                {
                    Title = textBox1.Text,
                    Description = textBox2.Text,
                };

                todoRepo.AddTodo(todo);
                todoRepo.Save();
                MessageBox.Show($"Saved\n{todo.Title}\n{todo.Description}");
                this.Refresh();
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show($"Unable to save Todo entry");
                this.Refresh();
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Todo todo = new Todo();
            int index;

            var check = int.TryParse(textBox4.Text.Substring(0), out index);

            todo.Id = index;
            todo.Title = textBox5.Text;
            todo.Description = textBox6.Text;
            todoRepo.UpdateTodo(todo);
            todoRepo.Save();
            MessageBox.Show("Update Successful");
            this.Refresh();
            textBox4.Clear();
            textBox6.Clear();
            textBox5.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index;
            var check = int.TryParse(textBox4.Text.Substring(0), out index);
            todoRepo.DeleteById(index);
            todoRepo.Save();
            MessageBox.Show("Todo Deleted!");
            this.Refresh();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}