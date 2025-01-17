﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using JetBrains.Annotations;

namespace SDL
{
    [Typedef]
    public enum SDL_DisplayID : UInt32;

    [Typedef]
    public enum SDL_WindowID : UInt32;

    [Flags]
    [Typedef]
    public enum SDL_WindowFlags : UInt64
    {
        SDL_WINDOW_FULLSCREEN = SDL3.SDL_WINDOW_FULLSCREEN,
        SDL_WINDOW_OPENGL = SDL3.SDL_WINDOW_OPENGL,
        SDL_WINDOW_OCCLUDED = SDL3.SDL_WINDOW_OCCLUDED,
        SDL_WINDOW_HIDDEN = SDL3.SDL_WINDOW_HIDDEN,
        SDL_WINDOW_BORDERLESS = SDL3.SDL_WINDOW_BORDERLESS,
        SDL_WINDOW_RESIZABLE = SDL3.SDL_WINDOW_RESIZABLE,
        SDL_WINDOW_MINIMIZED = SDL3.SDL_WINDOW_MINIMIZED,
        SDL_WINDOW_MAXIMIZED = SDL3.SDL_WINDOW_MAXIMIZED,
        SDL_WINDOW_MOUSE_GRABBED = SDL3.SDL_WINDOW_MOUSE_GRABBED,
        SDL_WINDOW_INPUT_FOCUS = SDL3.SDL_WINDOW_INPUT_FOCUS,
        SDL_WINDOW_MOUSE_FOCUS = SDL3.SDL_WINDOW_MOUSE_FOCUS,
        SDL_WINDOW_EXTERNAL = SDL3.SDL_WINDOW_EXTERNAL,
        SDL_WINDOW_HIGH_PIXEL_DENSITY = SDL3.SDL_WINDOW_HIGH_PIXEL_DENSITY,
        SDL_WINDOW_MOUSE_CAPTURE = SDL3.SDL_WINDOW_MOUSE_CAPTURE,
        SDL_WINDOW_ALWAYS_ON_TOP = SDL3.SDL_WINDOW_ALWAYS_ON_TOP,
        SDL_WINDOW_UTILITY = SDL3.SDL_WINDOW_UTILITY,
        SDL_WINDOW_TOOLTIP = SDL3.SDL_WINDOW_TOOLTIP,
        SDL_WINDOW_POPUP_MENU = SDL3.SDL_WINDOW_POPUP_MENU,
        SDL_WINDOW_KEYBOARD_GRABBED = SDL3.SDL_WINDOW_KEYBOARD_GRABBED,
        SDL_WINDOW_VULKAN = SDL3.SDL_WINDOW_VULKAN,
        SDL_WINDOW_METAL = SDL3.SDL_WINDOW_METAL,
        SDL_WINDOW_TRANSPARENT = SDL3.SDL_WINDOW_TRANSPARENT,
        SDL_WINDOW_NOT_FOCUSABLE = SDL3.SDL_WINDOW_NOT_FOCUSABLE,
    }

    [Flags]
    [Typedef]
    public enum SDL_GLProfile
    {
        SDL_GL_CONTEXT_PROFILE_CORE = SDL3.SDL_GL_CONTEXT_PROFILE_CORE,
        SDL_GL_CONTEXT_PROFILE_COMPATIBILITY = SDL3.SDL_GL_CONTEXT_PROFILE_COMPATIBILITY,
        SDL_GL_CONTEXT_PROFILE_ES = SDL3.SDL_GL_CONTEXT_PROFILE_ES,
    }

    [Flags]
    [Typedef]
    public enum SDL_GLContextFlag
    {
        SDL_GL_CONTEXT_DEBUG_FLAG = SDL3.SDL_GL_CONTEXT_DEBUG_FLAG,
        SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG = SDL3.SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG,
        SDL_GL_CONTEXT_ROBUST_ACCESS_FLAG = SDL3.SDL_GL_CONTEXT_ROBUST_ACCESS_FLAG,
        SDL_GL_CONTEXT_RESET_ISOLATION_FLAG = SDL3.SDL_GL_CONTEXT_RESET_ISOLATION_FLAG,
    }

    [Flags]
    [Typedef]
    public enum SDL_GLContextReleaseFlag
    {
        SDL_GL_CONTEXT_RELEASE_BEHAVIOR_NONE = SDL3.SDL_GL_CONTEXT_RELEASE_BEHAVIOR_NONE,
        SDL_GL_CONTEXT_RELEASE_BEHAVIOR_FLUSH = SDL3.SDL_GL_CONTEXT_RELEASE_BEHAVIOR_FLUSH,
    }

    [Flags]
    [Typedef]
    public enum SDL_GLContextResetNotification
    {
        SDL_GL_CONTEXT_RESET_NO_NOTIFICATION = SDL3.SDL_GL_CONTEXT_RESET_NO_NOTIFICATION,
        SDL_GL_CONTEXT_RESET_LOSE_CONTEXT = SDL3.SDL_GL_CONTEXT_RESET_LOSE_CONTEXT,
    }

    public static partial class SDL3
    {
        [Macro]
        public static int SDL_WINDOWPOS_UNDEFINED_DISPLAY(SDL_DisplayID X) => (int)(SDL_WINDOWPOS_UNDEFINED_MASK | (uint)X);

        [Macro]
        public static bool SDL_WINDOWPOS_ISUNDEFINED(int X) => (((X) & 0xFFFF0000) == SDL_WINDOWPOS_UNDEFINED_MASK);

        [Macro]
        public static int SDL_WINDOWPOS_CENTERED_DISPLAY(SDL_DisplayID X) => (int)(SDL_WINDOWPOS_CENTERED_MASK | (uint)X);

        [Macro]
        public static bool SDL_WINDOWPOS_ISCENTERED(int X) => (((X) & 0xFFFF0000) == SDL_WINDOWPOS_CENTERED_MASK);

        [MustDisposeResource]
        public static unsafe SDLArray<SDL_DisplayID>? SDL_GetDisplays()
        {
            int count;
            var array = SDL_GetDisplays(&count);
            return SDLArray.Create(array, count);
        }

        [MustDisposeResource]
        public static unsafe SDLPointerArray<SDL_DisplayMode>? SDL_GetFullscreenDisplayModes(SDL_DisplayID displayID)
        {
            int count;
            var array = SDL_GetFullscreenDisplayModes(displayID, &count);
            return SDLArray.Create(array, count);
        }

        [MustDisposeResource]
        public static unsafe SDLPointerArray<SDL_Window>? SDL_GetWindows()
        {
            int count;
            var array = SDL_GetWindows(&count);
            return SDLArray.Create(array, count);
        }
    }
}
