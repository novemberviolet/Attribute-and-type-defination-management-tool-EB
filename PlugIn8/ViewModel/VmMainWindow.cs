using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Aucotec.EngineeringBase.Client.Runtime;
using PlugIn8;
using PlugIn8.Model;
using System.Data;
using PlugIn8.Views;
using PlugIn8.ViewModel;

namespace Attribute_and_Type_Definition_Management_Tool
{
        public class VmMainWindow1 : Helpers.VmBase
        {

        public static List<string> GetAttr;
        public static ObjectItemViewModel Child;

        public VmMainWindow1(List<string> getAttr)
        {

            GetAttr = getAttr;
            MainWindow main = new MainWindow();
            main.DataContext = new MainWindow(GetAttr);
             
        }

        public VmMainWindow1(ObjectItemViewModel child)
        {
            Child = child;
        }

        public class VmMainWindow : Helpers.VmBase
        {

           
            public ImageSource Icon { get; set; }
            public class TabandAttr
                {
                public ObjectMaskDescription Tab { get; set; }
                public string Attr { get; set; }
            }
            public List<string> StringType;
            public MainWindow frm;
            public List<ObjectItem> DeviceBasedOnType;
            public ComboModelView SelType { get; set; }
            public ModelData MySelectedItem { get; set; }
            private ObservableCollection<ComboModelView> _Type;
            public ObservableCollection<ComboModelView> Type
            {
                get { return _Type; }
                set
                {
                    _Type = value;
                    OnPropertyChanged("Type");
                }
            }
            public ICommand CmdAdd { get; set; }
            public ICommand CmdAddAttr { get; set; }
            public Application myApplication;
            private ObservableCollection<ModelData> _MyGrid;
            public ObservableCollection<ModelData> MyGrid
            {
                get { return _MyGrid; }
                set
                {
                    _MyGrid = value;
                    OnPropertyChanged("MyGrid");
                }
            }

            public VmMainWindow DataContext { get; private set; }

            public string catalogName;

            public VmMainWindow(MainWindow frm, Application myApplication)
            {
                DeviceBasedOnType = new List<ObjectItem>();
                this.frm = frm;
                this.myApplication = myApplication;
                MyGrid = new ObservableCollection<ModelData>();  
                CmdAdd = new Helpers.RelayCommand(ExeAdd);
                CmdAddAttr = new Helpers.RelayCommand(ExeAddAttr);
                Type = new ObservableCollection<ComboModelView>();
                StringType = new List<string>();
                MaterialModel _devices = new MaterialModel();
               

                myApplication.Selection[0].ExecuteFormula("Ut;A5;", out catalogName); //only if run from materials and uner materials. have to do one for standardkatalog

                MaskDescriptionModel mappedDesc = new MaskDescriptionModel();
                myApplication.Folders.Catalogs.Children.ToList().ForEach(items =>
                {
                    if (items.Name == catalogName)
                    {
                        _devices.DeviceObjMat = getAllDeviceMat();
                       _devices.DeviceByStringTypes = getAllDeviceByStringType(_devices.DeviceObjMat);
                        getAllDeviceByStringType(_devices.DeviceObjMat).Distinct().ToList().ForEach(item => { Type.Add(new ComboModelView() { TypeName = item });  StringType.Add(item);  });

                    }
                });
               
                Icon = myApplication.Folders.Attributes.Image;


            }

            public void ExeAddAttr(object obj)
            {

                //  System.Windows.MessageBox.Show(MySelectedItem.Source.Name);
                ObjectItem itemInEB = myApplication.Utils.GetSingleObjectByID(myApplication.Folders.Attributes.Id);
                AvailableAttrWIndow availableAttrWIndow = new AvailableAttrWIndow();
                availableAttrWIndow.DataContext = new VmAvailableAttr(availableAttrWIndow, new List<ObjectItemViewModel>() { new ObjectItemViewModel(itemInEB) });
                availableAttrWIndow.ShowDialog();

                SolidColorBrush mySolidColorBrush3 = new SolidColorBrush { Color = Colors.Black };

                var selindex = obj;
                int index = (int)selindex + 1;
                MyGrid.Insert(index, new ModelData() { Attributes = Child.Name, FontSet = mySolidColorBrush3 });



            }

            private List<MaskDescriptionModel> MapMaskDescriptionModel(IList<ObjectMaskDescription> maskDescription)
            {
                List<MaskDescriptionModel> tabsAndAtt = new List<MaskDescriptionModel>();
                MaskDescriptionModel singletab = new MaskDescriptionModel();
                foreach (var obj in maskDescription)
                {
                    if (obj.ID.Equals(AttributeId.Unspecified))
                    {
                        if (singletab.TabAttributes != null)
                            tabsAndAtt.Add(singletab);

                        singletab = new MaskDescriptionModel();
                        singletab.TabName = obj;
                    }

                    if (singletab.TabAttributes == null)
                        singletab.TabAttributes = new List<ObjectMaskDescription>();

                    if (!obj.ID.Equals(AttributeId.Unspecified))
                        singletab.TabAttributes.Add(obj);

                }

                if (singletab != null)
                    tabsAndAtt.Add(singletab);

                return tabsAndAtt;

            }

