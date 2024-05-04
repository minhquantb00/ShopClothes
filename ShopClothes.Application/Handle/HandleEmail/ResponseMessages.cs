using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.Handle.HandleEmail
{
    public class ResponseMessages
    {
        public static string GetEmailSuccessMessage(string emailAddress) => $"Email đã được gửi đến: {emailAddress}";
    }
}
