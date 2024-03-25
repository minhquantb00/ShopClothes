﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class ConfirmEmail : BaseEntity
    {
        public string ConfirmCode { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime ExpiryTime { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
