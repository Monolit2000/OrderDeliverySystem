using Microsoft.AspNetCore.Mvc;

namespace OrderDeliverySystem.API.Modules.Payments.Payment.Model
{
    public class LiqPayCallbackModel
    {
        [FromForm(Name = "data")]
        public string data { get; set; }

        [FromForm(Name = "signature")]
        public string signature { get; set; }
    }
}
