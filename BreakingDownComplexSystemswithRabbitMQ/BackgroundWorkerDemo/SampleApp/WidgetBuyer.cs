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

        private void BuyWidgets_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(Quantity.Text);
            _orderSender.SendOrder(quantity);
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
            for (int i = 0; i < 20; i++)
            {
                _orderSender.SendOrder(1);
                _orderSender.SendOrder(10);
            }
        }
    }
}
