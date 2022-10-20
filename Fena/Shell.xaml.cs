using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fena
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shell : Window
    {
        public Shell()
        {
            this.InitializeComponent();
            Title = "Fena - a free, extensible note-taking application";
            shellFrame.Navigate(typeof(HomePage));

            ExtendsContentIntoTitleBar = true;
            SetTitleBar(tabs);
        }

        private void Tabs_AddTabButtonClick(TabView sender, object args)
        {
            TabViewItem newTab = new()
            {
                IconSource = new SymbolIconSource() { Symbol = Symbol.Document },
                Header = "New Document"
            };

            Frame frame = new Frame();
            newTab.Content = frame;
            //frame.Navigate(typeof(Editor));
            shellFrame.Navigate(typeof(Editor));

            sender.TabItems.Add(newTab);
        }

        private void Tabs_TabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
        {
            sender.TabItems.Remove(args.Tab);
        }
    }
}
