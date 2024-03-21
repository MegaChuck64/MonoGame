using FontStashSharp;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;
using System.Numerics;
using TrippyGL;

namespace CJsGameLib
{
    public class Terminal
    {
        private readonly IWindow _window;

        private GL _gl = null!;
        private Renderer _renderer = null!;
        private FontSystem _fontSystem = null!;
        private GraphicsDevice _graphicsDevice = null!;

        public Terminal(int w, int h, string title)
        {
            var options = WindowOptions.Default;
            options.Size = new Vector2D<int> (w, h);
            options.Title = title;

            _window = Window.Create(options);

            _window.Load += _window_Load;

            _window.Render += _window_Render;

            _window.Closing += _window_Closing;

            _window.Resize += _window_Resize;

            Task.Run(() =>
            {
                _window.Run();
            });


            Console.Read();
        }

        private void _window_Closing()
        {
            _graphicsDevice.Dispose();
        }

        private void _window_Resize(Vector2D<int> size)
        {
            _graphicsDevice.SetViewport(0, 0, (uint)size.X, (uint)size.Y);
            _renderer.OnViewportChanged();
        }

        private void _window_Load()
        {
            _graphicsDevice = new GraphicsDevice(GL.GetApi(_window));
            _renderer = new Renderer(_graphicsDevice);

            _window_Resize(_window.Size);

            var input = _window.CreateInput();
            for (int i = 0; i < input.Keyboards.Count; i++)
            {
                input.Keyboards[i].KeyDown += Terminal_KeyDown;
            }

            var fontSettings = new FontSystemSettings
            {
                FontResolutionFactor = 4,
                KernelWidth = 1,
                KernelHeight = 1,
            };

            _fontSystem = new FontSystem(fontSettings);
            _fontSystem.AddFont(File.ReadAllBytes(Path.Combine("Content", "Fonts", "SDS_8x8.ttf")));
        }

        private void _window_Render(double dt)
        {
            _graphicsDevice.ClearColor = new Vector4(0,0,0,1);
            _graphicsDevice.Clear(ClearBuffers.Color);

            _renderer.Begin();

            var text = "Hollow World";
            var scale = new Vector2(1,1);
            var font = _fontSystem.GetFont(12);
            var size = font.MeasureString(text, scale);
            var origin = new Vector2(0, 0);

            font.DrawText(_renderer, text, new Vector2(0, 0), FSColor.LightCoral, 0f, origin, scale);

            _renderer.End();
        }




        private void Terminal_KeyDown(IKeyboard arg1, Key arg2, int arg3)
        {
            if (arg2 == Key.E)
            {
                _window.Close();
            }
        }

    }
}
