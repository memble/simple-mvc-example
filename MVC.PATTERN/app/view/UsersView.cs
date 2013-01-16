/*
 * last edit : 01 jan 2013 23:26:00 pm
 * source    : http://www.codeproject.com/Articles/383153/The-Model-View-Controller-MVC-Pattern-with-Csharp
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using MVC.PATTERN.Controller;
using MVC.PATTERN.Model;
namespace MVC.PATTERN.View
{
    public partial class UsersView : Form, IUsersView
    {
        public UsersView()
        {
            InitializeComponent();
        }

        #region Events raised back to Controller

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this._controller.AddNewUser();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this._controller.RemoveUser();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this._controller.Save();
        }

        private void listUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listUser.SelectedItems.Count > 0)
            {
                this._controller.SelectedUserChanged(this.listUser.SelectedItems[0].Text);
            }
        }
#endregion

        #region View Implementation

        UsersController _controller;
        public void setController(UsersController controller)
        {
            _controller = controller;
        }

        public void ClearGrid()
        {
            this.listUser.Columns.Clear();

            this.listUser.Columns.Add("Id", 150, HorizontalAlignment.Left);
            this.listUser.Columns.Add("First Name", 150, HorizontalAlignment.Left);
            this.listUser.Columns.Add("Last Name", 150, HorizontalAlignment.Left);
            this.listUser.Columns.Add("Department", 150, HorizontalAlignment.Left);
            this.listUser.Columns.Add("Sex", 50, HorizontalAlignment.Left);

            this.listUser.Items.Clear();
        }

        public void AddUserToGrid(User usr)
        {
            ListViewItem parent;
            parent = this.listUser.Items.Add(usr.ID);
            parent.SubItems.Add(usr.FirstName);
            parent.SubItems.Add(usr.LastName);
            parent.SubItems.Add(usr.Departement);
            parent.SubItems.Add(Enum.GetName(typeof(User.SexOfPerson), usr.Sex));
        }

        public void UpdateGrid(User usr)
        {
            ListViewItem rowToUpdate = null;
            foreach (ListViewItem row in this.listUser.Items)
            {
                if (row.Text == usr.ID)
                {
                    rowToUpdate = row;
                }

                if (rowToUpdate != null)
                {
                    rowToUpdate.Text = usr.ID;
                    rowToUpdate.SubItems[1].Text = usr.FirstName;
                    rowToUpdate.SubItems[2].Text = usr.LastName;
                    rowToUpdate.SubItems[3].Text = usr.Departement;
                    rowToUpdate.SubItems[4].Text = Enum.GetName(typeof(User.SexOfPerson), usr.Sex);
                }
            }
        }

        public void RemoveUser(User usr)
        {
            ListViewItem rowToRemove = null;
            foreach (ListViewItem row in this.listUser.Items)
            {
                if (row.Text == usr.ID)
                {
                    rowToRemove = row;
                }

                if (rowToRemove != null)
                {
                    this.listUser.Items.Remove(rowToRemove);
                    this.listUser.Focus();
                }
            }
        }

        public string GetIdOfSelectedUserInGrid()
        {
            if (this.listUser.SelectedItems.Count > 0)
            {
                return this.listUser.SelectedItems[0].Text;
            }
            else
            {
                return "";
            }
        }

        public void SetSelectedUser(User usr)
        {
            foreach (ListViewItem row in this.listUser.Items)
            {
                if (row.Text == usr.ID)
                {
                    row.Selected = true;
                }
            }
        }

        public string FirstName
        {
            get
            {
                return this.txtFirstName.Text;
            }
            set
            {
                this.txtFirstName.Text = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.txtLastName.Text;
            }
            set
            {
                this.txtLastName.Text = value;
            }
        }

        public string ID
        {
            get
            {
                return this.txtID.Text;
            }
            set
            {
                this.txtID.Text = value;
            }
        }

        public string Departement
        {
            get
            {
                return this.txtDepartement.Text;
            }
            set
            {
                this.txtDepartement.Text = value;
            }
        }

        public User.SexOfPerson Sex
        {
            get
            {
                if (this.rdMale.Checked)
                {
                    return User.SexOfPerson.Male;
                }
                else
                {
                    return User.SexOfPerson.Female;
                }
            }
            set
            {
                if (value == User.SexOfPerson.Male)
                {
                    this.rdMale.Checked = true;
                }
                else
                {
                    this.rdFemale.Checked = true;
                }
            }
        }

        public bool CanModifyID
        {
            set
            {
                this.txtID.Enabled = value;
            }
        }
        #endregion

    }
}
