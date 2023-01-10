using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly user01Context user01Context;

        public TestController(user01Context user01Context)
        {
            this.user01Context = user01Context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Test(string session, int x, int y)
        {
            var sessionRow = await user01Context.
                Sessions.FirstOrDefaultAsync(s => s.SessionKey == session);
            if (sessionRow == null)
                return NotFound();
            if (sessionRow.Expiration < DateTime.UtcNow)
                return Forbid();

            return x + y;
        }
    }
}
