﻿using Mitto.Messenger.Core.Interfaces;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace Mitto.Messenger.Data.Repositories.Base
{
  public class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    protected IDbConnection db;

    public BaseRepository(IDbConnection db)
    {
      this.db = db;
    }

    public virtual List<T> GetAll()
    {
      return db.Select<T>();
    }

    public List<T> Get(Expression<Func<T, bool>> exp)
    {
      return db.Select(exp);
    }

    public List<T> Get(Expression<Func<T, bool>> exp, int? skip, int? take)
    {
      var query = db.From<T>().Where(exp);
      if ((skip.HasValue && skip.Value > 0) && (take.HasValue && take.Value > 0))
        query = query.Limit(skip, take);
      return db.Select(query);
    }

    public virtual T GetById(int id)
    {
      var o = db.SingleById<T>(id);
      return o;
    }

    public virtual T GetById(string id)
    {
      var o = db.SingleById<T>(id);
      return o;
    }

    public bool Save(T o)
    {
      db.Save(o);
      return true;
    }

    public void Delete(int id)
    {
      db.DeleteById<T>(id);
    }

    public void Delete(Expression<Func<T, bool>> exp)
    {
      db.Delete(exp);
    }
  }
}
