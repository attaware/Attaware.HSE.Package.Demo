using Attaware.HSE.Core.Processing;
using Attaware.HSE.Core.Processing.Types;
using Attaware.HSE.Core.Types;
using Attaware.HSE.Core.Types;
using Attaware.HSE.Core.Utilities;
using System;
using System.Text.RegularExpressions;
using static Attaware.HSE.Core.Utilities.StringUtilities;


 

namespace Attaware.HSE.Package.Demo.Processing.Directives
{

    
        public class DemoEnclosureArgDirective :  EnclosureArgDirectiveBase
    {


        public DemoEnclosureArgDirective(
            HSEProcessor processor,
            string symbol,
            string[] keys)
            : base(processor,
                  symbol,
                  keys,
                    new("{", "}"), // EnclosurePairs
                   new ("(", ")"),// ArgEnclosurePairs 
                   "=",// ArgsAssignator
                    new[] { " ", "\t", "\n" }, //Args Separators
                  new () { { "greet", "Hello" } }// InitialArgs


                  )
        {
        }


        public override async Task<bool> OnCapture(CaptureContext capture, HSEProcessorSpan span)
        {


            //Processor.Engine.ExecutionContext.__.WriteLine("START EnclosureArgDirective");
            //// HEADER
            //Processor.Engine.ExecutionContext.__.WriteLine("HEADER:");

            //Processor.Engine.ExecutionContext.__.WriteLine(" - " + capture.Header.View);

            //// ARGS
            //if (capture.Args!=null && capture.Args!.Count > 0)
            //{
            //    Processor.Engine.ExecutionContext.__.WriteLine("ARGS:");
            //    foreach (var arg in capture.Args!)
            //    {
            //        Processor.Engine.ExecutionContext.__.WriteLine(" - " + arg.Key + ":" + arg.Value);

            //    }
            //}

            //if (capture.Enclosure != null)
            //{
            //    Processor.Engine.ExecutionContext.__.WriteLine("ENCLOSURE:");
            //    Processor.Engine.ExecutionContext.__.WriteLine(" - " + capture.Enclosure.Inner.View);

            //}

            //Processor.Engine.ExecutionContext.__.WriteLine("END EnclosureArgDirective");



            if (capture.Header != null) Processor.Engine.ExecutionContext.__.Write(StringUtilities.RemoveComments(capture.Header.View!).Trim() + ((capture.Args == null && capture.Body == null) ? "\n" : ""));
            if (capture.Args != null) Processor.Engine.ExecutionContext.__.Write(" ARGUMENTS " + string.Join(",", capture.Args!.Select(kv => $"{kv.Key}:{kv.Value}")).Trim() + ((capture.Body == null) ? "\n" : ""));

            if (capture.Body != null) Processor.Engine.ExecutionContext.__.WriteLine(" " + StringUtilities.RemoveComments(capture.Body.Inner.View!).Trim());
         
            
            return true;
        }
           
         
    }
}
 