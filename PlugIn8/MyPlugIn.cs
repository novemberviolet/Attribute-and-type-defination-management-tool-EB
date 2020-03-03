using System;
using System.AddIn;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interop;
using System.Windows.Threading;
using Aucotec.EngineeringBase.Client.Runtime;

namespace Attribute_and_Type_Definition_Management_Tool
{
    /// <summary>
    /// Implements Wizard Attribute and Type Definition Management Tool
    /// </summary>
    [AddIn("Attribute and Type Definition Management Tool", Description = "Attribute wizard for specification catalogue", Publisher = "Yuvarani")]
    public class MyPlugIn : PlugInWizard
    {
        /// <summary>
        /// Runs the wizard.
        /// </summary>
        /// <param name="myApplication">Application object instance</param>	
        public override void Run(Application myApplication)
        {
            MainWindow frm = new MainWindow();
            frm.DataContext = new VmMainWindow1.VmMainWindow(frm, myApplication);

            WindowInteropHelper wih = new WindowInteropHelper(frm);
            wih.Owner = myApplication.ActiveWindow.Handle;
            frm.ShowDialog();

            // Make a synchronously shutdown
            if (!AppDomain.CurrentDomain.IsDefaultAppDomain())
                Dispatcher.CurrentDispatcher.InvokeShutdown();
        }
    }
}

