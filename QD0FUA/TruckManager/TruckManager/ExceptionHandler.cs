public static class ExceptionHandler
{
    public static void Handle(Exception ex)
    {
        ConsoleView.ShowError(ex.Message);
    }
}