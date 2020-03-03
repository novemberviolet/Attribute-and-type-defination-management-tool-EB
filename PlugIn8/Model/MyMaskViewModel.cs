using Aucotec.EngineeringBase.Client.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlugIn8
{
    public class MyMaskViewModel
    {
        public string Name { get; private set; }
        public List<MyAttributeViewModel> Attributes { get; set; }
    


        public MyMaskViewModel(ObjectMaskDescription maskItem)
        {
            Name = maskItem.Name;
            Attributes = new List<MyAttributeViewModel>();
        }
    }
}
