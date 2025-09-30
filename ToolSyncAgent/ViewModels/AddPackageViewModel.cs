using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ToolSyncAgent.ViewModels;

public partial class AddPackageViewModel : ObservableObject
{
    [ObservableProperty]
    private string? _packageName;

    [ObservableProperty]
    private string? _packageVersion;
}