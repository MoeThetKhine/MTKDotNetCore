namespace MTKDotNetCore.MvcApp.Models;

#region ErrorViewModel

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

#endregion
