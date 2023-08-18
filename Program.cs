using System;
using System.Runtime.InteropServices;
using SDL2;

namespace SdlTest
{
    class Program
    {
        const int SCREEN_WIDTH = 640;
        const int SCREEN_HEIGHT = 480;

        static int Main(string[] args)
        {
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

            var windowSurface = SDL.SDL_GetWindowSurface(window);
            var screenSurface = Marshal.PtrToStructure<SDL.SDL_Surface>(windowSurface);
            SDL.SDL_FillRect(windowSurface, IntPtr.Zero, SDL.SDL_MapRGB(screenSurface.format, 0x00, 0x00, 0xFF));

            SDL.SDL_UpdateWindowSurface(window);

            SDL.SDL_Delay(5000);

            SDL.SDL_DestroyWindow(window);
            SDL.SDL_Quit();

            return 0;
        }
    }
}
