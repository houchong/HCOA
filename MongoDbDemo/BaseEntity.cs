﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDemo
{
    public abstract class BaseEntity
    {
        [BsonId]
        public ObjectId Id{get;set; }
    }
}
