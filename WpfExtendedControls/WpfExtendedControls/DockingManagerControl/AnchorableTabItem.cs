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
using System.Windows;
using System.Windows.Controls;

namespace WpfExtendedControls
{
    public class AnchorableTabItem : ContentControl
    {
        static AnchorableTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnchorableTabItem), new FrameworkPropertyMetadata(typeof(AnchorableTabItem)));
        }

        public AnchorableTabItem() : base()
        {

        }

        public bool IsSelected { get { return (bool)GetValue(IsSelectedProperty); } set { SetValue(IsSelectedProperty, value); } }
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register(
            nameof(IsSelected),
            typeof(bool),
            typeof(AnchorableTabItem),
            new PropertyMetadata(false)
            );
        public object Header { get { return GetValue(HeaderProperty); } set { SetValue(HeaderProperty, value); } }
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            nameof(Header),
            typeof(object),
            typeof(AnchorableTabItem)
            );
    }
}
