/*
 * Last Edit : 02 jan 2013 18:00:00 PM  
 * source    : http://www.codeproject.com/Articles/383153/The-Model-View-Controller-MVC-Pattern-with-Csharp
 */

using System;
using System.Collections;
using MVC.PATTERN.Model;

namespace MVC.PATTERN.Controller
{
    public class UsersController
    {
        IUsersView _view;
        IList _users;
        User _selectedUser;

        public UsersController(IUsersView view, IList users)
        {
            _view = view;
            _users = users;
            view.setController(this);
        }

        public IList Users
        {
            get { return ArrayList.ReadOnly(_users); }
        }

        private void updateViewDetailValues(User usr)
        {
            _view.ID = usr.ID;
            _view.FirstName = usr.FirstName;
            _view.LastName = usr.LastName;
            _view.Departement = usr.Departement;
            _view.Sex = usr.Sex;
        }

        private void updateUserWithViewValues(User usr)
        {
            usr.ID = _view.ID;
            usr.FirstName = _view.FirstName;
            usr.LastName = _view.LastName;
            usr.Departement = _view.Departement;
            usr.Sex = _view.Sex;
        }

        public void LoadView()
        {
            _view.ClearGrid();
            foreach (User usr in this._users)
                _view.AddUserToGrid(usr);
            _view.SetSelectedUser((User)_users[0]);
        }

        public void SelectedUserChanged(string selectedUserID)
        {
            foreach (User usr in this._users)
            {
                if (usr.ID == selectedUserID)
                {
                    _selectedUser = usr;
                    updateViewDetailValues(usr);
                    _view.SetSelectedUser(usr);
                    this._view.CanModifyID = false;
                    break;
                }
            }
        }

        public void AddNewUser()
        {
            _selectedUser = new User("",
                                     "",
                                     "",
                                     "",
                                     User.SexOfPerson.Male);
            this.updateViewDetailValues(_selectedUser);
            this._view.CanModifyID = true;
        }

        public void RemoveUser()
        {
            string id = this._view.GetIdOfSelectedUserInGrid();
            User userToRemove = null;

            if (id != "")
            {
                foreach (User usr in this._users)
                {
                    if (usr.ID == id)
                    {
                        userToRemove = usr;
                        break;
                    }
                }

                if (userToRemove != null)
                {
                    int newSelectedIndex = this._users.IndexOf(userToRemove);
                    this._users.Remove(userToRemove);
                    this._view.RemoveUser(userToRemove);

                    if (newSelectedIndex > -1 && newSelectedIndex < _users.Count)
                    {
                        this._view.SetSelectedUser((User)_users[newSelectedIndex]);
                    }
                }
            }
        }

        public void Save()
        {
            updateUserWithViewValues(_selectedUser);
            if (!this._users.Contains(_selectedUser))
            {
                //add new user
                this._users.Add(_selectedUser);
                this._view.AddUserToGrid(_selectedUser);
            }
            else
            {
                //update existing user
                this._view.UpdateGrid(_selectedUser);
            }
            _view.SetSelectedUser(_selectedUser);
            this._view.CanModifyID = false;
        }
    }
}
