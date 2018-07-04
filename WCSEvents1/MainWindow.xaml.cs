using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Net.Mail;
using WCSEvents1.Models;
using System.Reflection;

namespace WCSEvents1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();



        }
        // Check if provided Email address is valid
        public void IsValidEmail()
        {
            try
            {
                MailAddress mail = new MailAddress(Email.Text);
                Email.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                return;

            }
            catch (Exception)
            {
                Email.Background = new SolidColorBrush(Color.FromArgb(50, 255, 0, 0));
                return;
            }
        }

        // Check if provided WSDC Number is Integer type
        public void IsValidWSDCNumber(TextChangedEventArgs e)
        {
            TextBox box = null;
            box = e.Source as TextBox;
            try
            {
                int number = Int32.Parse(box.Text);
                ChangeBackgroundColor(box, 255, 255, 255);
                return;
            }
            catch (Exception)
            {
                ChangeBackgroundColor(box, 50, 255, 0, 0);
                return;
            }
        }

        // Change background color for element
        private void ChangeBackgroundColor(TextBox box, byte r, byte g, byte b)
        {
            box.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }
        private void ChangeBackgroundColor(TextBox box, byte a, byte r, byte g, byte b)
        {
            box.Background = new SolidColorBrush(Color.FromArgb(a, r, g, b));
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Participant p = new Participant();
            try
            {
                p.FirstName = FirstName.Text;
                p.LastName = LastName.Text;
                p.WsdcNumber = Int32.Parse(WsdcNumber.Text);
                p.Email = Email.Text;
                p.CompLevel = CompLvl.Text;
                p.CompRole = CompRole.Text;
                p.WorkshopLevel = WorkshopLvl.Text;
                p.WorkshopRole = WorkshopRole.Text;

                using (WCSEventsEntities db = new WCSEventsEntities())
                {
                    var participants = from par in db.Participant
                                       where par.WsdcNumber == p.WsdcNumber
                                       select par;
                    // Add new
                    if (participants.Any() == false)
                    {
                        db.Participant.Add(p);
                        MessageBox.Show("Registration complete. ADDED new participant");
                    }
                    // Update
                    else
                    {
                        foreach (var item in participants)
                        {
                            if (item.WsdcNumber == p.WsdcNumber)
                            {
                                MessageBox.Show("WSDC Number already in system. Updating existing one!");

                                PropertyInfo[] info = p.GetType().GetProperties();
                                Participant dbParticipant = db.Participant.Find(item.ParticipantID);

                                foreach (var item2 in info)
                                {
                                    var x = dbParticipant.GetType().GetProperty(item2.Name);
                                    if (x.Name == "ParticipantID")
                                    {
                                        continue;
                                    }
                                    else if (dbParticipant.GetType().GetProperty(item2.Name) != null)
                                    {
                                        dbParticipant.GetType().GetProperty(item2.Name).SetValue(dbParticipant, item2.GetValue(p));
                                    }
                                }
                            }
                        }
                    }
                    // Send registration from data to database
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("End of Register Button Method ERROR", ex.ToString());
            }
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValidEmail();
        }

        private void WsdcNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValidWSDCNumber(e);
        }

        private void JnJCompRegisterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void JnJWsdcNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValidWSDCNumber(e);
        }
        private void GetWsdcDataWithNumber()
        {
            // https://points.worldsdc.com/lookup/find?num=10612
        }
    }
}
