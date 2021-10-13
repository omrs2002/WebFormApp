using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebFormApp.Web.Classes
{
    public static class Security
    {
        public static String sign(IDictionary<string, string> paramsArray)
        {
            String SECRET_KEY = "039f1fa63e64483287859ddec6774636448e74c7032641e0aac5254d243365c2cc147a2db5014916b1a9e70232cdd325f321a8b5b2ab494aab1723426a282260eb380e21799548d59b7221ed98e431cd1b5e2cf6886f48e7a7fedc89cbc74daf9a9221e5828d4810beb87caac85d49ee5a5733b3100944d882bf43b35c623955";
            return sign(buildDataToSign(paramsArray), SECRET_KEY);
        }

        private static String sign(String data, String secretKey)
        {
            UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(secretKey);

            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);
            byte[] messageBytes = encoding.GetBytes(data);
            return Convert.ToBase64String(hmacsha256.ComputeHash(messageBytes));
        }

        private static String buildDataToSign(IDictionary<string, string> paramsArray)
        {
            String[] signedFieldNames = paramsArray["signed_field_names"].Split(',');
            IList<string> dataToSign = new List<string>();

            foreach (String signedFieldName in signedFieldNames)
            {
                dataToSign.Add(signedFieldName + "=" + paramsArray[signedFieldName]);
            }

            return commaSeparate(dataToSign);
        }

        private static String commaSeparate(IList<string> dataToSign)
        {
            return String.Join(",", dataToSign);
        }
    }

}