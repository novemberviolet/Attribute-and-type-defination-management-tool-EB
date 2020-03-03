using Aucotec.EngineeringBase.Client.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Attribute_and_Type_Definition_Management_Tool
{
    public class VmAttrWindow : Helpers.VmBase
    {
        public Application myApplication;
      //  public List<ObjectItemAttr> Tree { get; }
        public ICommand CmdSelect { get; set; }
        public List<string> GetAtrName;

        public bool AttrID { get; set; }
        public string AttrName { get; set; }
        public bool Ugroup { get; set; }
        public bool Asst { get; set; }
        public bool DataSer { get; set; }
        public bool AttrFoldPath { get; set; }
        public bool DefU { get; set; }
        public bool Type { get; set; }

        public VmAttrWindow(Application myApplication) //, List<ObjectItemAttr> tree) //, new List<ObjectItemAttr>() { new ObjectItemAttr() }   
        {
            this.myApplication = myApplication;
           //Tree = tree;
            GetAtrName = new List<string>();
            CmdSelect = new Helpers.RelayCommand(ExeSelect);
        }

        private void ExeSelect(object obj)
        {
            if (AttrFoldPath == true)
            {
                // System.Windows.MessageBox.Show("True");
                GetAtrName.Add("AttrFoldPath");
                MainWindow mainWindow = new MainWindow();
                mainWindow.DataContext = new VmMainWindow1(GetAtrName);

            }
            if (DefU == true)
            {
                // System.Windows.MessageBox.Show("True");
                GetAtrName.Add("Def_Unit");
                MainWindow mainWindow = new MainWindow();
                mainWindow.DataContext = new VmMainWindow1(GetAtrName);

            }
            if (AttrID == true)
            {
               // System.Windows.MessageBox.Show("True");
                GetAtrName.Add("ID");
                MainWindow mainWindow = new MainWindow();
                mainWindow.DataContext = new VmMainWindow1(GetAtrName);

            }
            if (Asst == true)
            {
                // System.Windows.MessageBox.Show("True");
                GetAtrName.Add("Assistant");
                MainWindow mainWindow = new MainWindow();
                mainWindow.DataContext = new VmMainWindow1(GetAtrName);

            }
            if (Ugroup == true)
            {
                // System.Windows.MessageBox.Show("True");
                GetAtrName.Add("Unit_group");
                MainWindow mainWindow = new MainWindow();
                mainWindow.DataContext = new VmMainWindow1(GetAtrName);

            }
            if (DataSer == true)
            {
                // System.Windows.MessageBox.Show("True");
                GetAtrName.Add("Data_Service");
                MainWindow mainWindow = new MainWindow();
                mainWindow.DataContext = new VmMainWindow1(GetAtrName);

            }
            if (Type == true)
            {
                // System.Windows.MessageBox.Show("True");
                GetAtrName.Add("Type");
                MainWindow mainWindow = new MainWindow();
                mainWindow.DataContext = new VmMainWindow1(GetAtrName);

            }
            //Tree.ForEach(parent => { parent.Children.ForEach(child => {
            //   if (child.Checkbox == true)
            //        {
            //            GetAtrName.Add(child.Name);
            //            MainWindow mainWindow = new MainWindow();
            //            mainWindow.DataContext = new MainWindow(GetAtrName);

            //        }
            //    }); });

        }
    }
}
