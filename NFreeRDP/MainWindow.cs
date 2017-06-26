using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FreeRDP;
using FreeRDP.Core;

namespace NFreeRDP
{
	public partial class MainWindow : Form
	{
		readonly RdpPaintUpdates _rdpPaintUpdates;
		private readonly RDP _rdp;

		public MainWindow()
		{
			InitializeComponent();

			_rdp = new RDP();
			_rdpPaintUpdates = new RdpPaintUpdates(_rdp);
			_rdp.ErrorInfo += Rdp_ErrorInfo;
			_rdp.Terminated += Rdp_Terminated;

			_rdp.SetUpdateInterface(_rdpPaintUpdates);
			_rdp.SetPrimaryUpdateInterface(_rdpPaintUpdates);

			UpdateStatusLabel();
		}

		private void newConnectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (ConnectionDialog dialog = new ConnectionDialog())
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					var settings = dialog.GetConnectionSettings();

					_rdp.Connect(settings.hostname, settings.domain, settings.username, settings.password, settings.port,
						new FreeRDP.Core.ConnectionSettings() {DesktopWidth = 1920, DesktopHeight = 1080});

					//send enter to dismiss legal notice message
					Thread.Sleep(2000);
					_rdp.SendInputKeyboardEvent(KeyboardFlags.KBD_FLAGS_DOWN, 28);
					Thread.Sleep(200);
					_rdp.SendInputKeyboardEvent(KeyboardFlags.KBD_FLAGS_RELEASE, 28);

					UpdateStatusLabel();
				}
			}
		}

		private void disconnectToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			_rdp.Disconnect();
		}

		private void Rdp_Terminated(object sender, EventArgs e)
		{
			Invoke((MethodInvoker)UpdateStatusLabel);
		}

		private void Rdp_ErrorInfo(object sender, ErrorInfoEventArgs e)
		{
			MessageBox.Show(e.ErrorInfoMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void UpdateStatusLabel()
		{
			this.toolStripStatusLabel1.Text = _rdp.Connected ? "Connected" : "Disconnected";
			this.newConnectionToolStripMenuItem.Enabled = !_rdp.Connected;
			this.disconnectToolStripMenuItem1.Enabled = _rdp.Connected;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				components?.Dispose();
				_rdp?.Dispose();
			}
			base.Dispose(disposing);
		}

	}
}
