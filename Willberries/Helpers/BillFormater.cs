using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willberries.Enities;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;

namespace Willberries.Helpers
{
    class BillFormater
    {
        public static void GenerateAndOpenBill(Order order, string pathToSave) 
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont bfont = new XFont("Veranda", 14, XFontStyle.Bold);
            XFont font = new XFont("Veranda", 14, XFontStyle.Regular);

            gfx.DrawString("WILLBERIES / ЧЕК ЗАКАЗА", bfont, XBrushes.Black, new XRect(20, 0, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("[+] Номер заказа: " + order.Id.ToString(), font, XBrushes.Black, new XRect(40, 20, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("[+] Дата: " + order.Date.ToShortDateString(), font, XBrushes.Black, new XRect(40, 40, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("[+] Товар: " + order.Product.Code + " " + order.Product.Title, font, XBrushes.Black, new XRect(40, 60, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("[+] Количество: " + order.Quantity, font, XBrushes.Black, new XRect(40, 80, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("[+] Розничная цена: " + order.Product.Price.ToString(), font, XBrushes.Black, new XRect(40, 100, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("[+] Способ доставки: " + order.Product.DeliveryMethod.Method, font, XBrushes.Black, new XRect(40, 120, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("[+] Стоимость доставки: " + order.Product.DeliveryMethod.Amount.ToString(), font, XBrushes.Black, new XRect(40, 140, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("К ОПЛАТЕ => " 
                + order.Product.Price.ToString() 
                + "*" 
                + order.Quantity.ToString() 
                + "+" + order.Product.DeliveryMethod.Amount.ToString()
                + "="
                + (order.Product.Price * order.Quantity + order.Product.DeliveryMethod.Amount).ToString(), bfont, XBrushes.Black, new XRect(20, 160, page.Width, page.Height), XStringFormats.TopLeft);

            document.Save(pathToSave);
            Process.Start(pathToSave);
        }
    }
}
