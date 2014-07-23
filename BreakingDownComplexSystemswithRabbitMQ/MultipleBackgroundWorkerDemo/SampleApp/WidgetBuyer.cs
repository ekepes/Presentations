using System;
using System.Windows.Forms;

namespace SampleApp
{
    public partial class WidgetBuyer : Form
    {
        private readonly OrderSender _orderSender = new OrderSender();

        public WidgetBuyer()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                _orderSender.Dispose();
            }

            base.Dispose(disposing);
        }

        private void SendBatches_Click(object sender, EventArgs e)
        {
            _orderSender.SendBatches();
        }
    }
}
