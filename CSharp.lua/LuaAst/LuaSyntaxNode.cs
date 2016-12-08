using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpLua.LuaAst {
    public class LuaSyntaxNode {
        internal virtual void Render(LuaRenderer renderer) {
            throw new NotSupportedException($"{this.GetType().Name} is not override");
        }

        public class Tokens : Keyword {
            public static string Empty => string.Empty;
            public const string OpenParentheses = "(";
            public const string CloseParentheses = ")";
            public const string OpenBrace = "{";
            public const string CloseBrace = "}";
            public const string OpenBracket = "[";
            public const string CloseBracket = "]";
            public const string ObjectColon = ":";
            public const string Dot = ".";
            public const string Quote = "\"";
            public new const string Equals = " = ";
        }

        public class Keyword {
            public const string Function = "function";
            public const string End = "end";
            public const string Return = "return";
            public const string Local = "local";
            public const string Ref = "ref";
            public const string Out = "out";
            public const string If = "if";
            public const string Then = "then";
            public const string Else = "else";
            public const string Not = "not";
            public const string For = "for";
            public const string In = "in";
            public const string Do = "do";
            public const string And = "and";
            public const string Or = "or";
            public const string While = "while";
            public const string Repeat = "repeat";
            public const string Until = "until";
        }
    }

    public sealed class LuaSyntaxList<T> : List<T> where T : LuaSyntaxNode {
        public new void Add(T node) {
            if(node == null) {
                throw new ArgumentNullException(nameof(node));
            }
            base.Add(node);
        }

        public new void AddRange(IEnumerable<T> collection) {
            foreach(var item in collection) {
                if(item == null) {
                    throw new ArgumentNullException(nameof(item));
                }
                base.Add(item);
            }
        }
    }
}