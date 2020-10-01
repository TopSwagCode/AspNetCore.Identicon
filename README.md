# AspNetCore.Identicon

To get your own Identicon service. Add "Jdenticon.AspNetCore" nuget package to your project and create a api like the one in this project. The code can also be seen below here:

```
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
```
