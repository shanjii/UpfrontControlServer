using UFCServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace UFCServer.Data
{
    public class Controller
    {

        [HttpPost]
        [Route("/press-keyboard")]
        public void PressKeyboard([FromBody] ActionModel payload)
        {
            try
            {
                if (payload.Key == null) return;
                Inputs.PressKeyKeyboard(payload.Key, payload.Modifier);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Request error: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        [HttpPost]
        [Route("/release-keyboard")]
        public void ReleaseKeyboard([FromBody] ActionModel payload)
        {
            try
            {
                if (payload.Key == null) return;
                Inputs.ReleaseKeyKeyboard(payload.Key, payload.Modifier);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Request error: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        [HttpPost]
        [Route("/press-vjoy")]
        public void PressVjoy([FromBody] ActionModel payload)
        {
            try
            {
                if (payload.JoyKey == null) return;
                Inputs.PressKeyVjoy(Convert.ToUInt32(payload.JoyKey));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Request error: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        [HttpPost]
        [Route("/release-vjoy")]
        public void ReleaseVjoy([FromBody] ActionModel payload)
        {
            try
            {
                if (payload.JoyKey == null) return;
                Inputs.ReleaseKeyVjoy(Convert.ToUInt32(payload.JoyKey));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Request error: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }
    }
}
