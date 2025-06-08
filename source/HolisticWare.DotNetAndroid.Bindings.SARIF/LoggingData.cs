namespace HolisticWare.DotNetAndroid.Generator.Logging;

public partial class LoggingData
{
    public string? Path
    {
        get; set;
    }
    
    public (int, int) Location
    {
        get; set;
    }
    

    public string? Code
    {
        get; set;
    }

    public string? Message
    {
        get; set;
    }

    public string? Xpath
    {
        get; set;
    }

    public Project? Project
    {
        get; 
        set;
    }

    public Dictionary<string, string>? Is
    {
        get; 
        set;
    }

    public Dictionary<string, string>? ShouldBe
    {
        get; 
        set;
    }
}