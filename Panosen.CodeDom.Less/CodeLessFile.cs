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
        /// 文件注释
        /// </summary>
        public string Summary { get; set; }

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
        /// AddLess
        /// </summary>
        public static CodeLessFile AddLess(this CodeLessFile codeFile, CodeLess codeLess)
        {
            if (codeFile.CodeLessList == null)
            {
                codeFile.CodeLessList = new List<CodeLess>();
            }

            codeFile.CodeLessList.Add(codeLess);

            return codeFile;
        }

        /// <summary>
        /// AddLess
        /// </summary>
        public static CodeLess AddLess(this CodeLessFile codeFile, string name = null, string summary = null)
        {
            if (codeFile.CodeLessList == null)
            {
                codeFile.CodeLessList = new List<CodeLess>();
            }

            CodeLess codeLess = new CodeLess();
            codeLess.Name = name;
            codeLess.Summary = summary;

            codeFile.CodeLessList.Add(codeLess);

            return codeLess;
        }
    }
}
