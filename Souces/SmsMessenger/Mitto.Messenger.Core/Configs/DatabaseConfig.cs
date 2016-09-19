﻿using Mitto.Messenger.Core.Entities;
using ServiceStack.OrmLite;
using System.Data;

namespace Mitto.Messenger.Core.Configs
{
  public abstract class DatabaseConfig
  {
    public static void Initialize(IDbConnection db)
    {
      db.DropTable<Message>();
      db.DropTable<Subscriber>();
      db.DropTable<Country>();

      if (db.CreateTableIfNotExists<Country>())
        AddCountries(db);
      db.CreateTableIfNotExists<Subscriber>();
      db.CreateTableIfNotExists<Message>();
    }

    private static void AddCountries(IDbConnection db)
    {
      db.Insert(new Country { Name = "Germany", CountryCode = "49", MobileCountryCode = "262", PricePerSms = 0.055m });
      db.Insert(new Country { Name = "Austria", CountryCode = "43", MobileCountryCode = "232", PricePerSms = 0.053m });
      db.Insert(new Country { Name = "Poland", CountryCode = "48", MobileCountryCode = "260", PricePerSms = 0.032m });
    }
  }
}
