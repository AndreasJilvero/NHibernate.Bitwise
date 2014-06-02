using System;
using System.Linq.Expressions;
using NHibernate.Criterion;
using Expression = NHibernate.Criterion.Expression;

namespace NHibernate.Bitwise
{
    public class BitwiseExpression : LogicalExpression
    {
        public BitwiseExpression(string propertyName, Enum value, string @operator)
            : base(new SimpleExpression(propertyName, value, @operator), Expression.Sql("?", value, NHibernateUtil.Enum(value.GetType())))
        {
        }

        protected override string Op
        {
            get { return "="; }
        }

        public static BitwiseExpressionBuilder On<T>(Expression<Func<T, object>> property)
        {
            return new BitwiseExpressionBuilder(Projections.Property(property));
        }

        public static BitwiseExpressionBuilder On(string propertyName)
        {
            return new BitwiseExpressionBuilder(Projections.Property(propertyName));
        }
    }
}