namespace ReportService.Application.Utility.Results;

public interface IResult
{
    bool Succes { get; }

    string Message { get; }
}