﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Yandex.Checkout.V3
{
    /// <summary>
    /// Признак способа расчета
    /// </summary>
    public enum PaymentMode
    {
        /// <summary>
        /// Полная предоплата
        /// </summary>
        [EnumMember(Value = "full_prepayment")]
        FullPrepayment,

        /// <summary>
        /// Частичная предоплата
        /// </summary>
        [EnumMember(Value = "partial_prepayment")]
        PartialPrepayment,

        /// <summary>
        /// Аванс
        /// </summary>
        [EnumMember(Value = "advance")]
        Advance,

        /// <summary>
        /// Полный расчет
        /// </summary>
        [EnumMember(Value = "full_payment")]
        FullPayment,

        /// <summary>
        /// Частичный расчет и кредит
        /// </summary>
        [EnumMember(Value = "partial_payment")]
        PartialPayment,

        /// <summary>
        /// Кредит
        /// </summary>
        [EnumMember(Value = "credit")]
        Credit,

        /// <summary>
        /// Выплата по кредиту
        /// </summary>
        [EnumMember(Value = "credit_payment")]
        CreditPayment
    }
}
