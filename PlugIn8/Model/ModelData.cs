using Aucotec.EngineeringBase.Client.Runtime;
using PlugIn8.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Attribute_and_Type_Definition_Management_Tool
{
    public class ModelData:Helpers.VmBase
    {

        private AttributeId _mask;
        public AttributeId Mask
        {
            get { return _mask; }
            set
            {
                _mask = value;
                OnPropertyChanged("Mask");
            }
        }

        private string _fontSize;
        public string FontSize
        {
            get { return _fontSize; }
            set
            {
                _fontSize = value;
                OnPropertyChanged("FontSize");
            }
        }
        
        private SolidColorBrush _fontSet;
        public SolidColorBrush FontSet
        {
            get { return _fontSet; }
            set
            {
                _fontSet = value;
                OnPropertyChanged("FontSet");
            }
        }

        private SolidColorBrush _colorSet;
        public SolidColorBrush ColorSet
        {
            get { return _colorSet; }
            set
            {
                _colorSet = value;
                OnPropertyChanged("ColorSet");
            }
        }
        public ObjectItem Source;

        private string _attributes;
        public string Attributes
        {
                get { return _attributes; }
                set
                {
                _attributes = value;
                    OnPropertyChanged("Attributes");
                }
            }

        private string _desc;
        public string Desc
            {
                get { return _desc; }
                set
                {
                    _desc = value;
                    OnPropertyChanged("Desc");
                }
            }

        private int  _iD;
        public int ID
        {
            get { return _iD; }
            set
            {
                _iD = value;
                OnPropertyChanged("ID");
            }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        private string _def_Unit;
        public string Def_Unit
        {
            get { return _def_Unit; }
            set
            {
                _def_Unit = value;
                OnPropertyChanged("Def_Unit");
            }
        }

        private string _attrFoldPath;
        public string AttrFoldPath
        {
            get { return _attrFoldPath; }
            set
            {
                _attrFoldPath = value;
                OnPropertyChanged("AttrFoldPath");
            }
        }

        private string _data_Service;
        public string Data_Service
        {
            get { return _data_Service; }
            set
            {
                _data_Service = value;
                OnPropertyChanged("Data_Service");
            }
        }

        private string _assistant;
        public string Assistant
        {
            get { return _assistant; }
            set
            {
                _assistant = value;
                OnPropertyChanged("Assistant");
            }
        }

        private string _unit_group;
        public string Unit_group
        {
            get { return _unit_group; }
            set
            {
                _unit_group = value;
                OnPropertyChanged("Unit_group");
            }
        }

        private string _tabBelongsToo;
        public string TabBelongsToo
        {
            get { return _tabBelongsToo; }
            set
            {
                _tabBelongsToo = value;
                OnPropertyChanged("TabBelongsToo");
            }
        }

        public List<Tuple<string, int>> Sizes
        {
            get;
            set;
        }

        
        public ModelData(ObjectItem source)
            {
                Source = source;
                Attributes = source.Name;
                Desc = source.Attributes.FindById(AttributeId.Description).ToString();
          
              
           }

            public ModelData()
            {
        }




    }
}
