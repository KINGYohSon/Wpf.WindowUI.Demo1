using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.WindowUI.Demo1.ViewModels;

namespace Wpf.WindowUI.Demo1
{
    public partial class MainWindow : Window
    {
        MainViewModel viewModel;
        //private const int HTLEFT = 10;
        //private const int HTRIGHT = 11;
        //private const int HTTOP = 12;
        //private const int HTTOPLEFT = 13;
        //private const int HTTOPRIGHT = 14;
        //private const int HTBOTTOM = 15;
        //private const int HTBOTTOMLEFT = 16;
        //private const int HTBOTTOMRIGHT = 17;

        public MainWindow()
        {
            viewModel = new MainViewModel();
            this.DataContext = viewModel;
            InitializeComponent();
            this.StateChanged += new EventHandler(Window_StateChanged);
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);
        //    var handle = (new WindowInteropHelper(this)).Handle;
        //    var hwndSource = HwndSource.FromHwnd(handle);
        //    hwndSource.AddHook(new HwndSourceHook(WndProc));
        //}

        //private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        //{
        //    switch (msg)
        //    {
        //        case 0x0084: // WM_NCHITTEST
        //            handled = true;
        //            return HandleHitTest(lParam);
        //    }
        //    return IntPtr.Zero;
        //}


        //private IntPtr HandleHitTest(IntPtr lParam)
        //{
        //    Point point = new Point((short)lParam.ToInt32(), (short)(lParam.ToInt32() >> 16));
        //    Point mousePoint = this.PointFromScreen(point);

        //    // 如果鼠标在内容区域，则返回 HTCLIENT
        //    if (mousePoint.X > 5 && mousePoint.X < this.ActualWidth - 5 && mousePoint.Y > 5 && mousePoint.Y < this.ActualHeight - 5)
        //    {
        //        return new IntPtr(1); // HTCLIENT
        //    }

        //    // 以下代码处理窗口边缘的检测
        //    if (mousePoint.X <= 5)
        //    {
        //        if (mousePoint.Y <= 5) return (IntPtr)HTTOPLEFT;
        //        if (mousePoint.Y >= this.ActualHeight - 5) return (IntPtr)HTBOTTOMLEFT;
        //        return (IntPtr)HTLEFT;
        //    }
        //    if (mousePoint.X >= this.ActualWidth - 5)
        //    {
        //        if (mousePoint.Y <= 5) return (IntPtr)HTTOPRIGHT;
        //        if (mousePoint.Y >= this.ActualHeight - 5) return (IntPtr)HTBOTTOMRIGHT;
        //        return (IntPtr)HTRIGHT;
        //    }
        //    if (mousePoint.Y <= 5) return (IntPtr)HTTOP;
        //    if (mousePoint.Y >= this.ActualHeight - 5) return (IntPtr)HTBOTTOM;

        //    return IntPtr.Zero;
        //}

        private void Window_StateChanged(object sender, EventArgs e)
        {
            ToggleMaximizeRestoreButtons();
        }

        private void ToggleMaximizeRestoreButtons()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                MaximizeButton.Visibility = Visibility.Collapsed;
                RestoreButton.Visibility = Visibility.Visible;
            }
            else
            {
                MaximizeButton.Visibility = Visibility.Visible;
                RestoreButton.Visibility = Visibility.Collapsed;
            }
        }
    }
}