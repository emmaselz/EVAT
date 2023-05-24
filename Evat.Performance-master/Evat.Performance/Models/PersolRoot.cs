using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evat.Performance.Models
{

    public class Item
    {
        public string reference { get; set; }
        public string expire { get; set; }
        public string description { get; set; }
        public double quantity { get; set; }
        public double levyAmountA { get; set; }
        public double levyAmountB { get; set; }
        public double levyAmountC { get; set; }
        public double levyAmountD { get; set; }
        public double discount { get; set; }
        public string taxCode { get; set; }
        public string batch { get; set; }
        public string itemCategory { get; set; }
        public double unitPrice { get; set; }
        public double taxRate { get; set; }
    }


    public class PersolRootRequest
    {
        public string currency { get; set; }
        public double exchangeRate { get; set; }
        public string clientName { get; set; }
        public string invoiceNumber { get; set; }
        public double totalLevy { get; set; }
        public string userName { get; set; }
        public string flag { get; set; }
        public string clientTinPin { get; set; }
        public string companyTin { get; set; }
        public double totalVat { get; set; }
        public string fileName { get; set; }
        public string calculationType { get; set; }
        public string invoiceDate { get; set; }
        public string CallBack { get; set; }
        public string clientTin { get; set; }
        public int itemsCount { get; set; }
        public double totalAmount { get; set; }
        public double voucherAmount { get; set; }
        public string supplierTin { get; set; }
        public string supplierName { get; set; }
        public string purchaseDate { get; set; }
        public string saleType { get; set; }
        public string discountType { get; set; }
        public double discountAmount { get; set; }
        public string refundId { get; set; }
        public List<Item> items { get; set; }
    }
}
