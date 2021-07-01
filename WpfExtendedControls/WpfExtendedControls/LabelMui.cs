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
using System.Windows;
using System.Windows.Controls;
using WpfExtendedControls.Properties;

namespace WpfExtendedControls
{
    public class LabelMui : Control
    {
        static LabelMui()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabelMui), new FrameworkPropertyMetadata(typeof(LabelMui)));
        }

        public Type Resource { get { return (Type)GetValue(ResourceProperty); } set { SetValue(ResourceProperty, value); } }
        public static readonly DependencyProperty ResourceProperty = DependencyProperty.Register(
            nameof(Resource),
            typeof(Type),
            typeof(LabelMui),
            new PropertyMetadata(typeof(Resources),
                new PropertyChangedCallback((sender, args) => 
                {
                    if (args.NewValue == null)
                        return;
                    LabelMui inst = (LabelMui)sender;
                    if (string.IsNullOrEmpty(inst.ResourceKey))
                        return;
                    inst.Label = ResourcesSearcher.GetString((Type)args.NewValue, inst.ResourceKey);
                })));
        public string ResourceKey { get; set; }
        public static readonly DependencyProperty ResourceKeyProperty = DependencyProperty.Register(
            nameof(ResourceKey), 
            typeof(string),
            typeof(LabelMui), 
            new PropertyMetadata(string.Empty, 
                new PropertyChangedCallback((sender, args) => 
                {
                    if (args.NewValue == null)
                        return;
                    LabelMui inst = (LabelMui)sender;
                    if (inst.Resource == null)
                        return;
                    inst.Label = ResourcesSearcher.GetString(inst.Resource, args.NewValue.ToString());
                })));
        internal string Label { get { return GetValue(LabelProperty)?.ToString(); } set { SetValue(LabelProperty, value); } }
        internal static readonly DependencyProperty LabelProperty = DependencyProperty.Register(nameof(Label), typeof(string), typeof(LabelMui));
    }
}
