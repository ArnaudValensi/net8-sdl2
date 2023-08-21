using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SDL2;

namespace SdlTest
{
    unsafe class Program
    {
        static IntPtr renderer;

        [DllImport("*")]
        internal static extern unsafe void emscripten_set_main_loop(delegate* unmanaged <void> f, int fps,
            int simulate_infinite_loop);

        const int SCREEN_WIDTH = 640;
        const int SCREEN_HEIGHT = 480;

        // [UnmanagedCallersOnly(EntryPoint = "MainLoop", CallConvs = new Type[] {typeof(CallConvCdecl)})]
        [UnmanagedCallersOnly(EntryPoint = "MainLoop")]
        static void MainLoop()
        {
            Render(renderer);
        }

        static void Render(IntPtr renderer)
        {
            SDL.SDL_SetRenderDrawColor(renderer, 255, 0, 0, 255);
            SDL.SDL_RenderClear(renderer);
            SDL.SDL_RenderPresent(renderer);
        }

        // [DllImport("mylib.dll")]
        // internal static extern unsafe int answer();

        [DllImport("__Internal")]
        static extern int answer();

        static void Main()
        {
            int result = answer();
            Console.WriteLine($"Hello World! {result}");

            var window = IntPtr.Zero;

            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                throw new Exception($"SDL could not initialize! SDL_Error: {SDL.SDL_GetError()}");
            }

            window = SDL.SDL_CreateWindow(
                "SDL Tutorial",
                SDL.SDL_WINDOWPOS_UNDEFINED,
                SDL.SDL_WINDOWPOS_UNDEFINED,
                SCREEN_WIDTH,
                SCREEN_HEIGHT,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN
            );
            if (window == IntPtr.Zero)
            {
                throw new Exception("Window could not be created! SDL_Error: {SDL.SDL_GetError()}");
            }

            // setMainLoop
            emscripten_set_main_loop(&MainLoop, 0, 0);

            renderer = SDL.SDL_CreateRenderer(window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
            if (renderer == IntPtr.Zero)
            {
                throw new Exception("Could not create renderer: {SDL.SDL_GetError()}");
            }

            // SDL.SDL_SetRenderDrawColor(renderer, 255, 0, 0, 255);
            // SDL.SDL_RenderClear(renderer);
            // SDL.SDL_RenderPresent(renderer);
            //
            // SDL.SDL_Delay(5000);
            //
            // SDL.SDL_DestroyRenderer(renderer);
            // SDL.SDL_DestroyWindow(window);
            // SDL.SDL_Quit();
        }
    }
}
