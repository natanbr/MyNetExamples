using System.Text;
using System.Windows;
using DiffMatchPatch;

namespace WPF_Tutorials.HtmlDiff
{
    /// <summary>
    /// Interaction logic for DiffResultWinsow.xaml
    /// </summary>
    public partial class DiffResultWinsow : Window
    {
        public DiffResultWinsow()
        {
            InitializeComponent();
            var text1 = (new StringBuilder()).AppendLine("This string will be removed").AppendLine("This string will be").ToString();
            var text2 = (new StringBuilder()).AppendLine("This string will be").AppendLine("This string will be added").ToString();
            var d = new diff_match_patch();
            var res = d.diff_main(text1, text2, false);
            var res2 = d.diff_prettyHtml(res);
            TxtBrowser.NavigateToString(res2);
        }
    }
}
