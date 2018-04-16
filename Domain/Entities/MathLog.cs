using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class MathLog
    {
        public int Id { get; set; }

        public int NewFriendId { get; set; }

        public int FriendId { get; set; }

        public string NewFriendName { get; set; }

        public string FriendName { get; set; }

        public double NewFriendLatitude { get; set; }

        public double FriendLatitude { get; set; }

        public double NewFriendLongitude { get; set; }

        public double FriendLongitude { get; set; }

        public double Distance { get; set; }
    }
}
