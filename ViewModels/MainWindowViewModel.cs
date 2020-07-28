using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Reactive;
using System.Collections.ObjectModel;
using ConwayCore;
using Avalonia.Controls;

namespace ProjectConwayUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<string> Items { get; }

        public ReactiveCommand<Unit, Unit> AddItemsCmd { get; }

        public Image BGImage { get; }// background image of each tile
        

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<string>(GenerateItems(1));
            AddItemsCmd = ReactiveCommand.Create(() => PushItem("This is a test item to showcase the ConwayCore -> ConwayUI_Avalonia bridge Hello from the console realm :)"));
        }

        public void AddItems(int count = 10)
        {
            GenerateItems(count).ForEach(item => Items.Add(item));
            Items.Add("Last Item from this Addition");
        }
        public void PushItem(string item)//seperate alias for ConwayCore link
        {
            Items.Add(item);

        }

        private List<string> GenerateItems(int count)
        {
            var list = new List<string>(count);
            for (int i = 0; i < count; i++)
            {
                list.Add($"New String @{++Counter}");
            }

            return list;
        }

        private int Counter { get; set; }
    }
}
