using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    [Description("The image associated with the control"), Category("Appearance")] 
    public class FunctionDesctiptions
    {
        [Description("The image associated with the control"), Category("Appearance")] 
        public void Foo()
        {
            
        }

        public void GetDescription()
        {
            // Gets the attributes for the property.
             AttributeCollection attributes =
                TypeDescriptor.GetProperties(this)["FunctionDesctiptions"].Attributes;

             /* Prints the description by retrieving the DescriptionAttribute 
              * from the AttributeCollection. */
             DescriptionAttribute myAttribute = 
                (DescriptionAttribute)attributes[typeof(DescriptionAttribute)];

             Console.WriteLine(myAttribute.Description);
        }
    }
}
