namespace CJsGameLib.Input;

/// <summary>
/// Provides data for the <see cref="TerminalWindow.KeyUp"/> and <see cref="TerminalWindow.KeyDown"/> events.
/// </summary>
/// <remarks>
/// Create a new keyboard input event
/// </remarks>
/// <param name="key">The key involved in this event</param>
public readonly struct InputKeyEventArgs(Keys key = Keys.None)
{
    /// <summary>
    /// The key that was either pressed or released.
    /// </summary>
    public readonly Keys Key = key;
}
