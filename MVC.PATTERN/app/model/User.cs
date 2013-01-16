/*
 * Last Edit : 02 jan 2013 00:14:00 AM  
 * source    : http://www.codeproject.com/Articles/383153/The-Model-View-Controller-MVC-Pattern-with-Csharp
 */

using System;

namespace MVC.PATTERN.Model
{
    public class User
    {
        public enum SexOfPerson
        {
            Male = 1,
            Female = 2
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (value.Length > 50)
                {
                    Console.WriteLine("Karakter harus kurang dari 50 huruf");
                }
                else
                {
                    _FirstName = value;
                }
            }
        }

        private string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (value.Length > 50)
                {
                    Console.WriteLine("Karakter Harus kurang dari 50 huruf");
                }
                else
                {
                    _LastName = value;
                }
            }
        }

        private string _ID;
        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (value.Length > 9)
                {
                    Console.WriteLine("ID harus kurang dari 10 karakter");
                }
                else
                {
                    _ID = value;
                }
            }
        }

        private string _Departement;
        public string Departement
        {
            get
            {
                return _Departement;
            }
            set
            {
            	_Departement = value;
            }
        }

        private SexOfPerson _Sex;
        public SexOfPerson Sex
        {
            get
            {
                return _Sex;
            }
            set
            {
            	_Sex = value;
            }
        }

        public User(string firstname, string lastname, string departement, string id, SexOfPerson sex)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            Departement = departement;
            Sex = sex;
        }
    }
}
