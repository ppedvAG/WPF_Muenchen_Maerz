using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace XAMLDynamischLaden
{
    public class CustomPanel : Panel
    {
        // Make the panel as big as the biggest element
        protected override Size MeasureOverride(Size availableSize)
        {
            Size maxSize = new Size();

            foreach (UIElement child in this.InternalChildren)
            {
                child.Measure(availableSize);
                maxSize.Height = Math.Max(child.DesiredSize.Height, maxSize.Height);
                maxSize.Width = Math.Max(child.DesiredSize.Width, maxSize.Width);
            }
            return maxSize;
        }

        // Arrange the child elements to their final position
        protected override Size ArrangeOverride(Size finalSize)
        {
            List<UIElement> Liste = new List<UIElement>();

            foreach (UIElement item in InternalChildren)
            {
                Liste.Add(item);
            }

            Liste = Liste.OrderBy(x => CustomPanel.GetZOrder(x)).ToList();

            InternalChildren.Clear();

            Liste.ForEach(x => InternalChildren.Add(x));

            foreach (UIElement child in this.InternalChildren)
            {
                child.Arrange(new Rect(finalSize));
            }
            return finalSize;
        }

        //Attached Property

        public static readonly DependencyProperty ZOrderProperty = 
            DependencyProperty.RegisterAttached("ZOrder", typeof(int), typeof(CustomPanel), new FrameworkPropertyMetadata(0));

        public static int GetZOrder(UIElement element)
        {
            return (int)element.GetValue(CustomPanel.ZOrderProperty);
        }

        public static void SetZOrder(UIElement element, int value)
        {
            element.SetValue(CustomPanel.ZOrderProperty, value);
        }

    }
}
