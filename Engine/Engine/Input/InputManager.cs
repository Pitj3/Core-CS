using System;
using OpenTK;
using OpenTK.Input;

namespace CoreEngine.Engine.Input
{
    #region Enums
    /// <summary>
    /// Enum used to define the state of a button
    /// </summary>
    public enum ButtonState
    {
        PRESSED = 0,
        DOWN,
        UP,
        NONE
    }

    public enum Key
    {
        //
        // Summary:
        //     A key outside the known keys.
        Unknown = 0,
        //
        // Summary:
        //     The left shift key.
        ShiftLeft = 1,
        //
        // Summary:
        //     The left shift key (equivalent to ShiftLeft).
        LShift = 1,
        //
        // Summary:
        //     The right shift key.
        ShiftRight = 2,
        //
        // Summary:
        //     The right shift key (equivalent to ShiftRight).
        RShift = 2,
        //
        // Summary:
        //     The left control key.
        ControlLeft = 3,
        //
        // Summary:
        //     The left control key (equivalent to ControlLeft).
        LControl = 3,
        //
        // Summary:
        //     The right control key.
        ControlRight = 4,
        //
        // Summary:
        //     The right control key (equivalent to ControlRight).
        RControl = 4,
        //
        // Summary:
        //     The left alt key.
        AltLeft = 5,
        //
        // Summary:
        //     The left alt key (equivalent to AltLeft.
        LAlt = 5,
        //
        // Summary:
        //     The right alt key.
        AltRight = 6,
        //
        // Summary:
        //     The right alt key (equivalent to AltRight).
        RAlt = 6,
        //
        // Summary:
        //     The left win key.
        WinLeft = 7,
        //
        // Summary:
        //     The left win key (equivalent to WinLeft).
        LWin = 7,
        //
        // Summary:
        //     The right win key.
        WinRight = 8,
        //
        // Summary:
        //     The right win key (equivalent to WinRight).
        RWin = 8,
        //
        // Summary:
        //     The menu key.
        Menu = 9,
        //
        // Summary:
        //     The F1 key.
        F1 = 10,
        //
        // Summary:
        //     The F2 key.
        F2 = 11,
        //
        // Summary:
        //     The F3 key.
        F3 = 12,
        //
        // Summary:
        //     The F4 key.
        F4 = 13,
        //
        // Summary:
        //     The F5 key.
        F5 = 14,
        //
        // Summary:
        //     The F6 key.
        F6 = 15,
        //
        // Summary:
        //     The F7 key.
        F7 = 16,
        //
        // Summary:
        //     The F8 key.
        F8 = 17,
        //
        // Summary:
        //     The F9 key.
        F9 = 18,
        //
        // Summary:
        //     The F10 key.
        F10 = 19,
        //
        // Summary:
        //     The F11 key.
        F11 = 20,
        //
        // Summary:
        //     The F12 key.
        F12 = 21,
        //
        // Summary:
        //     The F13 key.
        F13 = 22,
        //
        // Summary:
        //     The F14 key.
        F14 = 23,
        //
        // Summary:
        //     The F15 key.
        F15 = 24,
        //
        // Summary:
        //     The F16 key.
        F16 = 25,
        //
        // Summary:
        //     The F17 key.
        F17 = 26,
        //
        // Summary:
        //     The F18 key.
        F18 = 27,
        //
        // Summary:
        //     The F19 key.
        F19 = 28,
        //
        // Summary:
        //     The F20 key.
        F20 = 29,
        //
        // Summary:
        //     The F21 key.
        F21 = 30,
        //
        // Summary:
        //     The F22 key.
        F22 = 31,
        //
        // Summary:
        //     The F23 key.
        F23 = 32,
        //
        // Summary:
        //     The F24 key.
        F24 = 33,
        //
        // Summary:
        //     The F25 key.
        F25 = 34,
        //
        // Summary:
        //     The F26 key.
        F26 = 35,
        //
        // Summary:
        //     The F27 key.
        F27 = 36,
        //
        // Summary:
        //     The F28 key.
        F28 = 37,
        //
        // Summary:
        //     The F29 key.
        F29 = 38,
        //
        // Summary:
        //     The F30 key.
        F30 = 39,
        //
        // Summary:
        //     The F31 key.
        F31 = 40,
        //
        // Summary:
        //     The F32 key.
        F32 = 41,
        //
        // Summary:
        //     The F33 key.
        F33 = 42,
        //
        // Summary:
        //     The F34 key.
        F34 = 43,
        //
        // Summary:
        //     The F35 key.
        F35 = 44,
        //
        // Summary:
        //     The up arrow key.
        Up = 45,
        //
        // Summary:
        //     The down arrow key.
        Down = 46,
        //
        // Summary:
        //     The left arrow key.
        Left = 47,
        //
        // Summary:
        //     The right arrow key.
        Right = 48,
        //
        // Summary:
        //     The enter key.
        Enter = 49,
        //
        // Summary:
        //     The escape key.
        Escape = 50,
        //
        // Summary:
        //     The space key.
        Space = 51,
        //
        // Summary:
        //     The tab key.
        Tab = 52,
        //
        // Summary:
        //     The backspace key.
        BackSpace = 53,
        //
        // Summary:
        //     The backspace key (equivalent to BackSpace).
        Back = 53,
        //
        // Summary:
        //     The insert key.
        Insert = 54,
        //
        // Summary:
        //     The delete key.
        Delete = 55,
        //
        // Summary:
        //     The page up key.
        PageUp = 56,
        //
        // Summary:
        //     The page down key.
        PageDown = 57,
        //
        // Summary:
        //     The home key.
        Home = 58,
        //
        // Summary:
        //     The end key.
        End = 59,
        //
        // Summary:
        //     The caps lock key.
        CapsLock = 60,
        //
        // Summary:
        //     The scroll lock key.
        ScrollLock = 61,
        //
        // Summary:
        //     The print screen key.
        PrintScreen = 62,
        //
        // Summary:
        //     The pause key.
        Pause = 63,
        //
        // Summary:
        //     The num lock key.
        NumLock = 64,
        //
        // Summary:
        //     The clear key (Keypad5 with NumLock disabled, on typical keyboards).
        Clear = 65,
        //
        // Summary:
        //     The sleep key.
        Sleep = 66,
        //
        // Summary:
        //     The keypad 0 key.
        Keypad0 = 67,
        //
        // Summary:
        //     The keypad 1 key.
        Keypad1 = 68,
        //
        // Summary:
        //     The keypad 2 key.
        Keypad2 = 69,
        //
        // Summary:
        //     The keypad 3 key.
        Keypad3 = 70,
        //
        // Summary:
        //     The keypad 4 key.
        Keypad4 = 71,
        //
        // Summary:
        //     The keypad 5 key.
        Keypad5 = 72,
        //
        // Summary:
        //     The keypad 6 key.
        Keypad6 = 73,
        //
        // Summary:
        //     The keypad 7 key.
        Keypad7 = 74,
        //
        // Summary:
        //     The keypad 8 key.
        Keypad8 = 75,
        //
        // Summary:
        //     The keypad 9 key.
        Keypad9 = 76,
        //
        // Summary:
        //     The keypad divide key.
        KeypadDivide = 77,
        //
        // Summary:
        //     The keypad multiply key.
        KeypadMultiply = 78,
        //
        // Summary:
        //     The keypad subtract key.
        KeypadSubtract = 79,
        //
        // Summary:
        //     The keypad minus key (equivalent to KeypadSubtract).
        KeypadMinus = 79,
        //
        // Summary:
        //     The keypad add key.
        KeypadAdd = 80,
        //
        // Summary:
        //     The keypad plus key (equivalent to KeypadAdd).
        KeypadPlus = 80,
        //
        // Summary:
        //     The keypad decimal key.
        KeypadDecimal = 81,
        //
        // Summary:
        //     The keypad period key (equivalent to KeypadDecimal).
        KeypadPeriod = 81,
        //
        // Summary:
        //     The keypad enter key.
        KeypadEnter = 82,
        //
        // Summary:
        //     The A key.
        A = 83,
        //
        // Summary:
        //     The B key.
        B = 84,
        //
        // Summary:
        //     The C key.
        C = 85,
        //
        // Summary:
        //     The D key.
        D = 86,
        //
        // Summary:
        //     The E key.
        E = 87,
        //
        // Summary:
        //     The F key.
        F = 88,
        //
        // Summary:
        //     The G key.
        G = 89,
        //
        // Summary:
        //     The H key.
        H = 90,
        //
        // Summary:
        //     The I key.
        I = 91,
        //
        // Summary:
        //     The J key.
        J = 92,
        //
        // Summary:
        //     The K key.
        K = 93,
        //
        // Summary:
        //     The L key.
        L = 94,
        //
        // Summary:
        //     The M key.
        M = 95,
        //
        // Summary:
        //     The N key.
        N = 96,
        //
        // Summary:
        //     The O key.
        O = 97,
        //
        // Summary:
        //     The P key.
        P = 98,
        //
        // Summary:
        //     The Q key.
        Q = 99,
        //
        // Summary:
        //     The R key.
        R = 100,
        //
        // Summary:
        //     The S key.
        S = 101,
        //
        // Summary:
        //     The T key.
        T = 102,
        //
        // Summary:
        //     The U key.
        U = 103,
        //
        // Summary:
        //     The V key.
        V = 104,
        //
        // Summary:
        //     The W key.
        W = 105,
        //
        // Summary:
        //     The X key.
        X = 106,
        //
        // Summary:
        //     The Y key.
        Y = 107,
        //
        // Summary:
        //     The Z key.
        Z = 108,
        //
        // Summary:
        //     The number 0 key.
        Number0 = 109,
        //
        // Summary:
        //     The number 1 key.
        Number1 = 110,
        //
        // Summary:
        //     The number 2 key.
        Number2 = 111,
        //
        // Summary:
        //     The number 3 key.
        Number3 = 112,
        //
        // Summary:
        //     The number 4 key.
        Number4 = 113,
        //
        // Summary:
        //     The number 5 key.
        Number5 = 114,
        //
        // Summary:
        //     The number 6 key.
        Number6 = 115,
        //
        // Summary:
        //     The number 7 key.
        Number7 = 116,
        //
        // Summary:
        //     The number 8 key.
        Number8 = 117,
        //
        // Summary:
        //     The number 9 key.
        Number9 = 118,
        //
        // Summary:
        //     The tilde key.
        Tilde = 119,
        //
        // Summary:
        //     The grave key (equivaent to Tilde).
        Grave = 119,
        //
        // Summary:
        //     The minus key.
        Minus = 120,
        //
        // Summary:
        //     The plus key.
        Plus = 121,
        //
        // Summary:
        //     The left bracket key.
        BracketLeft = 122,
        //
        // Summary:
        //     The left bracket key (equivalent to BracketLeft).
        LBracket = 122,
        //
        // Summary:
        //     The right bracket key.
        BracketRight = 123,
        //
        // Summary:
        //     The right bracket key (equivalent to BracketRight).
        RBracket = 123,
        //
        // Summary:
        //     The semicolon key.
        Semicolon = 124,
        //
        // Summary:
        //     The quote key.
        Quote = 125,
        //
        // Summary:
        //     The comma key.
        Comma = 126,
        //
        // Summary:
        //     The period key.
        Period = 127,
        //
        // Summary:
        //     The slash key.
        Slash = 128,
        //
        // Summary:
        //     The backslash key.
        BackSlash = 129,
        //
        // Summary:
        //     The secondary backslash key.
        NonUSBackSlash = 130,
        //
        // Summary:
        //     Indicates the last available keyboard key.
        LastKey = 131
    }

