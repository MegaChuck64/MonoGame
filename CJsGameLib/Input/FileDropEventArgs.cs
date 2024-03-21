
namespace CJsGameLib.Input;

/// <summary>
/// This class is used in the <see cref="TerminalWindow.FileDrop"/> event as <see cref="EventArgs"/>.
/// </summary>
/// <remarks>
/// Creates an instance of <see cref="FileDropEventArgs"/>.
/// </remarks>
/// <param name="files">Array of paths to dropped files.</param>
public struct FileDropEventArgs(string[] files)
{

    /// <summary>
    /// The paths of dropped files
    /// </summary>
    public string[] Files { get; private set; } = files;
}
