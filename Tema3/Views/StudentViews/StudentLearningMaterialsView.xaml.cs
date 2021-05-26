using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tema3.Views
{
    /// <summary>
    /// Interaction logic for StudentLearningMaterialsView.xaml
    /// </summary>
    public partial class StudentLearningMaterialsView : UserControl
    {
        public StudentLearningMaterialsView()
        {
            InitializeComponent();
        }
        private void DG_Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = (Hyperlink)e.OriginalSource;
            var uriString = link.NavigateUri.AbsoluteUri;
            //Process.Start(link.NavigateUri.AbsoluteUri);
        }
    }
}
