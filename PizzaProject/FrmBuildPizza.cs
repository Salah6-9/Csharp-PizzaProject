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
    public partial class FrmBuildPizza : Form
    {
        private readonly Image imgPizza = Properties.Resources.PizzaBase;
        private readonly Image imgCheese = Properties.Resources.cheese;
        private readonly Image imgTomato = Properties.Resources.Tomato;
        private readonly Image imgOlive = Properties.Resources.Olive;
        private readonly Image imgMushroom = Properties.Resources.mushroom;
        private readonly Image imgOnion = Properties.Resources.onion;
        private readonly Image imgGreenPepper = Properties.Resources.green_pepper;
        public FrmBuildPizza()
        {
            InitializeComponent();
            cheesePieces = new PictureBox[]
            {
                pictureBox1,
                pictureBox2,
                pictureBox3,
                pictureBox4,
                pictureBox5,
                pictureBox6,
                pictureBox7,
                pictureBox8,
                pictureBox9,
                pictureBox10,
                pictureBox11,
                pictureBox12
            };

            TomatoPieces = new PictureBox[]
            {
                pictureBox13,
                pictureBox14,
                pictureBox15,
                pictureBox16,
                pictureBox17,
                pictureBox18,
                pictureBox19,

            };
            OlivePieces = new PictureBox[]
            {
                pictureBox20,
                pictureBox21,
                pictureBox22,
                pictureBox23
            };

            MushroomPieces = new PictureBox[]
            {
                pictureBox24,
                pictureBox25,
                pictureBox26,
                pictureBox27
            };

            OnionPieces = new PictureBox[]
            {
                pictureBox28,
                pictureBox29,
                pictureBox30,
                pictureBox31
            };

            GreenPepperPieces = new PictureBox[]
            {
                pictureBox32,
                pictureBox33,
                pictureBox34,
                pictureBox35
            };

            lblToppingsSummary = new Label[]
            {
                lblTopping01,
                lblTopping02,
                lblTopping03,
                lblTopping04,
                lblTopping05,
                lblTopping06,
                lblTopping07,
                lblTopping08

            };


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

        private clsPrices Prices = new clsPrices();
        private float TotalPrice;





        private void FrmBuildPizza_Load(object sender, EventArgs e)
        {

            foreach (Label label in lblToppingsSummary)
                label.Visible = false;

            foreach (var arr in new[] { cheesePieces, TomatoPieces, OlivePieces,
                            MushroomPieces, OnionPieces, GreenPepperPieces })
                foreach (var pb in arr) pb.Visible = false;

            UpdateLabelTotalPrice();
            lblTopping07.Visible = true;
            lblTopping07.Text = "Size: Medium         $" + Prices.Medium.ToString("0.00");
            lblTopping08.Text = "Crust: Thin         $" + Prices.Thin.ToString("0.00");
            lblTopping08.Visible = true;


        }
        private void UpdateLabelTotalPrice()
        {
            TotalPrice = CalculateTotalPrice();
            lblTotalPrice.Text = "Total Price: $" + TotalPrice.ToString("0.00");
        }

        private float CalculateTotalPrice()
        {
            float total = 0;


            if (rbSmall.Checked) total += Prices.Small;
            else if (rbMedium.Checked) total += Prices.Medium;
            else if (rbLarge.Checked) total += Prices.Large;

            if (rbThin.Checked) total += Prices.Thin;
            else if (rbThick.Checked) total += Prices.Thick;

            if (chekCheese.Checked) total += Prices.Cheese;
            if (chekTomato.Checked) total += Prices.Tomato;
            if (chekOlive.Checked) total += Prices.Olive;
            if (chekMushroom.Checked) total += Prices.Mushrooms;
            if (chekOnion.Checked) total += Prices.Onion;
            if (chekGreenPepper.Checked) total += Prices.GreenPepper;

            return total;
        }
        // Print Toppings on the pizza canvas
        private void pnlPizzaCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;

            g.PixelOffsetMode =
                System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            Rectangle pizzaRect = GetPizzaRectangle();
            DrawPizza(g, pizzaRect);


        }


        private Rectangle GetPizzaRectangle()
        {
            Image pizza = imgPizza;

            float scale = Math.Min(
                (float)pnlPizzaCanvas.ClientSize.Width / pizza.Width,
                (float)pnlPizzaCanvas.ClientSize.Height / pizza.Height
            );

            int width = (int)(pizza.Width * scale);
            int height = (int)(pizza.Height * scale);

            int x = (pnlPizzaCanvas.ClientSize.Width - width) / 2;
            int y = (pnlPizzaCanvas.ClientSize.Height - height) / 2;

            return new Rectangle(x, y, width, height);
        }
        private void DrawPizza(Graphics g, Rectangle pizzaRect)
        {
            g.DrawImage(imgPizza, pizzaRect);

            if (chekCheese.Checked) DrawTopping(g, imgCheese, cheesePieces, pizzaRect);
            if (chekTomato.Checked) DrawTopping(g, imgTomato, TomatoPieces, pizzaRect);
            if (chekOlive.Checked) DrawTopping(g, imgOlive, OlivePieces, pizzaRect);
            if (chekMushroom.Checked) DrawTopping(g, imgMushroom, MushroomPieces, pizzaRect);
            if (chekOnion.Checked) DrawTopping(g, imgOnion, OnionPieces, pizzaRect);
            if (chekGreenPepper.Checked) DrawTopping(g, imgGreenPepper, GreenPepperPieces, pizzaRect);
        }

        private void DrawTopping(Graphics g, Image topping,
    PictureBox[] pictureBoxes, Rectangle pizzaRect)
        {
            float toppingSize = pizzaRect.Width * 0.22f;

            foreach (PictureBox pb in pictureBoxes)
            {
                g.DrawImage(topping, new RectangleF(pb.Left, pb.Top, toppingSize, toppingSize));
            }
        }
        // Cheese 
        private PictureBox[] cheesePieces;
        private void chekCheese_CheckedChanged(object sender, EventArgs e)
        {
            ToppingsCalcPrice();
            lblTopping02.Visible = chekCheese.Checked;


            pnlPizzaCanvas.Invalidate();
        }

        //Tomato
        private PictureBox[] TomatoPieces;
        private void chekTomato_CheckedChanged(object sender, EventArgs e)
        {
            lblTopping01.Visible = chekTomato.Checked;
            ToppingsCalcPrice();

            pnlPizzaCanvas.Invalidate();
        }


        //Olive
        private PictureBox[] OlivePieces;

        private void chekOlive_CheckedChanged(object sender, EventArgs e)
        {
            lblTopping04.Visible = chekOlive.Checked;
            ToppingsCalcPrice();


            pnlPizzaCanvas.Invalidate();
        }

        // MUSHROOM

        private PictureBox[] MushroomPieces;

        private void chekMushroom_CheckedChanged(object sender, EventArgs e)
        {
            lblTopping03.Visible = chekMushroom.Checked;
            ToppingsCalcPrice();



            pnlPizzaCanvas.Invalidate();
        }

        // Onion
        private PictureBox[] OnionPieces;

        private void chekOnion_CheckedChanged(object sender, EventArgs e)
        {
            lblTopping05.Visible = chekOnion.Checked;
            ToppingsCalcPrice();


            pnlPizzaCanvas.Invalidate();
        }

        // Green Pepper

        private PictureBox[] GreenPepperPieces;
        private void chekGreenPepper_CheckedChanged(object sender, EventArgs e)
        {
            lblTopping06.Visible = chekGreenPepper.Checked;
            ToppingsCalcPrice();






            pnlPizzaCanvas.Invalidate();
        }

        // fix radio issue
        private void SizeCalcPrice(string Text, bool IsChecked)
        {
            if (IsChecked) lblSizeDet.Text = Text;
            UpdateLabelTotalPrice();
        }
        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSmall.Checked)
            {
                rbMedium.Checked = false;
                rbLarge.Checked = false;

            }
            lblTopping07.Visible = rbSmall.Checked;
            lblTopping07.Text = "Size: Small         $" + Prices.Small.ToString("0.00");
            SizeCalcPrice("Size: Small", rbSmall.Checked);


        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMedium.Checked)
            {
                rbSmall.Checked = false;
                rbLarge.Checked = false;
            }
            lblTopping07.Visible = rbMedium.Checked;
            lblTopping07.Text = "Size: Medium         $" + Prices.Medium.ToString("0.00");
            SizeCalcPrice("Size: Medium", rbMedium.Checked);


        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLarge.Checked)
            {
                rbSmall.Checked = false;
                rbMedium.Checked = false;
            }
            lblTopping07.Visible = rbLarge.Checked;
            lblTopping07.Text = "Size: Large            $" + Prices.Large.ToString("0.00");
            SizeCalcPrice("Size: Large", rbLarge.Checked);
        }

        private void CrustClacPrice(string Text, bool IsChecked)
        {
            if (IsChecked) lblCrustDet.Text = Text;
            UpdateLabelTotalPrice();
        }

        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbThin.Checked)
            {
                rbThick.Checked = false;
            }
            lblTopping08.Text = "Crust: Thin         $" + Prices.Thin.ToString("0.00");
            lblTopping08.Visible = rbThin.Checked;

            CrustClacPrice("Crust: Thin", rbThin.Checked);
        }


        private void rbThik_CheckedChanged(object sender, EventArgs e)
        {
            if (rbThick.Checked)
            {
                rbThin.Checked = false;
            }
            lblTopping08.Text = "Crust: Thick         $" + Prices.Thick.ToString("0.00");
            lblTopping08.Visible = rbThick.Checked;
            CrustClacPrice("Crust: Thick", rbThick.Checked);
        }


        private void ToppingsCalcPrice()
        {
            int count = 0;
            if (chekCheese.Checked) count++;
            if (chekTomato.Checked) count++;
            if (chekOlive.Checked) count++;
            if (chekMushroom.Checked) count++;
            if (chekOnion.Checked) count++;
            if (chekGreenPepper.Checked) count++;

            lblToppingsDet.Text = "Toppings: " + count;
            UpdateLabelTotalPrice();
        }

        // summary

        private Label[] lblToppingsSummary;

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form frm = new FrmTableOfMenu();
            frm.Show();
            this.Close();
        }

        private void pbTomato_Click(object sender, EventArgs e)
        {

            chekTomato.Checked = !chekTomato.Checked;

        }

        private void pbChees_Click(object sender, EventArgs e)
        {
            chekCheese.Checked = !chekCheese.Checked;

        }

        private void pbMushroom_Click(object sender, EventArgs e)
        {
            chekMushroom.Checked = !chekMushroom.Checked;
        }

        private void pbOlive_Click(object sender, EventArgs e)
        {
            chekOlive.Checked = !chekOlive.Checked;
        }

        private void pbOnion_Click(object sender, EventArgs e)
        {
            chekOnion.Checked = !chekOnion.Checked;
        }

        private void pbPapper_Click(object sender, EventArgs e)
        {
            chekGreenPepper.Checked = !chekGreenPepper.Checked;
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            PizzaOrder PizzaOrder = new PizzaOrder();
            PizzaOrder.Tomato = chekTomato.Checked;
            PizzaOrder.Cheese = chekCheese.Checked;
            PizzaOrder.Olive = chekOlive.Checked;
            PizzaOrder.Mushroom = chekMushroom.Checked;
            PizzaOrder.Onion = chekOnion.Checked;
            PizzaOrder.GreenPepper = chekGreenPepper.Checked;

            PizzaOrder.Totalprice = TotalPrice;

            if (rbSmall.Checked)
            {
                PizzaOrder.Size = "Small";
            }
            else if (rbMedium.Checked)
            {
                PizzaOrder.Size = "Medium";
            }
            else if (rbLarge.Checked)
            {
                PizzaOrder.Size = "Large";
            }

            if (rbThin.Checked)
            {
                PizzaOrder.Crust = "Thin";
            }
            else if (rbThick.Checked)
            {
                PizzaOrder.Crust = "Thick";
            }
            Bitmap pizzaImage = CreatePizzaImage();
            FrmOrder frmOrder = new FrmOrder(PizzaOrder, pizzaImage, Prices);
            frmOrder.Show();
            this.Close();
        }

        private Bitmap CreatePizzaImage()
        {
            Rectangle pizzaRect = GetPizzaRectangle();

            Bitmap bitmap = new Bitmap(
                pizzaRect.Width,
                pizzaRect.Height,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb
            );

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // نفس إعدادات الجودة
                g.SmoothingMode =
                    System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                g.InterpolationMode =
                    System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;

                g.PixelOffsetMode =
                    System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                // خلفية شفافة
                g.Clear(Color.Transparent);

                // تحويل إحداثيات الـPanel إلى إحداثيات الـBitmap
                g.TranslateTransform(
                    -pizzaRect.X,
                    -pizzaRect.Y
                );

                // dRAW PIZZA AND tOPPINGS
                DrawPizza(g, pizzaRect);
            }

            return bitmap;
        }

        private void pbPizzaSmall_Click(object sender, EventArgs e)
        {
            rbSmall.Checked = true;
        }

        private void pbPizzaMedium_Click(object sender, EventArgs e)
        {
            rbMedium.Checked = true;

        }

        private void pbPizzaLarge_Click(object sender, EventArgs e)
        {
            rbLarge.Checked = true;

        }
    }
}


