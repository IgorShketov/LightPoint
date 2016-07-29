using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace xamarinHomework
{
    [Activity(Label = "xamarinHomework", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        static Stack<View> elements = new Stack<View>();
        static int contentCounter = 1;
        static LinearLayout contentLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button addButton = FindViewById<Button>(Resource.Id.button1);
            Button deleteButton = FindViewById<Button>(Resource.Id.button2);

            contentLayout = FindViewById<LinearLayout>(Resource.Id.contentLayout);

            if(elements.Count > 0)
            {
                foreach (var item in elements)
                {
                    contentLayout.AddView(item);
                }
            }

            addButton.Click += delegate
            {
                Button btn = new Button(this);
                btn.Text = "Button " + contentCounter.ToString();
                btn.Id = contentCounter++;
                
                elements.Push(btn);
                
                contentLayout.AddView(btn);
            };

            deleteButton.Click += delegate
            {
                if (elements.Count > 0)
                {
                    contentLayout.RemoveView(elements.Pop());
                }
            };
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            contentLayout.RemoveAllViews();
        }
    }
}