    #endregion

    /// <summary>
    /// Main Input Manager
    /// </summary>
    public static class InputManager
    {
        #region Data
        private static ButtonState[] _keys;
        private static ButtonState[] _mousebuttons;
        private static bool[] _hasKeyBeenReleased;
        private static bool[] _hasMouseBeenReleased;

        private static Vector2 _mousePosition;
        #endregion

        #region Events
        /// <summary>
        /// Called during the OnLoad of the application
        /// </summary>
        /// <param name="e">Event arguments</param>
        internal static void OnLoad(EventArgs e)
        {
            _keys = new ButtonState[(int)Key.LastKey];
            _mousebuttons = new ButtonState[(int)MouseButton.LastButton];

            _hasKeyBeenReleased = new bool[(int)Key.LastKey];
            _hasMouseBeenReleased = new bool[(int)MouseButton.LastButton];

            for (int i = 0; i < (int)Key.LastKey; i++)
            {
                _keys[i] = ButtonState.NONE;
                _hasKeyBeenReleased[i] = false;
            }

            for (int i = 0; i < (int)MouseButton.LastButton; i++)
            {
                _mousebuttons[i] = ButtonState.NONE;
                _hasMouseBeenReleased[i] = false;
            }

            SetupInputEvents();
        }

        /// <summary>
        /// Called on the Unload of the application
        /// </summary>
        /// <param name="e">Event arguments</param>
        internal static void OnUnload(EventArgs e)
        {

        }

