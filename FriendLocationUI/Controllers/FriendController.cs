using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using FriendLocationUI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace FriendLocationUI.Controllers
{
    [Route("api/[controller]")]
    public class FriendController : Controller
    {
        private readonly FriendApplicationInterface _FriendApplicationInterface;


        public FriendController(FriendApplicationInterface FriendApplicationInterface)
        {
            _FriendApplicationInterface = FriendApplicationInterface;
        }

        [HttpGet("[action]")]
        public List<FriendModel> ListFriends()
        {
            var IList = _FriendApplicationInterface.List();
            var FriendList = new List<FriendModel>();

            foreach (var friend in IList)
            {
                FriendList.Add(new Models.FriendModel
                {
                    Id = friend.Id,
                    Name = friend.Name,
                    Latitude = friend.Latitude,
                    Longitude = friend.Longitude
                });
            }

            return FriendList;
        }
        [HttpPost("[action]")]
        public List<FriendModel> ListThreFriends([FromBody]FriendModel friend)
        {
            var IList = _FriendApplicationInterface.ListThreFriends(new Domain.Entities.Friend {
                Name = friend.Name,
                Latitude = friend.Latitude,
                Longitude = friend.Longitude
            });
            var FriendList = new List<FriendModel>();

            foreach (var f in IList)
            {
                FriendList.Add(new Models.FriendModel
                {
                    Id = f.Id,
                    Name = f.Name,
                    Latitude = f.Latitude,
                    Longitude = f.Longitude
                });
            }

            return FriendList;
        }

        [HttpPost("[action]")]
        public void Create([FromBody]FriendModel friend)
        {
            _FriendApplicationInterface.Add(new Domain.Entities.Friend
            {
                Name = friend.Name,
                Latitude = friend.Latitude,
                Longitude = friend.Longitude
            });
        }

    }

    [EnableCors("CORSPolicy")]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {

    }

    [EnableCors("CORSPolicy")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class GreetingController : Controller
    {

    }
}
