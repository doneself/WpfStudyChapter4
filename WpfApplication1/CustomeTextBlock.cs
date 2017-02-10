using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    public class CustomeTextBlock:TextBlock
    {
        public static DependencyProperty TimeProperty;

        public DateTime Timer
        {
            get
            {
                return (DateTime)GetValue(TimeProperty);
            }
            set
            {
                SetValue(TimeProperty, value);
            }
        }
        static CustomeTextBlock()
        {
            FrameworkPropertyMetadata metaData = new FrameworkPropertyMetadata();
            metaData.Inherits = true;
            TimeProperty = MainWindow.TimeProperty.AddOwner(typeof(CustomeTextBlock));
            TimeProperty.OverrideMetadata(typeof(CustomeTextBlock), metaData);
        }
    }
}
