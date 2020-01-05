using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
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

namespace HtmlTest
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int counter = 0;

        public static WebBrowser m_wbBogen;

        public MainWindow()
        {
            InitializeComponent();
            WbBogen.Source = new Uri(@"C:\Users\Christoph\source\repos\HtmlTest\HtmlTest\Resources\Beobachtungsbogen.html");
            ObjectForScriptingHelper helper = new ObjectForScriptingHelper(this);
            this.WbBogen.ObjectForScripting = helper;
            m_wbBogen = this.WbBogen;
        }

        [PermissionSet(SecurityAction.Demand, Name ="FullTrust")]
        [ComVisible(true)]
        public class ObjectForScriptingHelper
        {
            MainWindow mExternalWPF;
            public ObjectForScriptingHelper(MainWindow w)
            {
                this.mExternalWPF = w;
            }

            public void InvokeMeFromJavaScript(string jsscript)
            {
                SwitchColors(jsscript);
            }

            public void SwitchColors(string jsscript)
            {
                m_wbBogen.InvokeScript("FillField", new object[] { jsscript });
            }

        }
    }
}
