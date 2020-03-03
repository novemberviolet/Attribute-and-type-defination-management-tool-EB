using Aucotec.EngineeringBase.Client.Runtime;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
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

namespace Attribute_and_Type_Definition_Management_Tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class DeviceAndIndex
        {
            public ObjectItem Device;
            public int index;
        }

        private ObservableCollection<ModelData> _MyGrid;
        public ObservableCollection<ModelData> MyGrid
        {
            get { return _MyGrid; }
            set
            {
                _MyGrid = value;
            }
        }

        public static List<string> GetAtrName { get; set; }
        public List<DeviceAndIndex> GetDeviceAndIndex { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            GetDeviceAndIndex = new List<DeviceAndIndex>();



        }

        public MainWindow(List<string> getAtrName)
        {

            GetAtrName = getAtrName;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //DataGridTextColumn c1 = new DataGridTextColumn();
            //c1.Header = "Num";
            //c1.Binding = new Binding("Num");
            //c1.Width = 110;
            //dataGrid.Columns.Add(c1);
            //DataGridTextColumn c2 = new DataGridTextColumn();
            //c2.Header = "Start";
            //c2.Width = 110;
            //c2.Binding = new Binding("Start");
            //dataGrid.Columns.Add(c2);
            //DataGridTextColumn c3 = new DataGridTextColumn();
            //c3.Header = "Finich";
            //c3.Width = 110;
            //c3.Binding = new Binding("Finich");
            //dataGrid.Columns.Add(c3);

            //var items = new List<Item>();
            //items.Add(new Item() { Start = "Fido" });
            //items.Add(new Item() { Start = "Fido" });
            //items.Add(new Item() { Start = "Fido" });
            //dataGrid.ItemsSource = items;

            var vm = DataContext as VmMainWindow1.VmMainWindow;

            AttrWindow attrWindow = new AttrWindow();
            attrWindow.DataContext = new VmAttrWindow(vm.myApplication);
            attrWindow.ShowDialog();

            if (GetAtrName != null)
            {
                foreach (var item in GetAtrName)
                {
                    DataGridTextColumn textColumn = new DataGridTextColumn();
                    textColumn.Header = item;
                    textColumn.Binding = new Binding(item);
                    textColumn.DisplayIndex = 1;
                    textColumn.MinWidth = 2;
                    dataGrid.Columns.Add(textColumn);

                    var items = new List<Item>();

                    foreach (var i in vm.MyGrid)
                    {
                        items.Add(new Item() { Attributes = i.Attributes, ID = i.ID, Def_Unit = i.Def_Unit, Data_Service = i.Data_Service, Assistant = i.Assistant, Type = i.Type, AttrFoldPath = i.AttrFoldPath });
                    }
                    //    //items.Add(new Item() { AttrID =  });
                    //    //items.Add(new Item() { AttrID = "Fido" });
                    //    //items.Add(new Item() { AttrID = "Fido" });
                    //    dataGrid.ItemsSource = items;
                    //}
                }
            }

            }

        public class Item
        {
            public string AID_001 { get; set; }
            public int Num { get; set; }
            public string Attributes { get; set; }
            public int ID { get; set; }
            public string Unit_group { get; set; }
            public string Assistant { get; set; }
            public string Data_Service { get; set; }
            public string AttrFoldPath { get; set; }
            public string Def_Unit { get; set; }
            public string Type { get; set; }
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as VmMainWindow1.VmMainWindow;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        public void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as VmMainWindow1.VmMainWindow;
            //if (GetDeviceAndIndex != null && GetDeviceAndIndex.Count >= 1)
            //{
            //    //foreach (var item in GetDeviceAndIndex)
            //    //{
            //    //   var check = dataGrid.Columns.Where(x => x.Header as String == item.Device.Name).FirstOrDefault();

            //    //    if(check!= null )
            //    //    dataGrid.Columns.Remove(check);

            //    //}                           


            //}

            int i = 1;

            var itemFromBack = vm.getAllDeviceMat();

            var TypesToShow = itemFromBack.Where(X => X.TypeName == vm.SelType.TypeName).ToList();

            foreach (var item in TypesToShow)
            {
                if (item.TypeName == vm.SelType.TypeName)
                {
                    DataGridTextColumn textColumn = new DataGridTextColumn();
                    textColumn.Header = item.Name;
                    textColumn.IsReadOnly = true;
                    textColumn.SortMemberPath = string.Format(item.Name, i);
                    textColumn.Binding = new Binding(string.Format(item.Name, i));
                    textColumn.DisplayIndex = i;
                    textColumn.MinWidth = 2;


                    dataGrid.Columns.Add(textColumn);

                    vm.ExeAdd(dataGrid);
                    var items = new List<Item>();
                    //    items.Add(new Item() {   Asst = "hi:" });

                    //  dataGrid.ItemsSource = items;

                    GetDeviceAndIndex.Add(new DeviceAndIndex() { Device = item, index = i });
                    i++;
                }
            }

            //vm.CmdAdd.Execute(dataGrid);

        }

        private void Combo_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void Combo_DropDownOpened(object sender, EventArgs e)
        {

        }

        private void Combo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var vm = DataContext as VmMainWindow1.VmMainWindow;
            var Combo = sender as ComboBox;
            Combo.ItemsSource = vm.Type;
            vm.Type.Clear();
            vm.StringType.ForEach(item => {
                if (item.ToLower().Contains(Combo.Text.ToLower()))
                {
                    vm.Type.Add(new  PlugIn8.ComboModelView() { TypeName = item });
                }
             
            });
          

        }

        private void ContextMenu_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg == null) return;
            var index = dg.SelectedIndex;
            //here we get the actual row at selected index
            DataGridRow row = dg.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
         
            //here we get the actual data item behind the selected row
            var item = dg.ItemContainerGenerator.ItemFromContainer(row);

            var vm = DataContext as VmMainWindow1.VmMainWindow;

            vm.ExeAddAttr(index);
        }
    }
    }


