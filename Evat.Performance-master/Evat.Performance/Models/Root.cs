using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evat.Performance.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Company
    {
        public string COMPANY_TIN { get; set; }
        public string COMPANY_NAMES { get; set; }
        public string COMPANY_SECURITY_KEY { get; set; }
    }

    public class Header
    {
        public string CALCULATION_TYPE { get; set; }
        public string FLAG { get; set; }
        public string USER_NAME { get; set; }
        public string NUM { get; set; }
        public object REFUND_ID { get; set; }
        public string INVOICE_DATE { get; set; }
        public string CURRENCY { get; set; }
        public string EXCHANGE_RATE { get; set; }
        public string CLIENT_TIN { get; set; }
        public string CLIENT_TIN_PIN { get; set; }
        public string CLIENT_NAME { get; set; }
        public string TOTAL_VAT { get; set; }
        public string TOTAL_LEVY { get; set; }
        public string TOTAL_AMOUNT { get; set; }
        public string ITEMS_COUNTS { get; set; }
        public string FILE_NAME { get; set; }
        public string CALL_BACK { get; set; }
        public string SALE_TYPE { get; set; }
        public string VOUCHER_AMOUNT { get; set; }
        public string DISCOUNT_TYPE { get; set; }
        public string DISCOUNT_AMOUNT { get; set; }
    }

    public class ItemList
    {
        public string ITMREF { get; set; }
        public string ITMDES { get; set; }
        public string TAXRATE { get; set; }
        public string TAXCODE { get; set; }
        public string LEVY_AMOUNT_A { get; set; }
        public string LEVY_AMOUNT_B { get; set; }
        public string LEVY_AMOUNT_C { get; set; }
        public string LEVY_AMOUNT_D { get; set; }
        public string QUANTITY { get; set; }
        public string UNITYPRICE { get; set; }
        public string ITMDISCOUNT { get; set; }
        public string BATCH { get; set; }
        public string EXPIRE { get; set; }
        public string ITEM_CATEGORY { get; set; }
    }

    public class RootRequest
    {
        public Company company { get; set; }
        public Header header { get; set; }
        public List<ItemList> item_list { get; set; }
    }
     

    public class PersolRootResponse
    {
        public string status { get; set; }
        public string error { get; set; } 
        public string num { get; set; }
        public string ysdcid { get; set; }
        public string ysdcrecnum { get; set; }
        public string ysdcintdata { get; set; }
        public string ysdcregsig { get; set; }
        public string ysdcmrc { get; set; }
        public string ysdcmrctim { get; set; }
        public string ysdctime { get; set; }
        public string tin { get; set; }
        public string flag { get; set; }
        public string qr_url { get; set; }
        public string print_qr_url { get; set; }
        public string print_qr_url_idahishe { get; set; }
        public string ysdstatus { get; set; }
        public string ysdcitems { get; set; }
        public string signature { get; set; }
    }

}
