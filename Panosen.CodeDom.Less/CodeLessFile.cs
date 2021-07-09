using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Less
{
    /// <summary>
    /// less 文件
    /// </summary>
    public class CodeLessFile
    {
        /// <summary>
        /// 变量
        /// </summary>
        public Dictionary<string, string> Variables { get; set; }

        /// <summary>
        /// less 样式
        /// </summary>
        public List<CodeLess> CodeLessList { get; set; }
    }

    /// <summary>
    /// extension
    /// </summary>
    public static class CodeLessFileExtension
    {
        /// <summary>
        /// 添加变量
        /// </summary>
        /// <param name="codeFile"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static CodeLessFile AddVariable(this CodeLessFile codeFile, string key, string value)
        {
            if (codeFile.Variables == null)
            {
                codeFile.Variables = new Dictionary<string, string>();
            }

            codeFile.Variables.Add(key, value);

            return codeFile;
        }

        /// <summary>
        /// add css
        /// </summary>
        /// <param name="codeFile"></param>
        /// <param name="codeLess"></param>
        public static CodeLessFile AddCodeLess(this CodeLessFile codeFile, CodeLess codeLess)
        {
            if (codeFile.CodeLessList == null)
            {
                codeFile.CodeLessList = new List<CodeLess>();
            }

            codeFile.CodeLessList.Add(codeLess);

            return codeFile;
        }

        /// <summary>
        /// add css
        /// </summary>
        /// <param name="codeFile"></param>
        /// <param name="name"></param>
        /// <param name="comment"></param>
        public static CodeLess AddCodeLess(this CodeLessFile codeFile, string name = null, string comment = null)
        {
            if (codeFile.CodeLessList == null)
            {
                codeFile.CodeLessList = new List<CodeLess>();
            }

            CodeLess codeLess = new CodeLess();
            codeLess.Name = name;
            codeLess.Comment = comment;

            codeFile.CodeLessList.Add(codeLess);

            return codeLess;
        }
    }
}
