using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DataTemplateSelectorBeispiel
{
    public class MyTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Person)
            {
                return (DataTemplate)Application.Current.Resources["PersonenTemplate"];
            }
            else
            {
                return (DataTemplate)Application.Current.Resources["AutoTemplate"];
            }
        }

    }
}
