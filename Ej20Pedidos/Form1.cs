using System.Diagnostics;
using System.Windows.Forms;

namespace Ej20Pedidos
{
    public partial class Form1 : Form
    {
       
        
     
    
        public Form1()
        {
            InitializeComponent();
            
        }

       




         private void radioButtonOptions_CheckedChanged(object sender, EventArgs e)
         {
             if (radioButtonOptions.Checked == true)
             {
                 Plus1.Visible = true;
                 Plus2.Visible = true;
                 Plus3.Visible = true;
                 Plus4.Visible = true;
                 Plus5.Visible = true;
                 Plus6.Visible = true;
                 Plus7.Visible = true;
                 Plus8.Visible = true;
                 minus1.Visible= true;
                 minus2.Visible= true;
                 minus3.Visible= true;
                 minus4.Visible= true;
                 minus5.Visible= true;
                 minus6.Visible= true;
                 minus7.Visible= true;
                 minus8.Visible= true;

             }
             else
             {
                 Plus1.Visible = false;
                 Plus2.Visible = false;
                 Plus3.Visible = false;
                 Plus4.Visible = false;
                 Plus5.Visible = false;
                 Plus6.Visible = false;
                 Plus7.Visible = false;
                 Plus8.Visible = false;
                 minus1.Visible = false;
                 minus2.Visible = false;
                 minus3.Visible = false;
                 minus4.Visible = false;
                 minus5.Visible = false;
                 minus6.Visible = false;
                 minus7.Visible = false;
                 minus8.Visible = false;

             }
         }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Plus9.Enabled = true;
                minus9.Enabled = true;
            }
            else
            {
                Plus9.Enabled = false;
                minus9.Enabled = false;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                Plus10.Enabled = true;
                minus10.Enabled = true;
            }
            else
            {
                Plus10.Enabled = false;
                minus10.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                Plus11.Enabled = true;
                minus11.Enabled = true;
            }
            else
            {
                Plus11.Enabled = false;
                minus11.Enabled = false;
            }
        }
        private void IncrementarValorMaskedTextBox(MaskedTextBox textBox,double precio)
        {


            try
            {
                double valorActual = double.Parse(textBox.Text);
                if (valorActual < 5)
                {
                    double nuevoValor = valorActual + 1;
                    textBox.Text = nuevoValor.ToString();
                    CalcularPrecioTotal();
                }
            }
            catch (FormatException)
            {
                textBox.Text = "1";
                CalcularPrecioTotal();
            }
        }
        private void DecrementarValorMaskedTextBox(MaskedTextBox textBox, double precio)
        {


            try
            {
                double valorActual = double.Parse(textBox.Text);
                if (valorActual > 0)
                {
                    double nuevoValor = valorActual - 1;
                    textBox.Text = nuevoValor.ToString();
                    CalcularPrecioTotal();
                }
            }
            catch (FormatException)
            {
                textBox.Text = "0";
                CalcularPrecioTotal();
            }
        }
        
            private decimal CalcularPrecioTotal()
            {
                decimal precioTotal = 0;

                
                Dictionary<MaskedTextBox, decimal> precios = new Dictionary<MaskedTextBox, decimal>
    {
        { maskedTextBoxBurger, 4.50m },
        { maskedTextBoxChips, 1.00m },
        { maskedTextBoxSoda, 1.50m },
        { maskedTextBoxPizza, 8.50m },
        { maskedTextBoxNuggets, 4.80m },
        { maskedTextBoxSalad, 4.20m },
        { maskedTextBoxYogurt, 0.80m },
        { maskedTextBoxWater, 1.00m }
        
       
    };

               
                foreach (var pair in precios)
                {
                    MaskedTextBox maskedTextBox = pair.Key;
                    decimal precio = pair.Value;
                    decimal valor = 0;

                    if (decimal.TryParse(maskedTextBox.Text, out valor))
                    {
                        precioTotal += valor * precio;
                    }
                }

               
                TextBoxTotalPay.Text = precioTotal.ToString();

                return precioTotal;
            }



        private void CalcularIVA(decimal precioTotal, out decimal precioSinIVA, out decimal iva)
        {
            const decimal porcentajeIVA = 0.21m;

            precioSinIVA = precioTotal / (1 + porcentajeIVA);
            iva = precioTotal - precioSinIVA;
        }


      


