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
            StatusPushService.SendToAll(new StatusUpdate
            {
                Type = "Progress",
                Message = "Messung gestartet...",
                ProgressPercent = 0,
                CurrentStep = "Initialisierung"
            });

            return Ok(new { status = "started", step = request.Action });
        }
    }
}