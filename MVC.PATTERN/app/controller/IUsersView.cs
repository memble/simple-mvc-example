/*
 * Last Edit : 02 jan 2013 00:14:00 AM  
 * source    : http://www.codeproject.com/Articles/383153/The-Model-View-Controller-MVC-Pattern-with-Csharp
 */

using System;
using MVC.PATTERN.Model;

namespace MVC.PATTERN.Controller
{
    public interface IUsersView
    {
        void setController(UsersController controller);
        void ClearGrid();
        void AddUserToGrid(User user);
        void UpdateGrid(User user);
        void RemoveUser(User user);
        void SetSelectedUser(User user);
        string GetIdOfSelectedUserInGrid();

        string ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Departement { get; set; }
        User.SexOfPerson Sex { get; set; }
        bool CanModifyID { set; }
        
    }
}