        /// <summary>
        /// Called on the Render of a frame
        /// </summary>
        /// <param name="e">Event arguments</param>
        internal static void OnRenderFrame(FrameEventArgs e)
        {
            for (int i = 0; i < (int)Key.LastKey; i++)
            {
                if (_keys[i] == ButtonState.PRESSED)
                {
                    if (!_hasKeyBeenReleased[i])
                    {
                        _keys[i] = ButtonState.DOWN;
                    }
                }

                if (_keys[i] == ButtonState.UP)
                    _keys[i] = ButtonState.NONE;

                if (_hasKeyBeenReleased[i])
                    _hasKeyBeenReleased[i] = false;
            }

            for (int i = 0; i < (int)MouseButton.LastButton; i++)
            {
                if (_mousebuttons[i] == ButtonState.PRESSED)
                {
                    if (!_hasMouseBeenReleased[i])
                    {
                        _mousebuttons[i] = ButtonState.DOWN;
                    }
                }

                if (_mousebuttons[i] == ButtonState.UP)
                    _mousebuttons[i] = ButtonState.NONE;

                if (_hasMouseBeenReleased[i])
                    _hasMouseBeenReleased[i] = false;
            }
        }

        #endregion

        #region Public API
        /// <summary>
        /// Returns if a key is being held down
        /// </summary>
        /// <param name="key">Key to check</param>
        public static bool IsKeyDown(Key key)
        {
            return _keys[(int)key] == ButtonState.DOWN || _keys[(int)key] == ButtonState.PRESSED;
        }

