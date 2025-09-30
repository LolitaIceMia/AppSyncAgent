using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ToolSyncAgent;

public partial class SoftwarePackage : ObservableObject
{
    // 数据库主键
    public int Id { get; set; }

    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private string currentVersion = string.Empty;

    [ObservableProperty]
    private string status = string.Empty;

    [ObservableProperty]
    private string downloadUrl = string.Empty;

    [ObservableProperty]
    private DateTime lastCheckedTime;
}