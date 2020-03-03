//using Aucotec.EngineeringBase.Client.Runtime;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows.Media;

//namespace Attribute_and_Type_Definition_Management_Tool
//{
//    public class ObjectItemAttr:Helpers.VmBase
//    {
//        public ObjectItem Source; 
//        public ObjectCollection Sources;
//        private AttributeItem attrib;
//        public bool Checkbox { get; set; }
//        public ImageSource Icon { get; }
//        public string Name { get; }
//        public List<ObjectItemAttr> Children { get; }

//        public ObjectItemAttr(ObjectItem source)
//        {
//            Source = source;
//            Name = source.Name;
//            Icon = source.Image;
//            Children = new List<ObjectItemAttr>();
//            // Sources = source.FindObjects(ObjectKind.Attributes, SearchBehavior.Deep);
//            List<string> test = new List<string>();
//            test.Add("HI");
//            test.Add("yes");
//            foreach (var child in test)
//            {
//                //  foreach (var attrib in child.Attributes)
//                //  {
//                Children.Add(new ObjectItemAttr(child));
//              //  }
//            }
//        }

//        public ObjectItemAttr(AttributeItem attrib)
//        {
//            this.attrib = attrib;
//            Name = attrib.Name;

//        }
//    }
//}
