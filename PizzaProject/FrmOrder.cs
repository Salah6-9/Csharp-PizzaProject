using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaProject
{
    public partial class FrmOrder : Form
    {
        private PizzaOrder Order;
        private Bitmap PizzaImage;

        private clsPrices prices;
        public FrmOrder(PizzaOrder pizzaOrder, Bitmap pizzaImage, clsPrices Prices)
        {
            InitializeComponent();
            Order = pizzaOrder;
            PizzaImage = pizzaImage;
            prices = Prices;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED

                return cp;
            }
        }

        private void FrmOrder_Load(object sender, EventArgs e)
        {
            pbPizzaBase.Image = PizzaImage;
            lblTotalPrice.Text = "$" + Order.Totalprice.ToString("0.00");
            if (Order.Size == "Small")
            {
                lblBasePizza.Text = "Base Pizza Size: Small";
                lblBasePizzaPrice.Text = "$" + prices.Small.ToString("0.00");
            }
            else if (Order.Size == "Medium")
            {
                lblBasePizza.Text = "Base Pizza Size: Medium";
                lblBasePizzaPrice.Text = "$" + prices.Medium.ToString("0.00");
            }
            else if (Order.Size == "Large")
            {
                lblBasePizza.Text = "Base Pizza Size: Large";
                lblBasePizzaPrice.Text = "$" + prices.Large.ToString("0.00");

            }

            if (Order.Crust == "Thin")
            {
                lblCrust.Text = "Crust: Thin";
                lblCrustPrice.Text = "$" + prices.Thin.ToString("0.00");
            }
            else if (Order.Crust == "Thick")
            {
                lblCrust.Text = "Crust: Thick";
                lblCrustPrice.Text = "$" + prices.Thick.ToString("0.00");
            }

            if (Order.Tomato)
            {
                lblTomato.Font = new Font(lblTomato.Font, lblTomato.Font.Style & ~FontStyle.Strikeout);
                lblTomatoP.Text = "$" + prices.Tomato.ToString("0.00");
            }
            if (Order.Cheese)
            {
                lblCheese.Font = new Font(lblCheese.Font, lblCheese.Font.Style & ~FontStyle.Strikeout);

                lblCheeseP.Text = "$" + prices.Cheese.ToString("0.00");
            }
            if (Order.Olive)
            {
                lblOlive.Font = new Font(lblOlive.Font, lblOlive.Font.Style & ~FontStyle.Strikeout);

                lblOliveP.Text = "$" + prices.Olive.ToString("0.00");
            }
            if (Order.Mushroom)
            {
                lblMushroom.Font = new Font(lblMushroom.Font, lblMushroom.Font.Style & ~FontStyle.Strikeout);
                lblMushroomP.Text = "$" + prices.Mushrooms.ToString("0.00");
            }
            if (Order.Onion)
            {
                lblOnion.Font = new Font(lblOnion.Font, lblOnion.Font.Style & ~FontStyle.Strikeout);
                lblOnionP.Text = "$" + prices.Onion.ToString("0.00");
            }
            if (Order.GreenPepper)
            {
                lblGreenPepare.Font = new Font(lblGreenPepare.Font, lblGreenPepare.Font.Style & ~FontStyle.Strikeout);
                lblGreenPepareP.Text = "$" + prices.GreenPepper.ToString("0.00");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form Frm = new FrmBuildPizza();
            Frm.Show();
            this.Hide();
        }


    }
}
