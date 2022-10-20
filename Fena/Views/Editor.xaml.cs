using Markdig;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fena.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Editor : Page
    {
        public bool EditorDisabled { get; private set; } = false;

        public Editor()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Updates the WebView2 (documentDisplay) with the contents of the RichTextEditor (documentEditor).
        /// TODO: update to save text to document before displaying. Storing as a string limits document size to 2MB, which is unacceptable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBarButton_Click(object sender, RoutedEventArgs e)
        {
            EditorDisabled = false;

            documentEditor.TextDocument.GetText(Microsoft.UI.Text.TextGetOptions.None, out string content);
            var html = Markdown.ToHtml(content);
            documentDisplay.CoreWebView2.NavigateToString(html);

            EditorDisabled = true;
        }
    }
}
