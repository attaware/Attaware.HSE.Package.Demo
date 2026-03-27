using Attaware.HSE.Core.Processing;
using Attaware.HSE.Core.Types;
using Attaware.HSE.Core.Types;
using Attaware.HSE.Core.Utilities;
using System;
using static Attaware.HSE.Core.Utilities.StringUtilities;



namespace Attaware.HSE.Package.Demo.Processing.Directives
{
     
      
    public class DemoBlockDirective : BlockDirectiveBase
    { 

         
        public DemoBlockDirective(
            HSEProcessor processor,
            string symbol,
            string[] keys )
            : base(processor, symbol, keys    )
        {
        }

        public override async Task<bool> OnCapture(CaptureContext capture, HSEProcessorSpan span)
        {


            //Processor.Engine.ExecutionContext.__.WriteLine("START BlockDirective");


            //Processor.Engine.ExecutionContext.__.WriteLine("HEADER:");

            //Processor.Engine.ExecutionContext.__.WriteLine(" - " + capture.Header.View);

            //Processor.Engine.ExecutionContext.__.WriteLine("ENCLOSURE:");
            //Processor.Engine.ExecutionContext.__.WriteLine(" - " + capture.Enclosure.Inner.View);
            //Processor.Engine.ExecutionContext.__.WriteLine("END BlockDirective");


            if (capture.Header != null) Processor.Engine.ExecutionContext.__.Write(StringUtilities.RemoveComments(capture.Header.View!).Trim() + ((capture.Enclosure == null) ? "\n" : ""));
            if (capture.Enclosure != null) Processor.Engine.ExecutionContext.__.WriteLine(" "+StringUtilities.RemoveComments(capture.Enclosure.Inner.View!).Trim());
            return true;
        }
           
         
    }
}
 