
using Student.DB;
using Student.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Student
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (StudentDB db = new StudentDB())
            {
                db.Configuration.LazyLoadingEnabled = true;
                IQueryable<Group> grp = db.Groups;

                foreach (var p in grp.Select(p => p.Student))
                {
                    ;
                }

            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
