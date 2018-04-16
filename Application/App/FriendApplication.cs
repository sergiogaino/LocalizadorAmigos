using Application.Interface;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.App
{
    public class FriendApplication : FriendApplicationInterface
    {

        FriendInterface _FriendInterface;

        public FriendApplication(FriendInterface FriendInterface)
        {
            _FriendInterface = FriendInterface;
        }

        public void Add(Friend Entitie)
        {
            var friends = _FriendInterface.List();
            var hasError = false;
            foreach(var friend in friends)
            {
                if((Entitie.Latitude == friend.Latitude) && (Entitie.Longitude == friend.Longitude))
                {
                    hasError = true;
                    break;
                }
            }

            if (hasError == false)
            {
                _FriendInterface.Add(Entitie);
            }
            else
            {
                throw new Exception("Já existe uma amigo na posição. Latitude: " + Entitie.Latitude + " Logitudo: " + Entitie.Longitude);
            }
        }

        public void Delete(int Id)
        {
            _FriendInterface.Delete(Id);
        }

        public Friend GetForId(int id)
        {
            return _FriendInterface.GetForId(id);
        }

        public List<Friend> List()
        {
            return _FriendInterface.List();
        }

        public List<Friend> ListThreFriends(Friend newFriend)
        {
            var friends =_FriendInterface.List();
            List<FriendDistance> listFriendDistances = new List<FriendDistance>();
            List<Friend> ThreFriends = new List<Friend>();
            MathLog mathLog = new MathLog();

            foreach (var friend in friends)
            {
                FriendDistance friendDistance = new FriendDistance();

                var x1 = newFriend.Latitude;
                var x2 = friend.Latitude;

                var y1 = newFriend.Longitude;
                var y2 = friend.Longitude;

                var x = x2 - x1;
                var y = y2 - y1;

                var sx = x * x;
                var sy = y * y;

                var sum = sx + sy;

                var distance = Math.Sqrt(sum);

                friendDistance.friend = friend;
                friendDistance.distance = distance;
                listFriendDistances.Add(friendDistance);

                mathLog.NewFriendId = newFriend.Id;
                mathLog.NewFriendName = newFriend.Name;
                mathLog.NewFriendLatitude = newFriend.Latitude;
                mathLog.NewFriendLongitude = newFriend.Longitude;
                mathLog.FriendId = friend.Id;
                mathLog.FriendName = friend.Name;
                mathLog.FriendLatitude = friend.Latitude;
                mathLog.FriendLongitude = friend.Longitude;
                mathLog.Distance = distance;

            }

            List<FriendDistance> orderList = listFriendDistances.OrderBy(friend => friend.distance).ToList();

            var count = 0;
            foreach(var obj in orderList)
            {
                if ((count < 3))
                {
                    if (obj.distance != 0)
                    {
                        ThreFriends.Add(obj.friend);
                        count++;
                    }
                        
                }
                else
                {
                    break;
                }
            }

            return ThreFriends;
        }

        public void Update(Friend Entitie)
        {
            _FriendInterface.Update(Entitie);
        }

        private class FriendDistance
        {
            public Friend friend;
            public double distance;
        }
    }
}
