using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChatTcpClient
{
    internal class ChatMessangeWapper
    {
        static public TextBlock GetTextBoxForYourMessange(string s)
        {
            var textBlock = new TextBlock();
            textBlock.Text = s;
            textBlock.TextAlignment = System.Windows.TextAlignment.Right;
            textBlock.Background = System.Windows.Media.Brushes.Aquamarine;
            return textBlock;
        }
        static public TextBlock GetTextBlockFornewMessange(string s)
        {
            var textBlock = new TextBlock();
            textBlock.Text = s;
            textBlock.TextAlignment = System.Windows.TextAlignment.Left;
            textBlock.Background = System.Windows.Media.Brushes.LightGreen;
            return textBlock;
        } 
    }
}