        /// <summary>
        /// Returns if a key is being pressed
        /// </summary>
        /// <param name="key">Key to check</param>
        public static bool IsKeyPressed(Key key)
        {
            return _keys[(int)key] == ButtonState.PRESSED;
        }

        /// <summary>
        /// Returns if a key has just been released
        /// </summary>
        /// <param name="key">Key to check</param>
        public static bool IsKeyUp(Key key)
        {
            return _keys[(int)key] == ButtonState.UP;
        }

        /// <summary>
        /// Returns if a mouse button is being held down
        /// </summary>
        /// <param name="button">Button to check</param>
        public static bool IsMouseButtonDown(MouseButton button)
        {
            return _mousebuttons[(int)button] == ButtonState.DOWN || _mousebuttons[(int)button] == ButtonState.PRESSED;
        }

        /// <summary>
        /// Returns if a mouse button is being pressed
        /// </summary>
        /// <param name="button">Button to check</param>
        public static bool IsMouseButtonPressed(MouseButton button)
        {
            return _mousebuttons[(int)button] == ButtonState.PRESSED;
        }

        /// <summary>
        /// Returns if a mouse button has just been released
        /// </summary>
        /// <param name="button">Button to check</param>
        public static bool IsMouseButtonUp(MouseButton button)
        {
            return _mousebuttons[(int)button] == ButtonState.UP;
        }

        /// <summary>
        /// Returns the current mouse position
        /// </summary>
        public static Vector2 MousePosition
        {
            get
            {
                return _mousePosition;
            }

            set
            {
                _mousePosition = value;
            }
        }
        #endregion

        #region Private API

        private static void SetupInputEvents()
        {
            CoreEngine.CurrentApplication.Keyboard.KeyDown += Keyboard_KeyDown;
            CoreEngine.CurrentApplication.Keyboard.KeyUp += Keyboard_KeyUp;
            CoreEngine.CurrentApplication.Keyboard.KeyRepeat = true;

            CoreEngine.CurrentApplication.Mouse.ButtonDown += Mouse_ButtonDown;
            CoreEngine.CurrentApplication.Mouse.ButtonUp += Mouse_ButtonUp;
            CoreEngine.CurrentApplication.Mouse.Move += Mouse_Move;
            CoreEngine.CurrentApplication.Mouse.WheelChanged += Mouse_Wheel;
        }

        private static void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (_keys[(int)e.Key] == ButtonState.PRESSED)
            {
                _keys[(int)e.Key] = ButtonState.DOWN;
                return;
            }
            if (_keys[(int)e.Key] == ButtonState.NONE)
            {
                _keys[(int)e.Key] = ButtonState.PRESSED;
                return;
            }
        }

        private static void Keyboard_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            _keys[(int)e.Key] = ButtonState.UP;
            _hasKeyBeenReleased[(int)e.Key] = true;
        }

        private static void Mouse_ButtonDown(object sender, MouseButtonEventArgs e)
        {
            _mousePosition = new Vector2(e.X, e.Y);
            if (_mousebuttons[(int)e.Button] == ButtonState.PRESSED)
            {
                _mousebuttons[(int)e.Button] = ButtonState.DOWN;
                return;
            }
            if (_mousebuttons[(int)e.Button] == ButtonState.NONE)
            {
                _mousebuttons[(int)e.Button] = ButtonState.PRESSED;
                return;
            }
        }

        private static void Mouse_ButtonUp(object sender, MouseButtonEventArgs e)
        {
            _mousePosition = new Vector2(e.X, e.Y);
            _mousebuttons[(int)e.Button] = ButtonState.UP;
            _hasMouseBeenReleased[(int)e.Button] = true;
        }

        private static void Mouse_Move(object sender, MouseMoveEventArgs e)
        {
            _mousePosition = new Vector2(e.X, e.Y);
        }

        private static void Mouse_Wheel(object sender, MouseWheelEventArgs args)
        {

        }
        #endregion
    }
}
