// Todo bring to standard
using Attaware.HSE.Core.Processing;
using Attaware.HSE.Core.Processing.Directives;
using Attaware.HSE.Core.Processing.Types;
using Attaware.HSE.Core.Types;
using Attaware.HSE.Core.Utilities;
using Attaware.HSE.Utils;
using Microsoft.CodeAnalysis.FlowAnalysis;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;


namespace Attaware.HSE.Package.Demo.Processing.Directives
{


    public class DemoFullCustomDirective : DirectiveBase
    {

        public DemoFullCustomDirective(HSEProcessor processor, string symbol, string[] keys) : base(processor, symbol, keys)
        {
            // It is posible to avoid unwanted define replacements this is what define does 
            //  Processor.OnDefModSkipTransformIfPrefixMatchesDefinitionModifier.Add(new(Keys[0], "\n")); // important
        }

        public override async Task<bool> Exec(HSEProcessorSpan state)
        {
            // Caret save
            state.CaretBefore = state.Caret;

            try
            {


                string opener = Keys[0];
                string closer = Keys[1];


                // this does nothing but capture all inbetween and then print it inline  

                EnclosureSpan bodyEnclosure = StringUtilities.CaptureEnclosure<EnclosureSpan>(state.View, new LexicalRegion[] { new(opener, closer) }, state.Caret);
                if (bodyEnclosure.IsEmpty()) throw new HSEException($"{typeof(DemoFullCustomDirective).FullName} Body enclosure error.", HSELocation.FromCaret(state));// return Result<string>.From(encArguments).ReLocateErrors(ErrorLocation.FromLineInfo(state.Text, state.CaretBefore)!);
                string bodyContentInOneLine = bodyEnclosure.Inner.View!.Trim();
                //bodyContentInOneLine =  StringUtilities.RemoveComments(bodyContentInOneLine).Trim();
                string content = bodyContentInOneLine;
                string aaa = state.View.Substring(state.Caret, bodyEnclosure.Outer.End - state.Caret);

                // replace the diretive by its replacement code if it has , in this case it has a writeline 
                // state.Text = StringUtilities.InsertAt(state.Text, state.Caret, bodyEnclosure.Outer.End - state.Caret, content);


                state.View = StringUtilities.InsertAtRange(state.View, state.Caret, bodyEnclosure.Outer.End, content);

                // as we have replaced the caret doesnt move  so the parser keeps parsing the result of this very thirective  
                return true;





            }
            catch (HSEException) { throw; }
            catch (Exception ex) { throw new HSEException(ex, HSELocation.FromCaretBefore(state)); }


        }




    }


}
