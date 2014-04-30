using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalculatorv1;

namespace UnitTestKalkulator
{
    /*
     * Setiap kelas unit test maka harus ada [TestClass] diatas class tersebut.
     * begitu juga dengan methodnya harus ada [TestMethod] diatas methodnya. 
     * jika tidak maka program tidak bisa membedakan mana yang unit test.
     */

    [TestClass]
    public class UnitTestKalkulator
    {
        #region TEST OPERASI

        /*
         * Test untuk Fungsi Add
         */ 
        [TestMethod]
        public void UTAddTest()
        {
            var test_object = new MainWindow();
            double expected = 9;
            double actual = test_object.Add(4, 5);
            Assert.AreEqual<double>(expected, actual, "Maaf masih salah");
        }

        /*
         * Test untuk Fungsi Substract
         */ 
        [TestMethod]
        public void UTSubstractTest()
        {
            var test_object = new MainWindow();
            double expected = -1;
            double actual = test_object.Substract(4, 5);
            Assert.AreEqual<double>(expected, actual, "Maaf masih salah");
        }

        /*
         * Test untuk Fungsi Multiply
         */ 
        [TestMethod]
        public void UTMultiplyTest()
        {
            var test_object = new MainWindow();
            double expected = 20;
            double actual = test_object.Multiply(4, 5);
            Assert.AreEqual<double>(expected, actual, "Maaf masih salah");
        }

        /*
         * Test untuk Fungsi Divide
         */ 
        [TestMethod]
        public void UTDivideTest()
        {
            var test_object = new MainWindow();
            double expected = 9;
            double actual = test_object.Divide(45, 5);
            Assert.AreEqual<double>(expected, actual, "Maaf masih salah");
        }

        #endregion

        #region TEST FUNGSI TOMBOL


        /*
         * Test jika klik tombol no 7 akan menghasilkan '7' ?
         */ 
        [TestMethod]
        public void UTButton_Click_1Test()
        {
            MainWindow window = new MainWindow();
            window.Show();
            WindowAutomationPeer windowPeer = new WindowAutomationPeer(window);
            List<AutomationPeer> children = windowPeer.GetChildren();

            ButtonAutomationPeer buttonPeer = (ButtonAutomationPeer)children[0];
            Button button = (Button)buttonPeer.Owner;
            RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent, button);
            button.RaiseEvent(args);
            Assert.AreEqual("7", button.Content.ToString(), button.Content.ToString());
        }

        /*
         * Test jika klik tombol = akan menghasilkan 2 ?
         * jika kondisi tb adalah "1+1"
         */ 
        [TestMethod]
        public void UTResult_clickTest()
        {
            string temp = "1+1";

            MainWindow window = new MainWindow();
            window.Show();
            WindowAutomationPeer windowPeer = new WindowAutomationPeer(window);
            List<AutomationPeer> children = windowPeer.GetChildren();

            TextBoxAutomationPeer textBoxPeer = (TextBoxAutomationPeer)children[1];
            ButtonAutomationPeer buttonPeer = (ButtonAutomationPeer)children[14];

            Button button = (Button)buttonPeer.Owner;
            TextBox tb = (TextBox)textBoxPeer.Owner;

            tb.Text = temp;

            RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent, button);
            button.RaiseEvent(args);

            Assert.AreEqual("1+1=2", tb.Text.ToString(), "GAGAGAGAL");
        }

        /*
         * Test jika klik tombol Del, maka tb akan ""  ?
         */ 
        [TestMethod]
        public void UTDel_ClickTest()
        {
            MainWindow window = new MainWindow();
            window.Show();
            WindowAutomationPeer windowPeer = new WindowAutomationPeer(window);
            List<AutomationPeer> children = windowPeer.GetChildren();

            TextBoxAutomationPeer textBoxPeer = (TextBoxAutomationPeer)children[1];
            ButtonAutomationPeer buttonPeer = (ButtonAutomationPeer)children[17];

            Button button = (Button)buttonPeer.Owner;
            TextBox tb = (TextBox)textBoxPeer.Owner;

            RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent, button);
            button.RaiseEvent(args);
            Assert.AreEqual("", tb.Text.ToString(), "GAgAL");
        }

        /*
        * Test jika klik tombol R, maka tb akan dihapus satu karakter terakhir  ?
        */
        [TestMethod]
        public void UTR_ClickTest()
        {
            MainWindow window = new MainWindow();
            window.Show();
            WindowAutomationPeer windowPeer = new WindowAutomationPeer(window);
            List<AutomationPeer> children = windowPeer.GetChildren();

            TextBoxAutomationPeer textBoxPeer = (TextBoxAutomationPeer)children[1];
            ButtonAutomationPeer buttonPeer = (ButtonAutomationPeer)children[18];

            Button button = (Button)buttonPeer.Owner;
            TextBox tb = (TextBox)textBoxPeer.Owner;

            
            RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent, button);
            button.RaiseEvent(args);

            int expected = 4;
            int actual = tb.Text.Length;

            Assert.AreEqual(expected, actual, "GAGALLLL");
        }

        #endregion
    }
}
