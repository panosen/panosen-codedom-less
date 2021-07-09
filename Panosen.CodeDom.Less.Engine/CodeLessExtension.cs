using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Less.Engine
{
    /// <summary>
    /// CodeLessExtension
    /// </summary>
    public static class CodeLessExtension
    {
        /// <summary>
        /// TransformText
        /// </summary>
        /// <param name="codeLess"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string TransformText(this CodeLess codeLess, GenerationOptions options = null)
        {
            var builder = new StringBuilder();

            new LessCodeEngine().Generate(codeLess, builder, options);

            return builder.ToString();
        }
    }
}
