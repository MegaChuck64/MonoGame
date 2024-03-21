namespace CJsGameLib.Input;

/// <summary>
/// This class is used in the <see cref="TerminalWindow.TextInput"/> event as <see cref="EventArgs"/>.
/// </summary>
/// <remarks>
/// Creates an instance of <see cref="TextInputEventArgs"/>.
/// </remarks>
/// <param name="character">Character for the key that was pressed.</param>
/// <param name="key">The pressed key.</param>
public readonly struct TextInputEventArgs(char character, Keys key = Keys.None)
{

    /// <summary>
    /// The character for the key that was pressed.
    /// </summary>
    public readonly char Character = character;

    /// <summary>
    /// The pressed key.
    /// </summary>
    public readonly Keys Key = key;
}
