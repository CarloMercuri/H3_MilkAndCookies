using Microsoft.AspNetCore.Mvc;

namespace H3_MilkAndCookies.Controllers
{
    public class CookiesController : ControllerBase
    {
        [HttpGet]
        [Route("SetFavoriteMilkshake")]
        public IActionResult SetFavoriteMilkshake(string favoriteMilkshake)
        {
            CookieOptions co = new CookieOptions();
                       

            co.Expires = DateTime.Now.AddMinutes(5);
            Response.Cookies.Append("favoriteMilkshake", favoriteMilkshake, co);
            return Ok();
        }

        [HttpGet]
        [Route("GetFavoriteMilkshake")]
        public IActionResult GetFavoriteFromCookies()
        {
            string? favCookie = Request.Cookies["favoriteMilkshake"];

            if(favCookie is null)
            {
                return Ok("Unknown");
            }
            else
            {
                return Ok(favCookie);
            }
        }

        [HttpGet]
        [Route("DeleteMilkshakeCookie")]
        public IActionResult DeleteMilkshakeCookie()
        {
            string? favCookie = Request.Cookies["favoriteMilkshake"];
            if(favCookie is null)
            {
                return Ok("Cookie was already deleted");
            }

            CookieOptions co = new CookieOptions();

            co.Expires = DateTime.Now.AddMinutes(-20);
            Response.Cookies.Append("favoriteMilkshake", favCookie, co);
            return Ok();
        }
    }
}
