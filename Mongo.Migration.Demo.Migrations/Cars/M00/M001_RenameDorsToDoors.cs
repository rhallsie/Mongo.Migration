﻿using System;
using Mongo.Migration.Demo.Model;
using Mongo.Migration.Migrations.Document;
using Mongo.Migration.Services;
using MongoDB.Bson;

namespace Mongo.Migration.Demo.MongoMigrations.Cars.M00
{
    public class M001_RenameDorsToDoors : DocumentMigration<Car>
    {
        private readonly IDocumentVersionService _service;

        public M001_RenameDorsToDoors(IDocumentVersionService service)
            : base("0.0.1")
        {
            _service = service;
        }

        public override void Up(BsonDocument document)
        {
            var doors = document["Dors"].ToInt32();
            document.Add("Doors", doors);
            document.Remove("Dors");
        }

        public override void Down(BsonDocument document)
        {
            var doors = document["Doors"].ToInt32();
            document.Add("Dors", doors);
            document.Remove("Doors");
        }
    }
}