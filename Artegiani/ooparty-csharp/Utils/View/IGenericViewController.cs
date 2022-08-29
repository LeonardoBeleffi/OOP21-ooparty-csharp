namespace ooparty_csharp.Utils.Controller
{
    public interface IGenericViewController
    {
        /// <summary>
        /// <c>Controller</c> represents the controller used.
        /// </summary>
        IGenericController Controller { get; set; }
    }
}