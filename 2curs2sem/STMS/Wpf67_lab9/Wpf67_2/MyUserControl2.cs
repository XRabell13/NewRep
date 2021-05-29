using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Wpf67
{
    class MyUserControl2 : Button
    {
        //Прямые (direct events) - они возникают и отрабытывают на одном элементе и никуда дальше не передаются
        //Поднимающиеся (bubbling events) - возникают на одном элементе, а потом передаются дальше к родителю
        //- элементу-контейнеру и далее, пока не достигнет наивысшего родителя в дереве элементов

        //Опускающиеся, туннельные (tunneling events) - начинает отрабатывать в корневом элементе 
        //окна приложения и идет далее по вложенным элементам, пока не достигнет элемента, вызвавшего это событие

        public static readonly RoutedEvent TappEvent = EventManager.RegisterRoutedEvent(
            "Tapp", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(MyUserControl1));

        public event RoutedEventHandler Tapp
        {
            add => AddHandler(TappEvent, value);
            remove => RemoveHandler(TappEvent, value);
        }

        // This method raises the Tap event
        void RaiseTapEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MyUserControl2.TappEvent);
            RaiseEvent(newEventArgs);
        }
        protected override void OnClick()
        {
            RaiseTapEvent();
        }


    }
}