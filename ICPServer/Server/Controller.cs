using ICPServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ICPServer.Data
{
    public class Controller
    {

        [HttpPost]
        [Route("/press")]
        public void Press([FromBody] ActionModel payload)
        {
            try
            {
                Inputs.PressKey(payload.Key);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Request error: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        [HttpPost]
        [Route("/release")]
        public void Release([FromBody] ActionModel payload)
        {
            try
            {
                Inputs.ReleaseKey(payload.Key);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Request error: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }
    }


}
