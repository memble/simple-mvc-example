/*
 * Last Edit : 02 jan 2013 00:14:00 AM  
 * source    : http://www.codeproject.com/Articles/383153/The-Model-View-Controller-MVC-Pattern-with-Csharp
 */

using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using MVC.PATTERN.Model;
using MVC.PATTERN.View;
using MVC.PATTERN.Controller;

namespace MVC.PATTERN.app
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //create view
            UsersView view = new UsersView();
            view.Visible = false;

            //create new user list
            IList users = new ArrayList();

            //list user
            users.Add(new User("Vladimir", "Putin", "Government of Russia", "122", User.SexOfPerson.Male));
            users.Add(new User("Barack", "Obama", "Government of USA", "123", User.SexOfPerson.Male));
            users.Add(new User("Stephen", "Harper", "Government of Canada", "124", User.SexOfPerson.Male));
            users.Add(new User("Jean", "Charest", "Government of Quebec", "125", User.SexOfPerson.Male));

            //create controller
            UsersController controller = new UsersController(view, users);
            controller.LoadView();
            view.ShowDialog();
        }
    }
}
