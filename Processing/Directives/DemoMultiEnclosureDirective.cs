 
using Attaware.HSE.Core.Processing;
using Attaware.HSE.Core.Processing.Types;
using Attaware.HSE.Core.Types;
using Attaware.HSE.Core.Types;
using Attaware.HSE.Core.Utilities;
using System;
using System.Reflection.PortableExecutable;
using static Attaware.HSE.Core.Utilities.StringUtilities;



namespace Attaware.HSE.Package.Demo.Processing.Directives
{


    public class DemoMultiEnclosureDirective : MultiEnclosureDirectiveBase
    {


        public DemoMultiEnclosureDirective(
            HSEProcessor processor,
              string symbol,
            string[] keys)
            : base(processor,
                  symbol,
                  keys,
                 new("{", "}"),
                  2
                  )
        {
        }
        public override async Task<bool> OnCapture(CaptureContext capture, HSEProcessorSpan span)
        {


            //Processor.Engine.ExecutionContext.__.WriteLine("START MultiEnclosureDirective");

            //// HEADERS
            //Processor.Engine.ExecutionContext.__.WriteLine("HEADERS:");

            //foreach (Span header in capture.Headers!)
            //{
            //    Processor.Engine.ExecutionContext.__.WriteLine(" - " + header.View);
            //}

            //// ENCLOSURES

            //if (capture.Enclosures != null)
            //{
            //    Processor.Engine.ExecutionContext.__.WriteLine("ENCLOSURES:");
            //    foreach (EnclosureSpan enclosure in capture.Enclosures)
            //    {

            //        Processor.Engine.ExecutionContext.__.WriteLine(" - " + enclosure.Inner.View);
            //    }
            //}
            //Processor.Engine.ExecutionContext.__.WriteLine("END MultiEnclosureDirective");
            if (capture.Headers != null)
            {
                for (int i = 0; i < capture.Headers.Length; i++)
                {
                    Processor.Engine.ExecutionContext.__.Write(StringUtilities.RemoveComments(capture.Headers[i].View!).Trim()); 
                    
                    if (capture.Enclosures != null ) Processor.Engine.ExecutionContext.__.Write(" " + StringUtilities.RemoveComments(capture.Enclosures[i].Inner.View!).Trim());
                }
            }
            Processor.Engine.ExecutionContext.__.WriteLine("");


            return true;
        }


       
    }
}
 