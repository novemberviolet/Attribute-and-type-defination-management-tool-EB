using Aucotec.EngineeringBase.Client.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace PlugIn8.Model
{
    public class ObjectItemViewModel : Helpers.VmBase
    {

        public TypeDefinition Source;
        public List<ObjectItemViewModel> Tree { get; }
        public string Name { get; }
        public bool Checked { get; set; }
        public ObjectItem typeDefinitions;
        public ImageSource Icon { get; }
        public List<ObjectItemViewModel> Children { get; }  //bcos its a list

  
        public ObjectItemViewModel(ObjectItem typeDefinitions)
        {
            this.typeDefinitions = typeDefinitions;
            Children = new List<ObjectItemViewModel>();
            Name = typeDefinitions.Name;
            Icon = typeDefinitions.Image;
            foreach (var item in typeDefinitions.Children)
            {
             
                Children.Add(new ObjectItemViewModel(item));
             
            }

        }


    }
}
