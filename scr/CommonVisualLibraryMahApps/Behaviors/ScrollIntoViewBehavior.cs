using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CommonVisualLibraryMahApps.Behaviors
{
    public class ScrollIntoViewLBBehavior : Behavior<ListBox>
    {
        protected override void OnAttached()
        {
            ListBox listBox = AssociatedObject;
            ((INotifyCollectionChanged)listBox.Items).CollectionChanged += OnListBox_CollectionChanged;
        }

        protected override void OnDetaching()
        {
            ListBox listBox = AssociatedObject;
            ((INotifyCollectionChanged)listBox.Items).CollectionChanged -= OnListBox_CollectionChanged;
        }

        private void OnListBox_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ListBox listBox = AssociatedObject;
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // scroll the new item into view   
                listBox.ScrollIntoView(listBox.Items[listBox.Items.Count - 1]);
            }
        }
    }
    public class ScrollIntoViewLVBehavior : Behavior<ListView>
    {
        protected override void OnAttached()
        {
            ListView listView = AssociatedObject;
            ((INotifyCollectionChanged)listView.Items).CollectionChanged += OnListView_CollectionChanged;
        }

        protected override void OnDetaching()
        {
            ListView listView = AssociatedObject;
            ((INotifyCollectionChanged)listView.Items).CollectionChanged -= OnListView_CollectionChanged;
        }

        private void OnListView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ListView listView = AssociatedObject;
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // scroll the new item into view   
                //listView.ScrollIntoView(listView.Items[listView.Items.Count - 1]);

                var items = listView.Items;
                var last = items[items.Count - 1];

                items.MoveCurrentTo(last);
                listView.ScrollIntoView(last);
            }
        }
    }
}
