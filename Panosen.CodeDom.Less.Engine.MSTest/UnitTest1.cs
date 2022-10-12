using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panosen.CodeDom.Css;

namespace Panosen.CodeDom.Less.Engine.MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var codeLess = PrepareCodeLess();

            var actual = codeLess.TransformText();

            var expected = PrepareExpected();

            Assert.AreEqual(expected, actual);
        }

        public CodeLess PrepareCodeLess()
        {
            CodeLess codeLess = new CodeLess();

            codeLess.Name = ".basic";
            codeLess.AddProperty("margin", "10px");
            codeLess.AddProperty("background-color", "#f00");

            {
                var less = codeLess.AddChild("&.active");
                less.AddProperty("margin", "5px");
            }

            {
                var less = codeLess.AddChild("&.disable");
                less.AddProperty("margin", "6px");

                {
                    var less2 = less.AddChild("a");
                    less2.AddProperty("background-color", "#f00");
                }
            }

            return codeLess;
        }

        private string PrepareExpected()
        {
            return @".basic {
    background-color: #f00;
    margin: 10px;

    &.active {
        margin: 5px;
    }

    &.disable {
        margin: 6px;

        a {
            background-color: #f00;
        }
    }
}
";
        }
    }
}