            private IList<ObjectMaskDescription> GetMaskDescription(string Typeid)
            {
                IList<ObjectMaskDescription> maskData = new List<ObjectMaskDescription>();
                ExApplication exApp = this.myApplication as ExApplication;
                exApp.ExtendedUtils.GetObjectsMaskDescription(0, Typeid, ref maskData);
                return maskData;
            }

            public List<AttributeItem> getAvailableAttrMat(List<ObjectItem> deviceObjMat)
            {
                List<AttributeItem> DistinctGetAvailableAttrMat = new List<AttributeItem>();

                deviceObjMat.ForEach(item =>
                {
                    item.Attributes.ToList().ForEach(attrib => {
                        DistinctGetAvailableAttrMat.Add(attrib);
                      
                    });
                });

                List<AttributeItem> GetAvailableAttrMat = DistinctGetAvailableAttrMat.GroupBy(elem => elem.Name).Select(group => group.First()).ToList();
                return GetAvailableAttrMat;
            }

            public List<ObjectItem> getAllDeviceMat()
            {
                List<ObjectItem> GetAllDeviceMat = new List<ObjectItem>();       
                ObjectCollection GetAllFol = myApplication.Selection[0].FindObjects(ObjectKind.Folder, SearchBehavior.Deep);
                GetAllFol.ToList().ForEach(item => { item.Children.ToList().ForEach(item2 => { GetAllDeviceMat.Add(item2); }); });
                return GetAllDeviceMat;
            }

            public List<string> getAllDeviceByStringType(List<ObjectItem> devices)
            {
                List<string> Types = new List<string>();
                devices.ForEach(item => { Types.Add(item.TypeName); });
                List<string> GetAllDeviceStringType = Types.Distinct().ToList();
                return GetAllDeviceStringType;
            }

            public void ExeAdd(object obj)
            {
                MyGrid.Clear();
                var data = obj as DataGrid;

                var DeviceMat = getAllDeviceMat();
                var TypesToShow = DeviceMat.Where(X => X.TypeName == SelType.TypeName).ToList();

                List<DeviceModel> DevicesAndDetail = new List<DeviceModel>();

                foreach (var item in TypesToShow)
                {

                    DeviceModel SingleDevice = new DeviceModel();
                    SingleDevice.Device = item;
                    var maskDesc = GetMaskDescription(item.Id);
                    var tabsAndAtt = MapMaskDescriptionModel(maskDesc);

                    DeviceBasedOnType.Add(item); //check what is item
                    SingleDevice.TabsAndAttribute = tabsAndAtt;
                    DevicesAndDetail.Add(SingleDevice);

                }
                var listToShow = MergeMultiTabsAttributes(DevicesAndDetail);
                foreach (var item in listToShow)
                {
                    item.TabAttributesWithId = searchAttribute(item.TabAttributes).FirstOrDefault();
                 
                    foreach (var IdItems in item.TabAttributesWithId.ToList())
                    {
                        var Destinationpath = GetPath(IdItems);
                       
                    }
                }
                #region close
                List<GetAttrDesc> AttrDetails = new List<GetAttrDesc>();
                //var GetTabAttributesWithId = from x in listToShow from f in x.TabAttributesWithId from y in f.ToList() select y;
                //GetTabAttributesWithId.ToList().ForEach(y => 
                //{
                //    AttrDetails = GetAttrDescs(y);

                //});

                //listToShow.ForEach(x =>
                //{
                //    SolidColorBrush mySolidColorBrush = new SolidColorBrush { Color = Colors.SteelBlue };
                //    SolidColorBrush mySolidColorBrush2 = new SolidColorBrush { Color = Colors.White };
                //    MyGrid.Add(new ModelData() { FontSize = "13", ColorSet = mySolidColorBrush, Attributes = x.TabName.Name, FontSet = mySolidColorBrush2 });
                //    {
                //        AttrDetails.ForEach(y => { 
                //           SolidColorBrush mySolidColorBrush3 = new SolidColorBrush { Color = Colors.Black };
                //            MyGrid.Add(new ModelData() { FontSet = mySolidColorBrush3, Assistant = y.Asst, ID = y.AttrID, Data_Service = y.DataSer,  Attributes = y.AttrName,  Type = y.Type, Def_Unit = y.DefU, Unit_group = y.Ugroup, AttrFoldPath = y.AttrFoldPath });
                //        });
                //    }
                //});

                //listToShow.ForEach(x =>
                //{
                //    x.TabAttributesWithId.ForEach(f => f.ToList().ForEach(y =>
                //    {
                //        // foreach (var attr in y.Attributes)
                //        // {
                //        test = GetAttrDescs(y);

                //        //    }

                //    }));
                //});
                #endregion
                int val = 0;
                listToShow.ForEach(x =>
                {
                   
                    SolidColorBrush mySolidColorBrush = new SolidColorBrush { Color = Colors.SteelBlue };
                    SolidColorBrush mySolidColorBrush2 = new SolidColorBrush { Color = Colors.White };
                   
                    MyGrid.Add(new ModelData() { FontSize = "13", ColorSet = mySolidColorBrush, Attributes = x.TabName.Name, FontSet = mySolidColorBrush2 });
                    {
                        x.TabAttributesWithId.ToList().ForEach(y =>
                        {
                            var Destinationpath = GetPath(y);
                            SolidColorBrush mySolidColorBrush3 = new SolidColorBrush { Color = Colors.Black };
                            var getType = GetAttrType(y.Attributes.GetAttributeValue(AttributeId.AttributType));
                            var Dic = new Dictionary<string, object>();
                            var id = int.Parse(y.Attributes.GetAttributeValue(AttributeId.Aid));
                            //var DevicesToshow = DevicesAndDetail.Select(p => p.Device.Attributes.Where(l => l.Id == (AttributeId)id)).FirstOrDefault();
                            //var DevicesToshow = DevicesAndDetail.Where(p => p.Device.Attributes.Where(l => l.Id == (AttributeId)id))).S();
                            var DevicesToshow = from i in DevicesAndDetail from u in i.Device.Attributes where u.Id == (AttributeId)id select i;
                            foreach (var device in DevicesToshow)
                            {
                                Dic.Add(device.Device.Name, "X");
                            }

                            MyGrid.Add(new ModelData() { Type = getType.ToString(), Source = y, Data_Service = y.Attributes.GetAttributeValue((AttributeId)177, null), FontSet = mySolidColorBrush3, ID = id, Attributes = y.Name, TabBelongsToo = x.TabName.Name, Assistant = y.Name, AttrFoldPath = Destinationpath, Unit_group = y.Attributes.GetAttributeValue((AttributeId)698, null), Custom = Dic });
                            val++;
                        });
                    }
                });
              
            }

