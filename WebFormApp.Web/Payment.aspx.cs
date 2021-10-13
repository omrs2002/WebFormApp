using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormApp.Web
{
    public partial class Payment : System.Web.UI.Page
    {
        public Dictionary<string, string> formParameters
        {
            get
            {
                string culture = "ar-xn";
                string referenceID = "2030333";
                string amount = "1000";
                string uuid = Guid.NewGuid().ToString();
                string ipAddress = "10.20.205.144";

                string signedDate = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");

                Dictionary<string, string> _form = new Dictionary<string, string>();
                _form.Add("access_key", "b819a92692483be1a098d92893e7335a");
                _form.Add("profile_id", "AF6438DD-F6BD-4F88-A8D1-8A2B19B32EE9");

                _form.Add("merchant_defined_data1", "Bill Payments");
                //TODO change it depending on what is the accepted card, also note that currently the nic services have three options vs two options by cybersource (local/international vs mada/mada+local/international
                _form.Add("merchant_defined_data6", "Y");
                _form.Add("transaction_type", "sale");

                //fraud
                _form.Add("device_fingerprint_id", uuid);
                _form.Add("customer_ip_address", @ipAddress);

                //settings
                _form.Add("locale", culture);
                _form.Add("currency", "SAR");

                //transaction details
                _form.Add("reference_number", referenceID);
                _form.Add("amount", @amount);

                _form.Add("bill_to_address_country", "US");
                _form.Add("bill_to_address_line1", "1295 Charleston Rd");
                _form.Add("bill_to_address_city", "Mountain View");
                _form.Add("bill_to_address_postal_code", "94043");
                _form.Add("bill_to_address_state", "CA");

                //security
                _form.Add("transaction_uuid", uuid);
                _form.Add("unsigned_field_names", "");
                _form.Add("signed_date_time", signedDate);
                _form.Add("signed_field_names", "access_key,profile_id,transaction_uuid,signed_field_names,unsigned_field_names,signed_date_time,locale,transaction_type,reference_number,amount,bill_to_address_country,bill_to_address_line1,bill_to_address_city,bill_to_address_postal_code,bill_to_address_state,currency,device_fingerprint_id,customer_ip_address,merchant_defined_data1,merchant_defined_data6");
                var signature = Classes.Security.sign(_form);
                _form.Add("signature", signature);

                return _form;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}