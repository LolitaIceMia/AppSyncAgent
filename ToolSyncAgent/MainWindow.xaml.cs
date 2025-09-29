using System.Windows;
using ToolSyncAgent.ViewModels;

namespace ToolSyncAgent;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}