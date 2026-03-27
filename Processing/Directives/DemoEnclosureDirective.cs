using Attaware.HSE.Core.Types;
using Attaware.HSE.Core.Types;
using System;
using System.Text.RegularExpressions;
using static Attaware.HSE.Core.Utilities.StringUtilities;

 
using Attaware.HSE.Core.Processing;
using Attaware.HSE.Core.Processing.Types;
using Attaware.HSE.Core.Utilities;

namespace Attaware.HSE.Package.Demo.Processing.Directives
{

   
        public class DemoEnclosureDirective :  EnclosureDirectiveBase
    {
   

        public DemoEnclosureDirective(
            HSEProcessor processor,
            string symbol,
            string[] keys )
            : base(processor,
                  symbol,
                  keys,
                    new("{", "}")
            
                  )
        {
        }

        public override async Task<bool> OnCapture(CaptureContext capture, HSEProcessorSpan span)
        {

            //Processor.Engine.ExecutionContext.__.WriteLine("START EnclosureDirective"  );

            //// HEADERS 
            //Processor.Engine.ExecutionContext.__.WriteLine("HEADER:");

            //Processor.Engine.ExecutionContext.__.WriteLine(" - " + capture.Header.View);


            //if (capture.Enclosure != null)
            //{
            //    Processor.Engine.ExecutionContext.__.WriteLine("ENCLOSURE:");
            //    Processor.Engine.ExecutionContext.__.WriteLine(" - " + capture.Enclosure.Inner.View);

            //}

            //Processor.Engine.ExecutionContext.__.WriteLine("END EnclosureDirective");
            if (capture.Header != null) Processor.Engine.ExecutionContext.__.Write(StringUtilities.RemoveComments(capture.Header.View!).Trim() + ((capture.Enclosure == null) ? "\n" : ""));
            if (capture.Enclosure != null) Processor.Engine.ExecutionContext.__.WriteLine(" " + StringUtilities.RemoveComments(capture.Enclosure.Inner.View!).Trim());

            return true;
        }
           

        //public override Result<string> Exec(ref string input, ref int i)
        //{
        //    Result<Span> enclosureResult =
        //        StringUtilities.CaptureEnclosure(
        //            input,
        //            new Tuple<string, string>(Keys[0], Keys[1]),
        //            i);

        //    if (!enclosureResult.Success)
        //        return Result<string>.Fail(
        //            new Error(
        //                IErrorCode.MalformedDirective,
        //                $"Malformed {Keys[0]} {Keys[1]} block."));





        //    //CaptureEventArgs captureEventArgs = new CaptureEventArgs()
        //    //{
        //    //    Span = enclosureResult.Value,
        //    //    OuterText = enclosureResult.Value.View!,
        //    //    InnerText = enclosureResult.Value.View!.Substring(Keys[0].Length + 1, enclosureResult.Value.View.Length - Keys[1].Length),
        //    //};
            
        //        i = i + enclosureResult.Value.End + Keys[1].Length;

        //    return _onCapture(this,enclosureResult.Value);
        //}
    }
}

//using HSE;
//using Attaware.HSE.Core.Types;
//using Attaware.HSE.Core.Types;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static Attaware.HSE.Core.Types.IErrorCode;
//using static System.Runtime.InteropServices.JavaScript.JSType;
//
//

//namespace Attaware.HSE.Package.Demo.Processing.Models
//{



//    namespace Attaware.HSE.Package.Demo.Processing.Models
//    {



//        public class GenericWrapperModel : DirectiveBase
//        {
//            public GenericWrapperModel(Processor preprocessor, string[]? keys = null) : base(preprocessor, keys ?? new string[] { "#print","#endprint" })
//            {

//            }
//            public override Result<string> Exec(ref string input, ref int i)
//            {


//             Result<Span> enclosureResult = StringUtilities.CaptureEnclosure(input, new Tuple<string, string>(Keys[0], Keys[1]),i);
//            if(!enclosureResult.Success) return Result<string>.Fail(new Error(IErrorCode.MalformedDirective, $"Malformed {Keys[0]} {Keys[1]} block."));
//                /// Do stuf here  

//                string captured = enclosureResult.Value.View.Substring(Keys[0].Length + 1, enclosureResult.Value.View.Length - Keys[1].Length);
//                PreProcessor.Engine.ExecutionContext.__.WriteLine(captured);

//                i = i+enclosureResult.Value.End +Keys[1].Length;

//                return Result<string>.Ok("");

//            }
//        }


//    }

//}
