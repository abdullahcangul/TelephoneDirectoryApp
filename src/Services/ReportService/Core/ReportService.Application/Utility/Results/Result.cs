namespace ReportService.Application.Utility.Results;

public class Result : IResult
{
    public Result(bool success, string message) : this(success)
    {
        Message = message;
    }
    public Result(bool success)
    {
        Succes = success;
    }
    public bool Succes { get; }

    public string Message { get; }
}