            private object GetAttrType(string v)
            {
                string lType = v;
                string sTypeName = "";
                switch (lType)
                {
                    case "3":
                        sTypeName = "Number";
                        break;
                    case "8":
                        sTypeName = "String";
                        break;
                    case "11":
                        sTypeName = "Boolean";
                        break;
                  
                }
                return sTypeName;
            }

            private string GetPath(ObjectItem oi)
            {
               
                string folders = "";

                try
                {
                    var p = oi.Parent;

                    if (p.Kind == ObjectKind.Attributes)
                    {
                        folders = p.Name + "/" + oi.FullName;
                    }
                    else
                    {
                        while (p.Kind != ObjectKind.Attributes)
                        {
                            if (folders != "")
                                folders = p.Name + "/" + folders;
                            else
                                folders = p.Name;
                            p = p.Parent;
                        }
                    }
                }
                catch (Exception ex)
                {
                    folders = "Not Found !";
                }
                return folders;
            }

            private List<MaskDescriptionModel> MergeMultiTabsAttributes(List<DeviceModel> DevicesAndDetail)
            {

                var DevicesWithMergedAttributesAndTab = (from devices in DevicesAndDetail
                                                         from TabsAttri in devices.TabsAndAttribute
                                                         group TabsAttri by TabsAttri.TabName into TabsAtt
                                                         select new MaskDescriptionModel()
                                                         {
                                                             TabName = TabsAtt.Key,
                                                             TabAttributes = (from TabAndAtt in TabsAtt
                                                                              from Attributes in TabAndAtt.TabAttributes
                                                                              group Attributes by Attributes.ID into GroupedIds
                                                                              select GroupedIds.Select(m => m).First()).ToList()
                                                         });


                return DevicesWithMergedAttributesAndTab.ToList();

            }

            private List<ObjectCollection> searchAttribute(List<ObjectMaskDescription> Attributes)
            {
                ObjectCollection AttObj = null;
                List<ObjectCollection> AttObjList = new List<ObjectCollection>();
                MultiFilterExpression fa = myApplication.CreateMultiFilter();
                int i = 0;
                try
                {
                    if (Attributes.Count != 0)
                    {
                        foreach (var item in Attributes)
                        {
                            i++;
                            FilterExpression fe = myApplication.CreateFilter();
                            var sxc = (int)item.ID;
                            //fe.FindById((AttributeId)sxc);
                            fe.Add((AttributeId.Aid), BinaryOperator.Equal, sxc);
                            fa.AddFilter(fe);
                            if (i == 25)
                            {
                                AttObj = myApplication.Folders.Attributes.FindObjects(fa, true);
                                fe = myApplication.CreateFilter();
                                AttObjList.Add(AttObj);
                            }
                            else if (i == 50)
                            {
                                AttObj = myApplication.Folders.Attributes.FindObjects(fa, true);
                                fe = myApplication.CreateFilter();
                                AttObjList.Add(AttObj);
                            }
                        }
                        AttObj = myApplication.Folders.Attributes.FindObjects(fa, SearchBehavior.Deep);

                        var t = from u in AttObj from k in Attributes where u.Name != k.Name select k;
                        AttObjList.Add(AttObj);
                    }
                }
                catch { System.Windows.MessageBox.Show("Finding Attribute Failed", "System Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error); }
                return AttObjList;
            }

        }
       

    }
}