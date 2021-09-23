using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace CryptCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.save_btc;
            textBox2.Text = Properties.Settings.Default.save_bch;
            textBox3.Text = Properties.Settings.Default.save_eth;
            textBox4.Text = Properties.Settings.Default.save_ltc;
            textBox5.Text = Properties.Settings.Default.save_zec;
            textBox6.Text = Properties.Settings.Default.save_neo;
            textBox7.Text = Properties.Settings.Default.save_btg;
        }

        public class CoinApi
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Symbol { get; set; }

            public string price_usd { get; set; }
            // ...
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            const string uri1 = @"https://api.coinmarketcap.com/v1/ticker/bitcoin/";
            var client = new WebClient();
            var content = client.DownloadString(uri1);
            var results = JsonConvert.DeserializeObject<List<CoinApi>>(content);
            label10.Text = results[0].price_usd.Replace(".", ","); // btc            

            const string uri2 = @"https://api.coinmarketcap.com/v1/ticker/bitcoin-cash/";
            var client2 = new WebClient();
            var content2 = client.DownloadString(uri2);
            var results2 = JsonConvert.DeserializeObject<List<CoinApi>>(content2);
            label11.Text = results2[0].price_usd.Replace(".", ","); // bch

            const string uri3 = @"https://api.coinmarketcap.com/v1/ticker/ethereum/";
            var client3 = new WebClient();
            var content3 = client.DownloadString(uri3);
            var results3 = JsonConvert.DeserializeObject<List<CoinApi>>(content3);
            label12.Text = results3[0].price_usd.Replace(".", ","); // eth

            const string uri4 = @"https://api.coinmarketcap.com/v1/ticker/litecoin/";
            var client4 = new WebClient();
            var content4 = client.DownloadString(uri4);
            var results4 = JsonConvert.DeserializeObject<List<CoinApi>>(content4);
            label13.Text = results4[0].price_usd.Replace(".", ","); // ltc

            const string uri5 = @"https://api.coinmarketcap.com/v1/ticker/zcash/";
            var client5 = new WebClient();
            var content5 = client.DownloadString(uri5);
            var results5 = JsonConvert.DeserializeObject<List<CoinApi>>(content5);
            label14.Text = results5[0].price_usd.Replace(".", ","); // zec

            const string uri6 = @"https://api.coinmarketcap.com/v1/ticker/neo/";
            var client6 = new WebClient();
            var content6 = client.DownloadString(uri6);
            var results6 = JsonConvert.DeserializeObject<List<CoinApi>>(content6);
            label15.Text = results6[0].price_usd.Replace(".", ","); // neo

            const string uri7 = @"https://api.coinmarketcap.com/v1/ticker/bitcoin-gold/";
            var client7 = new WebClient();
            var content7 = client.DownloadString(uri7);
            var results7 = JsonConvert.DeserializeObject<List<CoinApi>>(content7);
            label16.Text = results7[0].price_usd.Replace(".", ","); // btg

            //доллар
            WebClient web = new WebClient();
            string html = web.DownloadString("https://news.yandex.ru/quotes/1.html");
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var nodeCollection = doc.DocumentNode.SelectNodes("//td").Where(x => x.Attributes["class"].Value == "quote__value");

            if (doc != null)
            {
                foreach (var node in nodeCollection)
                {
                    var ss = node.InnerText; // тут значение
                    label21.Text = ss;
                    break;
                }
            }

            //расчеты
            double btc = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(label10.Text) * Convert.ToDouble(label21.Text);
            label22.Text = Convert.ToString(Math.Round(btc,2));

            double bch = Convert.ToDouble(textBox2.Text) * Convert.ToDouble(label11.Text) * Convert.ToDouble(label21.Text);
            label23.Text = Convert.ToString(Math.Round(bch,2));

            double eth = Convert.ToDouble(textBox3.Text) * Convert.ToDouble(label12.Text) * Convert.ToDouble(label21.Text);
            label24.Text = Convert.ToString(Math.Round(eth,2));

            double ltc = Convert.ToDouble(textBox4.Text) * Convert.ToDouble(label13.Text) * Convert.ToDouble(label21.Text);
            label25.Text = Convert.ToString(Math.Round(ltc,2));

            double zec = Convert.ToDouble(textBox5.Text) * Convert.ToDouble(label14.Text) * Convert.ToDouble(label21.Text);
            label26.Text = Convert.ToString(Math.Round(zec,2));

            double neo = Convert.ToDouble(textBox6.Text) * Convert.ToDouble(label15.Text) * Convert.ToDouble(label21.Text);
            label27.Text = Convert.ToString(Math.Round(neo,2));

            double btg = Convert.ToDouble(textBox7.Text) * Convert.ToDouble(label16.Text) * Convert.ToDouble(label21.Text);
            label28.Text = Convert.ToString(Math.Round(btg,2));

            double full_rub = btc + bch + eth + ltc + zec + neo + btg;
            label19.Text = Convert.ToString(Math.Round(full_rub,2));

            double usd = full_rub / Convert.ToDouble(label21.Text);
            label18.Text = Convert.ToString(Math.Round(usd, 2));            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.save_btc = textBox1.Text;
            Properties.Settings.Default.save_bch = textBox2.Text;
            Properties.Settings.Default.save_eth = textBox3.Text;
            Properties.Settings.Default.save_ltc = textBox4.Text;
            Properties.Settings.Default.save_zec = textBox5.Text;
            Properties.Settings.Default.save_neo = textBox6.Text;
            Properties.Settings.Default.save_btg = textBox7.Text;
            Properties.Settings.Default.Save();
        }        
    }
}
