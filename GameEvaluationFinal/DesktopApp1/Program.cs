using System;
using System.Windows.Forms;
using AdministrationLibrary;
using Logic;
using DatabaseLibrary;
using Microsoft.Extensions.Configuration;
using System.Configuration;

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

            IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

            object parameter = new object();  

            IGameDBHelper gameDBHelper = new GameDBHelper(configuration);
            IReviewDBHelper reviewDBHelper = new ReviewDBHelper(configuration);
            IUserDBHelper userDBHelper = new UserDBHelper(configuration);
            
            IGameAdministration gameAdmin = new GameAdministration(gameDBHelper);
            IUserAdministration userAdmin = new UserAdministration(userDBHelper);
            IReviewAdministration reviewAdmin = new ReviewAdministration(reviewDBHelper);


            Application.Run(new Form1(gameAdmin, userAdmin, reviewAdmin));
        }
    }
}