using System.Diagnostics;

namespace VDDInstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = @"C:\Windows\System32";
            proc.FileName = @"C:\Windows\System32\hdwwiz.exe";
            proc.Verb = "runas";
            try
            {
                Process.Start(proc);
                Console.WriteLine("Successfully elevated!");
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to elevate.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String command = @"C:\IddSampleDriver\installCert.bat";
            var proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = @"C:\Windows\System32";
            proc.FileName = @"cmd.exe";
            proc.Verb = "runas";
            proc.Arguments = "/c " + command;


            try
            {
                Process.Start(proc);
                Console.WriteLine("Successfully elevated!");
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to elevate.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            label4.Text = comboBox1.Text;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}