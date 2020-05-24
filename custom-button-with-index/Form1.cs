using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomButton
{
    public partial class Form1 : Form
    {
        class MyIndexedButton : Button
        {
            readonly List<Button>_list;
            public MyIndexedButton(List<Button> list)
            {
                // This button adds itself to the list.
                list.Add(this);
                _list = list;   // Here we keep track of the list it's in.
            }
            protected override void OnClick(EventArgs e)
            {
                // Here the button handles its own click event. 
                // Note: You DON'T need to do a += to subscribe!
                base.OnClick(e);
                // Now, to show that it works, we'll have it look 
                // in the list and retrieve its own index using
                // a System class called Linq.
                MessageBox.Show(
                    "Clicked " + 
                    _list.IndexOf(this) // Using System.Linq to detect the index.
                    .ToString());
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        // We'll just make a little layout panel to manage the button positions.
        TableLayoutPanel _layout;   
        // Here's the list of Buttons you already had. We still need it.
        List<Button> _test = new List<Button> { };
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _layout = new TableLayoutPanel() { ColumnCount = 4, RowCount = 4, Dock = DockStyle.Fill };
            Controls.Add(_layout);
            int row, column;
            for (int count = 0; count < 12; count++)
            {
                row = count / 4; column = count % 4;
                // When you make your custom button, just 
                // make sure you pass in the list like so:
                _layout.Controls.Add(new MyIndexedButton(_test), column, row);
            } 
        }
    }
}
