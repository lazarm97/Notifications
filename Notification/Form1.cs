using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.EventArgs;

namespace Notification
{
    public partial class Form1 : Form
    {
        private static string connString = ConfigurationManager.ConnectionStrings["Conn"].ToString();
        private SqlTableDependency<Zaposleni> _dependency;

        public Form1()
        {
            InitializeComponent();
            var mapper = new ModelToTableMapper<Zaposleni>();
            mapper.AddMapping(c => c.Prezime, "Prezime");
            mapper.AddMapping(c => c.Ime, "Ime");
            _dependency = new SqlTableDependency<Zaposleni>(connString, "Zaposleni", mapper: mapper);
            _dependency.OnChanged += Changed;
            _dependency.Start();
        }

        public void Changed(object sender, RecordChangedEventArgs<Zaposleni> e)
        {
            var changedEntity = e.Entity;
            Invoke((MethodInvoker)delegate
            {
                var text = changedEntity.Ime.ToString() + " " + changedEntity.Prezime.ToString();
                this.ShowNotification(text);
            });
        }

        private void ShowNotification(string contentText)
        {

            Alert a1 = new Alert(contentText);
            a1.ShowDialog();
        }
    }
}