private void maskedTextBox4_TextChanged(object sender, EventArgs e)
        {
        
            decimal nuevoPrecioTotal;
            if (decimal.TryParse(TextBoxTotalPay.Text, out nuevoPrecioTotal))
            {
                
                decimal precioSinIVA, iva;
                CalcularIVA(nuevoPrecioTotal, out precioSinIVA, out iva);
                TextBoxSubTotal.Text = precioSinIVA.ToString("N2");
                TextBoxIva.Text = iva.ToString("N2");
                
                ;
            }
        }











        private void Plus9_Click(object sender, EventArgs e)
        {
            IncrementarValorMaskedTextBox(maskedTextBoxBurger,4.50);
            IncrementarValorMaskedTextBox(maskedTextBoxChips,1.00);
            IncrementarValorMaskedTextBox(maskedTextBoxSoda, 1.50);

        }
       
        private void minus9_Click(object sender, EventArgs e)
        {
            DecrementarValorMaskedTextBox(maskedTextBoxBurger, 4.50);
            DecrementarValorMaskedTextBox(maskedTextBoxChips, 1.00);
            DecrementarValorMaskedTextBox(maskedTextBoxSoda, 1.50);
        }

        private void Plus10_Click(object sender, EventArgs e)
        {
            IncrementarValorMaskedTextBox(maskedTextBoxPizza, 8.50);
            IncrementarValorMaskedTextBox(maskedTextBoxNuggets, 4.80);
            IncrementarValorMaskedTextBox(maskedTextBoxSoda, 1.50);
        }

        private void minus10_Click(object sender, EventArgs e)
        {
            DecrementarValorMaskedTextBox(maskedTextBoxPizza, 8.50);
            DecrementarValorMaskedTextBox(maskedTextBoxNuggets, 4.80);
            DecrementarValorMaskedTextBox(maskedTextBoxSoda, 1.50);
        }

        private void Plus11_Click(object sender, EventArgs e)
        {
            IncrementarValorMaskedTextBox(maskedTextBoxSalad, 4.20);
            IncrementarValorMaskedTextBox(maskedTextBoxYogurt, 0.80);
            IncrementarValorMaskedTextBox(maskedTextBoxWater, 1.00);
        }

        private void minus11_Click(object sender, EventArgs e)
        {
            DecrementarValorMaskedTextBox(maskedTextBoxSalad, 4.20);
            DecrementarValorMaskedTextBox(maskedTextBoxYogurt, 0.80);
            DecrementarValorMaskedTextBox(maskedTextBoxWater, 1.00);
        }

        private void Plus1_Click(object sender, EventArgs e)
        {
            IncrementarValorMaskedTextBox(maskedTextBoxBurger, 4.50);
        }

      

        private void minus1_Click(object sender, EventArgs e)
        {
            DecrementarValorMaskedTextBox(maskedTextBoxBurger, 4.50);
        }

        private void Plus2_Click(object sender, EventArgs e)
        {
            IncrementarValorMaskedTextBox(maskedTextBoxChips, 1.00);
        }

        private void minus2_Click(object sender, EventArgs e)
        {
            DecrementarValorMaskedTextBox(maskedTextBoxChips, 1.00);
        }

        private void Plus3_Click(object sender, EventArgs e)
        {
            IncrementarValorMaskedTextBox(maskedTextBoxSoda, 1.50);
        }

        private void minus3_Click(object sender, EventArgs e)
        {
            DecrementarValorMaskedTextBox(maskedTextBoxSoda, 1.50);
        }

        private void Plus4_Click(object sender, EventArgs e)
        {
            IncrementarValorMaskedTextBox(maskedTextBoxPizza, 8.50);
        }

        private void minus4_Click(object sender, EventArgs e)
        {
            DecrementarValorMaskedTextBox(maskedTextBoxPizza, 8.50);
        }

        private void Plus5_Click(object sender, EventArgs e)
        {
            IncrementarValorMaskedTextBox(maskedTextBoxNuggets, 4.80);
        }

        private void minus5_Click(object sender, EventArgs e)
        {
            DecrementarValorMaskedTextBox(maskedTextBoxNuggets, 4.80);
        }

        private void Plus6_Click(object sender, EventArgs e)
        {
            IncrementarValorMaskedTextBox(maskedTextBoxSalad, 4.20);
        }

        private void minus6_Click(object sender, EventArgs e)
        {
            DecrementarValorMaskedTextBox(maskedTextBoxSalad, 4.20);
        }

        private void Plus7_Click(object sender, EventArgs e)
        {
            IncrementarValorMaskedTextBox(maskedTextBoxYogurt, 0.80);
        }

        private void minus7_Click(object sender, EventArgs e)
        {
            DecrementarValorMaskedTextBox(maskedTextBoxYogurt, 0.80);
        }

        private void Plus8_Click(object sender, EventArgs e)
        {
            IncrementarValorMaskedTextBox(maskedTextBoxWater, 1.00);
        }

        private void minus8_Click(object sender, EventArgs e)
        {
            DecrementarValorMaskedTextBox(maskedTextBoxWater, 1.00);
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxPostalcod.Text))
            {
                MessageBox.Show("Por favor, ingrese el código postal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBoxPostalcod.Focus();
            }
            else
            {
                decimal valor1, valor2;

                if (decimal.TryParse(TextBoxTotalPay.Text, out valor1) && decimal.TryParse(TextBoxpaymant.Text, out valor2))
                {
                    decimal suma = valor2 - valor1;
                    
                    TextBoxChange.Text = suma.ToString();
                }
                else
                {
                    
                    TextBoxChange.Text = "Error en la entrada de datos";
                }
            }
          
        }
        private void ResetValues()
        {
            maskedTextBoxBurger.Text = "0";
            maskedTextBoxChips.Text = "0";
            maskedTextBoxSoda.Text = "0";
            maskedTextBoxPizza.Text = "0";
            maskedTextBoxNuggets.Text = "0"; 
            maskedTextBoxSalad.Text = "0";
            maskedTextBoxYogurt.Text = "0";
            maskedTextBoxWater.Text = "0";
            TextBoxChange.Text= "0";
            TextBoxpaymant.Text = "0";
            TextBoxPostalcod.Text = "";
            CalcularPrecioTotal();
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea salir?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                
                Application.Exit();
            }
            else
            {
              
            }
        }

        private void buttonNewOder_Click(object sender, EventArgs e)
        {
            ResetValues();
        }
    }
}