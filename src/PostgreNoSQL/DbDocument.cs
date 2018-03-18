﻿namespace PostgreNoSQL
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using PostgreNoSQL.Linq;
    using Remotion.Linq;
    using Remotion.Linq.Parsing.Structure;

    public class DbDocument<TEntity> : IQueryable<TEntity>, IOrderedQueryable<TEntity> where TEntity : class
    {
        private DbDocumentQueryable<TEntity> _entityQueryable;

        public DbDocument()
        {
            _entityQueryable = new DbDocumentQueryable<TEntity>(new DefaultQueryProvider(typeof(DbDocumentQueryable<>),
                                                                                         QueryParser.CreateDefault(),
                                                                                         new DbDocumentQueryExecutor()));
        }

        public IEnumerator GetEnumerator() => _entityQueryable.GetEnumerator();

        Type IQueryable.ElementType => typeof(TEntity);

        Expression IQueryable.Expression => _entityQueryable.Expression;

        IQueryProvider IQueryable.Provider => _entityQueryable.Provider;

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator() => _entityQueryable.GetEnumerator();
    }
}

//public virtual EntityEntry<TEntity> Add(TEntity entity) => throw new NotImplementedException();
