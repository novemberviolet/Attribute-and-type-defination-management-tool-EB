using Aucotec.EngineeringBase.Client.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlugIn8.Model
{
    public class DeviceModel
    {
       public ObjectItem Device { get; set; }
       public List<MaskDescriptionModel> TabsAndAttribute { get; set; }
    }
}
