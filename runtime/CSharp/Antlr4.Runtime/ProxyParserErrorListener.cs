/*
 * [The "BSD license"]
 *  Copyright (c) 2013 Terence Parr
 *  Copyright (c) 2013 Sam Harwell
 *  All rights reserved.
 *
 *  Redistribution and use in source and binary forms, with or without
 *  modification, are permitted provided that the following conditions
 *  are met:
 *
 *  1. Redistributions of source code must retain the above copyright
 *     notice, this list of conditions and the following disclaimer.
 *  2. Redistributions in binary form must reproduce the above copyright
 *     notice, this list of conditions and the following disclaimer in the
 *     documentation and/or other materials provided with the distribution.
 *  3. The name of the author may not be used to endorse or promote products
 *     derived from this software without specific prior written permission.
 *
 *  THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
 *  IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 *  OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 *  IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
 *  INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 *  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 *  DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 *  THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 *  (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 *  THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime
{
    /// <author>Sam Harwell</author>
    public class ProxyParserErrorListener : ProxyErrorListener<IToken>, IParserErrorListener
    {
        public ProxyParserErrorListener(ICollection<IAntlrErrorListener<IToken>> delegates)
            : base(delegates)
        {
        }

        public virtual void ReportAmbiguity(Parser recognizer, DFA dfa, int startIndex, int stopIndex, bool exact, BitSet ambigAlts, ATNConfigSet configs)
        {
            foreach (IAntlrErrorListener<IToken> listener in Delegates)
            {
                if (!(listener is IParserErrorListener))
                {
                    continue;
                }
                IParserErrorListener parserErrorListener = (IParserErrorListener)listener;
                parserErrorListener.ReportAmbiguity(recognizer, dfa, startIndex, stopIndex, exact, ambigAlts, configs);
            }
        }

        public virtual void ReportAttemptingFullContext(Parser recognizer, DFA dfa, int startIndex, int stopIndex, BitSet conflictingAlts, SimulatorState conflictState)
        {
            foreach (IAntlrErrorListener<IToken> listener in Delegates)
            {
                if (!(listener is IParserErrorListener))
                {
                    continue;
                }
                IParserErrorListener parserErrorListener = (IParserErrorListener)listener;
                parserErrorListener.ReportAttemptingFullContext(recognizer, dfa, startIndex, stopIndex, conflictingAlts, conflictState);
            }
        }

        public virtual void ReportContextSensitivity(Parser recognizer, DFA dfa, int startIndex, int stopIndex, int prediction, SimulatorState acceptState)
        {
            foreach (IAntlrErrorListener<IToken> listener in Delegates)
            {
                if (!(listener is IParserErrorListener))
                {
                    continue;
                }
                IParserErrorListener parserErrorListener = (IParserErrorListener)listener;
                parserErrorListener.ReportContextSensitivity(recognizer, dfa, startIndex, stopIndex, prediction, acceptState);
            }
        }
    }
}
