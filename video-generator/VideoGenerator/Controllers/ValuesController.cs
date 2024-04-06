using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PexelsDotNetSDK.Api;
using static System.Net.Mime.MediaTypeNames;

namespace AiVideos_Demo.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {


        [Route("GenerateVideos")]
        [HttpGet]
        public async Task<IActionResult> GenerateVideos(string prompt)
        {
            List<string> LstVideos = new List<string>();

            var pexelsClient = new PexelsClient("sPb71yRgnqe09JoxwuuofE0wtNkN6LvKqr1J0QM7pdCmt8HgwVfavykt");
            var result = await pexelsClient.SearchVideosAsync(prompt);

            List<PexelsDotNetSDK.Models.Video> lstvds = new List<PexelsDotNetSDK.Models.Video>();

            lstvds = result.videos.ToList();

            foreach (var video in lstvds)
            {
                string vediolink = video.videoFiles.FirstOrDefault().link;
                LstVideos.Add(vediolink);
            }

            return Ok(LstVideos);
        }
    }
}