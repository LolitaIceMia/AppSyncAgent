namespace ToolSyncAgent;

public class SoftwarePackage
{
    // { get; set; } 是一种简写，让这个属性可以被读取和写入
    public string Name { get; set; }
    public string CurrentVersion { get; set; }
    public string Status { get; set; }
}