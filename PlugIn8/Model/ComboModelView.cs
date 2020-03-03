using Aucotec.EngineeringBase.Client.Runtime;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PlugIn8
{
    public class ComboModelView: Helpers.VmBase
    {
        private string _typeName;
        public string TypeName
        {
            get
            {
                return _typeName;
            }

            set
            {
                _typeName = value;
                OnPropertyChanged("TypeName");
            }
        }


        public ComboModelView(ObjectItem equipSource)
        {

            TypeName = equipSource.Name;
        }

        public ComboModelView()
        {
        }


    }
}
