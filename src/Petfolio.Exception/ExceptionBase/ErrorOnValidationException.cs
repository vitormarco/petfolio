namespace Petfolio.Exception.ExceptionBase;

public class ErrorOnValidationException : PetfolioException
{
    public List<string> Errors { get; set; }

    public ErrorOnValidationException(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}
