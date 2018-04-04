using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace VstsDockerBuild.PongService.Models
{
    public class PingRegisteredEvent
    {
        public ObjectId Id { get; set; }
        public DateTime RegisteredAt { get; set; }
        public Dictionary<string, string[]> Headers { get; set; }
    }
}