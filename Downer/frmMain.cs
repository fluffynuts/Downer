using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeanutButter.TrayIcon;

namespace Downer
{
    public partial class frmMain : Form
    {
        private TrayIcon _icon;
        private bool _exiting;
        private int _currentDay;
        private int _currentHour;
        private int _currentYear;
        private int _currentMinute;
        private int _currentMonth;
        private bool _settingProgrammatically;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cmbMonth.Items.AddRange(new[]
            {
                new MonthItem(1, "Jan"),
                new MonthItem(2, "Feb"),
                new MonthItem(3, "Mar"),
                new MonthItem(4, "Apr"),
                new MonthItem(5, "May"),
                new MonthItem(6, "Jun"),
                new MonthItem(7, "Jul"),
                new MonthItem(8, "Aug"),
                new MonthItem(9, "Sep"),
                new MonthItem(10, "Oct"),
                new MonthItem(11, "Nov"),
                new MonthItem(12, "Dec")
            });
            SetSelectedDateTimeTo(DateTime.Now.AddHours(1));
        }

        private void InitTrayIcon()
        {
            lock (this)
            {
                if (_icon != null) return;
                _icon = new TrayIcon(this.Icon);
                _icon.NotifyIcon.Click += (o, s) =>
                {
                    this.BeginInvoke((Action) (() =>
                    {
                        if (this.Visible)
                            this.Hide();
                        else
                            this.Show();
                    }));
                };
                _icon.AddMenuItem("Shutdown...", () =>
                {
                    this.BeginInvoke((Action) (() =>
                    {
                        this.radShutdown.Checked = true;
                        this.Show();
                    }));
                });
                _icon.AddMenuItem("Reboot...", () =>
                {
                    this.BeginInvoke((Action) (() =>
                    {
                        this.radReboot.Checked = true;
                        this.Show();
                    }));
                });
                _icon.AddMenuSeparator();
                _icon.AddMenuItem("Abort pending shutdown...", () =>
                {
                    AbortPendingShutdown();
                    this.BeginInvoke((Action) (() =>
                    {
                        this.Visible = false;
                        this.Update();
                        MessageBox.Show("Any pending shutdown has been aborted...", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }));
                });
                _icon.AddMenuItem("Exit", (Action) (() =>
                {
                    this._exiting = true;
                    this.Close();
                }));
                _icon.Show();
            }
        }

        protected override void SetVisibleCore(bool value)
        {
            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
                value = false;
            }
            base.SetVisibleCore(value);
            InitTrayIcon();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AbortPendingShutdown();
            Run("shutdown", "-t", CalculateShutdownTimeFromNowInMinutes(), GetShutDownOrRebootOption());
            Close();
        }

        private void AbortPendingShutdown()
        {
            Run("shutdown", "-a");
        }

        private string GetShutDownOrRebootOption()
        {
            return radReboot.Checked ? "-r":"-s";
        }

        private string CalculateShutdownTimeFromNowInMinutes()
        {
            var delta = GetSelectedDateTime() - DateTime.Now;
            var value = delta.TotalSeconds < 0 ? 0 : delta.TotalSeconds;
            string stringVal = Int32.Parse(Math.Round(value).ToString()).ToString();
            return stringVal;
        }

        private DateTime GetSelectedDateTime()
        {
            return new DateTime(_currentYear, _currentMonth, _currentDay, _currentHour, _currentMinute, 0);
        }

        private void SetEnabled(bool enabled)
        {
            btnOK.Enabled = enabled;
            btnCancel.Enabled = enabled;
            spinDay.Enabled = enabled;
            cmbMonth.Enabled = enabled;
            spinHour.Enabled = enabled;
            spinMinute.Enabled = Enabled;
            spinYear.Enabled = enabled;
        }

        private void Run(string command, params string[] parameters)
        {
            SetEnabled(false);
            var process = new Process();
            var pinfo = new ProcessStartInfo();
            pinfo.FileName = QuoteIfRequired(command);
            if (parameters.Length > 0)
                pinfo.Arguments = String.Join(" ", parameters);
            pinfo.UseShellExecute = false;
            pinfo.WindowStyle = ProcessWindowStyle.Hidden;
            pinfo.CreateNoWindow = true;
            process.StartInfo = pinfo;
            process.Start();
            process.WaitForExit();
            Task.Factory.StartNew(() =>
            {
                this.BeginInvoke((Action)(() => { this.SetEnabled(true); }));
            });
        }

        private string QuoteIfRequired(string command)
        {
            return command.Contains(" ") 
                ? "\"" + command + "\""
                : command;
        }


        private void frmMain_Shown(object sender, EventArgs e)
        {
            SetSelectedDateTimeTo(DateTime.Now.AddHours(1));
        }

        private void SetSelectedDateTimeTo(DateTime date)
        {
            try
            {
                _settingProgrammatically = true;
                spinDay.Value = date.Day;
                spinHour.Value = date.Hour;
                spinYear.Value = date.Year;
                spinMinute.Value = date.Minute;
                cmbMonth.SelectedIndex = date.Month - 1;

                _currentDay = (int) spinDay.Value;
                _currentHour = (int) spinHour.Value;
                _currentYear = (int) spinYear.Value;
                _currentMinute = (int) spinMinute.Value;
                _currentMonth = (cmbMonth.SelectedItem as MonthItem).Month;
            }
            finally
            {
                _settingProgrammatically = false;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._exiting)
                return;
            this.Visible = false;
            e.Cancel = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _icon.Hide();
            _icon.Dispose();
        }

        private void spinDay_ValueChanged(object sender, EventArgs e)
        {
            if (_settingProgrammatically) return;
            var currentValue = GetSelectedDateTime();
            var delta = (int) (spinDay.Value - _currentDay);
            var newValue = currentValue.AddDays(delta);
            this.SetSelectedDateTimeTo(newValue);
        }

        private int MaxDaysForCurrentMonth()
        {
            switch (_currentMonth)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if (_currentYear%4 == 0)
                        return 29;
                    return 28;
                default:
                    return 30;
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_settingProgrammatically) return;
            var month = (cmbMonth.SelectedItem as MonthItem).Month;
            var delta = month - _currentMonth;
            var currentValue = GetSelectedDateTime();
            var newValue = currentValue.AddMonths(delta);
            SetSelectedDateTimeTo(newValue);
        }

        private void spinYear_ValueChanged(object sender, EventArgs e)
        {
            if (_settingProgrammatically) return;
            var year = (int) spinYear.Value;
            var delta = year - _currentYear;
            var newValue = GetSelectedDateTime().AddYears(delta);
            SetSelectedDateTimeTo(newValue);
        }

        private void spinHour_ValueChanged(object sender, EventArgs e)
        {
            if (_settingProgrammatically) return;
            var hour = (int) spinHour.Value;
            var delta = hour - _currentHour;
            var newValue = GetSelectedDateTime().AddHours(delta);
            SetSelectedDateTimeTo(newValue);
        }

        private void spinMinute_ValueChanged(object sender, EventArgs e)
        {
            if (_settingProgrammatically) return;
            var minute = (int) spinMinute.Value;
            var delta = minute - _currentMinute;
            var newValue = GetSelectedDateTime().AddMinutes(delta);
            SetSelectedDateTimeTo(newValue);
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            AbortPendingShutdown();
        }
    }
}
