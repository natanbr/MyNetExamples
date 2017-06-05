using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;

namespace CSharp.AdvCs
{
    public class CodeDOMSample
    {
        public static void CodeDOMSampleMain()
        {
            try
            {
                var compileUnit = CreateCompileUnit();

                Compile(compileUnit, @"c:\temp\Hello.Exe");

                Console.WriteLine("Success!");
            }
            catch (CompileException ex)
            {
                Console.WriteLine("Errors in compilation");
                
                foreach (CompilerError err in ex.Errors)
                    Console.WriteLine(err);
            }
        }

        private static CodeCompileUnit CreateCompileUnit()
        {
            // create a class

            var helloClass = new CodeTypeDeclaration("Hello")
            {
                IsClass = true,
                Attributes = MemberAttributes.Assembly
            };

            // create the Main method

            var main = new CodeMemberMethod
            {
                Name = "Main",
                ReturnType = new CodeTypeReference(typeof(void)),
                Attributes = MemberAttributes.Public | MemberAttributes.Static
            };

            var stringExpression = new CodePrimitiveExpression("hello, Code DOM!");
            var consoleReference = new CodeTypeReferenceExpression(typeof(Console));

            main.Statements.Add(new CodeMethodInvokeExpression(consoleReference, "WriteLine", stringExpression));
            // add the method to the class
            helloClass.Members.Add(main);

            // create a namespace
            CodeNamespace ns = new CodeNamespace("CodeDOMDemo");

            // add the class to the namespace
            ns.Types.Add(helloClass);

            // create a code-compile unit
            CodeCompileUnit compileUnit = new CodeCompileUnit();

            // add the namespace to the code-compile unit
            compileUnit.Namespaces.Add(ns);

            return compileUnit;
        }

        private static void Compile(CodeCompileUnit compileUnit, string exeName)
        {
            // prepare for compilation

            CodeDomProvider codeProvider = new CSharpCodeProvider();
            CompilerParameters compilerParameters = new CompilerParameters
            {
                GenerateExecutable = true,
                GenerateInMemory = false,
                IncludeDebugInformation = true,
                OutputAssembly = exeName
            };

            codeProvider.GenerateCodeFromCompileUnit(compileUnit, Console.Out, new CodeGeneratorOptions());

            // compile!
            CompilerResults result = codeProvider.CompileAssemblyFromDom(compilerParameters, compileUnit);
            if (result.Errors.Count > 0)
            {
                throw new CompileException
                {
                    Errors = result.Errors
                };
            }

            // Get asssembly
            Assembly assembly = result.CompiledAssembly;
        }

        class CompileException : Exception
        {
            public CompilerErrorCollection Errors { get; set; }
        }
    }
}
