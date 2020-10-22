using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncInClient
{
    public partial class Form1 : Form
    {
        int counter = 0;
        int heavyTasksRunning = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void heavyTaskBlocking_Click(object sender, EventArgs e)
        {
            label2.Text = "Running heavy task...";
            HeavyTask();
            if (heavyTasksRunning == 0)
            {
                label2.Text = "Finished!";
            }
        }

        private async void heavyTaskNonBlocking_Click(object sender, EventArgs e)
        {
            Interlocked.Increment(ref heavyTasksRunning);
            label2.Text = "Running heavy task...";
            label3.Text = $"Heavy tasks running {heavyTasksRunning}";
            try
            {
                await HeavyTaskAsync();
            }
            finally
            {
                Interlocked.Decrement(ref heavyTasksRunning);
            }
            label3.Text = $"Heavy tasks running {heavyTasksRunning}";
            if (heavyTasksRunning == 0)
            {
                label2.Text = "Finished!";
            }

        }
        private void increaseCounter_Click(object sender, EventArgs e)
        {
            counter++;
            label1.Text = counter.ToString();
        }

        private async Task HeavyTaskAsync()
        {
            await Task.Run(() => HeavyTask());
        }

        private void HeavyTask()
        {
            for (int i = 0; i < 2000000000; i++)
            {

            }
        }

    }
}
