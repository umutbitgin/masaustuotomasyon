﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giris
{
    
    static class Program
    {
        // Tüm formlarda veri tabanı bağlantısı örnek: Progam.bag_str
        public static string bag_str = "Data Source=umut\\sqlexpress;Initial Catalog=DBOtomasyon;Integrated Security=True";
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Giris());
        }
    }
}
