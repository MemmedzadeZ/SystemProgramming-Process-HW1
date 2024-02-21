using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using SystemProgramming_Process_HW1.Classes;

namespace SystemProgramming_Process_HW1;


public partial class MainWindow : Window
{
   
    public List<Proces>? Proces { get; set; }
    public List<string> BList { get; set; }

    public MainWindow()
    {
        InitializeComponent();
        Proces = new List<Proces>();
        foreach (var item in Process.GetProcesses())
        {
            Proces proces = new Proces();
            proces.Id= item.Id;
            proces.Name = item.ProcessName;
            proces.MachineName= item.MachineName;
            Proces.Add(proces);
        }
        BList = new List<string>();
        DataContext = this;
    }

    private void Button_Click(object sender, RoutedEventArgs e)//Create Proccess
    {
        if(textBox.Text.Length != 0) 
        {
            int choice = 0;
            try
            {
                if (choice == 0)
                {
                    Process.Start(textBox.Text);
                    textBox.Text = null;

                }

                foreach (var item in BList)
                {
                    if(item == textBox.Text)
                    {
                        MessageBox.Show("Bloke List-de process movcuddur.");
                        textBox.Text = null;
                        choice++;
                        break;
                    }

                }

                
            }
            catch (Exception )
            {

                MessageBox.Show("Zehmer olmasa proces daxil edin.");

                throw;
            }
        
        
        }
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)//Add Black Proccess
    {
        if(textBox.Text.Length != 0)
        {
            int choice = 0;
            foreach (var item in BList)
            {

                if(textBox.Text != item)
                {
                    choice++;
                    break;
                }

            }
            if(choice == BList.Count())
            {

                BList.Add(textBox.Text);
                MessageBox.Show("Ish dogru formada yerine yetirildi.");
                textBox.Text = null;

            }
            else
            {
                MessageBox.Show("Process Block Listde artiq var.");
                textBox.Text = null;

            }

        }

        else
        {
            MessageBox.Show("Zehmer olmasa proces daxil edin.");

          
        }
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)//End Proccess
    {
        Proces? proces = listviewitem.SelectedItem as Proces;

        if(proces != null)
        {
            foreach (var item in Process.GetProcesses())
            {
                if(item.ProcessName == proces.Name)
                {
                    item.Kill();
                    textBox.Text = null;
                }
            }
        }
        else
        {
            MessageBox.Show("Zehmer olmasa proces daxil edin.");


        }
    }
}
