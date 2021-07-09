using Panosen.CodeDom.Css;
using System;
using System.Collections.Generic;

namespace Panosen.CodeDom.Less
{
    /// <summary>
    /// less 样式
    /// </summary>
    public class CodeLess : CodeCss
    {
        /// <summary>
        /// 子 less 样式
        /// </summary>
        public List<CodeLess> Children { get; set; }
    }

    /// <summary>
    /// 扩展
    /// </summary>
    public static class CodeLessExtension
    {
        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="codeLess"></param>
        /// <param name="less"></param>
        public static void AddChild(this CodeLess codeLess, CodeLess less)
        {
            if (codeLess.Children == null)
            {
                codeLess.Children = new List<CodeLess>();
            }

            codeLess.Children.Add(less);
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="codeLess"></param>
        /// <param name="name"></param>
        public static CodeLess AddChild(this CodeLess codeLess, string name)
        {
            if (codeLess.Children == null)
            {
                codeLess.Children = new List<CodeLess>();
            }

            CodeLess less = new CodeLess();
            less.Name = name;

            codeLess.Children.Add(less);

            return less;
        }
    }
}
