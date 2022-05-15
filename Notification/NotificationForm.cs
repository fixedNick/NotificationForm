using System;
using System.Drawing;
using System.Windows.Forms;

namespace Notification
{
    public partial class NotificationForm : Form
    {

        private Point FormStartPosition = new Point();
        private Size FormSize = new Size();

        private Point Gap = new Point(5, 5);
        private int TimeToHide = 13;//todo

        public NotificationForm()
        {
            InitializeComponent();
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            FormSize = this.Size;
            // Setup showing location
            var UserResolution = Screen.PrimaryScreen.WorkingArea;
            SetupViewLocation(UserResolution.Width - FormSize.Width - Gap.X, UserResolution.Height - FormSize.Height - Gap.Y);
            this.Location = FormStartPosition;
            HideNotification();
        }

        public async void HideNotification()
        {
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(TimeToHide));
            this.Close();
        }

        public void SetupViewLocation(int x, int y)
        {
            int CurrentResolutionHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int CurrentResolutionWidth = Screen.PrimaryScreen.WorkingArea.Width;

            if (x < 0 || y < 0)
                throw new Exception("Location cannot be lower than Zero.");
            else if (y > CurrentResolutionHeight || x > CurrentResolutionWidth)
                throw new Exception("x or y cannot be bigger than current user resolution");
            FormStartPosition = new Point(x,y);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}