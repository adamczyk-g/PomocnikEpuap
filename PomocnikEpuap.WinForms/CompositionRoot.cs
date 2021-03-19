using System;
using System.Collections.Generic;
using System.Text;
using PomocnikEpuap.WinForms.View;
using PomocnikEpuap.WinForms.Presenter;

namespace PomocnikEpuap.WinForms
{
    public class CompositionRoot
    {

        public void Compose()
        {
            MainView = new MainForm();

            MainPresenter mainPresenter = new MainPresenter(MainView);
        }

        public MainForm MainView { get; private set; }
    }
}
