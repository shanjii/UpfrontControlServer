using WindowsInput.Events;

namespace ICPServer.Data
{
    public class Inputs
    {
        public static void PressKey(string key)
        {
            KeyCode keyCode = GetKeyCode(key);
            WindowsInput.Simulate.Events().Hold(keyCode).Invoke();
        }

        public static void ReleaseKey(string key)
        {
            KeyCode keyCode = GetKeyCode(key);
            WindowsInput.Simulate.Events().Release(keyCode).Invoke();
        }

        private static KeyCode GetKeyCode(string key)
        {
            var value = Convert.ToInt32(key, 16);
            KeyCode keyCode = (KeyCode)value;
            return keyCode;
        }
    }
}
