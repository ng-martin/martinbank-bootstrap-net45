using System;
using System.Web.Mvc;
using MartinBank.Core.Interfaces;
using MartinBank.Core.Utils;
using MartinBank.Web.Models;

namespace MartinBank.Web.Controllers
{
    public class ChequeGeneratorController : Controller
    {
        private readonly ILoggingService _logginService;
        private readonly IWebConfigurationSettings _webConfigurationSettings;

        public ChequeGeneratorController(ILoggingService logginService, IWebConfigurationSettings webConfigurationSettings)
        {
            _logginService = logginService;
            _webConfigurationSettings = webConfigurationSettings;
        }

        public ActionResult Index()
        {
            var model = new ChequeViewModel
            {
                BankName = _webConfigurationSettings.GetBankName(),
                DateAsString = DateTime.UtcNow.ToString("dd-MMM-yyyy"),
                Amount = 0d
            };

            return View(model);
        }

        [HttpPost]

        public JsonResult ConvertAmountInWords(ChequeViewModel model)
        {
            try
            {
                model.AmountInWords = ChequeConverter.NumericAmountToWords(model.Amount);
                // Fake e-signature for client
                model.ESignature = Guid.NewGuid().ToString();
                // Assumption: Payment service is provided to store details in external or local database. Map model to entity (Cheque)

                return Json(new { success = true, words = model.AmountInWords, esignature = model.ESignature });
            }
            catch (Exception ex)
            {
                _logginService.Error("Something wrong happened!", ex);
            }

            // assumption: Error can be set via resource file or database error codes.
            return Json(new { success = false, err = "An error occurred, try again..." });
        }

    }
}
