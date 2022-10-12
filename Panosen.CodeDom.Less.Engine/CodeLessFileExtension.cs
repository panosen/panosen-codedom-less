using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Less.Engine
{
    /// <summary>
    /// CodeLessFileExtension
    /// </summary>
    public static class CodeLessFileExtension
    {
        /// <summary>
        /// TransformText
        /// </summary>
        public static string TransformText(this CodeLessFile codeLessFile, GenerationOptions options = null)
        {
            var builder = new StringBuilder();

            new LessCodeEngine().Generate(codeLessFile, builder, options);

            return builder.ToString();
        }
    }
}
