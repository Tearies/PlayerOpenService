using System;
using System.Globalization;
using System.IO;
using System.Net;
using Microsoft.Owin;

namespace WebApi
{
    internal abstract class BaseMiddlewareView
    {
        /// <summary>The request context</summary>
        protected IOwinContext Context { get; private set; }

        /// <summary>The request</summary>
        protected IOwinRequest Request { get; private set; }

        /// <summary>The response</summary>
        protected IOwinResponse Response { get; private set; }

        /// <summary>The output stream</summary>
        protected StreamWriter Output { get; private set; }

        /// <summary>Execute an individual request</summary>
        /// <param name="context"></param>
        public void Execute(IOwinContext context)
        {
            this.Context = context;
            this.Request = this.Context.Request;
            this.Response = this.Context.Response;
            this.Output = new StreamWriter(this.Response.Body);
            this.Execute();
            this.Output.Dispose();
        }

        /// <summary>Execute an individual request</summary>
        public abstract void Execute();

        /// <summary>Write the given value directly to the output</summary>
        /// <param name="value"></param>
        protected void WriteLiteral(string value)
        {
            this.Output.Write(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="name"></param>
        /// <param name="leader"></param>
        /// <param name="trailer"></param>
        /// <param name="part1"></param>
        protected void WriteAttribute<T1>(
            string name,
            Tuple<string, int> leader,
            Tuple<string, int> trailer,
            Tuple<Tuple<string, int>, Tuple<T1, int>, bool> part1)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (leader == null)
                throw new ArgumentNullException(nameof(leader));
            if (trailer == null)
                throw new ArgumentNullException(nameof(trailer));
            if (part1 == null)
                throw new ArgumentNullException(nameof(part1));
            this.WriteLiteral(leader.Item1);
            this.WriteLiteral(part1.Item1.Item1);
            this.Write((object)part1.Item2.Item1);
            this.WriteLiteral(trailer.Item1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="name"></param>
        /// <param name="leader"></param>
        /// <param name="trailer"></param>
        /// <param name="part1"></param>
        /// <param name="part2"></param>
        protected void WriteAttribute<T1, T2>(
            string name,
            Tuple<string, int> leader,
            Tuple<string, int> trailer,
            Tuple<Tuple<string, int>, Tuple<T1, int>, bool> part1,
            Tuple<Tuple<string, int>, Tuple<T2, int>, bool> part2)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (leader == null)
                throw new ArgumentNullException(nameof(leader));
            if (trailer == null)
                throw new ArgumentNullException(nameof(trailer));
            if (part1 == null)
                throw new ArgumentNullException(nameof(part1));
            if (part2 == null)
                throw new ArgumentNullException(nameof(part2));
            this.WriteLiteral(leader.Item1);
            this.WriteLiteral(part1.Item1.Item1);
            this.Write((object)part1.Item2.Item1);
            this.WriteLiteral(part2.Item1.Item1);
            this.Write((object)part2.Item2.Item1);
            this.WriteLiteral(trailer.Item1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="name"></param>
        /// <param name="leader"></param>
        /// <param name="trailer"></param>
        /// <param name="part1"></param>
        /// <param name="part2"></param>
        /// <param name="part3"></param>
        protected void WriteAttribute<T1, T2, T3>(
            string name,
            Tuple<string, int> leader,
            Tuple<string, int> trailer,
            Tuple<Tuple<string, int>, Tuple<T1, int>, bool> part1,
            Tuple<Tuple<string, int>, Tuple<T2, int>, bool> part2,
            Tuple<Tuple<string, int>, Tuple<T3, int>, bool> part3)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (leader == null)
                throw new ArgumentNullException(nameof(leader));
            if (trailer == null)
                throw new ArgumentNullException(nameof(trailer));
            if (part1 == null)
                throw new ArgumentNullException(nameof(part1));
            if (part2 == null)
                throw new ArgumentNullException(nameof(part2));
            if (part3 == null)
                throw new ArgumentNullException(nameof(part3));
            this.WriteLiteral(leader.Item1);
            this.WriteLiteral(part1.Item1.Item1);
            this.Write((object)part1.Item2.Item1);
            this.WriteLiteral(part2.Item1.Item1);
            this.Write((object)part2.Item2.Item1);
            this.WriteLiteral(part3.Item1.Item1);
            this.Write((object)part3.Item2.Item1);
            this.WriteLiteral(trailer.Item1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="name"></param>
        /// <param name="leader"></param>
        /// <param name="trailer"></param>
        /// <param name="part1"></param>
        /// <param name="part2"></param>
        /// <param name="part3"></param>
        /// <param name="part4"></param>
        protected void WriteAttribute<T1, T2, T3, T4>(
            string name,
            Tuple<string, int> leader,
            Tuple<string, int> trailer,
            Tuple<Tuple<string, int>, Tuple<T1, int>, bool> part1,
            Tuple<Tuple<string, int>, Tuple<T2, int>, bool> part2,
            Tuple<Tuple<string, int>, Tuple<T3, int>, bool> part3,
            Tuple<Tuple<string, int>, Tuple<T4, int>, bool> part4)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (leader == null)
                throw new ArgumentNullException(nameof(leader));
            if (trailer == null)
                throw new ArgumentNullException(nameof(trailer));
            if (part1 == null)
                throw new ArgumentNullException(nameof(part1));
            if (part2 == null)
                throw new ArgumentNullException(nameof(part2));
            if (part3 == null)
                throw new ArgumentNullException(nameof(part3));
            if (part4 == null)
                throw new ArgumentNullException(nameof(part4));
            this.WriteLiteral(leader.Item1);
            this.WriteLiteral(part1.Item1.Item1);
            this.Write((object)part1.Item2.Item1);
            this.WriteLiteral(part2.Item1.Item1);
            this.Write((object)part2.Item2.Item1);
            this.WriteLiteral(part3.Item1.Item1);
            this.Write((object)part3.Item2.Item1);
            this.WriteLiteral(part4.Item1.Item1);
            this.Write((object)part4.Item2.Item1);
            this.WriteLiteral(trailer.Item1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="name"></param>
        /// <param name="leader"></param>
        /// <param name="trailer"></param>
        /// <param name="part1"></param>
        /// <param name="part2"></param>
        /// <param name="part3"></param>
        /// <param name="part4"></param>
        /// <param name="part5"></param>
        protected void WriteAttribute<T1, T2, T3, T4, T5>(
            string name,
            Tuple<string, int> leader,
            Tuple<string, int> trailer,
            Tuple<Tuple<string, int>, Tuple<T1, int>, bool> part1,
            Tuple<Tuple<string, int>, Tuple<T2, int>, bool> part2,
            Tuple<Tuple<string, int>, Tuple<T3, int>, bool> part3,
            Tuple<Tuple<string, int>, Tuple<T4, int>, bool> part4,
            Tuple<Tuple<string, int>, Tuple<T5, int>, bool> part5)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (leader == null)
                throw new ArgumentNullException(nameof(leader));
            if (trailer == null)
                throw new ArgumentNullException(nameof(trailer));
            if (part1 == null)
                throw new ArgumentNullException(nameof(part1));
            if (part2 == null)
                throw new ArgumentNullException(nameof(part2));
            if (part3 == null)
                throw new ArgumentNullException(nameof(part3));
            if (part4 == null)
                throw new ArgumentNullException(nameof(part4));
            if (part5 == null)
                throw new ArgumentNullException(nameof(part5));
            this.WriteLiteral(leader.Item1);
            this.WriteLiteral(part1.Item1.Item1);
            this.Write((object)part1.Item2.Item1);
            this.WriteLiteral(part2.Item1.Item1);
            this.Write((object)part2.Item2.Item1);
            this.WriteLiteral(part3.Item1.Item1);
            this.Write((object)part3.Item2.Item1);
            this.WriteLiteral(part4.Item1.Item1);
            this.Write((object)part4.Item2.Item1);
            this.WriteLiteral(part5.Item1.Item1);
            this.Write((object)part5.Item2.Item1);
            this.WriteLiteral(trailer.Item1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="name"></param>
        /// <param name="leader"></param>
        /// <param name="trailer"></param>
        /// <param name="part1"></param>
        /// <param name="part2"></param>
        /// <param name="part3"></param>
        /// <param name="part4"></param>
        /// <param name="part5"></param>
        /// <param name="part6"></param>
        protected void WriteAttribute<T1, T2, T3, T4, T5, T6>(
            string name,
            Tuple<string, int> leader,
            Tuple<string, int> trailer,
            Tuple<Tuple<string, int>, Tuple<T1, int>, bool> part1,
            Tuple<Tuple<string, int>, Tuple<T2, int>, bool> part2,
            Tuple<Tuple<string, int>, Tuple<T3, int>, bool> part3,
            Tuple<Tuple<string, int>, Tuple<T4, int>, bool> part4,
            Tuple<Tuple<string, int>, Tuple<T5, int>, bool> part5,
            Tuple<Tuple<string, int>, Tuple<T6, int>, bool> part6)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (leader == null)
                throw new ArgumentNullException(nameof(leader));
            if (trailer == null)
                throw new ArgumentNullException(nameof(trailer));
            if (part1 == null)
                throw new ArgumentNullException(nameof(part1));
            if (part2 == null)
                throw new ArgumentNullException(nameof(part2));
            if (part3 == null)
                throw new ArgumentNullException(nameof(part3));
            if (part4 == null)
                throw new ArgumentNullException(nameof(part4));
            if (part5 == null)
                throw new ArgumentNullException(nameof(part5));
            if (part6 == null)
                throw new ArgumentNullException(nameof(part6));
            this.WriteLiteral(leader.Item1);
            this.WriteLiteral(part1.Item1.Item1);
            this.Write((object)part1.Item2.Item1);
            this.WriteLiteral(part2.Item1.Item1);
            this.Write((object)part2.Item2.Item1);
            this.WriteLiteral(part3.Item1.Item1);
            this.Write((object)part3.Item2.Item1);
            this.WriteLiteral(part4.Item1.Item1);
            this.Write((object)part4.Item2.Item1);
            this.WriteLiteral(part5.Item1.Item1);
            this.Write((object)part5.Item2.Item1);
            this.WriteLiteral(part6.Item1.Item1);
            this.Write((object)part6.Item2.Item1);
            this.WriteLiteral(trailer.Item1);
        }

        /// <summary>Html encode and write</summary>
        /// <param name="value"></param>
        private void WriteEncoded(string value)
        {
            WebUtility.HtmlEncode(value, (TextWriter)this.Output);
        }

        /// <summary>Convert to string and html encode</summary>
        /// <param name="value"></param>
        protected void Write(object value)
        {
            this.WriteEncoded(Convert.ToString(value, (IFormatProvider)CultureInfo.InvariantCulture));
        }

        /// <summary>Html encode and write</summary>
        /// <param name="value"></param>
        protected void Write(string value)
        {
            this.WriteEncoded(value);
        }

    }
}