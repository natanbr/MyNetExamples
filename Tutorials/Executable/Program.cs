using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp;
using CSharp.AdvCs;
using CSharp.AdvCs.EventsDelegateSample;
using DiffMatchPatch;
using LinqToXmlEx;

namespace Executable
{
    class Program
    {
        private static void Main(string[] args)
        {
            Plink.Ex7Execute();

            TcpWrite.Execute();

            MailSystemMain.Execute();


            #region Adavnced C# Course 

            #region Reflections, DOMs
            ReflectionSamples.ReflectionSamplesMain();
            AttributeDemo.AnalayzeAssembly();
            CodeDOMSample.CodeDOMSampleMain();
            DynInvoke.DynInvokeMain();

            // Get description from function
            (new FunctionDesctiptions()).GetDescription();
            // Get the description from the enum
            EnumDescriptionExample();
            #endregion

            #region Templates
            VarianceSamples.VarianceSamplesMain();
            #endregion

            #region Managin Resources

            #endregion

            #region ...
            #endregion

            #endregion

            // Diff between code example
            Diff();
        }

        private static void Diff()
        {
            //var res = DiffUtiles.DiffText("abcbasdf sdfasdfasd", "abcdcb", true, true, false);
            var d = new diff_match_patch();
            var res = d.diff_main("abcabxyz bbb", "abcabxyz a bbb");
            var res2 = d.diff_prettyHtml(res);
        }

        public static void EnumDescriptionExample()
        {
            Console.WriteLine("Enum example: \n");

            var descOfVal0 = Enums.GetEnumDescriptionByValue(DescriptionEnum.VAL0);
            var descOfVal1 = Enums.GetEnumDescriptionByValue(DescriptionEnum.VAL1);

            Console.WriteLine("description of {0} = {1} is \"{2}\"\n", "DescriptionEnum.VAL0", DescriptionEnum.VAL0, descOfVal0);
            Console.WriteLine("description of {0} = {1} is \"{2}\"\n", "DescriptionEnum.VAL1", DescriptionEnum.VAL1, descOfVal1);
        }


    }
}
