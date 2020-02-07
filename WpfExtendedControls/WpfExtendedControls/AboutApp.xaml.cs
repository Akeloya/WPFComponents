/*
 *  Wpf extended user controls for using it in WPF applications
 *  Copyright (C) 2020  Yugov V. Maxim
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfExtendedControls
{
    /// <summary>
    /// Логика взаимодействия для AboutApp.xaml
    /// </summary>
    public partial class AboutApp : Window
    {
        public AboutApp(IEnumerable<LicenseInformation> info, object image = null)
        {
            InitializeComponent();
            if (image != null)
            {
                SetAppImage(image);
            }
            else
            {
                SetAppImage(Properties.Resources.Properties);
            }
            VersionInfo = GetVersionInfo();
            List<LicenseInformation> licenses = new List<LicenseInformation> { new LicenseInformation("WPF Extended Controls", Encoding.UTF8.GetString(Properties.Resources.LICENSE), false) };
            licenses.AddRange(info);
            Licenses = licenses;
        }
        internal static FileVersionInfo GetVersionInfo()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi;
        }
        internal BitmapFrame BitmapFrame { get { return (BitmapFrame)GetValue(BitmapFrameProperty); } set { SetValue(BitmapFrameProperty, value); } }
        internal static readonly DependencyProperty BitmapFrameProperty = DependencyProperty.Register(nameof(BitmapFrame), typeof(BitmapFrame), typeof(AboutApp));
        internal List<LicenseInformation> Licenses { get { return (List<LicenseInformation>)GetValue(LicensesProperty); } set { SetValue(LicensesProperty, value); } }
        internal static readonly DependencyProperty LicensesProperty = DependencyProperty.Register(nameof(Licenses), typeof(List<LicenseInformation>), typeof(AboutApp));
        internal FileVersionInfo VersionInfo { get { return (FileVersionInfo)GetValue(VersionInfoProperty); } set { SetValue(VersionInfoProperty, value); } }
        internal static readonly DependencyProperty VersionInfoProperty = DependencyProperty.Register(nameof(VersionInfo), typeof(FileVersionInfo), typeof(AboutApp));

        private void CloseBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void SetAppImage(object image)
        {
            Type imageType = image.GetType();
            if (imageType != typeof(BitmapFrame) && imageType != typeof(string) && imageType != typeof(Uri) && imageType != typeof(BitmapSource) && imageType != typeof(byte[]))
                throw new ArgumentException();
            if(imageType == typeof(BitmapFrame))
            {
                BitmapFrame = (BitmapFrame)image;
                return;
            }
            if(imageType == typeof(BitmapSource))
            {
                BitmapFrame = BitmapFrame.Create(((BitmapSource)image));
                return;
            }

            if(imageType == typeof(Uri))
            {
                BitmapFrame = BitmapFrame.Create((Uri)image);
                return;
            }

            if(imageType == typeof(string))
            {
                BitmapFrame = BitmapFrame.Create(new Uri(image.ToString()));
            }
            if(imageType == typeof(byte[]))
            {
                using MemoryStream ms = new MemoryStream((byte[])image);
                BitmapFrame = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }
    }
}
