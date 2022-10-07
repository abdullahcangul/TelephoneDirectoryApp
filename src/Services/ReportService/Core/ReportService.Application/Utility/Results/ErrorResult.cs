

namespace ReportService.Application.Utility.Results;

public class ErrorResult : Result
{
    public ErrorResult(string message) : base(false, message)
    {

    }

    public ErrorResult(bool success) : base(success)
    {

    }
}