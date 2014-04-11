using System;
using System.Windows.Documents;
using HtmlAgilityPack;
using System.Windows;

namespace BF.SL
{
    public class StrongToXaml : HtmlTypeBase
    {
        string tag;
        public StrongToXaml(string tag)
        {
            this.tag = tag;
        }

        public override string TagName
        {
            get { return this.tag; }
        }

        public override void ApplyType(HtmlNode htmlNode, Block block)
        {
            var s = RichTextboxStyle.GetDefault(htmlNode);
            s.FontWeight = FontWeights.Bold;

            TextToRun(htmlNode.InnerText, s, block);
        }
    }
}
