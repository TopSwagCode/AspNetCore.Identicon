using System.IO;
using System.Threading.Tasks;
using Jdenticon;
using Microsoft.AspNetCore.Mvc;

namespace TopSwagCode.WebApi.Identicon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdenticonController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get(string name, int size)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var icon = Jdenticon.Identicon.FromValue(name, size);

                await icon.SaveAsPngAsync(ms);

                ms.Position = 0;
                return File(ms.ToArray(), "image/png");
            }
        }
    }
}
