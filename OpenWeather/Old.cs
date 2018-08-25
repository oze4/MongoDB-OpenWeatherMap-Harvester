using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherHarvester
{
    class Old
    {
        /*
        // OLD build mongo connection
        var username = "-";
        var password = "-";
        var mongoHost = "-";
        var mongoCredential = new MongoCredential(
            "SCRAM-SHA-1",
            new MongoInternalIdentity("admin", username),
            new PasswordEvidence(password)
            );
        var address = new MongoServerAddress(string.Format("{0}", mongoHost));
        var settings = new MongoClientSettings()
        {
            Server = address,
            Credential = mongoCredential
        };
        var mongo = new MongoClient(settings);
        var database = mongo.GetDatabase("-");
        var collection = database.GetCollection<BsonDocument>("-");
        */
    }
}
