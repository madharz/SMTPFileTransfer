using Microsoft.AspNetCore.Mvc;
using SMTPFileTransfer.Models;
using SMTPFileTransfer.Services;

namespace SMTPFileTransfer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormDataController : ControllerBase
    {
        private readonly IFormDataProcessingService _formDataProcessingService;

        public FormDataController(IFormDataProcessingService formDataProcessingService)
        {
            _formDataProcessingService = formDataProcessingService;
        }

        [HttpPost("ProcessFormData")]
        public async Task<IActionResult> ProcessFormData([FromForm] FormData? formData)
        {
            try
            {
                // Перевірка, чи formData не є нульовим
                if (formData == null)
                {
                    return BadRequest("Дані з форми не були надіслані або були надіслані некоректно");
                }

                // Перевірка, чи властивість Files не є нульовою перед її використанням
                if (formData.Files != null)
                {
                    // Виклик сервісу для обробки даних з форми
                    await _formDataProcessingService.ProcessFormData(formData);
                    return Ok("Дані було успішно оброблено");
                }
                else
                {
                    // Логіка обробки, якщо файли відсутні
                    return Ok("Дані було успішно оброблено (файли відсутні)");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Помилка: {ex.Message}");
            }
        }
    }
}
