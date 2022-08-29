namespace ooparty_csharp.Utils.Controller
{
    /// <summary>
	/// This interface models a generic controller.
	/// </summary>
    public interface IGenericController
    {
        /// <summary>
        /// <c>ViewController</c> represents the view controller used.
        /// </summary>
        IGenericViewController ViewController { get; set; }
    }
}