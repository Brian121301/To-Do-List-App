using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List_App
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        DataTable todoList = new DataTable();
        bool isEditing = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create Columns
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");
            todoList.Columns.Add("Priority");

            //Point our datagridview to our datasource
            toDoListView.DataSource = todoList;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleInput.Text = string.Empty;
            descInput.Text = string.Empty;
            priorityBox.Text = string.Empty;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;

            //Fill text fields with data from table
            titleInput.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descInput.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
            priorityBox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[2].ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = titleInput.Text;
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = descInput.Text;
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Priority"] = priorityBox.Text;
                isEditing = false;
            }
            else
            {
                todoList.Rows.Add(titleInput.Text, descInput.Text, priorityBox.Text);
            }

            // Clear fields
            titleInput.Text = string.Empty;
            descInput.Text = string.Empty;
            priorityBox.Text = string.Empty;
        }
    }
}
