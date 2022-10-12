using Panosen.CodeDom.Css.Engine;
using System;
using System.Collections.Generic;

namespace Panosen.CodeDom.Less.Engine
{
    /// <summary>
    /// css 代码引擎
    /// </summary>
    public class LessCodeEngine
    {
        /// <summary>
        /// 生成css文件
        /// </summary>
        public void Generate(CodeLessFile codeFile, CodeWriter codeWriter, GenerationOptions options = null)
        {
            if (codeFile == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerationOptions();

            if (!string.IsNullOrEmpty(codeFile.Summary))
            {
                codeWriter.Write(options.IndentString)
                    .Write(Marks.SLASH).Write(Marks.STAR).WriteLine(Marks.Exclamation)
                    .Write(Marks.WHITESPACE).Write(Marks.STAR).Write(Marks.WHITESPACE).WriteLine(codeFile.Summary)
                    .Write(Marks.WHITESPACE).Write(Marks.STAR).WriteLine(Marks.SLASH);
                codeWriter.WriteLine();
            }

            if (codeFile.Variables != null && codeFile.Variables.Count > 0)
            {
                Generate(codeFile.Variables, codeWriter, options);
                codeWriter.WriteLine();
            }

            Generate(codeFile.CodeLessList, codeWriter, options);
        }

        /// <summary>
        /// 生成变量
        /// </summary>
        public void Generate(Dictionary<string, string> variables, CodeWriter codeWriter, GenerationOptions options = null)
        {
            if (variables == null || variables.Count == 0)
            {
                return;
            }

            foreach (var item in variables)
            {
                codeWriter.Write(item.Key).Write(Marks.COLON).Write(Marks.WHITESPACE).Write(item.Value).WriteLine(Marks.SEMICOLON);
            }
        }

        /// <summary>
        /// 生成 css 列表
        /// </summary>
        /// <param name="codeCssList"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void Generate(List<CodeLess> codeCssList, CodeWriter codeWriter, GenerationOptions options = null)
        {
            if (codeCssList == null || codeCssList.Count == 0)
            {
                return;
            }

            var enumerator = codeCssList.GetEnumerator();
            var moveNext = enumerator.MoveNext();
            while (moveNext)
            {
                var codeCss = enumerator.Current;
                Generate(codeCss, codeWriter, options);

                moveNext = enumerator.MoveNext();
                if (moveNext)
                {
                    codeWriter.WriteLine();
                }
            }
        }

        /// <summary>
        /// 生成css
        /// </summary>
        public void Generate(CodeLess codeLess, CodeWriter codeWriter, GenerationOptions options = null)
        {
            if (codeLess == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerationOptions();

            if (!string.IsNullOrEmpty(codeLess.Summary))
            {
                codeWriter.Write(options.IndentString)
                    .Write(Marks.SLASH).Write(Marks.STAR).Write(Marks.WHITESPACE)
                    .Write(codeLess.Summary)
                    .Write(Marks.WHITESPACE).Write(Marks.STAR).WriteLine(Marks.SLASH);
            }
            codeWriter.Write(options.IndentString).Write(codeLess.Name).Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            CssCodeEngine.GenerateCssProperty(codeLess, codeWriter, new Css.Engine.GenerationOptions
            {
                IndentSize = options.IndentSize
            });

            if (codeLess.Children != null && codeLess.Children.Count > 0)
            {
                codeWriter.WriteLine();

                Generate(codeLess.Children, codeWriter, new GenerationOptions
                {
                    IndentSize = options.IndentSize
                });
            }

            options.PopIndent();
            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
