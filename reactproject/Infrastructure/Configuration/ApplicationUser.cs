﻿using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;

namespace reactproject.Infrastructure.Configuration
{
    [CollectionName("Users")]
    public class ApplicationUser : MongoIdentityUser<ObjectId>
    {
        public ObjectId GenerateId()
        {
            return ObjectId.GenerateNewId();
        }
    }
}