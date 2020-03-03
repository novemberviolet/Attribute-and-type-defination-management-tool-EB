using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aucotec.EngineeringBase.Client.Runtime;

namespace PlugIn8
{
    public class MaskDescriptionModel
    {
        public List<MaskDescriptionModel> TreeView { get; set; }
        public ObjectMaskDescription TabName { get; set; }
        public List<ObjectMaskDescription> TabAttributes { get; set; }
        public ObjectCollection TabAttributesWithId { get; set; }
        public string TabNameString { get; set; }  
        public string Typename { get; set; }
        public string FolderName { get; set; }
    }
}