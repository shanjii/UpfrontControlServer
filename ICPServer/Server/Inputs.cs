using WindowsInput.Events;

namespace ICPServer.Data
{
    public class Inputs
    {
        public static void PressKey(string key)
        {
            bool extended = key.Contains('#');
            KeyCode keyCode = GetKeyCode(extended ? key.Replace("#", "") : key);
            WindowsInput.Simulate.Events().Hold(keyCode, extended).Invoke();
        }

        public static void ReleaseKey(string key)
        {
            bool extended = key.Contains('#');
            KeyCode keyCode = GetKeyCode(extended ? key.Replace("#", "") : key);
            WindowsInput.Simulate.Events().Release(keyCode, extended).Invoke();
        }

        private static KeyCode GetKeyCode(string key)
        {
            var value = Convert.ToInt32(key, 16);
            KeyCode keyCode = (KeyCode)value;
            return keyCode;
        }
    }
}
