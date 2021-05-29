using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Wpf67
{
    class MyUserControl1:Button
    {
        //Прямые (direct events) - они возникают и отрабытывают на одном элементе и никуда дальше не передаются
        //Поднимающиеся (bubbling events) - возникают на одном элементе, а потом передаются дальше к родителю
        //- элементу-контейнеру и далее, пока не достигнет наивысшего родителя в дереве элементов

        //Опускающиеся, туннельные (tunneling events) - начинает отрабатывать в корневом элементе 
        //окна приложения и идет далее по вложенным элементам, пока не достигнет элемента, вызвавшего это событие
     
        public static readonly RoutedEvent TapEvent = EventManager.RegisterRoutedEvent(
            "Tap", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MyUserControl1));

        public event RoutedEventHandler Tap
        {
            add => AddHandler(TapEvent, value);
            remove => RemoveHandler(TapEvent, value);
        }

        // This method raises the Tap event
        void RaiseTapEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MyUserControl1.TapEvent);
            RaiseEvent(newEventArgs);
        }
        protected override void OnClick()
        {
            RaiseTapEvent();
        }
       

    }
}
