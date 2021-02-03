using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Chart_GettingStarted
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
    }
    public class ViewModel
    {
        public List<Person> Data { get; set; }
        public ViewModel()
        {
            Data = new List<Person>()
            {
                new Person("David", 180),
                new Person("Micheal", 170),
                new Person("Steve", 160),
                new Person("Joel", 182)
            };
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public double Height { get; set; }

        public Person(string name, double height)
        {
            this.Name = name;
            this.Height = height;
        }
    }
}
