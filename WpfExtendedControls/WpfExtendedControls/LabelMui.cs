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
        /// <summary>
        /// Resource type with multilangual strings
        /// </summary>
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
        /// <summary>
        /// Resource key with string value for displaying
        /// </summary>
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
