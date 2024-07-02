using System;
using System.Windows.Forms;
using AdministrationLibrary;
using GameEvaluationProject;
using Logic;

namespace DesktopApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            IDBHelper dbHelper = new DBHelper(); 

            
            IGameAdministration gameAdmin = new GameAdministration(dbHelper);

          
            Application.Run(new Form1(gameAdmin));
        }
    }
}