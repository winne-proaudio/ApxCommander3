using System.Web.Http;
using APxCommander3.Shared;

namespace APxCommander3.Backend.Api
{
    [RoutePrefix("api/command")]
    public class CommandController : ApiController
    {
        [HttpPost]
        [Route("")]
        public IHttpActionResult PostCommand(CommandRequest request)
        {
            WebSocketHost.PushStatus(new StatusUpdate
            {
                Type = "Progress",
                Message = "Messung gestartet...",
                ProgressPercent = 0,
                CurrentStep = request.Action
            });

            return Ok(new { status = "started", step = request.Action });
        }

        [HttpGet]
        [Route("~/api/health")]
        public IHttpActionResult GetHealth()
        {
            return Ok("OK");
        }
    }
}