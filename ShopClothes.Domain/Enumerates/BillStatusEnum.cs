using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Enumerates
{
    public enum BillStatusEnum
    {
        Delivering = 0,
        Delivered = 1,
        CustomerCancelOrder = 2,
        ShopCancelOrder = 3,
        Paid = 4,
        WaitConfirmation = 5,
        WaitForBankPayment = 6,
        WaitingDelivery = 7,
        PendingBill = 8,
        Returned = 9,
        RefuseToReturn = 10
    }
}
