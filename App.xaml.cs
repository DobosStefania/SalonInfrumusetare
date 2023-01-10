using System;
using SalonInfrumusetare.Data;
using System.IO;
namespace SalonInfrumusetare;


    public partial class App : Application
    {
        static ServiciuDatabase database;
        public static ServiciuDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   ServiciuDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder. LocalApplicationData), "Serviciu.db3"));
                }
                return database;
            }
        }

        public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
