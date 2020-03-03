using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Attribute_and_Type_Definition_Management_Tool;
using PlugIn8.Model;
using PlugIn8.Views;

namespace PlugIn8.ViewModel
{
    public class VmAvailableAttr : Helpers.VmBase
    {
        private AvailableAttrWIndow availableAttrWIndow;
        public List<ObjectItemViewModel> Tree { get; }
        public ICommand CmdSelect { get; set; }


        public VmAvailableAttr(AvailableAttrWIndow availableAttrWIndow, List<ObjectItemViewModel> tree)
        {
            Tree = tree;
            this.availableAttrWIndow = availableAttrWIndow;
            CmdSelect = new Helpers.RelayCommand(ExeSelect);
        }

        public void ExeSelect(object obj)
        {
            foreach (var item in Tree)
            {
                foreach (var child in item.Children)
                {

               
                if (child.Checked == true)
                {
                    MainWindow main = new MainWindow();
                    main.DataContext = new VmMainWindow1(child);

                    }
                }
            }
        }
    }
}
